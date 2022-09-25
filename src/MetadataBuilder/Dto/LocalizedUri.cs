using System;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class LocalizedUri
    {
        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public string Language { get; set; }
        /// <summary>
        /// Gets or sets the URI.
        /// </summary>
        /// <value>
        /// The URI.
        /// </value>
        public Uri Uri { get; set; } 
    }
}
