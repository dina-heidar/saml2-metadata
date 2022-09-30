using MetadataBuilder.Schema.Metadata;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Xml;
using Saml.MetadataBuilder.Constants;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Saml.MetadataBuilder.IMetadataReader" />
    public class MetadataReader : IConfigurationRetriever<EntityDescriptor>, IMetadataReader
    {
        private readonly IMetadataMapper<EntityDescriptorType, EntityDescriptor> _mapper;

        public MetadataReader(IMetadataMapper<EntityDescriptorType, EntityDescriptor> mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Retrieves a populated configuration given an address and an <see cref="T:Microsoft.IdentityModel.Protocols.IDocumentRetriever" />.
        /// </summary>
        /// <param name="address">Address of the discovery document.</param>
        /// <param name="retriever">The <see cref="T:Microsoft.IdentityModel.Protocols.IDocumentRetriever" /> to use to read the discovery document.</param>
        /// <param name="cancel">A cancellation token that can be used by other objects or threads to receive notice of cancellation. <see cref="T:System.Threading.CancellationToken" />.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<EntityDescriptor> GetConfigurationAsync(string address,
            IDocumentRetriever retriever, CancellationToken cancel)
        {
            return Read(address, retriever, cancel);
        }

        internal T DeSerializeToClass<T>(string document, string namespaceName) where T : class
        {
            var safeSettings = new XmlReaderSettings
            {
                XmlResolver = null,
                DtdProcessing = DtdProcessing.Prohibit,
                ValidationType = ValidationType.None
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (var reader = XmlReader.Create(new StringReader(document), safeSettings))
            {
                XmlUtil.CheckReaderOnEntry(reader, "EntityDescriptor", namespaceName);
                var envelopeReader = new EnvelopedSignatureReader(reader);
                return (T)xmlSerializer.Deserialize(reader);
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

            var document = await retriever.GetDocumentAsync(address, cancel).ConfigureAwait(false);
            var entityDescriptorType = DeSerializeToClass<EntityDescriptorType>(document, NamespaceTypes.MetadataNamespace);
            var entityDescriptor = _mapper.MapEntity(entityDescriptorType);
            return entityDescriptor;
        }
    }
}
