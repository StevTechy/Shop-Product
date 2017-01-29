using Shop_Product_Parser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Product_Parser
{
    class CsvReader
    {
        public IEnumerable<Item> ReadFromFile<T>(string filePath, bool headerRow = false)
        {
            //"X", "Y", "Z"
            //"X1,"Y1",Z1"
            var lines = File.ReadAllLines(filePath)
                .SelectMany(a => a.Split(new char[] { ';', '\n' }, StringSplitOptions.RemoveEmptyEntries));

            lines = lines.Select(x => x.Replace(@"""", "").Trim());

            return lines.Select(x => new Item() { Name = x.Split(',')[0].Trim(),
                Price = Convert.ToDouble(x.Split(',')[1]),
                Currency = x.Split(',')[2].Trim(),
                Stock = Convert.ToInt32(x.Split(',')[3])
            });
        }
    }
}
