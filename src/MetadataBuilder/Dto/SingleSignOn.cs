namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Saml.MetadataBuilder.Role" />
    public class SingleSignOn : Role
    {
        /// <summary>
        /// Gets or sets the artifact resolution service.
        /// </summary>
        /// <value>
        /// The artifact resolution service.
        /// </value>
        public IndexedEndpoint[] ArtifactResolutionService { get; set; }

        /// <summary>
        /// Gets or sets the single logout service.
        /// </summary>
        /// <value>
        /// The single logout service.
        /// </value>
        public Endpoint[] SingleLogoutService { get; set; }

        /// <summary>
        /// Gets or sets the manage name identifier service.
        /// </summary>
        /// <value>
        /// The manage name identifier service.
        /// </value>
        public Endpoint[] ManageNameIdService { get; set; }

        /// <summary>
        /// Gets or sets the name identifier format.
        /// </summary>
        /// <value>
        /// The name identifier format.
        /// </value>
        public string[] NameIdFormat { get; set; }
    }
}
