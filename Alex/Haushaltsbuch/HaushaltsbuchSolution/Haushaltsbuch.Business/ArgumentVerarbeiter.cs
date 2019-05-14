using System;
using System.Linq;
using Haushaltsbuch.Shared;

namespace Haushaltsbuch.Business
{
    public static class ArgumentVerarbeiter
    {
        public static void Ist_Uebersicht_Kommando(string[] args, Action<string[]> onIstUebersicht, Action<string[]> onIstEinAuszahlung)
        {
            if (args.First().Equals("übersicht", StringComparison.CurrentCulture))
            {
                onIstUebersicht(args.Skip(1).ToArray());
            }
            else
            {
                onIstEinAuszahlung(args);
            }
        }

        public static DateTime Erstelle_Datum_aus_Eingabeparameter(string[] args)
        {
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

        private static Tuple<Transaktion, string[]> Erstelle_Transaktion_aus_Typ(string[] args)
        {
            return null;
        }

        private static Tuple<Transaktion, string[]> Ergaenze_Datum(Transaktion transaktion, string[] args)
        {
            return null;
        }

        private static Tuple<Transaktion, string[]> Ergaenze_Betrag(Transaktion transaktion, string[] args)
        {
            return null;
        }

        private static Tuple<Transaktion, string[]> Ergaenze_Kategorie(Transaktion transaktion, string[] args)
        {
            return null;
        }

        private static Transaktion Ergaenze_Memo(Transaktion transaktion, string[] args)
        {
            return null;
        }
    }
}
