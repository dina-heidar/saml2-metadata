using System.Security.Cryptography.X509Certificates;

namespace Saml.MetadataBuilder
{
    public class EncryptingCertificate
    {
        /// <summary>
        /// Gets or sets the encrypting certificates.
        /// </summary>
        /// <value>
        /// The encrypting certificates.
        /// </value>
        public X509Certificate2 EncryptionCertificate { get; set; }
        /// <summary>
        /// Gets or sets the accepted encryption methods.
        /// </summary>
        /// <value>
        /// The accepted encryption methods.
        /// </value>
        public EncryptionMethod[] AcceptedEncryptionMethods { get; set; } = new EncryptionMethod[0];
    }
}
