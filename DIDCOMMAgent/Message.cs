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
using Newtonsoft.Json;

namespace DIDCOMMAgent
{

    public class Message
    {
        public static string Decrypt(DIDCOMMEncryptedMessage didcommEM, JsonWebKey senderMsgPublicKey, JsonWebKey receiverMsgSecretKey)
        {
            EncryptedMessage emessage = new EncryptedMessage()
            {
                Iv = ByteString.FromBase64(didcommEM.lv64),
                Ciphertext = ByteString.FromBase64(didcommEM.ciphertext64),
                Tag = ByteString.FromBase64(didcommEM.tag64),
            };
            
            EncryptionRecipient recipient = new EncryptionRecipient();
            recipient.MergeFrom(ByteString.FromBase64(didcommEM.recipients64[0]));
            emessage.Recipients.Add(recipient);

            Console.WriteLine(emessage.Recipients.Count.ToString());
            Console.WriteLine(emessage.Recipients[0].Header.SenderKeyId);
            Console.WriteLine(emessage.Recipients[0].Header.KeyId);

            string skidid = emessage.Recipients[0].Header.SenderKeyId;
            string keyid = emessage.Recipients[0].Header.KeyId;

            var decryptedMessage = DIDComm.Unpack(
              new UnpackRequest
              {
                  Message = emessage,
                  SenderKey = senderMsgPublicKey,
                  ReceiverKey = receiverMsgSecretKey
              }
            );

            var plaintext = decryptedMessage.Plaintext;
            CoreMessage core = new CoreMessage();
            core.MergeFrom(plaintext);
            BasicMessage basic = new BasicMessage();
            basic.MergeFrom(core.Body);
            return basic.Text;
        }


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

        private static CoreMessage CreateCoreMessage(string senderKeyId, string[] recipientkeyIds, string msg, long expires = 0)
        {
            CoreMessage core = new CoreMessage();

            core.Id = Guid.NewGuid().ToString();
            //core.Type = "https://example.org/vctp/1.0/notify";
            core.Type = "test";

            var message = new BasicMessage();
            message.Text = msg;
            core.Body = message.ToByteString();

            core.Expires = expires;

            core.From = senderKeyId;
            core.To.Add(recipientkeyIds);

            return core;
        }

        /// <summary>
        /// 
        /// Sends a DIDComm/HTTP message to the specified endpoint.
        /// Returns a collection of HTTP status codes for each message sent.
        ///
        /// </summary>
        public static IEnumerable<DIDCOMMResponse> Send(string endpointUrl, string plaintextMsg, ISubject sender, List<ISubject> recipients)
        {
            var responses = new List<DIDCOMMResponse>();

            // get the recipient keys
            var recipientKeys = recipients.Select(r => r.DIDKey.KeyId).ToArray();
            var coreMessage = CreateCoreMessage(sender.DIDKey.KeyId, recipientKeys, plaintextMsg);

            // loop through each recipient's key id, encrypt the core message, then send via HTTP to the endpoint url
            foreach (var recipient in recipients)
            {
                // pack the message
                PackResponse encryptedPackage = DIDComm.Pack(new PackRequest
                {
                    Plaintext = coreMessage.ToByteString(),
                    SenderKey = sender.MsgSecretKey,
                    ReceiverKey = recipient.MsgSecretKey,
                    Mode = EncryptionMode.Direct
                });

                // convert packed message to DIDCOMM encrypted message
                EncryptedMessage emessage = encryptedPackage.Message;

                DIDCOMMEncryptedMessage em = new DIDCOMMEncryptedMessage(
                    emessage.Iv.ToBase64(),
                    emessage.Ciphertext.ToBase64(),
                    emessage.Tag.ToBase64(),
                    recipients64: new List<string>() {
                        emessage.Recipients[0].ToByteString().ToBase64() 
                    });

                // convert DIDCOMM message to json
                DIDCOMMMessage didcommMsg = new DIDCOMMMessage(sender.Name, recipient.Name, em);
                var emJson = didcommMsg.ToString();

                // send message to endpoint
                using (HttpClient httpClient = new HttpClient())
                {
                    using (HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("POST"), endpointUrl))
                    {
                        requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
                        requestMessage.Content = new StringContent(emJson);
                        var task = httpClient.SendAsync(requestMessage);
                        task.Wait();
                        HttpResponseMessage result = task.Result;
                        string jsonResponse = result.Content.ReadAsStringAsync().Result;
                        DIDCOMMResponse res = JsonConvert.DeserializeObject<DIDCOMMResponse>(jsonResponse);
                        responses.Add(res);
                    }
                }
            }

            return responses;
        }

    }
}

