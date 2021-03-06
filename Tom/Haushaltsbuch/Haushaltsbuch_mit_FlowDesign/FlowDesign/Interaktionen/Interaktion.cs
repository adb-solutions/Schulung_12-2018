﻿using FlowDesign.Business;
using FlowDesign.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using FlowDesign.Persistenz;

namespace FlowDesign.Interaktionen
{
    public class Interaktion
    {
        private TransaktionsRespository _respository;
       
        public Interaktion(TransaktionsRespository respository)
        {
            _respository = respository;
        }

        public void Start(string[] args, Action<decimal> ausgangFuerEinzahlung, Action<decimal, Kategorie> ausgangFuerAuszahlung, Action<Uebersicht> onUebersicht)
        {
            ArgumentVerarbeiter.Ist_Kommando_Uebersicht(                // 0
                args: args,
                onIstUebersicht: (argsUebersicht) => {                  // 1        Variablenname : ankommender Rückgabewert
                    Uebersicht uebersicht = Uebersicht(argsUebersicht); // 3 = 2    (Methodenaufruf(Übergabeparameter)
                    onUebersicht(uebersicht);                           //          Methodenaufruf raus (Übergabewert)
                },
                onIstTransaktion: (argsTranksaktion) => {
                    Zahlung(argsTranksaktion, 
                        onAuszahlung: (ausgangFuerAuszahlung), 
                        onEinzahlung: (kassenbestand) => {
                            ausgangFuerEinzahlung(kassenbestand);
                        }
                    );
                }
            );
        }

        public void Zahlung(string[] args, Action<decimal, Kategorie> onAuszahlung, Action<decimal> onEinzahlung)
        {
            Transaktion transaktion = ArgumentVerarbeiter.Erstelle_Transaktion_aus_Eingabe(args);
            _respository.Speichern(transaktion);
            List<Transaktion> alleTransaktionen = _respository.Lade_alle_Transaktionen();
            TypErmittler.Ermittle_Typ(
                transaktion.Typ,
                onIstAuszahlung: () => {                                                                                                        // 1        Variablenname : ankommender Rückgabewert
                    Kategorie kategorie = Rechner.Ermittle_Kategorie(transaktion.ZahlungsDatum, transaktion.Kategorie, alleTransaktionen);      // 3 = 2    (Methodenaufruf(Übergabeparameter)
                    decimal kassebestand = Rechner.Kassenbestand_ermitteln(alleTransaktionen);                                                  //          Methodenaufruf raus (Übergabewert)

                    onAuszahlung(kassebestand, kategorie);
                },
                onIstEinzahlung: () =>{
                    decimal kassenbestand = Rechner.Kassenbestand_ermitteln(alleTransaktionen);
                    onEinzahlung(kassenbestand);
                }
            );

        }

        public Uebersicht Uebersicht(string[] args)
        {
            DateTime Datum = ArgumentVerarbeiter.Erstelle_Datum_aus_Eingabeparameter(args);
            List<Transaktion> alleTransaktionen = _respository.Lade_alle_Transaktionen_vor_und_aus_dem_Zeitraum(Datum);
            List<Kategorie> alleKategorien = Rechner.Ermittle_alle_Kategorien(Datum, alleTransaktionen);
            decimal kategorienKassenbestand = Rechner.Ermittle_Kassenbestand_der_Kategorie(alleTransaktionen);
            Uebersicht uebergabeUebersicht = new Uebersicht(Datum, alleKategorien, kategorienKassenbestand);
            return uebergabeUebersicht;
        }
    }
}