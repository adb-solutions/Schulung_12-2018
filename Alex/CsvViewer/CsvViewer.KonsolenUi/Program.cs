using System;
using System.IO;

namespace CsvViewer.KonsolenUi
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            args = new string[] { $"DemoDaten{Path.DirectorySeparatorChar}personen.csv", "15" };
#endif

            App app = new App(args);
            app.Run();
        }
    }
}
