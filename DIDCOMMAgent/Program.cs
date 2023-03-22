using DIDCOMMAgent;
using System;
using System.Configuration;

namespace DIDCOMMAgent
{
    public class Program
    {
        #region properties

        public static int Port 
        { 
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            }
        }

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
        

        public static void Main()
        {
            //init alice and bob
            //Subject alice = new Subject("alice");
            //Subject bob = new Subject("bob");
            Trinity.TrinityConfig.HttpPort = 8081;

            DIDCOMMAgent didAgent = new DIDCOMMAgent();
            didAgent.Start();
            Console.WriteLine("DIDCOMM Agent started...");

            //Console.WriteLine("Press Enter to stop DIDCOMM Agent...");
            Console.ReadLine();

            didAgent.Stop();
        }

        #endregion

    }
}
