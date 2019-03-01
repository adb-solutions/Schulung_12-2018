using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSV_Viewer.App;

namespace CSV_Viewer
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[] { @"C:\Users\jakl\Documents\Home\Arbeit\Schulung\FlowDesign\Aufgaben\Schulung_12-2018\Jason\CSV-Viewer\CSV-Viewer\demo\personen.csv", "5" };

            Prozess prozess = new Prozess();
            prozess.Start(args);
        }

        public static void NotImplementedException(string methode)
        {
            Console.WriteLine($"Die Methode \"{methode}\" ist noch nicht implementiert");
        }
    }
}
