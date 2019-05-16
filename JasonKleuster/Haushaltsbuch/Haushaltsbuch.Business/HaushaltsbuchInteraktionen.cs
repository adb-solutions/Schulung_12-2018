using Haushaltsbuch.Persistence;
using Haushaltsbuch.Shared;
using Haushaltsbuch.Shared.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.Business
{
    public class HaushaltsbuchInteraktionen
    {
        // TODO Lieser fragen ist das konsistent
        public IHaushaltsbuch Start(string[] args)
        {
            var verarbeiter = new ArgumentVerarbeiter();

            IHaushaltsbuch dtoModel = null;

            verarbeiter.ParameterAktionBestimmen(args, 
                onZahlung: argumente =>
                {
                    var transaktion = verarbeiter.ZahlungsdatenAuslesen(argumente);
                    dtoModel = Ein_Auszahlung(transaktion);
                },
                onIndex: argumente => 
                {
                    var index = verarbeiter.IndexdatenAuslesen(argumente);
                    dtoModel = Index_anzeigen(index);
                });

            return dtoModel;
        }

        private HaushaltsbuchEinzeln Ein_Auszahlung(Transaktion transaktion)
        {
            Locker locker = new Locker();

            TransaktionenRepository repository = new TransaktionenRepository();
            repository.Speichern(transaktion);

            locker.LockBeenden();


            var transaktionen = repository.TransaktionenLadenByDatumAndKategorie(transaktion.Datum, transaktion.Kategorie);

            HaushaltsbuchRechner rechner = new HaushaltsbuchRechner();
            var gesamtbetrag = rechner.KategorieGesamtbetragBerechnen(transaktionen);

            Kategorie kategorie = new Kategorie(transaktion.Kategorie, gesamtbetrag);


            var kassenbestand = rechner.KassenbestandBerechnen(transaktionen);

            HaushaltsbuchEinzeln dtoModel = new HaushaltsbuchEinzeln(kassenbestand, kategorie);

            return null;
        }

        private HaushaltsbuchGesamt Index_anzeigen(Index index)
        {
            HaushaltsbuchRechner rechner = new HaushaltsbuchRechner();
            var datum = rechner.DatumErmitteln(index);

            TransaktionenRepository repository = new TransaktionenRepository();
            var transaktionen = repository.TransaktionenLadenByDatum(datum);

            decimal kassenbestand = rechner.KassenbestandBerechnen(transaktionen);
            var kategorien = rechner.KategorienGesamtbetraegeBerechnen(transaktionen);

            HaushaltsbuchGesamt dtoModel = new HaushaltsbuchGesamt(datum, kassenbestand, kategorien);

            return dtoModel;
        }
    }
}
