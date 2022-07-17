namespace Saml.MetadataBuilder
{
    /// <summary>
    /// Endpoint class
    /// </summary>
    public class Endpoint
    {
        /// <summary>Gets or sets the binding.</summary>
        /// <value>The binding.</value>
        public string Binding { get; set; }
        /// <summary>Gets or sets the location.</summary>
        /// <value>The location.</value>
        public string Location { get; set; }
        /// <summary>Gets or sets the response location.</summary>
        /// <value>The response location.</value>
        public string ResponseLocation { get; set; }
    }
}
