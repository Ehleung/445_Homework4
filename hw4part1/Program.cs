using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace hw4part1
{
    class Program
    {
        static void Main(string[] args)
        {
            verifySchema();
            easyValidate();
        }

        public static void easyValidate()
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, "Hotels.xsd");
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.IgnoreWhitespace = true;

                XmlReader hotel = XmlReader.Create("Hotels.xml", settings);
                XmlDocument document = new XmlDocument();
                document.Load(hotel);

                ValidationEventHandler eventHandler = new ValidationEventHandler(validate);

                document.Validate(eventHandler);
                Console.ReadKey();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public static void verifySchema()
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(null, "Hotels.xsd");
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += new ValidationEventHandler(validate);
            settings.IgnoreWhitespace = true;

            XmlReader hotel = XmlReader.Create("Hotels.xml", settings);

            while (hotel.Read())
            {
                System.Console.WriteLine("{0}, {1}: {2} ", hotel.NodeType, hotel.Name, hotel.Value);
            }

            Console.ReadKey();
        }

        private static void validate(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
                Console.WriteLine(" Warning" + e.Message);
            else // Error
                Console.WriteLine(" Error message" + e.Message);
        }
    }
}
