
namespace Saml.MetadataBuilder
{
    /// <summary>
    ///  Indexed endpoint which inherits from Endpoint.
    /// </summary>
    public class IndexedEndpoint : Endpoint
    {
        /// <summary>Gets or sets the index.</summary>
        /// <value>The index.</value>
        public ushort Index { get; set; }
        /// <summary>Gets or sets a value indicating whether this index value is the default value.</summary>
        /// <value>
        ///   <c>true</c> if this index value is default; otherwise, <c>false</c>.</value>
        public bool IsDefault { get; set; }
        /// <summary>Gets or sets a value indicating whether if default value is specified.</summary>
        /// <value>
        ///   <c>true</c> if default value specified; otherwise, <c>false</c>.</value>
        public bool IsDefaultSpecified { get; set; } = true;
    }
}
