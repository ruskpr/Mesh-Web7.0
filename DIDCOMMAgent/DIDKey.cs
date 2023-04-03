using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;
using Google.Protobuf;
using Newtonsoft.Json;
using Okapi.Keys.V1;
using Okapi.Security;
using Okapi.Security.V1;

namespace DIDCOMMAgent
{
    public class DIDKey 
    {

        #region props

        //public CreateOberonKeyResponse ProofKey { get; set; }
        public string ProofKeySk { get; set; } 
        public string ProofKeyPk { get; set; } 
        public string KeyFilePath { get => _subjectKeyPath; }
        public bool IsInitialized { get => _isInitialized; }

        #endregion

        #region fields

        //private Subject _subject;
        private string _subjectKeyPath;
        private bool _isInitialized = false;

        public JsonWebKey SecretKey { get; set; }
        public JsonWebKey PublicKey { get; set; }
        public string KeyId { get; set; }
        #endregion

        #region constructor

        public DIDKey(string subjectName, string path)
        {
            // temporary key store
            _subjectKeyPath = Path.Combine(path, subjectName + ".profile.json");
        }

        public DIDKey()
        {
            
        }

        #endregion

        #region public

        public void InitKey()
        {
            if (File.Exists(_subjectKeyPath)) return;

            //if (_isInitialized) return;
            //_isInitialized = true;

            JsonWebKey didWebKey;

            //if (!File.Exists(_subjectKeyPath))
            //{
               
            //}
            //else
            //{
            //    string didKeyJson = File.ReadAllText(_subjectKeyPath);
            //    didWebKey = JsonSerializer.Deserialize<JsonWebKey>(didKeyJson);
            //}

            GenerateKeyResponse didKey = Okapi.Keys.DIDKey.Generate(new GenerateKeyRequest { KeyType = KeyType.X25519 });
            didWebKey = didKey.Key[0];
            //string didKeyJson = JsonConvert.SerializeObject(didWebKey);
            //File.WriteAllText(_subjectKeyPath, didKeyJson);

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
            CreateOberonKeyResponse ProofKey = Oberon.CreateKey(new CreateOberonKeyRequest());
            ProofKeySk = ProofKey.Sk.ToBase64();
            ProofKeyPk = ProofKey.Pk.ToBase64();
        }

        #endregion

    }

    
}
