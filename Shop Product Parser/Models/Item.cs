using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Shop_Product_Parser.Models
{
    public class Item
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Price")]
        public double Price { get; set; }
        [XmlAttribute("Currency")]
        public string Currency { get; set; }
        [XmlAttribute("Stock")]
        public int Stock { get; set; }
    }

    [XmlRoot("Products")]
    public class ItemContainer
    {
        [XmlElement("Product", Type = typeof(Item))]
        public Item[] Items { get; set; }
    }
}
