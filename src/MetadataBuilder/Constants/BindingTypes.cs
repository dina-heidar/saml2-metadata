namespace Saml.MetadataBuilder.Constants
{
    /// <summary>
    ///  Binding contstant values
    /// </summary>
    public static class BindingTypes
    {
        /// <summary>The HTTP redirect saml xml constant value</summary>
        public const string Redirect = "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-Redirect";
        /// <summary>The HTTP post saml xml constant value</summary>
        public const string Post = "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST";
        /// <summary>The HTTP artifact saml xml constant value</summary>
        public const string Artifact = "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-Artifact";
    }
}
