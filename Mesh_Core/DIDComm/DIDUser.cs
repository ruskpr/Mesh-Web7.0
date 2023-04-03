

using DIDCOMMAgent;
using Google.Protobuf;
using Newtonsoft.Json;
using Okapi.Keys.V1;

namespace Mesh_Core.DIDComm
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
            var user = JsonConvert.DeserializeObject<DIDUser>(keyPath);
            return user;
        }

        public static DIDUser? Import(string keyPath, bool overwrite)
        {
            if (!keyPath.EndsWith(".profile")) return null;

            var fileName = Path.GetFileName(keyPath);

            var profileFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Technitium", "Mesh");

            if (!Directory.Exists(profileFolder))
                Directory.CreateDirectory(profileFolder);

            File.Copy(keyPath, Path.Combine(profileFolder + fileName), overwrite);

            return JsonConvert.DeserializeObject<DIDUser>(profileFolder);
        }

        public static void Create(string name, string password)
        {
            var profileFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Technitium", "Mesh");

            if (!Directory.Exists(profileFolder))
                Directory.CreateDirectory(profileFolder);

            DIDUser user = new DIDUser()
            {
                Name = name,
                Password = password,
            };

            DIDKey key = new DIDKey(user.Name, profileFolder);
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
            File.WriteAllText(Path.Combine(profileFolder, $"{user.Name}.profile.json"), userAsJson);
        }

    }
}
