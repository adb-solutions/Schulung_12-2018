using System;
using System.Collections.Generic;
using CSV_Viewer.App.Business;
using CSV_Viewer.App.Daten;

namespace CSV_Viewer.App.View
{
    class Display
    {
        private Design _show = null;

        public Display()
        {
            _show = new Design();
        }

        public string Show(List<CsvDatensatz> csvDatensaetze)
        {
            Console.Clear();

            _show.Ueberschrift1("CSV-Viewer");

            _show.DatenTabelle(csvDatensaetze);
            _show.MenueAktionen();

            Console.Write("Eingabe: ");
            string result = Console.ReadLine();

            return result;
        }
    }
}
