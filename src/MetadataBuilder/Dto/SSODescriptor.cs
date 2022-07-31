namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Saml.MetadataBuilder.RoleDescriptor" />
    public class SSODescriptor : RoleDescriptor
    {
        /// <summary>
        /// Gets or sets the artifact resolution service.
        /// </summary>
        /// <value>
        /// The artifact resolution service.
        /// </value>
        public IndexedEndpoint[] ArtifactResolutionServices { get; set; }

        /// <summary>
        /// Gets or sets the single logout service.
        /// </summary>
        /// <value>
        /// The single logout service.
        /// </value>
        public Endpoint[] SingleLogoutServices { get; set; }

        /// <summary>
        /// <para>Used to configure handlers that are responsible 
        /// for processing name identifier management messages from an IdP. 
        /// These are protocol specific, but generally fall into two classes: 
        /// requests, which inform the SP of a change, and responses, 
        /// which conclude a change event initiated by the SP</para>.
        /// </summary>
        /// <value>
        /// The manage name identifier service.
        /// </value>
        public Endpoint[] ManageNameIdServices { get; set; }

        /// <summary>
        /// Gets or sets the name identifier format.
        /// </summary>
        /// <value>
        /// The name identifier format.
        /// </value>
        public string[] NameIdFormats { get; set; }
    }
}
