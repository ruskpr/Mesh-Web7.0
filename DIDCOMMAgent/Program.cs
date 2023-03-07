using System;
using System.Threading.Tasks;

namespace DIDCOMMAgent
{
    public class Program
    {
        #region DIDCOMM endpoint handler
        class DIDCOMMAgent : DIDCOMMAgentBase
        {
            public override void DIDCOMMEndpointHandler(DIDCOMMMessage request, out DIDCOMMResponse response)
            {
                response.rc = (int)Trinity.TrinityErrorCode.E_SUCCESS;
                Console.WriteLine($"RESPONSE CODE: {response.rc}");
            }
        }

        #endregion

        #region Main()

        public static void Main()
        {
            Trinity.TrinityConfig.HttpPort = 8081;

            DIDCOMMAgent didAgent = new DIDCOMMAgent();
            didAgent.Start();
            Console.WriteLine("DIDCOMM Agent start...");

            Console.WriteLine("Press Enter to stop DIDCOMM Agent...");
            Console.ReadLine();

            didAgent.Stop();
        }

        #endregion

    }
}
