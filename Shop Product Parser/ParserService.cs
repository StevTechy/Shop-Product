using Shop_Product_Parser.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

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

            //ParseCSV();
            ParseXML();
            ParseJSON();
        }

        private void ParseCSV()
        {
            Console.WriteLine("Enter file name from CSV folder, file: Books - Batch #1.txt used by default");

            var userEnteredValue = string.IsNullOrEmpty(Console.ReadLine()) ? "Books - Batch #1.txt" : Console.ReadLine();

            var items = new CsvReader().ReadFromFile(
                AppDomain.CurrentDomain.BaseDirectory + $@"CSV Files\{userEnteredValue}", true).ToList();
        }

        private void ParseXML()
        {
            Console.WriteLine("Enter file name from XML folder, file: Books - 1.xml used by default");

            var userEnteredValue = string.IsNullOrEmpty(Console.ReadLine()) ? "Books - 1.xml" : Console.ReadLine();

            var items = new XmlReader().ReadFromFile<ItemContainer>(
                AppDomain.CurrentDomain.BaseDirectory + $@"XML Files\{userEnteredValue}", true);
        }

        private void ParseJSON()
        {

        }

        protected override void OnStop()
        {
            Trace.WriteLine("Parser Service has stopped");
        }
    }
}
