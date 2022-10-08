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
                xml.AddXmlSignature(entityDescriptor.Signature);
            }
            return xml;
        }
    }
}
