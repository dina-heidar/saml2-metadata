using System;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// The logo
    ///  logos SHOULD:  use a transparent background where appropriate
    ///  use PNG, or GIF(less preferred), images use HTTPS URLs in order 
    ///  to avoid mixed-content warnings within browsers
    /// </summary>
    public class Logo
    {
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public string Height { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public string Width { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public string Language { get; set; }
        /// <summary>
        /// Gets or sets the value as a Url.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public Uri Value { get; set; }
    }
}
