using DIDCOMMAgent;
using Google.Protobuf;
using Newtonsoft.Json;
using Okapi.Examples.V1;
using Okapi.Keys.V1;
using Okapi.Transport.V1;
using Okapi.Transport;
using Pbmse.V1;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using Trinity;
using System.Threading.Tasks;
using Trinity.Diagnostics;
using Trinity.Network;

namespace DIDCOMMAgent
{
    public class Program
    {

        #region fields

        static int? _didcommAgentPort;
        private static int _userAgentPort;

        #endregion

        #region didcomm endpoint handler

        class DIDCOMMAgent : DIDCOMMAgentBase
        {
            public override void DIDCOMMEndpointHandler(DIDCOMMMessage request, out DIDCOMMResponse response)
            {
                DIDCOMMEncryptedMessage didcommEncryptedMessage64 = request.encryptedMessage;

                EncryptedMessage encryptedMessage = new EncryptedMessage();
                encryptedMessage.Iv = ByteString.FromBase64(didcommEncryptedMessage64.lv64);
                encryptedMessage.Ciphertext = ByteString.FromBase64(didcommEncryptedMessage64.ciphertext64);
                encryptedMessage.Tag = ByteString.FromBase64(didcommEncryptedMessage64.tag64);
                EncryptionRecipient recipient = new EncryptionRecipient();
                recipient.MergeFrom(ByteString.FromBase64(didcommEncryptedMessage64.recipients64[0]));
                encryptedMessage.Recipients.Add(recipient);

                string kid = recipient.Header.KeyId;
                string skid = recipient.Header.SenderKeyId;

                // Persist encryptedMessage
                DIDCOMMEncryptedMessage_Cell encryptedMessageCell = new DIDCOMMEncryptedMessage_Cell(didcommEncryptedMessage64);
                // encryptedMessageCell.em = didcommEncryptedMessage64;
                Global.LocalStorage.SaveDIDCOMMEncryptedMessage_Cell(encryptedMessageCell);
                Global.LocalStorage.SaveStorage();
                var celltype = Global.LocalStorage.GetCellType(encryptedMessageCell.CellId);
                ulong cellcount = Global.LocalStorage.CellCount;
                Console.WriteLine("cellid: " + encryptedMessageCell.CellId.ToString() + " celltype: " + celltype.ToString() + " cellcount: " + cellcount);

                if (!Program.Queues.ContainsKey(kid))
                {
                    Program.Queues.TryAdd(kid, new ConcurrentQueue<EncryptedMessage>());
                }
                Program.Queues[kid].Enqueue(encryptedMessage);

                response.rc = (int)Trinity.TrinityErrorCode.E_SUCCESS;

                //Program.MessagesReceived++;
                //Console.WriteLine("DIDCommEndpointHandler: "
                //    + DIDCommHelpers.DIDCommMessageRequestsSent.ToString() + " DIDComm sent. "
                //    + DIDCommHelpers.HttpMessagesSent.ToString() + " HTTP sent. "
                //    + Program.MessagesReceived.ToString() + " HTTP rcvd. "
                //    + Program.VCsProcessed.ToString() + " VCs proc.");
            }
        }

        #endregion

        public static ConcurrentDictionary<string, ConcurrentQueue<EncryptedMessage>> Queues =
            new ConcurrentDictionary<string, ConcurrentQueue<EncryptedMessage>>();

        public static Dictionary<string, ISubject> SubjectVault = new Dictionary<string, ISubject>();

        public static int MessagesReceived;
        public static int VCsProcessed;
        public static bool Processing = true;

        #region main

        public static void Main(string[] args)
        {
            // store subjects in memory for testing
            InitSubjects();

            _didcommAgentPort = HandleAgentPortArgs(args);
            _userAgentPort = 8082;

#pragma warning disable CS0612 // Type or member is obsolete
            if (args.Length == 3)
                TrinityConfig.ServerPort = HandleServerPortArgs(args);
#pragma warning restore CS0612 // Type or member is obsolete

            Trinity.TrinityConfig.HttpPort = _didcommAgentPort ?? throw new ArgumentNullException("No port was initialized, use '-p <port number>' to set your agent port");
            DIDCOMMAgent didAgent = new DIDCOMMAgent();
            didAgent.Start();
            Console.WriteLine($"DIDCOMM Agent started on port {_didcommAgentPort}...");

            while (Processing)
            {
                foreach (var queue in Queues)
                {
                    string kid = queue.Key;
                    ConcurrentQueue<EncryptedMessage> emessages = queue.Value;
                    while (emessages.Count > 0)
                    {
                        EncryptedMessage emessage = new EncryptedMessage();
                        bool dequeued = emessages.TryDequeue(out emessage);
                        if (dequeued) ProcessEncryptedMessage(emessage);
                    }
                }
            }

            Console.ReadLine();
            didAgent.Stop();
        }       

        private static void ProcessEncryptedMessage(EncryptedMessage encryptedMessage)
        {
            EncryptionRecipient r = new EncryptionRecipient();
            r = encryptedMessage.Recipients.First<EncryptionRecipient>();
            string kid = r.Header.KeyId;
            string skid = r.Header.SenderKeyId;
            Console.WriteLine("ProcessMessage:" + skid + " to\r\n" + kid);

            var unpackResponse = DIDComm.Unpack(new UnpackRequest { Message = encryptedMessage, SenderKey = SubjectVault[skid].MsgPublicKey, ReceiverKey = SubjectVault[kid].MsgSecretKey });
            var plaintext = unpackResponse.Plaintext;
            CoreMessage core = new CoreMessage();
            core.MergeFrom(plaintext);
            BasicMessage basic = new BasicMessage();
            basic.MergeFrom(core.Body);
            Console.WriteLine("BasicMessage: " + core.Type + " " + basic.Text);

            var endpoint = $"http://localhost/DIDCOMMEndpoint:{_userAgentPort}";
            Console.WriteLine("sending to " + endpoint);
            var task = Task.Run(() => Message.EncryptAndSend(endpoint, basic.Text, SubjectVault[skid], SubjectVault[kid]));
            task.Wait();
            Console.WriteLine($"response code: {task.Result.rc}");


            //ProcessVCTPSMessage(skid, kid, core.Type, basic.Text);
        }



        #endregion

        private static void InitSubjects()
        {
            var subjectProfilePaths = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Technitium", "Mesh");

            if (!Directory.Exists(subjectProfilePaths))
                Directory.CreateDirectory(subjectProfilePaths); 

            var keys = Directory.EnumerateFiles(subjectProfilePaths, "*.key.json");

            foreach (var key in keys)
            {
                var subject = JsonConvert.DeserializeObject<DIDUser>(File.ReadAllText(key));    
                SubjectVault.Add(subject.DIDKey.KeyId, subject);
            }
        }

        private static int? HandleAgentPortArgs(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-p")
                {
                    if (int.TryParse(args[i + 1], out int port))
                    {
                        return port;
                    }

                }
            }

            

            return null;
        }

        private static int HandleServerPortArgs(string[] args)
        {
            if (args.Length == 3)
            {
                try
                {
                    return Convert.ToInt32(args[2]);
                }
                catch { return 5304; }
            }

            return 5304;
        }
    }
}
