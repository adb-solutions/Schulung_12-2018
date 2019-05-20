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
        public void Start(string[] args, 
            Action<Transaktion> onZahlung, 
            Action<Index> onIndex)
        {
            var verarbeiter = new ArgumentVerarbeiter();

            verarbeiter.ParameterAktionBestimmen(args, 
                onZahlung: argumente =>
                {
                    var transaktion = verarbeiter.ZahlungsdatenAuslesen(argumente);
                    onZahlung(transaktion);
                },
                onIndex: argumente => 
                {
                    var index = verarbeiter.IndexdatenAuslesen(argumente);
                    onIndex(index);
                });
        }

        public HaushaltsbuchEinzeln Zahlung(Transaktion transaktion)
        {
            Locker locker = new Locker();
            bool isLocked = true;

            do
            {
                locker.Check_for_locked(
                    () => {
                        isLocked = false;
                        locker.Lock_starten();
                    },
                    () => {
                        isLocked = true;
                        locker.Warte();
                    }
                );

            } while (isLocked);

            TransaktionenRepository repository = new TransaktionenRepository();
            repository.Speichern(transaktion);

            locker.Lock_beenden();

            var transaktionen = repository.TransaktionenLadenByDatumAndKategorie(transaktion.Datum, transaktion.Kategorie);

            HaushaltsbuchRechner rechner = new HaushaltsbuchRechner();
            var gesamtbetrag = rechner.KategorieGesamtbetragBerechnen(transaktionen);

            Kategorie kategorie = new Kategorie(transaktion.Kategorie, gesamtbetrag);


            var kassenbestand = rechner.KassenbestandBerechnen(transaktionen);

            HaushaltsbuchEinzeln dtoModel = new HaushaltsbuchEinzeln(kassenbestand, kategorie);

            return null;
        }

        public HaushaltsbuchGesamt Index_anzeigen(Index index)
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
