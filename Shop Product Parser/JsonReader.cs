using Newtonsoft.Json;
using System.IO;

namespace Shop_Product_Parser
{
    class JsonReader
    {
        public T ReadFromFile<T>(string filePath)
        {
            using(var streamReader = new StreamReader(filePath))
            {
                var json = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}
