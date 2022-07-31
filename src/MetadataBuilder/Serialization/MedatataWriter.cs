using MetadataBuilder.Schema.Metadata;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class MedatataWriter : IMedatataWriter
    {
        private readonly IMetadataMapper<EntityDescriptor, EntityDescriptorType> _metadataMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MedatataWriter" /> class.
        /// </summary>
        /// <param name="spMetadataMapper">The sp metadata mapper.</param>
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

        private XmlDocument SerializeToXml<T>(T item) where T : class
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

        public async Task<XmlDocument> Output(EntityDescriptor entityDescriptor)
        {
            UiInfo ui = new UiInfo
            {
                Description = new LocalizedName { Language = "en-US", Value = "A test OTS site" },
                DisplayName = new LocalizedName { Language = "en-US", Value = "OTS" },
                Keywords = new Keyword { Language = "en-US", Values = new[] { "ots", "saml", "hello" } }
            };
            //};

            var uIInfoType =
                new UIInfoType
                {
                    Items = new object[] {
                        new localizedNameType { lang = ui.DisplayName.Language, Value = ui.DisplayName.Value },
                        new localizedNameType { lang = "fr", Value ="OTTSe" },
                        new localizedNameType { lang = "fr", Value ="OTS us in LA" }
                    },
                    ItemsElementName = new ItemsChoiceType8[] {
                        ItemsChoiceType8.@DisplayName,
                        ItemsChoiceType8.@DisplayName,
                        ItemsChoiceType8.@Description
                    }
                }; 

            string xmlTemplate2 = string.Empty;
            XmlSerializer ser = new XmlSerializer(typeof(UIInfoType));
            XmlElement myElement =
            new XmlDocument().CreateElement("UIInfo");
            //myElement.InnerText = "Hello World";
            using (MemoryStream memStm = new MemoryStream())
            {
                ser.Serialize(memStm, uIInfoType);
                memStm.Position = 0;
                xmlTemplate2 = new StreamReader(memStm).ReadToEnd();
            }
            XmlDocument xmlDoc1 = new XmlDocument();
            xmlDoc1.LoadXml(xmlTemplate2);
            XmlElement element = xmlDoc1.DocumentElement;//.SelectSingleNode("//UIInfo");//xmlDoc1.DocumentElement.SelectNodes("//*");

            XmlElement[] elementarray = new XmlElement[] { element };//nodes.Cast<XmlElement>();


            var entityDescriptorType = _metadataMapper.MapEntity(entityDescriptor);

            entityDescriptorType.Extensions = new ExtensionsType
            {
                Any = elementarray 
            };

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
