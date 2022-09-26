using MetadataBuilder.Schema.Metadata;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Saml.MetadataBuilder.IMedatataWriter" />
    public class MedatataWriter : IMedatataWriter
    {
        /// <summary>
        /// The metadata mapper
        /// </summary>
        private readonly IMetadataMapper<EntityDescriptor, EntityDescriptorType> _metadataMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MedatataWriter" /> class.
        /// </summary>
        /// <param name="metadataMapper">The metadata mapper.</param>
        public MedatataWriter(IMetadataMapper<EntityDescriptor, EntityDescriptorType> metadataMapper)
        {
            _metadataMapper = metadataMapper;
        }

        //public async Task<XmlDocument> For<T>(T entity) where T : class
        //{

        //}

        //public async Task<XmlDocument> For(SimpleSpMetadata sp) 
        //{
        //    SpMetadata spMetadata = sp;
        //    return await For(spMetadata);
        //}

        //public async Task<XmlDocument> For(SpMetadata sp)
        //{
        //    var spssoDescriptorType = _spMetadataMapper.Map(sp);
        //    var entityDescriptorType = new EntityDescriptorType()
        //    {
        //        entityID = sp.EntityID,
        //        Items = new object[]
        //        {
        //            spssoDescriptorType
        //        }
        //    };

        //    var xmlDoc = SerializeToXml<EntityDescriptorType>(entityDescriptorType);
        //    return xmlDoc;
        //}

        //public Task<XmlDocument> For(T entity)
        //{
        //    throw new System.NotImplementedException();
        //}

        /// <summary>
        /// Serializes to XML.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        internal XmlDocument SerializeToXml<T>(T item) where T : class
        {
            string xmlTemplate = string.Empty;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (MemoryStream memStm = new MemoryStream())
            {
                xmlSerializer.Serialize(memStm, item);
                memStm.Position = 0;
                xmlTemplate = new StreamReader(memStm).ReadToEnd();
            }
            //create xml document from string
            XmlDocument xmlDoc = new XmlDocument();
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

            return SerializeToXml<EntityDescriptorType>(entityDescriptorType);
        }
    }
}
