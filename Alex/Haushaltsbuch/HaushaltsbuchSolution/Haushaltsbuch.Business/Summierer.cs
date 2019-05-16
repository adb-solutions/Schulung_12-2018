using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haushaltsbuch.Shared;
using NodaMoney;

namespace Haushaltsbuch.Business
{
    public static class Summierer
    {
        public static Money Ermittle_Kassenbestand(DateTime datum, List<Transaktion> transaktionen)
        {
            Money kassenbestand = new Money(0);

            foreach (Transaktion transaktion in transaktionen.Where(transaktion => transaktion.Datum.Year <= datum.Year && transaktion.Datum.Month <= datum.Month))
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

        public static Kategorie Ermittle_Kategorie(string kategorie, DateTime datum, List<Transaktion> transaktionen)
        {
            IEnumerable<Transaktion> temp = transaktionen.Where(transaktion => 
                                                            transaktion.Typ == TransaktionTyp.Auszahlung &&
                                                            transaktion.Datum.Month == datum.Month &&
                                                            transaktion.Datum.Year == datum.Year &&

                                                            transaktion.Kategorie.Equals(kategorie, StringComparison.OrdinalIgnoreCase));

            Money summe = new Money(0);
            foreach (var elem in temp)
            {
                summe += elem.Betrag;
            }

            return new Kategorie(kategorie, summe);
        }

        public static List<Kategorie> Ermittle_alle_Kategorien(DateTime datum, List<Transaktion> transaktionen)
        {
            var temp = transaktionen.Where(transaktion => 
                                                            transaktion.Typ == TransaktionTyp.Auszahlung &&
                                                            transaktion.Datum.Month == datum.Month &&
                                                            transaktion.Datum.Year == datum.Year)
                                    .GroupBy(transaktion => transaktion.Kategorie);

            List<Kategorie> result = new List<Kategorie>();
            foreach (var elem in temp)
            {
                Money summe = new Money(0);
                foreach (Transaktion trans in elem)
                {
                    summe += trans.Betrag;
                }

                result.Add(new Kategorie(elem.Key, summe));
            }

            return result;
        }
    }
}
