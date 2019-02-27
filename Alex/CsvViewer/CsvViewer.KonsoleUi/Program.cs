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
            var debug = new string[] { $"DemoDaten{Path.DirectorySeparatorChar}personen.csv", "5" };
            App app = new App(debug);  //new App(args);
            app.Start();
        }
    }
}
