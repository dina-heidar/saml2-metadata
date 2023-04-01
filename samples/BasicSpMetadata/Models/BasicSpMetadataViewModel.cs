namespace BasicSpMetadata.Models;

public class BasicSpMetadataViewModel : Saml2Metadata.BasicSpMetadata
{
    /// <summary>
    /// Gets or sets the signing certificate PFX.
    /// </summary>
    /// <value>
    /// The signing certificate PFX.
    /// </value>
    public PfxFile? SigningCertificatePfx { get; set; }
    /// <summary>
    /// Gets or sets the encrypting certificate PFX.
    /// </summary>
    /// <value>
    /// The encrypting certificate PFX.
    /// </value>
    public PfxFile? EncryptingCertificatePfx { get; set; }
    /// <summary>
    /// Gets or sets the signature certificate PFX.
    /// </summary>
    /// <value>
    /// The signature certificate PFX.
    /// </value>
    public PfxFile? SignatureCertificatePfx { get; set; }
}
