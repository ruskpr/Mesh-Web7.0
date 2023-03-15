using Google.Protobuf;
using Okapi.Keys.V1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDCOMMAgent
{
    public class Subject
    {
        #region static
        // key is subjects Key ID
        public static Dictionary<string, Subject> Subjects = new Dictionary<string, Subject>();

        #endregion

        #region props

        public string Name { get; set; }
        public JsonWebKey MsgPublicKey { get; set; }    // public key: Identity, Message Encryption/Decryption
        public JsonWebKey MsgSecretKey { get; set; }    // secret key: Identity, Message Encryption/Decryption
        public ByteString ProofPublicKey { get; set; }  // Creation/Verification of Credential Proofs
        public ByteString ProofSecretKey { get; set; }  // Creation/Verification of Credential Proofs

        public DIDKey DIDKey { get; }

        #endregion

        #region constructor

        public Subject(string name)
        {
            Name = name;

            // init key by passing in subject
            DIDKey key = new DIDKey(this);
            key.InitKey();

            //set subject's public and secret keys
            DIDKey = key;
            MsgPublicKey = DIDKey.PublicKey;
            MsgSecretKey = DIDKey.SecretKey;
            ProofPublicKey = DIDKey.ProofKey.Pk;
            ProofSecretKey = DIDKey.ProofKey.Sk;

            // add subject to static 'Subjects' dictionary
            Subjects.Add(key.KeyId, this);
        }

        #endregion

    }
}
