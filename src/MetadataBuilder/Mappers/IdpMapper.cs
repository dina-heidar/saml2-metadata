using MetadataBuilder.Schema.Metadata;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Saml.MetadataBuilder
{
    internal static class IdpMapper
    {
        #region ToXml


        #endregion

        #region FromXml

        public static IDPSSODescriptor Map(this IDPSSODescriptorType src)
        {
            var idpSsoDescriptor = new IDPSSODescriptor()
            {
                //idp
                SingleSignOnServices = (src.SingleSignOnService != null ? src.SingleSignOnService.MapEach() : new Endpoint[0]),
                NameIdMappingServices = (src.NameIDMappingService != null ? src.NameIDMappingService.MapEach() : new Endpoint[0]),
                AssertionIdRequestServices = (src.AssertionIDRequestService != null ? src.AssertionIDRequestService.MapEach() : new Endpoint[0]),
                AttributeProfiles = (src.AttributeProfile != null ? src.AttributeProfile : new string[0]),
                Attributes = (src.Attribute != null ? src.Attribute.MapEach() : new Attribute[0]),
                WantAuthnRequestsSigned = src.WantAuthnRequestsSigned,

                //sso
                NameIdFormats = (src.NameIDFormat != null ? src.NameIDFormat : new string[0]),
                ArtifactResolutionServices = (src.ArtifactResolutionService != null ? src.ArtifactResolutionService.MapEach() : new IndexedEndpoint[0]),
                SingleLogoutServices = (src.SingleLogoutService != null ? src.SingleLogoutService.MapEach() : new Endpoint[0]),
                ManageNameIdServices = (src.ManageNameIDService != null ? src.ManageNameIDService.MapEach() : new Endpoint[0]),

                //role
                ProtocolSupportEnumeration = (src.protocolSupportEnumeration != null ? src.protocolSupportEnumeration[0] : string.Empty),
                ContactPersons = (src.ContactPerson != null ? src.ContactPerson.MapEach() : new ContactPerson[0]),
                Organization = (src.Organization != null ? src.Organization.Map() : null),
                EncryptingCertificates = (src.KeyDescriptor != null ? RoleMapper.MapEach(src.KeyDescriptor, KeyTypes.encryption) : new X509Certificate2[0]),
                SigningCertificates = (src.KeyDescriptor != null ? RoleMapper.MapEach(src.KeyDescriptor, KeyTypes.signing) : new X509Certificate2[0]),
                Id = src.ID,
                ValidUntil = src.validUntil,
                CacheDuration = src.cacheDuration
            };
            return idpSsoDescriptor;
        }

        public static Attribute[] MapEach(this AttributeType[] src)
        {
            if (src.Count() > 0 || src != null)
            {
                var attribute = new Attribute[src.Length];
                var i = 0;
                foreach (var att in src)
                {
                    attribute[i] = new Attribute
                    {
                        AttributeValue = att.AttributeValue,
                        FriendlyName = att.FriendlyName,
                        Name = att.Name,
                        NameFormat = att.NameFormat
                    };
                    if (i < src.Length) { i++; };
                }
                return attribute;
            }
            return new Attribute[0];
        }

        #endregion
    }
}
