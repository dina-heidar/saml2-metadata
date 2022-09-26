using MetadataBuilder.Constants;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Saml.MetadataBuilder
{
    public class SpMetadata : EntityDescriptor
    {
        public string NameIdFormat { get; set; }
        public IndexedEndpoint[] AssertionConsumerServices { get; set; } = new IndexedEndpoint[0];
        public IndexedEndpoint[] ArtifactResolutionServices { get; set; } = new IndexedEndpoint[0];
        public virtual Endpoint[] SingleLogoutServiceEndpoints { get; set; } = new Endpoint[0];
        public bool AuthnRequestsSigned { get; set; }
        public bool WantAssertionsSigned { get; set; }
        public X509Certificate2[] EncryptingCertificates { get; set; }
        public X509Certificate2[] SigningCertificates { get; set; }
        public AttributeConsumingService[] AttributeConsumingService { get; set; } = new AttributeConsumingService[0];
        public SpMetadata()
        {
            RoleDescriptor = new RoleDescriptor
            {
                ProtocolSupportEnumeration = ProtocolSupportEnumerationTypes.Default,
            };
            MetadataType = MetadataType.SSOSPSSODescriptorType;
        }

    }
}
