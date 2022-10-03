using MetadataBuilder.Schema.Metadata;

namespace Saml.MetadataBuilder
{
    internal class EntityDescriptorTypeMapper : IMetadataMapper<EntityDescriptor, EntityDescriptorType>
    {
        public EntityDescriptorType MapEntity(EntityDescriptor src)
        {

            var entityDescriptorType = new EntityDescriptorType()
            {
                cacheDuration = src.CacheDuration, //optional
                validUntilSpecified = (src.ValidUntil != null),//optional
                validUntil = src.ValidUntil,//optional
                entityID = src.EntityID, //---> required
                ID = src.Id, //optional
                ContactPerson = (src.ContactPersons != null ? src.ContactPersons.MapEach() : null), //optional
                Organization = (src.Organization != null ? src.Organization.Map() : null),  //optional              
                //Signature  = //optional signtaure of metatadata file itself
                //AdditionalMetadataLocation = src.AdditionalMetadataLocations //optional
            };


            if (src.GetType() == typeof(SpMetadata))
            {
                var spMetadata = src as SpMetadata;
                SPSSODescriptorType sPSSODescriptorType = spMetadata.Map(); //---> required

                entityDescriptorType.Items = new object[] { sPSSODescriptorType };
            }
            if (src.GetType() == typeof(IdpMetadata))
            {
                var idpMetadata = src as IdpMetadata;
                IDPSSODescriptorType idPSSODescriptorType = idpMetadata.Map(); //---> required
            }

            return entityDescriptorType;
        }
    }
}
