using DIDCOMMAgent;
using Google.Protobuf;
using Newtonsoft.Json;
using Okapi.Keys.V1;
using Pbmse.V1;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Trinity;

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

                Program.MessagesReceived++;
                Console.WriteLine("DIDCommEndpointHandler: "
                    + DIDCommHelpers.DIDCommMessageRequestsSent.ToString() + " DIDComm sent. "
                    + DIDCommHelpers.HttpMessagesSent.ToString() + " HTTP sent. "
                    + Program.MessagesReceived.ToString() + " HTTP rcvd. "
                    + Program.VCsProcessed.ToString() + " VCs proc.");
        }
        }

        #endregion

        public static ConcurrentDictionary<string, ConcurrentQueue<EncryptedMessage>> Queues =
            new ConcurrentDictionary<string, ConcurrentQueue<EncryptedMessage>>();

        public static Dictionary<string, ISubject> SubjectVault = new Dictionary<string, ISubject>();

        public static int MessagesReceived;
        public static int VCsProcessed;

        #region main

        public static void Main(string[] args)
        {
            Console.WindowWidth = 50;

            // store subjects in memory for testing
            GetSubjects();

            //_didcommAgentPort = HandlePortArgs(args);

            _didcommAgentPort = 8081; // TODO: remove this line after testing
            _userAgentPort = 8082;

            Trinity.TrinityConfig.HttpPort = _didcommAgentPort ?? throw new ArgumentNullException("No port was initialized, use '-p <port number>' to set your agent port");

            DIDCOMMAgent didAgent = new DIDCOMMAgent();
            didAgent.Start();
            Console.WriteLine($"DIDCOMM Agent started on port {_didcommAgentPort}...");

            Console.ReadLine();
            didAgent.Stop();
        }

        private static void GetSubjects()
        {
            var subjectProfilePaths = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Technitium", "Mesh");

            if (!Directory.Exists(subjectProfilePaths))
                Directory.CreateDirectory(subjectProfilePaths); 

            var keys = Directory.EnumerateFiles(subjectProfilePaths, "*.key.json");

            foreach (var key in keys)
            {
                var subject = JsonConvert.DeserializeObject<DIDUser>(File.ReadAllText(key));    
                SubjectVault.Add(subject.Name, subject);
            }
        }

        #endregion

        private static int? HandlePortArgs(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-p")
                {
                    int port;
                    if (int.TryParse(args[i + 1], out port))
                    {
                        return port;
                    }

                }
            }

            

            return null;
        }

    }
}
