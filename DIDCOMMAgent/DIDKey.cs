using System;
using System.IO;
using Okapi.Keys;
using Okapi.Keys.V1;
using System.Text.Json;
using Okapi.Security;
using Okapi.Security.V1;

namespace DIDCOMMAgent
{
    public class DIDKey
    {

        #region props

        public CreateOberonKeyResponse ProofKey { get; set; }
        public string KeyFilePath { get => _keyFilePath; }
        public bool IsInitialized { get => _isInitialized; }

        #endregion

        #region fields

        private Subject _subject;
        private string _keyFilePath;
        private bool _isInitialized = false;
        public JsonWebKey SecretKey;
        public JsonWebKey PublicKey = new JsonWebKey();
        public string KeyId;

        #endregion

        #region constructor

        public DIDKey(Subject subject)
        {
            _subject = subject;

            // temporary key store
            _keyFilePath = $"e:\\didcomm\\keys\\{_subject.Name.ToLower()}.keyfile.json";
        }

        #endregion

        #region public

        public void InitKey()
        {

            if (_isInitialized) return;
            _isInitialized = true;

            JsonWebKey didWebKey;

            if (!File.Exists(_keyFilePath))
            {
                GenerateKeyResponse didKey = Okapi.Keys.DIDKey.Generate(new GenerateKeyRequest { KeyType = KeyType.X25519 });
                didWebKey = didKey.Key[0];
                string didKeyJson = JsonSerializer.Serialize(didWebKey);
                File.WriteAllText(_keyFilePath, didKeyJson);
            }
            else
            {
                string didKeyJson = File.ReadAllText(_keyFilePath);
                didWebKey = JsonSerializer.Deserialize<JsonWebKey>(didKeyJson);
            }

            // set secret key
            SecretKey = new JsonWebKey()
            {
                Kid = didWebKey.Kid,
                Kty = didWebKey.Kty,
                Crv = didWebKey.Crv,
                D = didWebKey.D,
            };

            // set public key
            PublicKey = new JsonWebKey()
            {
                Kid = didWebKey.Kid,
                Kty = didWebKey.Kty,
                Crv = didWebKey.Crv,
                X = didWebKey.X,
            };
            

            KeyId = didWebKey.Kid;
            ProofKey = Oberon.CreateKey(new CreateOberonKeyRequest());
        }

        #endregion

    }

    
}
