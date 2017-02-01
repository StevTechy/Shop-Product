using System.Xml.Serialization;

namespace Shop_Product_Parser.Models
{
    public class Product
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
    public class ProductContainer
    {
        [XmlElement("Product", Type = typeof(Product))]
        public Product[] Products { get; set; }
    }
}
