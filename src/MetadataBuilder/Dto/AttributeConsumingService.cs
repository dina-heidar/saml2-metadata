namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class AttributeConsumingService
    {
        /// <summary>
        /// Gets or sets the service names.
        /// </summary>
        /// <value>
        /// The service names.
        /// </value>
        public LocalizedName[] ServiceNames { get; set; }

        /// <summary>
        /// Gets or sets the service descriptions.
        /// </summary>
        /// <value>
        /// The service descriptions.
        /// </value>
        public LocalizedName[] ServiceDescriptions { get; set; }

        /// <summary>
        /// Gets or sets the requested attributes.
        /// </summary>
        /// <value>
        /// The requested attributes.
        /// </value>
        public RequestedAttribute[] RequestedAttributes { get; set; }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public ushort Index { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefault { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is default field specified.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is default field specified; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefaultFieldSpecified { get; set; } = true;
    }
}
