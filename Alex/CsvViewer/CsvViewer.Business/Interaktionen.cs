using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvViewer.Persistence;
using CsvViewer.Shared;

namespace CsvViewer.Business
{
    public class Interaktionen
    {
        public Interaktionen()
        {

        }

        public List<CsvDatensatz> Start(string[] args)
        {
            string pfad = new ArgumentVerarbeiter().Lese_Eingabeparameter(args);
            List<string> zeilen = new DateiBereitsteller().Lese_Dateiinhalt(pfad);
            List<CsvDatensatz> datensaetze = new CsvParser().Zerlege_Csv_in_CsvDatensaetze(zeilen).ToList();

            Status.Instanz.CsvDatensaetze.Setze(datensaetze);

            return Erste_Seite();
        }

        public List<CsvDatensatz> Erste_Seite()
        {
            throw new NotImplementedException();
        }

        public List<CsvDatensatz> Letzte_Seite()
        {
            throw new NotImplementedException();
        }

        public List<CsvDatensatz> Naechste_Seite()
        {
            throw new NotImplementedException();
        }

        public List<CsvDatensatz> Vorherige_Seite()
        {
            throw new NotImplementedException();
        }
    }
}
