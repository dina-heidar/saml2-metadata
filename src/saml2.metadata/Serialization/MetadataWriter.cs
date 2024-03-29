﻿// Copyright (c) 2022 Dina Heidar
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
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Saml2Metadata.Schema;

namespace Saml2Metadata
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Saml2Metadata.IMetadataWriter" />
    public class MetadataWriter : IMetadataWriter
    {
        /// <summary>
        /// The metadata mapper
        /// </summary>
        private readonly IMetadataMapper<EntityDescriptor, EntityDescriptorType> _metadataMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataWriter"/> class.
        /// </summary>
        /// <param name="metadataMapper">The metadata mapper.</param>
        public MetadataWriter(IMetadataMapper<EntityDescriptor, EntityDescriptorType> metadataMapper)
        {
            _metadataMapper = metadataMapper;
        }

        /// <summary>
        /// Serializes to XML.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        private XmlDocument SerializeToXml<T>(T item) where T : class
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

            bool hasEmptyElement = true;

            while (hasEmptyElement == true)
            {
                var emptyElementList = xmlDoc.SelectNodes(@"//*[not(node()) and count(@*) = 0]");
                if (emptyElementList.Count == 0)
                {
                    hasEmptyElement = false;
                }

                int listSize = emptyElementList.Count;
                for (int i = listSize - 1; i >= 0; i--)
                {
                    emptyElementList[i].ParentNode.RemoveChild(emptyElementList[i]);
                }
            }
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

        /// <summary>
        /// Validates the specified XML document.
        /// </summary>
        /// <param name="xmlDoc">The XML document.</param>
        /// <returns></returns>
        public bool Validate(XmlDocument xmlDoc)
        {

            const XmlSchemaValidationFlags validationFlags =
          XmlSchemaValidationFlags.ProcessInlineSchema |
          XmlSchemaValidationFlags.ProcessSchemaLocation |
          XmlSchemaValidationFlags.ReportValidationWarnings |
          XmlSchemaValidationFlags.AllowXmlAttributes;

            var path = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).LocalPath;
            var settings = new XmlReaderSettings();


            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);
            //schemaSet.Add("urn:oasis:names:tc:SAML:2.0:metadata", path + "\\Xsd\\metadata4.xsd");
            schemaSet.Add("urn:oasis:names:tc:SAML:2.0:metadata", path + "\\Xsd\\saml-schema-metadata-2.0.xsd");
            schemaSet.Add("http://www.w3.org/XML/1998/namespace", path + "\\Xsd\\xml.xsd");
            schemaSet.Add("http://www.w3.org/2001/04/xmlenc#", path + "\\Xsd\\xenc-schema.xsd");
            schemaSet.Add("urn:oasis:names:tc:SAML:2.0:assertion", path + "\\Xsd\\saml-schema-assertion-2.0.xsd");
            schemaSet.Add("http://www.w3.org/2000/09/xmldsig#", path + "\\Xsd\\xmldsig-core-schema.xsd");
            schemaSet.Add("urn:oasis:names:tc:SAML:metadata:ui", path + "\\Xsd\\sstc-saml-metadata-ui-v1.0.xsd");

            schemaSet.Compile();

            // Set the validation settings.
            settings.Schemas.Add(schemaSet);
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += ValidationCallback;
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationFlags = validationFlags;

            using (TextReader tr = new StringReader(xmlDoc.OuterXml))
            {
                var xmlRreader = XmlReader.Create(tr, settings);

                while (xmlRreader.Read()) { }
                return true;
            }
        }

        private static void ValidationCallback(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
            {
                Console.Write("WARNING: ");
            }
            else if (args.Severity == XmlSeverityType.Error)
            {
                Console.Write("ERROR: ");
            }
            Console.WriteLine(args.Message);
        }
    }
}
