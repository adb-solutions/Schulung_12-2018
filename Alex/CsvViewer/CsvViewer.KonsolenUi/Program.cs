using System;
using System.IO;

namespace CsvViewer.KonsolenUi
{
    class Program
    {
        static void Main(string[] args)
        {
            var debug = new string[] { $"DemoDaten{Path.DirectorySeparatorChar}personen.csv", "15" };
            App app = new App(debug);  //new App(args);
            app.Run();
        }
    }
}
