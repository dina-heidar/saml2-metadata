namespace Saml.MetadataBuilder.Constants
{
    /// <summary>
    /// 
    /// </summary>
    public static class AuthnContextRefTypes
    {
        /// <summary>
        /// The user name and password
        /// </summary>
        public const string UserNameAndPassword = "urn:oasis:names:tc:SAML:2.0:ac:classes:Password";
        /// <summary>
        /// The password protected transport
        /// </summary>
        public const string PasswordProtectedTransport = "urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport";
        /// <summary>
        /// The transport layer security client
        /// </summary>
        public const string TransportLayerSecurityClient = "urn:oasis:names:tc:SAML:2.0:ac:classes:TLSClient";
        /// <summary>
        /// The X509 certificate
        /// </summary>
        public const string X509Certificate = "urn:oasis:names:tc:SAML:2.0:ac:classes:X509";
        /// <summary>
        /// The integrated windows authentication
        /// </summary>
        public const string IntegratedWindowsAuthentication = "urn:federation:authentication:windows";
        /// <summary>
        /// The kerberose
        /// </summary>
        public const string Kerberose = "urn:oasis:names:tc:SAML:2.0:ac:classes:Kerberos";
    }
}
