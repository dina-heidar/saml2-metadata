using MetadataBuilder.Schema.Metadata;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Saml.MetadataBuilder
{
    internal class EntityDescriptorMapper : IMetadataMapper<EntityDescriptorType, EntityDescriptor>
    {
        public EntityDescriptor MapEntity(EntityDescriptorType src)
        {
            var entityDescriptor = new EntityDescriptor()
            {
                CacheDuration = src.cacheDuration,
                ValidUntil = src.validUntil,
                EntityID = src.entityID,
                Id = src.ID,
                Items = src.Items,
                ContactPersons = (src.ContactPerson != null ? src.ContactPerson.MapEach() : null), //optional
                Organization = (src.Organization != null ? src.Organization.Map() : null),  //optional
                Extensions = (src.Extensions != null ? Map(src.Extensions) : null),
                AdditionalMetadataLocations = (src.AdditionalMetadataLocation != null ? MapEach(src.AdditionalMetadataLocation)
                : new AdditionalMetadataLocation[0])//optional
            };

            if (src.Items.Length != 0)
            {
                var items = new object[src.Items.Length];
                var i = 0;
                foreach (var item in src.Items)
                {
                    if (item.GetType() == typeof(IDPSSODescriptorType))
                    {
                        var idpSSODescriptor = (item as IDPSSODescriptorType).Map();
                        entityDescriptor.Items[i] = idpSSODescriptor;
                        if (i < src.Items.Length) { i++; };
                    }
                    if (item.GetType() == typeof(SPSSODescriptorType))
                    {
                        var spSSODescriptor = (item as SPSSODescriptorType).Map();
                        entityDescriptor.Items[i] = spSSODescriptor;
                        if (i < src.Items.Length) { i++; };
                    }
                }
            }
            return entityDescriptor;
        }
        #region FromXml
        public static AdditionalMetadataLocation[] MapEach(AdditionalMetadataLocationType[] src)
        {
            if (src.Length > 0 || src != null)
            {
                var additionalMetadataLocation = new AdditionalMetadataLocation[src.Length];
                var i = 0;
                foreach (var ams in src)
                {
                    additionalMetadataLocation[i] = new AdditionalMetadataLocation()
                    {
                        Value = ams.Value,
                        Namespace = ams.@namespace
                    };
                    if (i < src.Length) { i++; };
                }
                return additionalMetadataLocation;
            }
            return null;
        }
        public static Extension Map(ExtensionsType src)
        {
            var extensions = new Extension();
            var objectList = new List<object>();

            if (src != null)
            {
                foreach (var item in src.Any)
                {

                    if (item.GetType() == typeof(DigestMethodType1))
                    {
                        var digestMethodType = (DigestMethodType1)item;
                        var digestMethod = new DigestMethod();
                        digestMethod.Algorithm = digestMethodType.Algorithm;
                        objectList.Add(digestMethod);
                    }
                    if (item.GetType() == typeof(SigningMethod))
                    {
                        var signingMethodType = (SigningMethodType)item;
                        var signingMethod = new SigningMethod
                        {
                            Algorithm = signingMethodType.Algorithm,
                            MinKeySize = signingMethodType.MinKeySize,
                            MaxKeySize = signingMethodType.MaxKeySize,
                        };
                        objectList.Add(signingMethod);
                    }
                }
                extensions.Any = objectList.ToArray<object>();
            }
            return extensions;
        }
        #endregion
    }
}
