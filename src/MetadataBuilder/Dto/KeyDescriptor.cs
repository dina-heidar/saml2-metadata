// MIT License
// Copyright (c) 2019 Dina Heidar
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY
//
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM
//
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

using Microsoft.IdentityModel.Xml;
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
        public KeyInfoNameEnumTypes KeyInfoNameType { get; set; }
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
        public KeyEnumTypes KeyType { get; set; }

        /// <summary>
        /// The encryption methods
        /// </summary>
        public EncryptionMethod[] EncryptionMethods { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use field specified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use field specified]; otherwise, <c>false</c>.
        /// </value>
        public bool UseSpecified { get; set; } = true;
    }
}

