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
            Console.WriteLine("Enter file name from CSV folder, file: Books - Batch #1.txt used by default");

            var userEnteredValue = string.IsNullOrEmpty(Console.ReadLine()) ? "Books - Batch #1.txt" : Console.ReadLine();

            var items = new CsvReader().ReadFromFile<Item>(AppDomain.CurrentDomain.BaseDirectory + $@"CSV Files\{userEnteredValue}").ToList();

        }

        protected override void OnStop()
        {
            Trace.WriteLine("Parser Service has stopped");
        }
    }
}
