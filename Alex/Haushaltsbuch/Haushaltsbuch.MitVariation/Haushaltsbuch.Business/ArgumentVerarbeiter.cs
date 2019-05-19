using System;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using Haushaltsbuch.Shared;
using NodaMoney;

namespace Haushaltsbuch.Business
{
    public static class ArgumentVerarbeiter
    {
        public static void Ist_Uebersicht_Kommando(string[] args, Action<string[]> onIstUebersicht, Action<string[]> onIstEinAuszahlung)
        {
            var kommando = args.First();
            if (kommando.Equals("übersicht", StringComparison.CurrentCultureIgnoreCase))
            {
                onIstUebersicht(args.Skip(1).ToArray());
            }
            else if (kommando.Equals("einzahlung", StringComparison.CurrentCultureIgnoreCase))
            {
                onIstEinAuszahlung(args);
            }
            else if (kommando.Equals("auszahlung", StringComparison.CurrentCultureIgnoreCase))
            {
                onIstEinAuszahlung(args);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Kommando nicht erkannt");
            }
        }

        public static DateTime Erstelle_Datum_aus_Eingabeparameter(string[] args)
        {
            Tuple<int, string[]> monat = Ermittle_Monat(args);
            int jahr = Ermittle_Jahr(monat.Item2);

            return new DateTime(jahr, monat.Item1, 1);
        }

        public static Transaktion Erstelle_Transaktion_aus_Eingabeparameter(string[] args)
        {
            Tuple<Transaktion, string[]> temp = Erstelle_Transaktion_aus_Typ(args);
            temp = Ergaenze_Datum(temp.Item1, temp.Item2);
            temp = Ergaenze_Betrag(temp.Item1, temp.Item2);
            temp = Ergaenze_Kategorie(temp.Item1, temp.Item2);
            Transaktion transaktion = Ergaenze_Memo(temp.Item1, temp.Item2);

            return transaktion;
        }

        internal static int Ermittle_Jahr(string[] args)
        {
            if (args != null && args.Any())
            {
                int jahr = int.Parse(args.First());

                return jahr;
            }

            return DateTime.Now.Year;
        }

        internal static Tuple<int, string[]> Ermittle_Monat(string[] args)
        {
            if(args != null && args.Any())
            {
                int monat = int.Parse(args.First());
                return new Tuple<int, string[]>(monat, args.Skip(1).ToArray());
            }

            return new Tuple<int, string[]>(DateTime.Now.Month, null);
        }
        
        internal static Tuple<Transaktion, string[]> Erstelle_Transaktion_aus_Typ(string[] args)
        {
            var typ = TransaktionTypKonvertierer.FromString(args.First());

            return new Tuple<Transaktion, string[]>(new Transaktion(typ), args.Skip(1).ToArray());
        }

        internal static Tuple<Transaktion, string[]> Ergaenze_Datum(Transaktion transaktion, string[] args)
        {
            string[] argsResult = args;

            DateTime datum;
            if (DateTime.TryParseExact(args.First(), Konstanten.Unterstuetze_EingabeDatumsformate, null, DateTimeStyles.None, out datum))
            {
                argsResult = args.Skip(1).ToArray();
            } 
            else
            {
                datum = DateTime.Now;
            }

            transaktion.Datum = datum;

            return new Tuple<Transaktion, string[]>(transaktion, argsResult);
        }
        
        internal static Tuple<Transaktion, string[]> Ergaenze_Betrag(Transaktion transaktion, string[] args)
        {
            decimal betrag = decimal.Parse(args.First());
            transaktion.Betrag = new Money(betrag, Konstanten.DefaultWaehrung);

            return new Tuple<Transaktion, string[]>(transaktion, args.Skip(1).ToArray());
        }

        internal static Tuple<Transaktion, string[]> Ergaenze_Kategorie(Transaktion transaktion, string[] args)
        {
            if(args != null && args.Any())
            {
                transaktion.Kategorie = args.First();
                return new Tuple<Transaktion, string[]>(transaktion, args.Skip(1).ToArray());
            }

            return new Tuple<Transaktion, string[]>(transaktion, null);
        }

        internal static Transaktion Ergaenze_Memo(Transaktion transaktion, string[] args)
        {
            if (args != null && args.Any())
            {
                transaktion.Memotext = args.First();
                return transaktion;
            }

            return transaktion;
        }
    }
}
