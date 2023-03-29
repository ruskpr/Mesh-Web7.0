using Google.Protobuf;
using Okapi.Keys.V1;

namespace DIDCOMMAgent
{
    public interface ISubject
    {
        string Name { get; set; }
        DIDKey DIDKey { get; }
        JsonWebKey MsgPublicKey { get; set; }
        JsonWebKey MsgSecretKey { get; set; }
        ByteString ProofPublicKey { get; set; }
        ByteString ProofSecretKey { get; set; }
    }
}