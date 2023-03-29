using System.IO;
using System.Text.Json;
using Okapi.Keys.V1;
using Okapi.Security;
using Okapi.Security.V1;

namespace DIDCOMMAgent
{
    public class DIDKey
    {

        #region props

        public CreateOberonKeyResponse ProofKey { get; set; }
        public string KeyFilePath { get => _subjectKeyPath; }
        public bool IsInitialized { get => _isInitialized; }

        #endregion

        #region fields

        //private Subject _subject;
        private string _subjectKeyPath;
        private bool _isInitialized = false;
        public JsonWebKey SecretKey;
        public JsonWebKey PublicKey = new JsonWebKey();
        public string KeyId;

        #endregion

        #region constructor

        public DIDKey(Subject subject)
        {
            //_subject = subject;

           
        }

        public DIDKey(string subjectName, string path)
        {
            // temporary key store
            _subjectKeyPath = Path.Combine(path, subjectName + ".profile");
        }

        #endregion

        #region public

        public void InitKey()
        {
            //if (File.Exists(_subjectKeyPath)) return;

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
            string didKeyJson = JsonSerializer.Serialize(didWebKey);
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
            ProofKey = Oberon.CreateKey(new CreateOberonKeyRequest());
        }

        #endregion

    }

    
}
