using FlowDesign.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowDesign.Business
{
    public static class ArgumentVerarbeiter
    {
        public static void Ist_Kommando_Uebersicht(string[] args, Action<string[]> onIstUebersicht, Action<string[]> onIstTransaktion)
        {
            if (args.First().Equals("Übersicht", StringComparison.InvariantCultureIgnoreCase))
            {
                onIstUebersicht(args.Skip(1).ToArray());
            }
            else if (args.First().Equals("auszahlung", StringComparison.InvariantCultureIgnoreCase) || args.First().Equals("einzahlung", StringComparison.InvariantCultureIgnoreCase))
            {
                onIstTransaktion(args);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Kommmando existiert nicht.");
            }
        }
        internal static Transaktion Erstelle_Transaktion_aus_Kommando(string[] args)
        {
            var typ = Erstelle_Transaktion_aus_Typ(args.First());
            var datum = Ergaenze_Datum(args.ElementAt(1));
            var betrag = Ergaenze_Betrag(args.ElementAt(2));
            var kategorie = Erganze_Kategorie(args.ElementAt(3));
            var bezeichnung = Ergaenze_Bezeichnung(args.ElementAt(4));

            Transaktion transaktion = new Transaktion();
            transaktion.Typ = typ;
            transaktion.Zahlungsdatum = datum;
            transaktion.Betrag = betrag;
            transaktion.Kategorie = kategorie;
            transaktion.Bemerkung = bezeichnung;

            return transaktion;

        }

        private static string Ergaenze_Bezeichnung(string args)
        {
            string bemerkung = args;
            return bemerkung;
        }

        private static string Erganze_Kategorie(string args)
        {
            string kategorie = args;
            return kategorie;
        }

        private static decimal Ergaenze_Betrag(string args)
        {
            decimal betrag = decimal.Parse(args);
            return betrag;
        }

        private static DateTime Ergaenze_Datum(string args)
        {
            DateTime datum;
            if (DateTime.TryParse(args, out datum)){
            }
            else
            {
                datum = DateTime.Now;
            }
            return datum;

        }

        private static TransaktionTyp Erstelle_Transaktion_aus_Typ(string args)
        {
            switch (args.ToLower())
            {
                case "einzahlung":
                    return TransaktionTyp.Einzahlung;
                case "auszahlung":
                    return TransaktionTyp.Auszahlung;
                default:
                    throw new ArgumentOutOfRangeException("TransaktionsTyp nicht erkannt!");
            }
        }


        internal static DateTime Erstelle_Datum_aus_Eingabeparameter(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
