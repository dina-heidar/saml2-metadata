namespace Saml.MetadataBuilder
{
    public class EncryptionMethod
    {
        /// <summary>
        /// Gets or sets the size of the key.
        /// </summary>
        /// <value>
        /// The size of the key.
        /// </value>
        public string KeySize { get; set; }
        /// <summary>
        /// Gets or sets the oae pparams.
        /// </summary>
        /// <value>
        /// The oae pparams.
        /// </value>
        public byte[] OAEPparams { get; set; }
        /// <summary>
        /// Gets or sets the algorithm.
        /// </summary>
        /// <value>
        /// The algorithm.
        /// </value>
        public string Algorithm { get; set; }
    }
}
