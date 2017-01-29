using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Product_Parser.Models
{
    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public int Stock { get; set; }
    }
}
