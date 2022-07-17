﻿using Microsoft.IdentityModel.Xml;
using Saml.MetadataBuilder.Constants;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class KeyDescriptor
    {
        /// <summary>
        /// Gets or sets the type of the key information name.
        /// </summary>
        /// <value>
        /// The type of the key information name.
        /// </value>
        public KeyInfoNameType KeyInfoNameType { get; set; }
        /// <summary>
        /// Gets or sets the key information.
        /// </summary>
        /// <value>
        /// The key information.
        /// </value>
        internal KeyInfo KeyInfo { get; set; }
        /// <summary>
        /// Gets or sets the type of the key.
        /// </summary>
        /// <value>
        /// The type of the key.
        /// </value>
        public KeyTypes KeyType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use field specified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use field specified]; otherwise, <c>false</c>.
        /// </value>
        public bool UseSpecified { get; set; } = true;
    }
}

