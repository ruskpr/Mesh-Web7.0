using DIDCOMMAgent;
using System;

namespace DIDCOMMAgent
{
    public class Program
    {
        #region DIDCOMM endpoint handler
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

        #region Main()

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
