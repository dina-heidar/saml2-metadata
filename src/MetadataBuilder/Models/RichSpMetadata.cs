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
using Saml.MetadataBuilder.Constants;

namespace Saml.MetadataBuilder
{
    public class RichSpMetadata : EntityDescriptor
    {
        public string NameIdFormat { get; set; }
        public IndexedEndpoint[] AssertionConsumerServices { get; set; } = new IndexedEndpoint[0];
        public IndexedEndpoint[] ArtifactResolutionServices { get; set; } = new IndexedEndpoint[0];
        public virtual Endpoint[] SingleLogoutServiceEndpoints { get; set; } = new Endpoint[0];
        public bool AuthnRequestsSigned { get; set; }
        public bool WantAssertionsSigned { get; set; }
        public EncryptingCertificate[] EncryptingCertificates { get; set; }
        public X509Certificate2[] SigningCertificates { get; set; }
        internal string ProtocolSupportEnumeration { get; set; } = ProtocolSupportEnumerationTypes.Default;
        public AttributeConsumingService[] AttributeConsumingService { get; set; } = new AttributeConsumingService[0];
        public RichSpMetadata()
        {
            MetadataType = MetadataType.SSOSPSSODescriptorType;
        }

    }
}
