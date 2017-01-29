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
        public IEnumerable<Item> ReadFromFile(string filePath, bool headerRow = false)
        {
            //Get the list of lines from CSV
            var lines = File.ReadAllLines(filePath)
                .SelectMany(a => a.Split(new char[] { ';', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                .Select(x => x.Replace(@"""", "").Trim());

            //Remove header row if required
            if (headerRow) lines = lines.Skip(1);

            //Format the lines into enumerable Items
            return lines.Select(x => new Item() {
                Name = x.Split(',')[0].Trim(),
                Price = Convert.ToDouble(x.Split(',')[1]),
                Currency = x.Split(',')[2].Trim(),
                Stock = Convert.ToInt32(x.Split(',')[3])
            });
        }
    }
}
