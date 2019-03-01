using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSV_Viewer.App.Daten;

namespace CSV_Viewer.App.View
{
    public class Design
    {
        public void Ueberschrift1(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine("---------");
            Console.WriteLine();
        }

        public void Ueberschrift2(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine("---");
        }

        public void DatenTabelle(List<CsvDatensatz> csvDatensaetze)
        {
            Ueberschrift2("Datensätze");

            foreach (var csvDatensatz in csvDatensaetze)
            {
                foreach (var csvDatensatzWert in csvDatensatz.Werte)
                {
                    Console.Write(csvDatensatzWert + " | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void MenueAktionen()
        {
            Ueberschrift2("Datensätze");
            Console.WriteLine("(F) Erste Seite, (N) Nächste Seite, (P) Vorherige Seite, (L) Letze Seite, (E) Beenden;");
            Console.WriteLine();
        }

        public void Aufraeumen()
        {
            Console.Clear();
        }
    }
}
