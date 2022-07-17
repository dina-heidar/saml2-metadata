namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestedAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is required field.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is required field; otherwise, <c>false</c>.
        /// </value>
        public bool IsRequiredField { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is required field specified.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is required field specified; otherwise, <c>false</c>.
        /// </value>
        public bool IsRequiredFieldSpecified { get; set; } = true;
    }
}
