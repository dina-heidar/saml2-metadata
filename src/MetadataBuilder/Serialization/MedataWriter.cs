using System.IO;
using System.Xml;
using System.Xml.Serialization;
using MetadataBuilder.Schema.Metadata;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Saml.MetadataBuilder.IMetadataWriter" />
    public class MedataWriter : IMetadataWriter
    {
        /// <summary>
        /// The metadata mapper
        /// </summary>
        private readonly IMetadataMapper<EntityDescriptor, EntityDescriptorType> _metadataMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MedataWriter" /> class.
        /// </summary>
        /// <param name="metadataMapper">The metadata mapper.</param>
        public MedataWriter(IMetadataMapper<EntityDescriptor, EntityDescriptorType> metadataMapper)
        {
            _metadataMapper = metadataMapper;
        }

        /// <summary>
        /// Serializes to XML.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        internal XmlDocument SerializeToXml<T>(T item) where T : class
        {
            var xmlTemplate = string.Empty;
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var memStm = new MemoryStream())
            {
                xmlSerializer.Serialize(memStm, item);
                memStm.Position = 0;
                xmlTemplate = new StreamReader(memStm).ReadToEnd();
            }
            //create xml document from string
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlTemplate);

            xmlDoc.PreserveWhitespace = true;
            return xmlDoc;
        }

        /// <summary>
        /// Outputs the specified entity.
        /// </summary>
        /// <param name="entityDescriptor">The entity descriptor.</param>
        /// <returns></returns>
        public XmlDocument Output(EntityDescriptor entityDescriptor)
        {
            var entityDescriptorType = _metadataMapper.MapEntity(entityDescriptor);

            var xml = SerializeToXml<EntityDescriptorType>(entityDescriptorType);

            if (entityDescriptor.Signature != null)
            {
                xml.AddSignature(entityDescriptor.Signature);
            }
            return xml;
        }
    }
}
