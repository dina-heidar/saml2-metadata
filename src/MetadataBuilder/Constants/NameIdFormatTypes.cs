namespace Saml.MetadataBuilder.Constants
{
    /// <summary>
    ///  NameIDFormats constant values
    /// </summary>
    public static class NameIdFormatTypes
    {
        /// <summary>
        /// The email saml xml constant value
        /// </summary>
        public const string Email = "urn:oasis:names:tc:SAML:1.1:nameid-format:emailAddress";
        /// <summary>
        /// The persistent saml xml constant value
        /// </summary>
        public const string Persistent = "urn:oasis:names:tc:SAML:2.0:nameid-format:persistent";
        /// <summary>
        /// The transient saml xml constant value
        /// </summary>
        public const string Transient = "urn:oasis:names:tc:SAML:2.0:nameid-format:transient";
        /// <summary>
        /// The unspecified saml xml constant value
        /// </summary>
        public const string Unspecified = "urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified";
        /// <summary>
        /// The encrypted saml xml constant value
        /// </summary>
        public const string Encrypted = "urn:oasis:names:tc:SAML:2.0:nameid-format:encrypted";
        /// <summary>
        /// The entity identifier saml xml constant value
        /// </summary>
        public const string EntityIdentifier = "urn:oasis:names:tc:SAML:2.0:nameid-format:entity";
        /// <summary>
        /// The kerberos principal name saml xml constant value
        /// </summary>
        public const string KerberosPrincipalName = "urn:oasis:names:tc:SAML:2.0:nameid-format:kerberos";
        /// <summary>
        /// The subject name saml xml constant value
        /// </summary>
        public const string SubjectName = "urn:oasis:names:tc:SAML:1.1:nameid-format:X509SubjectName";
        /// <summary>
        /// The windows domain qualified name saml xml constant value
        /// </summary>
        public const string WindowsDomainQualifiedName = "urn:oasis:names:tc:SAML:1.1:nameid-format:WindowsDomainQualifiedName";
    }
}
