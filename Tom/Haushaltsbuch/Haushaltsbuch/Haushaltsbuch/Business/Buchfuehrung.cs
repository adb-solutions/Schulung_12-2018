using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Haushaltsbuch.Operationen;

namespace Haushaltsbuch.Business
{
    class Buchfuehrung
    {
        private readonly Eintraege _Uebersicht;
        private static bool _isFirstRun = true;

        static public int entscheideOperation(string text)
        {
            string ersterString = Regex.Split(text.TrimStart(), @"[\s]")[0];
            int operation = 0;
            switch (ersterString)
            {
                case "Einzahlung": operation = 1 ;
                    break;
                case "Auszahlung":
                    operation = 2;
                    break;
                case "Uebersicht":
                    operation = 3;
                    break;
                case "Abbruch":
                    operation = 9;
                    break;
                default:
                    Console.WriteLine("Fehler!");
                    break;
            }

            return operation;
        }

        internal static DateTime setzeDatum(string eingabe)
        {

        }
    }
}