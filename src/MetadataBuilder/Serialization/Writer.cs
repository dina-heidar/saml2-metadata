using AutoMapper;
using MetadataBuilder;
using MetadataBuilder.Schema.Metadata;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class Writer : IWriter
    {     
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Writer"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public Writer(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Outputs the specified entity descriptor.
        /// </summary>
        /// <param name="entityDescriptor">The entity descriptor.</param>
        /// <returns></returns>
        public XmlDocument Output(EntityDescriptor entityDescriptor)
        {
            var entityDescriptorType = _mapper.Map<EntityDescriptor, EntityDescriptorType>(entityDescriptor);
            string xmlTemplate = string.Empty;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(EntityDescriptorType));

            using (MemoryStream memStm = new MemoryStream())
            {
                xmlSerializer.Serialize(memStm, entityDescriptorType);
                memStm.Position = 0;
                xmlTemplate = new StreamReader(memStm).ReadToEnd();
            }

            //create xml document from string
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlTemplate);

            xmlDoc.PreserveWhitespace = true;
            return xmlDoc;
            //xmlDoc.Save(System.IO.Path.Combine(options.DefaultMetadataFolderLocation, options.DefaultMetadataFileName + ".xml"));           
         }
    }
}
