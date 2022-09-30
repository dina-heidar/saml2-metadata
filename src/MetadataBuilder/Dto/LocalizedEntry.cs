using System.Globalization;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// Localization
    /// </summary>
    public abstract class LocalizedEntry
    {
        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public CultureInfo Language { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizedEntry"/> class.
        /// </summary>
        protected LocalizedEntry()
            : this(null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizedEntry"/> class.
        /// </summary>
        /// <param name="language">The language.</param>
        protected LocalizedEntry(CultureInfo language)
        {
            Language = language;
        }
    }
}
