using System.Collections.Generic;
using System.Linq;
using CSV_Viewer.App.Daten;

namespace CSV_Viewer.App.Business
{
    public class Interaktionen
    {
        SeitenBereitsteller _seitenBereitsteller = new SeitenBereitsteller();

        public Interaktionen()
        {
            _seitenBereitsteller = new SeitenBereitsteller();
        }

        public List<CsvDatensatz> Start(string[] args)
        {
            string pfad = new ArgumentVerarbeiter().Lese_Eingabeparameter(args);
            List<string> zeilen = new DateiBereitsteller().Lese_Dateiinhalt(pfad);
            List<CsvDatensatz> alleDatensaetze = new CsvWandler().Zerlege_Csv_in_CsvDatensaetze(zeilen).ToList();
            Status.Instanz.CsvDatensaetze.Setze(alleDatensaetze);
            List<CsvDatensatz> datensaetzeErsteSeite = ErsteSeite();

            return datensaetzeErsteSeite;
        }

        public List<CsvDatensatz> ErsteSeite()
        {
            List<CsvDatensatz> alleDatensaetze = Status.Instanz.CsvDatensaetze.Lade();
            int seitenlaenge = Status.Instanz.Seitenlaenge.Lade();
            int seitenNummer = _seitenBereitsteller.Ermittle_Seitennummer_Erste_Seite();
            Status.Instanz.AktuelleSeitenummer.Setze(seitenNummer);

            List<CsvDatensatz> datensaetzeErsteSeite = _seitenBereitsteller.Filtere_Seite(alleDatensaetze, seitenlaenge, seitenNummer);

            return datensaetzeErsteSeite;
        }

        public List<CsvDatensatz> NaechsteSeite()
        {
            List<CsvDatensatz> alleDatensaetze = Status.Instanz.CsvDatensaetze.Lade();
            int seitenlaenge = Status.Instanz.Seitenlaenge.Lade();
            int aktuelleSeitennummer = Status.Instanz.AktuelleSeitenummer.Lade();
            int seitenNummer = _seitenBereitsteller.Erhoehe_Seitennummer_um_eins(aktuelleSeitennummer);
            Status.Instanz.AktuelleSeitenummer.Setze(seitenNummer);

            List<CsvDatensatz> datensaetzeErsteSeite = _seitenBereitsteller.Filtere_Seite(alleDatensaetze, seitenlaenge, seitenNummer);

            return datensaetzeErsteSeite;
        }

        public List<CsvDatensatz> VorherigeSeite()
        {
            List<CsvDatensatz> alleDatensaetze = Status.Instanz.CsvDatensaetze.Lade();
            int seitenlaenge = Status.Instanz.Seitenlaenge.Lade();
            int aktuelleSeitennummer = Status.Instanz.AktuelleSeitenummer.Lade();
            int seitenNummer = _seitenBereitsteller.Verringere_Seitennummer_um_eins(aktuelleSeitennummer);
            Status.Instanz.AktuelleSeitenummer.Setze(seitenNummer);

            List<CsvDatensatz> datensaetzeErsteSeite = _seitenBereitsteller.Filtere_Seite(alleDatensaetze, seitenlaenge, seitenNummer);

            return datensaetzeErsteSeite;
        }
        public List<CsvDatensatz> LetzeSeite()
        {
            List<CsvDatensatz> alleDatensaetze = Status.Instanz.CsvDatensaetze.Lade();
            int seitenlaenge = Status.Instanz.Seitenlaenge.Lade();
            int seitenNummer = _seitenBereitsteller.Ermittle_Seitennummer_Letzte_Seite(alleDatensaetze, seitenlaenge);
            Status.Instanz.AktuelleSeitenummer.Setze(seitenNummer);

            List<CsvDatensatz> datensaetzeErsteSeite = _seitenBereitsteller.Filtere_Seite(alleDatensaetze, seitenlaenge, seitenNummer);

            return datensaetzeErsteSeite;
        }
    }
}
