using DIDCOMMAgent;
using Newtonsoft.Json;
using Okapi.Keys.V1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace DIDCOMMAgent
{
    public class Program
    {

        #region fields

        static int? _port;

        #endregion

        #region didcomm endpoint handler
        
        class DIDCOMMAgent : DIDCOMMAgentBase
        {
            public override void DIDCOMMEndpointHandler(DIDCOMMMessage request, out DIDCOMMResponse response)
            {
                // recieve message from user agent
                var sender = SubjectVault[request.senderUsername];
                var reciever = SubjectVault["bob"];

                // send it to the reciever

                var plaintext = Message.Decrypt(request.encryptedMessage, sender.MsgPublicKey, reciever.MsgSecretKey);

                response.rc = (int)Trinity.TrinityErrorCode.E_SUCCESS;
                response.message = plaintext;
                Console.WriteLine($"RESPONSE CODE: {response.rc}");
            }
        }

        #endregion

        public static Dictionary<string, ISubject> SubjectVault = new Dictionary<string, ISubject>();

        #region main

        public static void Main(string[] args)
        {
            Console.WindowWidth = 50;

            // store subjects in memory for testing
            GetSubjects();

            _port = HandlePortArgs(args);

            _port = 8081; // TODO: remove this line after testing

            Trinity.TrinityConfig.HttpPort = _port ?? throw new ArgumentNullException("No port was initialized, use '-p <port number>' to set your agent port");
            //Trinity.TrinityConfig.HttpPort = 8081;

            DIDCOMMAgent didAgent = new DIDCOMMAgent();
            didAgent.Start();
            Console.WriteLine($"DIDCOMM Agent started on port {_port}...");

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
