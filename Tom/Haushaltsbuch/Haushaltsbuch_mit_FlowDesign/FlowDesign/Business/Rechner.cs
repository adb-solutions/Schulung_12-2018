﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowDesign.Shared;

namespace FlowDesign.Business
{
    class Rechner
    {
        public static Kategorie Ermittle_Kategorie(DateTime zahlungsdatum, string kategorieName, List<Transaktion> alleTransaktionen)
        {
            IEnumerable<Transaktion> zaehler = alleTransaktionen.Where(transaktion =>
                                                            transaktion.Typ == TransaktionTyp.Auszahlung &&
                                                            transaktion.ZahlungsDatum.Month == zahlungsdatum.Month &&
                                                            transaktion.ZahlungsDatum.Year == zahlungsdatum.Year &&

                                                            transaktion.Kategorie.Equals(kategorieName, StringComparison.OrdinalIgnoreCase));
            decimal summe = 0m;
            foreach (var item in zaehler)
            {
                summe += item.Betrag;
            }
            Kategorie kategorie = new Kategorie(summe, kategorieName);
            return kategorie;
        }

        public static decimal Kassenbestand_ermitteln(List<Transaktion> alleTransaktionen)
        {
            decimal kassenbestand = 0m;
            foreach (Transaktion transaktion in alleTransaktionen)
            {
                if (transaktion.Typ == TransaktionTyp.Einzahlung)
                {
                    kassenbestand += transaktion.Betrag;
                }

                if (transaktion.Typ == TransaktionTyp.Auszahlung)
                {
                    kassenbestand -= transaktion.Betrag;
                }
            }

            return kassenbestand;
        }

        public static List<Kategorie> Ermittle_alle_Kategorien(DateTime datum, List<Transaktion> alleTransaktionen)
        {
            var zaehlerTransaktionen = alleTransaktionen.Where(transaktion =>
                                                            transaktion.Typ == TransaktionTyp.Auszahlung &&
                                                            transaktion.ZahlungsDatum.Month == datum.Month &&
                                                            transaktion.ZahlungsDatum.Year == datum.Year)
                                    .GroupBy(transaktion => transaktion.Kategorie);

            List<Kategorie> result = new List<Kategorie>();
            foreach (var item in zaehlerTransaktionen)
            {
                decimal summe = 0m;
                foreach (Transaktion transaktion in item)
                {
                    summe += transaktion.Betrag;
                }

                result.Add(new Kategorie(summe, item.Key));
            }

            return result;
        }

        public static decimal Ermittle_Kassenbestand_der_Kategorie(List<Transaktion> alleTransaktionenderKategorie)
        {
            decimal kassenbestand = 0m;
            foreach (Transaktion transaktion in alleTransaktionenderKategorie)
            {
                if (transaktion.Typ == TransaktionTyp.Einzahlung)
                {
                    kassenbestand += transaktion.Betrag;
                }

                if (transaktion.Typ == TransaktionTyp.Auszahlung)
                {
                    kassenbestand -= transaktion.Betrag;
                }
            }
            return kassenbestand;
        }
    }
}