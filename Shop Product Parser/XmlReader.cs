using Shop_Product_Parser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Shop_Product_Parser
{
    class XmlReader
    {
        public T ReadFromFile<T>(string filePath, bool formatted = true) where T : class
        {
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var streamReader = new StreamReader(fileStream, Encoding.UTF8);
            string xml = streamReader.ReadToEnd();

            xml = xml.Replace("\uFFFD", "");

            if (formatted) xml.Replace(@"\", "");

            var xmlSerializer = new XmlSerializer(typeof(T));

            using(var stringReader = new StringReader(xml))
            {
                using (var xmlReader = new XmlTextReader(stringReader))
                {
                    return xmlSerializer.Deserialize(xmlReader) as T;
                }
            }
        }
    }
}
