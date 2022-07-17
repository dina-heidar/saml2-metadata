using Microsoft.IdentityModel.Xml;
using System;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public string EntityId { get; set; }
        /// <summary>
        /// Gets or sets the protocol support enumeration.
        /// </summary>
        /// <value>
        /// The protocol support enumeration.
        /// </value>
        public string[] ProtocolSupportEnumeration { get; set; }
        /// <summary>
        /// Gets or sets the contact person.
        /// </summary>
        /// <value>
        /// The contact person.
        /// </value>
        public ContactPerson[] ContactPerson { get; set; }
        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        /// <value>
        /// The organization.
        /// </value>
        public Organization Organization { get; set; }

        /// <summary>
        /// Gets or sets the signature.
        /// </summary>
        /// <value>
        /// The signature.
        /// </value>
        public Signature Signature { get; set; }

        /// <summary>
        /// Gets or sets the extensions.
        /// </summary>
        /// <value>
        /// The extensions.
        /// </value>
        public Extension Extensions { get; set; }

        /// <summary>
        /// Gets or sets the key descriptor.
        /// </summary>
        /// <value>
        /// The key descriptor.
        /// </value>
        public KeyDescriptor KeyDescriptor { get; set; }


        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get;set; }

        /// <summary>
        /// Gets or sets the valid until.
        /// </summary>
        /// <value>
        /// The valid until.
        /// </value>
        public DateTime ValidUntil { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [valid until field specified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [valid until field specified]; otherwise, <c>false</c>.
        /// </value>
        public bool ValidUntilFieldSpecified { get; set; } = true;

        /// <summary>
        /// Gets or sets the duration of the cache.
        /// </summary>
        /// <value>
        /// The duration of the cache.
        /// </value>
        public string CacheDuration { get; set; }
    }
}
