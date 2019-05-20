using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haushaltsbuch.Persistence;
using Haushaltsbuch.Shared;
using Haushaltsbuch.Shared.BusinessModels;

namespace Haushaltsbuch.Business
{
    public class HaushaltsbuchRechner
    {
        public decimal Kassenbestand_berechnen(List<Transaktion> transaktionen)
        {
            decimal bestand = 0;

            foreach (var transaktion in transaktionen)
            {
                bestand = bestand + transaktion.Wert;
            }

            return bestand;
        }

        public List<Kategorie> Kategorien_Gesamtbetraege_berechnen(List<Transaktion> transaktionen)
        {
            List<Kategorie> kategorien = new List<Kategorie>();

            foreach (var transaktion in transaktionen)
            {
                if (kategorien.Any(li => li.Equals(transaktion.Kategorie)))
                {
                    var kategorie = kategorien.Find(li => li.Bezeichnung.Equals(transaktion.Kategorie));
                    kategorie.Gesamtbetrag = kategorie.Gesamtbetrag + transaktion.Wert;
                }
                else
                {
                    Kategorie kategorie = new Kategorie(transaktion.Kategorie, transaktion.Wert);
                    kategorien.Add(kategorie);
                }
            }

            return kategorien;
        }


        public DateTime DatumErmitteln(Index index)
        {
            DateTimeFormatInfo info = new DateTimeFormatInfo();

            int jahr = Convert.ToInt32(index.Jahr);
            int monat = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(index.Monat) + 1;

            var temp = new DateTime(jahr, monat, 1);

            DateTime datum = temp.AddMonths(1).AddDays(-1);

            return datum;
        }

        public decimal Kategorie_Gesamtbetrag_berechnen(List<Transaktion> transaktionen)
        {
            decimal gesamtbetrag = 0;

            foreach (var transaktion in transaktionen)
            {
                gesamtbetrag = gesamtbetrag + transaktion.Wert;
            }

            return gesamtbetrag;
        }

        public decimal Kassenbestand_verringern(decimal kassenbestand, decimal betrag)
        {
            kassenbestand = kassenbestand - betrag;
            return kassenbestand;
        }

        public decimal Kassenbestand_erhoehen(decimal kassenbestand, decimal betrag)
        {
            kassenbestand = kassenbestand + betrag;
            return kassenbestand;
        }
    }
}
