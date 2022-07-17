namespace Saml.MetadataBuilder
{
    /// <summary>
    /// Ui info
    /// </summary>
    public class UiInfo
    {
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public LocalizedName DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public LocalizedName Description { get; set; }

        /// <summary>
        /// Gets or sets the information URL.
        /// </summary>
        /// <value>
        /// The information URL.
        /// </value>
        public LocalizedUri InformationURL { get; set; }

        /// <summary>
        /// Gets or sets the privacy statement URL.
        /// </summary>
        /// <value>
        /// The privacy statement URL.
        /// </value>
        public LocalizedUri PrivacyStatementURL { get; set; }

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>
        /// The logo.
        /// </value>
        public Logo Logo { get; set; }
        /// <summary>
        /// Gets or sets the keywords.
        /// </summary>
        /// <value>
        /// The keywords.
        /// </value>
        public Keyword Keywords { get; set; }

    }
}
