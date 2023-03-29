

using DIDCOMMAgent;
using Google.Protobuf;
using Newtonsoft.Json;
using Okapi.Keys.V1;

namespace Mesh_Core.DIDComm
{
    public class DIDUser : ISubject
    {
        public string Password { get; set; }

        public DIDUser(string keyPath)
        {

        }

        public DIDUser()
        {
        }

        #region interface properties
        public string Name { get; set; }
        public DIDKey DIDKey { get; set; }
        public JsonWebKey MsgPublicKey { get; set; }
        public JsonWebKey MsgSecretKey { get; set; }
        public ByteString ProofPublicKey { get; set; }
        public ByteString ProofSecretKey { get; set; }



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

            //set subject's public and secret keys
            user.DIDKey = key;
        }

    }
}
