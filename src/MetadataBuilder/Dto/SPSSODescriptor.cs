namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Saml.MetadataBuilder.SSODescriptor" />
    public class SPSSODescriptor : SSODescriptor
    {

        /// <summary>
        /// Gets or sets the assertion consumer services.
        /// </summary>
        /// <value>
        /// The assertion consumer services.
        /// </value>
        public IndexedEndpoint[] AssertionConsumerServices { get; set; }

        /// <summary>
        /// Gets or sets the attribute consuming service.
        /// </summary>
        /// <value>
        /// The attribute consuming service.
        /// </value>
        public AttributeConsumingService[] AttributeConsumingService { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [authn requests signed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [authn requests signed]; otherwise, <c>false</c>.
        /// </value>
        public bool AuthnRequestsSigned { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [authn requests signed field specified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [authn requests signed field specified]; otherwise, <c>false</c>.
        /// </value>
        public bool AuthnRequestsSignedFieldSpecified { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether [want assertions signed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [want assertions signed]; otherwise, <c>false</c>.
        /// </value>
        public bool WantAssertionsSigned { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [want assertions signed field specified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [want assertions signed field specified]; otherwise, <c>false</c>.
        /// </value>
        public bool WantAssertionsSignedFieldSpecified { get; set; } = true;

    }
}

