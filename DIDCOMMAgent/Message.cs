using Google.Protobuf;
using Okapi.Keys.V1;
using Okapi.Transport.V1;
using Okapi.Transport;
using Pbmse.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using Okapi.Examples.V1;
using System.Net.Http;
using System.Net;

namespace DIDCOMMAgent
{

    public class Message
    {
        public static string Decrypt(EncryptedMessage em, JsonWebKey senderPublicKey, JsonWebKey recipientSecretKey)
        {
            // create unpack request
            var decryptedMessage = DIDComm.Unpack(
               new UnpackRequest
               {
                   Message = em,
                   SenderKey = senderPublicKey, // sender public key
                   ReceiverKey = recipientSecretKey // reciever secret key
               }
            );

            var plaintext = decryptedMessage.Plaintext;

            CoreMessage core = new CoreMessage();
            core.MergeFrom(plaintext);

            BasicMessage basic = new BasicMessage();
            basic.MergeFrom(core.Body);

            //var sender = Program.KeyVault[senderKeyId].Name;
            //var reciever = Program.KeyVault[recipientkeyId].Name;
            //Console.WriteLine($"Basic text message (sender = {sender}, reciever = {reciever}):" +
            //    $" {basic.Text}");

            return basic.Text;

        }

        private static CoreMessage CreateCoreMessage(string sender, string[] recipients, string msg, long expires = 0)
        {
            CoreMessage core = new CoreMessage();

            core.Id = Guid.NewGuid().ToString();
            //core.Type = "https://example.org/vctp/1.0/notify";
            core.Type = "test";

            var message = new BasicMessage();
            message.Text = msg;
            core.Body = message.ToByteString();

            core.Expires = expires;

            core.From = sender;
            core.To.Add(recipients);

            return core;
        }

        /// <summary>
        /// 
        /// Sends a DIDComm/HTTP message to the specified endpoint.
        /// Returns a collection of HTTP status codes for each message sent.
        ///
        /// </summary>
        public static IEnumerable<HttpStatusCode> Send(string endpointUrl, string plaintextMsg, string senderKeyId, string[] recipientKeyIds)
        {
            var statusCodes = new List<HttpStatusCode>();

            //1. create a (Okapi) core message
            var coreMessage = CreateCoreMessage(senderKeyId, recipientKeyIds, plaintextMsg);

            // loop through each recipient's key id, encrypt the core message, then send via HTTP to the endpoint url
            foreach (string recieverKeyId in coreMessage.To.ToList())
            {
                // pack the message
                PackResponse encryptedPackage = DIDComm.Pack(new PackRequest
                {
                    Plaintext = coreMessage.ToByteString(),
                    SenderKey = Subject.Subjects[senderKeyId].MsgSecretKey,
                    ReceiverKey = Subject.Subjects[recieverKeyId].MsgSecretKey,
                    Mode = EncryptionMode.Direct
                });

                // convert packed message to DIDCOMM encrypted message
                EncryptedMessage emessage = encryptedPackage.Message;

                DIDCOMMEncryptedMessage em = new DIDCOMMEncryptedMessage(
                    emessage.Iv.ToBase64(),
                    emessage.Ciphertext.ToBase64(),
                    emessage.Tag.ToBase64(),
                    recipients64: new List<string>() {
                        emessage.Recipients[0].ToByteString().ToBase64() });

                // convert DIDCOMM message to json
                DIDCOMMMessage didcommMsg = new DIDCOMMMessage(em);
                var emJson = didcommMsg.ToString();

                // send message to endpoint
                using (HttpClient httpClient = new HttpClient())
                {
                    using (HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("POST"), endpointUrl))
                    {
                        requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
                        //Console.WriteLine(">>>Payload:" + emJson);
                        requestMessage.Content = new StringContent(emJson);
                        var task = httpClient.SendAsync(requestMessage);
                        task.Wait();
                        HttpResponseMessage result = task.Result;
                        statusCodes.Add(result.StatusCode);
                        string jsonResponse = result.Content.ReadAsStringAsync().Result;
                        //Console.WriteLine(">>>Response:" + jsonResponse);
                    }
                }
            }

            return statusCodes;
        }

    }
}

