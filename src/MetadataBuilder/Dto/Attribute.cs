namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class Attribute
    {
        /// <summary>
        /// Gets or sets the attribute value.
        /// </summary>
        /// <value>
        /// The attribute value.
        /// </value>
        public object[] AttributeValue { get;set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name format.
        /// </summary>
        /// <value>
        /// The name format.
        /// </value>
        public string NameFormat { get; set; }

        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        /// <value>
        /// The name of the friendly.
        /// </value>
        public string FriendlyName { get; set; }
    }
}
