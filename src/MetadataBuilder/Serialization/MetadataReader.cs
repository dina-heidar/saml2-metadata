using MetadataBuilder.Schema.Metadata;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Xml;
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
            (string document, string namespaceName) where T : class
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (var reader = XmlReader.Create(new StringReader(document), safeSettings))
            {
                XmlUtil.CheckReaderOnEntry(reader, "EntityDescriptor", namespaceName);

                var envelopeReader = new EnvelopedSignatureReader(reader);
                var signature = envelopeReader.Signature;
                return ((T)xmlSerializer.Deserialize(reader));//, envelopeReader.Signature);
            }
        }
        //private string SerializeToStringXml<T>(T item) where T : class
        //{
        //    string xmlString = string.Empty;
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        //    using (MemoryStream memStm = new MemoryStream())
        //    {
        //        xmlSerializer.Serialize(memStm, item);
        //        memStm.Position = 0;
        //        xmlString = new StreamReader(memStm).ReadToEnd();
        //    }
        //    return xmlString;
        //}        

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

            var entityDescriptorType = DeSerializeToClass<EntityDescriptorType>
            (document, "urn:oasis:names:tc:SAML:2.0:metadata");
            var entityDescriptor = _mapper.MapEntity(entityDescriptorType);

            //foreach (var data in signature.KeyInfo.X509Data)
            //{
            //    foreach (var certificateString in data.Certificates)
            //    {
            //        var x509Certificate2 = new X509Certificate2(Convert.FromBase64String(certificateString));
            //        //configuration.SigningKeys.Add(new X509SecurityKey(cert));
            //        //configuration.X509Certificate2.Add(new X509Certificate2(cert));
            //        entityDescriptor.Signature = x509Certificate2;
            //    }
            //}
            return entityDescriptor;
        }

    }
}
