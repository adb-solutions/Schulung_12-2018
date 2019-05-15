using System;
using System.Collections.Generic;
using Haushaltsbuch.Persistence;
using Haushaltsbuch.Shared;
using NodaMoney;

namespace Haushaltsbuch.Business
{
    public class Interaktionen
    {
        private TransaktionenRepository _repository;

        public Interaktionen(TransaktionenRepository repository)
        {
            _repository = repository;
        }

        public void Start(string[] args, Action<Tuple<Money, Kategorie>> onEinAuszahlung, Action<KategorieUebersicht> onUebersicht)
        {
            ArgumentVerarbeiter.Ist_Uebersicht_Kommando(
                args, 
                onIstUebersicht: (argumenteUebersicht) => {
                    DateTime datum = ArgumentVerarbeiter.Erstelle_Datum_aus_Eingabeparameter(argumenteUebersicht);

                    onUebersicht(Uebersicht(datum));
                },
                onIstEinAuszahlung: (argumenteEinAuszahlung) => {
                    Transaktion transaktion = ArgumentVerarbeiter.Erstelle_Transaktion_aus_Eingabeparameter(argumenteEinAuszahlung);

                    onEinAuszahlung(Ein_Auszahlung(transaktion));
                }
            );
        }

        public Tuple<Money, Kategorie> Ein_Auszahlung(Transaktion transaktion)
        {
            _repository.Add_und_Speichern(transaktion);

            List<Transaktion> alleTranskationen = _repository.Lade();
            Money kassenbestand = Summierer.Ermittle_Kassenbestand(alleTranskationen);
            Kategorie kategorie = Summierer.Ermittle_Kategorie(transaktion.Kategorie, transaktion.Datum, alleTranskationen);

            return new Tuple<Money, Kategorie>(kassenbestand, kategorie);
        }

        public KategorieUebersicht Uebersicht(DateTime datum)
        {
            List<Transaktion> alleTranskationen = _repository.Lade();
            Money kassenbestand = Summierer.Ermittle_Kassenbestand(alleTranskationen);
            List<Kategorie> kategorien = Summierer.Ermittle_alle_Kategorien(datum, alleTranskationen);

            return new KategorieUebersicht()
            {
                Datum = datum,
                Kassenbestand = kassenbestand,
                Kategorien = kategorien
            };
        }
    }
}
