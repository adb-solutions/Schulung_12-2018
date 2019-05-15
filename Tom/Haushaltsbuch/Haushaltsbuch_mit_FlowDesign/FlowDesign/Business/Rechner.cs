using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowDesign.Shared;

namespace FlowDesign.Business
{
    class Rechner
    {
        internal static Kategorie Ermittle_Kategorie(DateTime zahlungsdatum, string kategorieName, List<Transaktion> alleTransaktionen)
        {
            IEnumerable<Transaktion> zaehler = alleTransaktionen.Where(transaktion =>
                                                            transaktion.Typ == TransaktionTyp.Auszahlung &&
                                                            transaktion.Datum.Month == datum.Month &&
                                                            transaktion.Datum.Year == datum.Year &&

                                                            transaktion.Kategorie.Equals(kategorieName, StringComparison.OrdinalIgnoreCase));
            decimal summe = 0m;
            foreach (var item in zaehler)
            {
                summe += item.Betrag;
            }
            Kategorie kategorie = new Kategorie(summe, kategorieName);
            return kategorie;
        }

        internal static decimal Kassenbestand_ermitteln(List<Transaktion> alleTransaktionen)
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

        internal static List<Kategorie> Ermittle_alle_Kategorien(DateTime datum, List<Transaktion> alleTransaktionen)
        {
            var zaehlerTransaktionen = alleTransaktionen.Where(transaktion =>
                                                            transaktion.Typ == TransaktionTyp.Auszahlung &&
                                                            transaktion.Zahlungsdatum.Month == datum.Month &&
                                                            transaktion.Zahlungsdatum.Year == datum.Year)
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

        internal static decimal Ermittle_Kassenbestand_der_Kategorie(List<Transaktion> alleTransaktionenderKategorie)
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
