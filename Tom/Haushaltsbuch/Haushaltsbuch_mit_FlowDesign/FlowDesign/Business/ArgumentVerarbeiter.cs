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
        internal static Transaktion Erstelle_Transaktion_aus_Eingabe(string[] args)
        {
            throw new NotImplementedException();
        }

        internal static DateTime Erstelle_Datum_aus_Eingabeparameter(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
