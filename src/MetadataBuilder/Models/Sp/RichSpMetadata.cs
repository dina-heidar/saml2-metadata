// Copyright (c) 2022 Dina Heidar
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

using System;
using System.Security.Cryptography.X509Certificates;
using Saml.MetadataBuilder.Constants;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Saml.MetadataBuilder.EntityDescriptor" />
    public class RichSpMetadata : EntityDescriptor
    {
        /// <summary>
        /// Gets or sets the name identifier format.
        /// </summary>
        /// <value>
        /// The name identifier format.
        /// </value>
        public string NameIdFormat { get; set; }
        /// <summary>
        /// Gets or sets the assertion consumer services.
        /// </summary>
        /// <value>
        /// The assertion consumer services.
        /// </value>
        public IndexedEndpoint[] AssertionConsumerServices { get; set; } = null;
        /// <summary>
        /// Gets or sets the artifact resolution services.
        /// </summary>
        /// <value>
        /// The artifact resolution services.
        /// </value>
        public IndexedEndpoint[] ArtifactResolutionServices { get; set; } = null;
        /// <summary>
        /// Gets or sets the single logout service endpoints.
        /// </summary>
        /// <value>
        /// The single logout service endpoints.
        /// </value>
        public virtual Endpoint[] SingleLogoutServiceEndpoints { get; set; } = null;
        /// <summary>
        /// Gets or sets a value indicating whether [authn requests signed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [authn requests signed]; otherwise, <c>false</c>.
        /// </value>
        public bool AuthnRequestsSigned { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [want assertions signed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [want assertions signed]; otherwise, <c>false</c>.
        /// </value>
        public bool WantAssertionsSigned { get; set; }
        /// <summary>
        /// Gets or sets the encrypting certificates.
        /// </summary>
        /// <value>
        /// The encrypting certificates.
        /// </value>
        public EncryptingCertificate[] EncryptingCertificates { get; set; } = null;
        /// <summary>
        /// Gets or sets the signing certificates.
        /// </summary>
        /// <value>
        /// The signing certificates.
        /// </value>
        public X509Certificate2[] SigningCertificates { get; set; } = null;
        /// <summary>
        /// Gets or sets the protocol support enumeration.
        /// </summary>
        /// <value>
        /// The protocol support enumeration.
        /// </value>
        internal string ProtocolSupportEnumeration { get; set; } = ProtocolSupportEnumerationTypes.Default;
        /// <summary>
        /// Gets or sets the attribute consuming service.
        /// </summary>
        /// <value>
        /// The attribute consuming service.
        /// </value>
        public AttributeConsumingService[] AttributeConsumingService { get; set; } 
        /// <summary>
        /// Initializes a new instance of the <see cref="RichSpMetadata"/> class.
        /// </summary>
        public RichSpMetadata()
        {
            MetadataType = MetadataType.SSOSPSSODescriptorType;
        }
    }
}
