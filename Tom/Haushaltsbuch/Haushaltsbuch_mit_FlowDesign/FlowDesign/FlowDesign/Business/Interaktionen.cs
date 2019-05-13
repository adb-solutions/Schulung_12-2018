using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign.Business
{
    class Interaktionen
    {
        public string klassifiziereZustand(string ersterParameter)
        {
            string operation = null;

            switch (ersterParameter)
            {
                case "Einzahlung":
                    operation = "Einzahlung";
                    break;
                case "Auszahlung":
                    operation = "Auszahlung";
                    break;
                case "Uebersicht":
                    operation = "Uebersicht";
                    break;
                case "Abbruch":
                    operation = "Abbruch";
                    break;
                default:
                    Console.WriteLine("Fehler!");
                    break;
            }
            return operation;
        }
    }
}
