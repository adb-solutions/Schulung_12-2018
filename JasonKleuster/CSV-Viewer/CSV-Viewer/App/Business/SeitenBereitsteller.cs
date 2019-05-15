using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSV_Viewer.App.Daten;

namespace CSV_Viewer.App.Business
{
    public class SeitenBereitsteller
    {
        public int Ermittle_Seitennummer_Erste_Seite()
        {
            return 1; //Per Definition immer Seite 1
        }

        public int Erhoehe_Seitennummer_um_eins(int aktuelleSeitennummer)
        {
            int erhoeht = aktuelleSeitennummer + 1;

            return erhoeht;
        }

        public int Verringere_Seitennummer_um_eins(int aktuelleSeitennummer)
        {
            int verringert = aktuelleSeitennummer - 1;

            if (verringert <= 0)
            {
                throw new ArgumentException("Die Seitennummer darf kleiner gleich 0 sein.");
            }

            return verringert;
        }

        public int Ermittle_Seitennummer_Letzte_Seite(List<CsvDatensatz> alleCsvDatensaetze, int seitenlaenge)
        {
            int anzahlInhalt = (alleCsvDatensaetze.Count - 1);
            int letzteSeite = (anzahlInhalt / seitenlaenge);
            int rest = (anzahlInhalt % seitenlaenge);
            if (rest > 0)
            {
                letzteSeite++;
            }

            return letzteSeite;
        }

        public List<CsvDatensatz> Filtere_Seite(List<CsvDatensatz> alleCsvDatensaetze, int seitenlaenge, int gewuenschteSeite)
        {
            int anzahlElementeZuUeberspringen = (gewuenschteSeite - 1) * seitenlaenge + 1; //+1 wegen Kopfzeile

            CsvDatensatz kopfzeile = alleCsvDatensaetze.FirstOrDefault();
            List<CsvDatensatz> inhalte = alleCsvDatensaetze.Skip(anzahlElementeZuUeberspringen).Take(seitenlaenge).ToList();

            List<CsvDatensatz> result = new List<CsvDatensatz>();
            result.Add(kopfzeile);
            result.AddRange(inhalte);

            return result;
        }
    }
}
