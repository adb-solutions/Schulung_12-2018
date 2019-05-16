using FlowDesign.Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        internal static Transaktion Erstelle_Transaktion_aus_Eingabe(string[] args)
        {
            Tuple<Transaktion, string[]> temp = null;
            Transaktion transaktion = new Transaktion();
            transaktion.Typ = Erstelle_Transaktion_aus_Kommando(args);
            temp = Ergaenze_Datum(transaktion, args);
            temp = Ergaenze_Betrag(temp.Item1, temp.Item2);
            temp = Erganze_Kategorie(temp.Item1, temp.Item2);
            temp = Ergaenze_Bezeichnung(temp.Item1, temp.Item2);
            transaktion = temp.Item1;

            return transaktion;
        }
        internal static TransaktionTyp Erstelle_Transaktion_aus_Kommando(string[] args)
        {
            switch (args.First().ToLower())
            {
                case "einzahlung":
                    return TransaktionTyp.Einzahlung;
                case "auszahlung":
                    return TransaktionTyp.Auszahlung;
                default:
                    throw new ArgumentOutOfRangeException("TransaktionsTyp nicht erkannt!");
            }
        }

        internal static Tuple<Transaktion, string[]> Ergaenze_Datum(Transaktion transaktion, string[] args)
        {
            DateTime datum;
            string[] argsGekuerzt = args;
            if (DateTime.TryParseExact(args.First(), "dd.MM.YYYY", provider:null,style:DateTimeStyles.None, out datum))
            {
                argsGekuerzt = args.Skip(1).ToArray();
            }
            else
            {
                datum = DateTime.Now;
            }

            transaktion.ZahlungsDatum = datum;
            return new Tuple<Transaktion, string[]> (transaktion, argsGekuerzt);
        }
        private static Tuple<Transaktion, string[]> Ergaenze_Betrag(Transaktion transaktion, string[] args)
        {
            decimal betrag = 0m;
            string[] argsGekuerzt = null;
            betrag = decimal.Parse(args.First());
            argsGekuerzt = args.Skip(1).ToArray();
            transaktion.Betrag = betrag;
            return new Tuple<Transaktion, string[]> (transaktion, argsGekuerzt);
        }

        private static Tuple<Transaktion, string[]> Erganze_Kategorie(Transaktion transaktion, string[] args)
        {
            string kategorieName = String.Empty;
            string[] argsGekuerzt = null;
            kategorieName = args.First();
            transaktion.Kategorie = kategorieName;
            argsGekuerzt = args.Skip(1).ToArray();
            return new Tuple<Transaktion, string[]> (transaktion, argsGekuerzt);
        }

        private static Tuple<Transaktion, string[]> Ergaenze_Bezeichnung(Transaktion transaktion, string[] args)
        {
            string bezeichnungName = string.Empty;
            string[] argsGekuerzt = null;
            bezeichnungName = args.First();
            transaktion.Bemerkung = bezeichnungName;
            argsGekuerzt = args.Skip(1).ToArray();
            return new Tuple<Transaktion, string[]> (transaktion, argsGekuerzt);
        }
        internal static DateTime Erstelle_Datum_aus_Eingabeparameter(string[] args)
        {
            int monat, jahr;
            monat = Ermittle_Monat(args.First());
            jahr = Ermittle_Jahr(args.ElementAt(1));

            return new DateTime(jahr, monat, 1);
        }

        private static int Ermittle_Jahr(string args)
        {
            int year = int.Parse(args);
            return Convert.ToInt32(year);
        }

        private static int Ermittle_Monat(string args)
        {
            int monat = int.Parse(args);
            return Convert.ToInt32(monat);

        }
    }
}