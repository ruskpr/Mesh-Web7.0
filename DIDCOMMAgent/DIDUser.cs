

using Newtonsoft.Json;
using Okapi.Keys.V1;
using System.IO;

namespace DIDCOMMAgent
{
    public class DIDUser : ISubject
    {
        public DIDUser()
        {

        }

        #region properties

        public string Name { get; set; }
        public string Password { get; set; }

        public DIDKey DIDKey { get; set; }
        public JsonWebKey MsgPublicKey { get; set; }
        public JsonWebKey MsgSecretKey { get; set; }
        public string ProofPublicKey { get; set; }
        public string ProofSecretKey { get; set; }

        #endregion

        public static DIDUser GetUser(string keyPath)
        {
            var json = File.ReadAllText(keyPath);
            var user = JsonConvert.DeserializeObject<DIDUser>(json);
            return user;
        }
        
        public static void Create(string name, string password, string keyPath)
        {
            DIDUser user = new DIDUser()
            {
                Name = name,
                Password = password,
            };

            DIDKey key = new DIDKey(user.Name, keyPath);
            key.InitKey();
            user.DIDKey = key;
            user.MsgPublicKey = user.DIDKey.PublicKey;
            user.MsgSecretKey = user.DIDKey.SecretKey;
            user.ProofPublicKey = user.DIDKey.ProofKeyPk;
            user.ProofSecretKey = user.DIDKey.ProofKeySk;

            //set subject's public and secret keys
            user.DIDKey = key;

            // jsonconvert user to profile folder
            var userAsJson = JsonConvert.SerializeObject(user);
            File.WriteAllText(keyPath, userAsJson);
        }

    }
}
