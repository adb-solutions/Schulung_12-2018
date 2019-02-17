using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvViewer.Business;

namespace CsvViewer.KonsoleUi
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = File.Exists("Test.csv");
            var xx = new FileInfo("Test.csv");

            //string pfad = Path.GetFullPath("Test.csv");
            //Console.WriteLine(pfad);

            Console.WriteLine("hi");
            Console.ReadKey();
        }
    }
}
