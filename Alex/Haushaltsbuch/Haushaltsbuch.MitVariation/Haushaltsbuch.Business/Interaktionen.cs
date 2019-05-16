using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using Haushaltsbuch.Persistence;
using Haushaltsbuch.Shared;
using NodaMoney;

namespace Haushaltsbuch.Business
{
    public class Interaktionen
    {
        private TransaktionenRepository _repository;
        private Benutzerabfragen _benutzerabfragen;

        public Interaktionen(TransaktionenRepository repository, Benutzerabfragen benutzerabfragen)
        {
            _repository = repository;
            _benutzerabfragen = benutzerabfragen;
        }

        public void Start(string[] args, Action<Money, Kategorie> onEinAuszahlung, Action<KategorieUebersicht> onUebersicht)
        {
            ArgumentVerarbeiter.Ist_Uebersicht_Kommando(
                args, 
                onIstUebersicht: (argumenteUebersicht) => {
                    DateTime datum = ArgumentVerarbeiter.Erstelle_Datum_aus_Eingabeparameter(argumenteUebersicht);

                    onUebersicht(Uebersicht(datum));
                },
                onIstEinAuszahlung: (argumenteEinAuszahlung) => {
                    Transaktion transaktion = ArgumentVerarbeiter.Erstelle_Transaktion_aus_Eingabeparameter(argumenteEinAuszahlung);

                    Ein_Auszahlung(
                        transaktion, 
                        onErfolg: (kassenbestand, kategorie) => {
                            onEinAuszahlung(kassenbestand, kategorie);
                        }, 
                        onAbbruch: () => {
                            //Tue nichts
                        }
                    );
                }
            );
        }

        public void Ein_Auszahlung(Transaktion transaktion, Action<Money, Kategorie> onErfolg, Action onAbbruch)
        {
            TransaktionTypKonvertierer.Ermittle_Typ(
                transaktion.Typ,
                istEinzahlung: () => {
                    Transaktion_durchfuehren(transaktion, onErfolg);
                },
                istAuszahlung: () => {
                    _repository.Kategorie_existiert(
                        transaktion.Kategorie,
                        onJa: () => {
                            Transaktion_durchfuehren(transaktion, onErfolg);
                        },
                        onNein: () => {
                            bool jaKategorieAnlegen = _benutzerabfragen.Benutzerabfrage_Kategorie_neu_anlegen(transaktion.Kategorie);
                            if (jaKategorieAnlegen)
                            {
                                Transaktion_durchfuehren(transaktion, onErfolg);
                            }
                        }
                    );
                }
            );
        }

        

        private void Transaktion_durchfuehren(Transaktion transaktion, Action<Money, Kategorie> onErfolg)
        {
            _repository.Add_und_Speichern(transaktion);

            List<Transaktion> alleTranskationen = _repository.Lade();
            Money kassenbestand = Summierer.Ermittle_Kassenbestand(transaktion.Datum, alleTranskationen);
            Kategorie kategorie = Summierer.Ermittle_Kategorie(transaktion.Kategorie, transaktion.Datum, alleTranskationen);
            onErfolg(kassenbestand, kategorie);
        }

        public KategorieUebersicht Uebersicht(DateTime datum)
        {
            List<Transaktion> alleTranskationen = _repository.Lade();
            Money kassenbestand = Summierer.Ermittle_Kassenbestand(datum, alleTranskationen);
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
