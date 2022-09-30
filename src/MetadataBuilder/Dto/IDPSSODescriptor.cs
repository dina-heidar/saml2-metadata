namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Saml.MetadataBuilder.SSODescriptor" />
    public class IDPSSODescriptor : SSODescriptor
    {
        /// <summary>
        /// Gets or sets the single sign on service.
        /// </summary>
        /// <value>
        /// The single sign on service.
        /// </value>
        public Endpoint[] SingleSignOnServices { get; set; }

        /// <summary>
        /// Gets or sets the name identifier mapping service.
        /// </summary>
        /// <value>
        /// The name identifier mapping service.
        /// </value>
        public Endpoint[] NameIdMappingServices { get; set; }

        /// <summary>
        /// Gets or sets the assertion identifier request service.
        /// </summary>
        /// <value>
        /// The assertion identifier request service.
        /// </value>
        public Endpoint[] AssertionIdRequestServices { get; set; }

        /// <summary>
        /// Gets or sets the attribute profile field.
        /// </summary>
        /// <value>
        /// The attribute profile field.
        /// </value>
        public string[] AttributeProfiles { get; set; }

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        public Attribute[] Attributes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [want authn requests signed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [want authn requests signed]; otherwise, <c>false</c>.
        /// </value>
        public bool WantAuthnRequestsSigned { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [want authn requests signed field specified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [want authn requests signed field specified]; otherwise, <c>false</c>.
        /// </value>
        public bool WantAuthnRequestsSignedFieldSpecified { get; set; } = true;
    }
}

