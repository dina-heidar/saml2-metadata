using System.Xml.Schema;

namespace Xsd.IncludeImport
{
    /// <summary>
    /// Tool to flatten Xsd files
    /// </summary>
    /// <remarks>
    /// based on the work of @Daemonic at http://arstechnica.com/civis/viewtopic.php?f=20&t=180943
    /// </remarks>
    public class XsdFlatteningApp
    {
        //https://learn.microsoft.com/en-us/dotnet/standard/data/xml/including-or-importing-xml-schemas
        //https://gist.github.com/saamorim/04ba5658a5f6e86ae0f4
        static int Main(string[] args)
        {
            //if (args.Length != 2)
            //{
            //    Console.WriteLine("Usage XsdFlattening [input] [output]");
            //    return -1;
            //}

            //string input = args[0];
            //string output = args[1];
            string input = "C:\\Users\\dinah\\source\\repos\\saml-metadata\\src\\MetadataBuilder\\Xsd\\saml-schema-metadata-2.0.xsd";
            string output = "C:\\Users\\dinah\\source\\repos\\saml-metadata\\src\\MetadataBuilder\\Xsd\\metadata4.xsd";
            var x = CreateExpandedSchema(input);
            using (StreamWriter sw = new StreamWriter(output))
            {
                x.Write(sw);
            }
            return 0;
        }


        public static XmlSchema CreateExpandedSchema(string strSchemaPath)
        {
            // Get the current directory and set it as current directory
            FileInfo file = new FileInfo(strSchemaPath);
            Directory.SetCurrentDirectory(file.Directory.FullName);

            // Read the base schema
            XmlSchema xsBase = null;
            using (StreamReader srSchema = new StreamReader(strSchemaPath))
            {
                try
                {
                    xsBase = XmlSchema.Read(srSchema, null);
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            // Create a list to store schemas imported (in case of duplicate dependencies)
            List<string> strSchemasAdded = new List<string>();

            if (AddSchemasToSchema(ref xsBase, xsBase.Includes, strSchemasAdded) == false)
                return null;

            // Remove the includes, otherwise bad things happen
            xsBase.Includes.Clear();

            // Return the fully flattened schema
            return xsBase;
        }

        static void RecurseExternals(XmlSchema schema)
        {
            foreach (XmlSchemaExternal external in schema.Includes)
            {
                if (external.SchemaLocation != null)
                {
                    Console.WriteLine("External SchemaLocation: {0}", external.SchemaLocation);
                }

                if (external is XmlSchemaImport)
                {
                    XmlSchemaImport import = external as XmlSchemaImport;
                    Console.WriteLine("Imported namespace: {0}", import.Namespace);
                }

                if (external.Schema != null)
                {
                    external.Schema.Write(Console.Out);
                    RecurseExternals(external.Schema);
                }
            }
        }

        static void ValidationCallback(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.Write("WARNING: ");
            else if (args.Severity == XmlSeverityType.Error)
                Console.Write("ERROR: ");

            Console.WriteLine(args.Message);
        }

        public static bool AddSchemasToSchema(ref XmlSchema xsBase, XmlSchemaObjectCollection xsAdd, List<string> strAddedSchemas)
        {
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);
            schemaSet.Add(xsBase);

            foreach (XmlSchemaObject xmlObj in xsAdd)
            {
                XmlSchemaImport xsInclude = xmlObj as XmlSchemaImport;
                schemaSet.Add(xsInclude.Namespace, xsInclude.SchemaLocation);
            }

            schemaSet.Compile();

            schemaSet.Reprocess(xsBase);
            schemaSet.Compile();
            xsBase.Write(Console.Out);

            RecurseExternals(xsBase);



            //// Expand the includes
            //foreach (XmlSchemaObject xmlObj in xsAdd)
            //{
            //    XmlSchemaExternal xsInclude = xmlObj as XmlSchemaExternal;
            //    if (strAddedSchemas.Contains(xsInclude.SchemaLocation) == false)
            //    {
            //        // Add to list so we don't add it again
            //        strAddedSchemas.Add(xsInclude.SchemaLocation);

            //        // Read the stream
            //        StreamReader sIncludeReader = new StreamReader(xsInclude.SchemaLocation);
            //        XmlSchema xsSchemaToAdd = null;
            //        try
            //        {
            //            xsSchemaToAdd = XmlSchema.Read(sIncludeReader, null);
            //        }
            //        catch (Exception e)
            //        {
            //            return false;
            //        }
            //        sIncludeReader.Close();

            //        // merge all elements from the included schema into the main document
            //        foreach (XmlSchemaObject xsObj in xsSchemaToAdd.Items)
            //        {
            //            // Add anything that is NOT an include
            //            if (!(xsObj is XmlSchemaInclude))
            //                xsBase.Items.Add(xsObj);

            //            // Process all includes
            //            if (AddSchemasToSchema(ref xsBase, xsSchemaToAdd.Includes, strAddedSchemas) == false)
            //                return false;
            //        }
            //    }
            //}

            return true;
        }
    }
}