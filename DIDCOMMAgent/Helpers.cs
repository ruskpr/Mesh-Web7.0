using Okapi.Transport.V1;
using Okapi.Transport;
using Pbmse.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;

namespace DIDCOMMAgent
{
    public static class DIDCommHelpers
    {
        public static int HttpMessagesSent = 0;
        public static int DIDCommMessageRequestsSent = 0;
        static readonly HttpClient httpClient = new HttpClient();
        // https://www.thecodebuzz.com/using-httpclient-best-practices-and-anti-patterns/

        private static string SendHttpMessage(string url, string jsonMessageRequest)
        {
            string jsonResponse = "{ }";

            HttpMessagesSent++;
            Console.WriteLine("SendHTTPCOMMMessage: "
                + DIDCommHelpers.DIDCommMessageRequestsSent.ToString() + " DIDComm sent. "
                + DIDCommHelpers.HttpMessagesSent.ToString() + " HTTP sent. "
                + Program.MessagesReceived.ToString() + " HTTP rcvd.");

            Console.WriteLine(">>>Agent Url:" + url);
            using (var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), url))
            {
                requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
                Console.WriteLine(">>>Request:" + jsonMessageRequest);
                requestMessage.Content = new StringContent(jsonMessageRequest);
                var task = httpClient.SendAsync(requestMessage);
                task.Wait();  // if an exception is thrown here, you likely forgot to run Visual Studio in "Run as Administrator" mode
                //var result = task.Result;
                //jsonResponse = result.Content.ReadAsStringAsync().Result;
                //Console.WriteLine(">>>Response:" + url);
            }

            return jsonResponse;
        }

        public static void SendDIDCommMessageRequest(string DIDCommEndpointUrl, CoreMessage core)
        {
            foreach (var to in core.To.ToList())
            {
                DIDCommHelpers.SendDIDCommMessageRequest(DIDCommEndpointUrl, core.From, to, core);
            }
        }

        public static string SendDIDCommMessageRequest(string DIDCommEndpointUrl, string from, string to, CoreMessage core)
        {
            string jsonResponse = "{ }";

            Console.WriteLine("SendDIDCommMessageRequest: "
                + DIDCommHelpers.DIDCommMessageRequestsSent.ToString() + " DIDComm sent. "
                + DIDCommHelpers.HttpMessagesSent.ToString() + " HTTP sent. "
                + Program.MessagesReceived.ToString() + " HTTP rcvd.");

            Console.WriteLine(">>Sending to: " + Program.SubjectVault[to].Name + "\t" + to); ;
            var packResponse = DIDComm.Pack(new PackRequest
            {
                Plaintext = core.ToByteString(),
                SenderKey = Program.SubjectVault[from].MsgSecretKey,
                ReceiverKey = Program.SubjectVault[to].MsgPublicKey,
                Mode = EncryptionMode.Direct
            });
            var encryptedMessage = packResponse.Message;
            DIDCOMMEncryptedMessage encryptedMessage64 = new DIDCOMMEncryptedMessage(
                encryptedMessage.Iv.ToBase64(),
                encryptedMessage.Ciphertext.ToBase64(),
                encryptedMessage.Tag.ToBase64(),
                recipients64: new List<string>() { encryptedMessage.Recipients[0].ToByteString().ToBase64() }
            );

            DIDCOMMMessage messageRequest = new DIDCOMMMessage(encryptedMessage64);
            var jsonMessageRequest = messageRequest.ToString();

            // Perform async HTTP POST
            var task = Task.Run(() => DIDCommHelpers.SendHttpMessage(DIDCommEndpointUrl, jsonMessageRequest));
            DIDCommMessageRequestsSent++;

            return jsonResponse;
        }
    }
}
