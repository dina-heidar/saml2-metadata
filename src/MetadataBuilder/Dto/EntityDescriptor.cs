using Saml.MetadataBuilder.Constants;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// This base class that creates the metadata.
    /// </summary>
    public class EntityDescriptor
    {
        /// <summary>
        /// <para><b>*Required*</b><br/> 
        /// The unique identifier of the SAML entity 
        /// which is described by this definition.<br/>
        /// Example: dev.contoso.com
        /// </para>
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        /// <example>dev.constoso.com</example>
        public string EntityID { get; set; }

        /// <summary>
        /// <para><b>Optional</b><br/>
        /// The expiration time of the metadata.<br/>
        /// Example: 2028-01-21T18:12:29.287Z
        /// </para>
        /// </summary>
        /// <value>
        /// The valid until value.
        /// </value>        
        /// <example>2028-01-21T18:12:29.287Z</example>
        public DateTime ValidUntil { get; set; }

        /// <summary>
        /// <para><b>Optional</b><br/>
        /// The maximum length of time a consumer should cache the metadata.<br/>
        /// Example: PT604800S
        /// </para>
        /// </summary>
        /// <value>
        /// The duration of the cache.
        /// </value>
        /// <example>PT604800S</example>
        public string CacheDuration { get; set; }

        /// <summary>
        /// <para><b>Optional</b><br/> 
        /// A document-unique identifier 
        /// for the element, typically used as a reference point when signing. <br/>
        /// Example: 35D0C44A-52CE-4D2F-BE06-AE5F00C30AA7
        /// </para>
        /// </summary>
        /// <value>
        /// The a document-unique identifier.
        /// </value>
        /// <example>35D0C44A-52CE-4D2F-BE06-AE5F00C30AA7</example>
        public string Id { get; set; }

        /// <summary>
        /// <para>
        /// <b>Optional for Service Providers</b><br/> 
        /// <b>Required for Identity Providers</b><br/> 
        /// Used to include a digital signature that can be used to 
        /// sign various elements in a metadata definition.
        /// </para>
        /// </summary>
        /// <value>
        /// The certificate used for signature.
        /// </value>
        public X509Certificate2 Signature { get; set; }

        /// <summary>
        /// <para><b>Optional</b><br/> 
        /// Used to include metadata extensions that are agreed upon 
        /// between a metadata publisher and the consumer.
        /// </para>
        /// </summary>
        /// <value>
        /// The extensions.
        /// </value>
        public Extension Extensions { get; set; }
        /// <summary>
        /// <para><b>*Required*</b><br/> 
        /// Used to describe the role or capabilities of the SAML entity.
        /// </para>
        /// </summary>
        /// <value>
        /// The role descriptor.
        /// </value>
        public object[] Items { get; set; }
        //internal RoleDescriptor RoleDescriptor { get; set; }
        /// <summary>
        /// <para><b>Optional</b><br/> 
        /// Used to identifying the organization 
        /// responsible for the SAML entity, it possible 
        /// to include details such as organization’s name, 
        /// display name, URL.
        /// </para>
        /// </summary>
        /// <value>
        /// The organization.
        /// </value>
        public Organization Organization { get; set; }
        /// <summary>
        /// <para><b>Optional</b><br/> 
        /// used to provide various kind of information about 
        /// a contact person such as individuals’ name,
        /// email address and phone numbers.
        /// </para>
        /// </summary>
        /// <value>
        /// The contact persons.
        /// </value>
        public ContactPerson[] ContactPersons { get; set; } = null;

        /// <summary>
        /// <para><b>Optional</b><br/> 
        /// Used to provide a set of locations where additional 
        /// metadata exists for the current SAML entity.
        /// </para>
        /// </summary>
        /// <value>
        /// The additional metadata location field.
        /// </value>
        public AdditionalMetadataLocation[] AdditionalMetadataLocations { get; set; } = null;
        internal MetadataType MetadataType { get; set; }
    }
}
