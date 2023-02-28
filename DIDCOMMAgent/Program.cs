using System;
using System.Threading.Tasks;

namespace DIDCOMMAgent
{
    internal class Program
    {
        #region DidComm endpoint handler

        class DIDCOMMAgent : DIDCOMMAgentBase
        {
            public override void DIDCOMMEndpointHandler(DIDCOMMMessage request, out DIDCOMMResponse response)
            {
                Console.WriteLine($"REQUEST: {request.encryptedMessage.ciphertext64}");
                response.rc = (int)Trinity.TrinityErrorCode.E_SUCCESS;
                Console.WriteLine($"RESPONSE: {response.rc}");
            }
        }

        #endregion

        #region Main()

        public static void Main(string[] args)
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
