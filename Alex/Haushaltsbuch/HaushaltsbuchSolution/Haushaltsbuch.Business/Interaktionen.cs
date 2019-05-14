using System;
using System.Collections.Generic;
using Haushaltsbuch.Persistence;
using Haushaltsbuch.Shared;
using Money;

namespace Haushaltsbuch.Business
{
    public class Interaktionen
    {
        private TransaktionenRepository _repository;

        public Interaktionen(TransaktionenRepository repository)
        {
            _repository = repository;
        }

        public void Start(string[] args, Action<Tuple<Money<decimal>, Kategorie>> onEinAuszahlung, Action<KategorieUebersicht> onUebersicht)
        {
            ArgumentVerarbeiter.Ist_Uebersicht_Kommando(
                args, 
                onIstUebersicht: (argumenteUebersicht) => {
                    DateTime datum = ArgumentVerarbeiter.Erstelle_Datum_aus_Eingabeparameter(args);

                    onUebersicht(Uebersicht(datum));
                },
                onIstEinAuszahlung: (argumenteEinAuszahlung) => {
                    Transaktion transaktion = ArgumentVerarbeiter.Erstelle_Transaktion_aus_Eingabeparameter(args);

                    onEinAuszahlung(Ein_Auszahlung(transaktion));
                }
            );
        }

        public Tuple<Money<decimal>, Kategorie> Ein_Auszahlung(Transaktion transaktion)
        {
            _repository.Add_und_Speichern(transaktion);

            List<Transaktion> alleTranskationen = _repository.Lade();
            Money<decimal> kassenbestand = Summierer.Ermittle_Kassenbestand(alleTranskationen);
            Kategorie kategorie = Summierer.Ermittle_Kategoriesumme(transaktion.Kategorie, alleTranskationen);

            return new Tuple<Money<decimal>, Kategorie>(kassenbestand, kategorie);
        }

        public KategorieUebersicht Uebersicht(DateTime datum)
        {
            List<Transaktion> alleTranskationen = _repository.Lade();
            Money<decimal> kassenbestand = Summierer.Ermittle_Kassenbestand(alleTranskationen);
            List<Kategorie> kategorien = Summierer.Ermittle_Kategorien(alleTranskationen);

            return new KategorieUebersicht()
            {
                Datum = datum,
                Kassenbestand = kassenbestand,
                Kategorien = kategorien
            };
        }
    }
}
