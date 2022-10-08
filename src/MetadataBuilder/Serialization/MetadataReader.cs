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

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using MetadataBuilder.Schema.Metadata;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Xml;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Saml.MetadataBuilder.IMetadataReader" />
    public class MetadataReader : IConfigurationRetriever<EntityDescriptor>, IMetadataReader
    {
        private readonly IMetadataMapper<EntityDescriptorType, EntityDescriptor> _mapper;
        private XmlReaderSettings safeSettings;

        public MetadataReader(IMetadataMapper<EntityDescriptorType, EntityDescriptor> mapper)
        {
            _mapper = mapper;

            safeSettings = new XmlReaderSettings
            {
                XmlResolver = null,
                DtdProcessing = DtdProcessing.Prohibit,
                ValidationType = ValidationType.None
            };
        }
        public Task<EntityDescriptor> GetConfigurationAsync(string address,
            IDocumentRetriever retriever, CancellationToken cancel)
        {
            return Read(address, retriever, cancel);
        }

        internal T DeSerializeToClass<T>
            (string xmlString) where T : class
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var reader = CreateReader(xmlString))
            {
                return ((T)xmlSerializer.Deserialize(reader));
            }
        }

        internal XmlReader CreateReader(string xmlString)
        {
            var reader = XmlReader.Create(new StringReader(xmlString), safeSettings);
            return reader;
        }

        internal Signature GetSignature(string xmlString)
        {
            using (var reader = CreateReader(xmlString))
            {
                var envelopeReader = new EnvelopedSignatureReader(reader);
                envelopeReader.ReadOuterXml();
                var signature = envelopeReader.Signature;
                return signature;
            }
        }
        public async Task<EntityDescriptor> Read(string address, CancellationToken cancel)
        {
            return await Read(address, new HttpDocumentRetriever(), cancel);
        }

        private async Task<EntityDescriptor> Read(string address,
            IDocumentRetriever retriever, CancellationToken cancel)
        {
            if (string.IsNullOrEmpty(address))
                throw new Saml2MetadataSerializationException($"{nameof(address)} cannot ne null");

            if (retriever == null)
                throw new Saml2MetadataSerializationException($"{nameof(retriever)} cannot ne null");

            var xmlString = await retriever.GetDocumentAsync(address, cancel);

            var entityDescriptorType = DeSerializeToClass<EntityDescriptorType>(xmlString);

            //there is always one signature in entityDescriptor
            //this is different than having multiple signatures that can be used
            var signature = GetSignature(xmlString);
            var entityDescriptor = _mapper.MapEntity(entityDescriptorType);

            if (signature != null)
            {
                var x509Data = signature.KeyInfo.X509Data.FirstOrDefault();
                var x509Certificate2 = new X509Certificate2(Convert.FromBase64String
                    (x509Data.Certificates.FirstOrDefault()));

                entityDescriptor.Signature = x509Certificate2;
            }
            return entityDescriptor;
        }

    }
}
