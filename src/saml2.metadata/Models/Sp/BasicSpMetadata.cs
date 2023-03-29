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

using System.Security.Cryptography.X509Certificates;

namespace Saml2Metadata
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Saml.MetadataBuilder.RichSpMetadata" />
    public class BasicSpMetadata : RichSpMetadata
    {
        /// <summary>
        /// Gets or sets the assertion consumer service.
        /// </summary>
        /// <value>
        /// The assertion consumer service.
        /// </value>
        public IndexedEndpoint AssertionConsumerService { get; set; }
        /// <summary>
        /// Gets or sets the artifact resolution service.
        /// </summary>
        /// <value>
        /// The artifact resolution service.
        /// </value>
        public IndexedEndpoint ArtifactResolutionService { get; set; }
        /// <summary>
        /// Gets or sets the single logout service endpoint.
        /// </summary>
        /// <value>
        /// The single logout service endpoint.
        /// </value>
        public Endpoint SingleLogoutServiceEndpoint { get; set; }
        /// <summary>
        /// Gets or sets the encrypting certificate.
        /// </summary>
        /// <value>
        /// The encrypting certificate.
        /// </value>
        public EncryptingCertificate EncryptingCertificate { get; set; } = new EncryptingCertificate();
        /// <summary>
        /// Gets or sets the signing certificate.
        /// </summary>
        /// <value>
        /// The signing certificate.
        /// </value>
        public X509Certificate2 SigningCertificate { get; set; }
    }
}
