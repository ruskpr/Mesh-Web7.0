using DIDCOMMAgent;
using System;
using System.Configuration;

namespace DIDCOMMAgent
{
    public class Program
    {
        #region properties

        #endregion

        #region fields

        private int _port;

        #endregion

        #region didcomm endpoint handler

        class DIDCOMMAgent : DIDCOMMAgentBase
        {
            public override void DIDCOMMEndpointHandler(DIDCOMMMessage request, out DIDCOMMResponse response)
            {
                // TODO decrypt request message

                response.rc = (int)Trinity.TrinityErrorCode.E_SUCCESS;
                Console.WriteLine($"RESPONSE CODE: {response.rc}");
            }
        }

        #endregion

        #region main
        

        public static void Main(string[] args)
        {
            //init alice and bob
            //Subject alice = new Subject("alice");
            //Subject bob = new Subject("bob");


            int? port = HandlePortArgs(args);

            Trinity.TrinityConfig.HttpPort = port ?? 8081;

            DIDCOMMAgent didAgent = new DIDCOMMAgent();
            didAgent.Start();
            Console.WriteLine("DIDCOMM Agent started...");

            //Console.WriteLine("Press Enter to stop DIDCOMM Agent...");
            Console.ReadLine();

            didAgent.Stop();
        }

        #endregion

        private static int? HandlePortArgs(string[] args)
        {
            if (args.Length > 0 && args[0] == "-p")
            {
                if (args.Length > 1)
                {
                    int port;
                    if (int.TryParse(args[1], out port))
                    {
                        if (port != 0) return port;
                    }
                }
                
            }

            return null;
        }

    }
}
