using Haushaltsbuch.Persistence;
using Haushaltsbuch.Shared;
using Haushaltsbuch.Shared.BusinessModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

            
            TransaktionenRepository transaktionenRepository = new TransaktionenRepository();
            KassenbestandRepository kassenbestandRepository = new KassenbestandRepository();
            HaushaltsbuchRechner rechner = new HaushaltsbuchRechner();

            decimal kassenbestand = kassenbestandRepository.Lade();

            Transaktionstyp_pruefen(transaktion.Typ,
                onEinzahlung: () =>
                {
                    kassenbestand = rechner.Kassenbestand_verringern(kassenbestand, transaktion.Wert);

                },
                onAuszahlung: () =>
                {
                    kassenbestand = rechner.Kassenbestand_erhoehen(kassenbestand, transaktion.Wert);
                }
            );

            transaktionenRepository.Speichern(transaktion);
            kassenbestandRepository.Speichern(kassenbestand);
            locker.Lock_beenden();

            var transaktionen = transaktionenRepository.Transaktionen_laden_by_Datum_and_Kategorie(transaktion.Datum, transaktion.Kategorie);
            var gesamtbetrag = rechner.Kategorie_Gesamtbetrag_berechnen(transaktionen);

            Kategorie kategorie = new Kategorie(transaktion.Kategorie, gesamtbetrag);
            HaushaltsbuchEinzeln dtoModel = new HaushaltsbuchEinzeln(kassenbestand, kategorie, transaktion.Typ);

            return dtoModel;
        }

        public HaushaltsbuchGesamt Index_anzeigen(Index index)
        {
            HaushaltsbuchRechner rechner = new HaushaltsbuchRechner();
            var datum = rechner.DatumErmitteln(index);

            TransaktionenRepository repository = new TransaktionenRepository();
            var transaktionen = repository.Transaktionen_laden_by_Datum(datum);

            decimal kassenbestand = rechner.Kassenbestand_berechnen(transaktionen);
            var kategorien = rechner.Kategorien_Gesamtbetraege_berechnen(transaktionen);

            HaushaltsbuchGesamt dtoModel = new HaushaltsbuchGesamt(datum, kassenbestand, kategorien);

            return dtoModel;
        }

        private void Transaktionstyp_pruefen(Zahlung typ, 
            Action onEinzahlung, 
            Action onAuszahlung)
        {
            if (typ == Shared.BusinessModels.Zahlung.Einzahlung)
            {
                onEinzahlung();
            }
            else if (typ == Shared.BusinessModels.Zahlung.Auszahlung)
            {
                onAuszahlung();
            }
            else
            {
                throw new Exception("Transaktionstyp_pruefen fehlgeschlagen.");
            }
        }
    }
}
