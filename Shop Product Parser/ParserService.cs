using Shop_Product.Data;
using Shop_Product_Parser.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;

namespace Shop_Product_Parser
{
    public partial class ParserService : ServiceBase
    {
        public ParserService()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            Trace.WriteLine("Parser Service has started");

            ParseCSV();
            ParseXML();
            ParseJSON();
        }

        private void ParseCSV()
        {
            Console.WriteLine("Enter file name from CSV folder, file: Books - 1.txt used by default");

            var userEnteredValue = string.IsNullOrEmpty(Console.ReadLine()) ? "Books - 1.txt" : Console.ReadLine();

            var products = new CsvReader().ReadFromFile(
                AppDomain.CurrentDomain.BaseDirectory + $@"CSV Files\{userEnteredValue}", true).ToList();

            SaveProductsToDatabase(products);
        }

        private void ParseXML()
        {
            Console.WriteLine("Enter file name from XML folder, file: Books - 1.xml used by default");

            var userEnteredValue = string.IsNullOrEmpty(Console.ReadLine()) ? "Books - 1.xml" : Console.ReadLine();

            var productContainer = new XmlReader().ReadFromFile<ProductContainer>(
                AppDomain.CurrentDomain.BaseDirectory + $@"XML Files\{userEnteredValue}", true);

            SaveProductsToDatabase(productContainer.Products);
        }

        private void ParseJSON()
        {
            Console.WriteLine("Enter file name from JSON folder, file: Books - 1.json used by default");

            var userEnteredValue = string.IsNullOrEmpty(Console.ReadLine()) ? "Books - 1.json" : Console.ReadLine();

            var productContainer = new JsonReader().ReadFromFile<ProductContainer>(
                AppDomain.CurrentDomain.BaseDirectory + $@"JSON Files\{userEnteredValue}");

            SaveProductsToDatabase(productContainer.Products);
        }

        private void SaveProductsToDatabase(IEnumerable<Models.Product> products)
        {
            var shopConnection = new ShopConnection();

            foreach (var product in products)
                shopConnection.UpdateProduct(product.Name, Convert.ToDecimal(product.Price), product.Currency, product.Stock);
        }

        protected override void OnStop()
        {
            Trace.WriteLine("Parser Service has stopped");
        }
    }
}
