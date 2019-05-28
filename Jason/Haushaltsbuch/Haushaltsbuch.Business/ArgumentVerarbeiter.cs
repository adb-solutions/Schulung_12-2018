using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Haushaltsbuch.Shared.BusinessModels;

namespace Haushaltsbuch.Business
{
    public class ArgumentVerarbeiter
    {
        public void Parameter_Aktion_bestimmen(string[] args, 
            Action<string[]> onZahlung, 
            Action<string[]> onIndex)
        {
            string aktion = args.First();

            if (args.First() == "einzahlung")
            {
                onZahlung(args);
            }
            else if (args.First() == "auszahlung")
            {
                onZahlung(args);
            }
            else if (args.First() == "überischt")
            {
                onIndex(args);
            }
        }

        public Transaktion Zahlungsdaten_auslesen(string[] args)
        {
            var values = Paramet_Aktion_auslesen_und_Transaktion_erstellen(args);
            values = Parameter_Datum_auslesen(values.Item1, values.Item2);
            values = Parameter_Betrag_auslesen(values.Item1, values.Item2);
            values = Parameter_Kategorie_auslesen(values.Item1, values.Item2); 
            var result = Parameter_Memo_auslesen(values.Item1, values.Item2); 

            return result;
        }

        // ZahlungsdatenAuslesen
        private Tuple<string[], Transaktion> Paramet_Aktion_auslesen_und_Transaktion_erstellen(string[] args)
        {
            Transaktion transaktion = new Transaktion();

            if (args.First() == "einzahlung")
            {
                transaktion.Typ = Zahlung.Einzahlung;
            }
            else if (args.First() == "auszahlung")
            {
                transaktion.Typ = Zahlung.Auszahlung;
            }
      
            return new Tuple<string[], Transaktion>(args.Skip(1).ToArray(), transaktion);
        }

        // ZahlungsdatenAuslesen
        internal Tuple<string[], Transaktion> Parameter_Datum_auslesen(string[] args, Transaktion transaktion)
        {
            string[] argsResult = args;

            DateTime datum;
            if (DateTime.TryParse(args.First(), out datum))
            {
                argsResult = args.Skip(1).ToArray();
            }
            else
            {
                datum = DateTime.Now;
            }

            transaktion.Datum = datum;

            return new Tuple<string[], Transaktion>(argsResult, transaktion);
        }

        // ZahlungsdatenAuslesen
        private Tuple<string[], Transaktion> Parameter_Betrag_auslesen(string[] args, Transaktion transaktion)
        {
            decimal betrag = decimal.Parse(args.First());
            transaktion.Wert = betrag;

            return new Tuple<string[], Transaktion>(args.Skip(1).ToArray(), transaktion);
        }

        // ZahlungsdatenAuslesen
        private Tuple<string[], Transaktion> Parameter_Kategorie_auslesen(string[] args, Transaktion transaktion)
        {
            if (args != null && args.Any())
            {
                transaktion.Kategorie = args.First();
                return new Tuple<string[], Transaktion>(args.Skip(1).ToArray(), transaktion);
            }

            return new Tuple<string[], Transaktion>(null, transaktion);
        }

        // ZahlungsdatenAuslesen
        private Transaktion Parameter_Memo_auslesen(string[] args, Transaktion transaktion)
        {
            if (args != null && args.Any())
            {
                transaktion.Memotext = args.First();
                return transaktion;
            }

            return transaktion;
        }



        public Index Indexdaten_auslesen(string[] args)
        {
            var values = Parameter_Monat_auslesen_und_Index_erstellen(args);
            var result = Parameter_Jahr_auslesen(values.Item1, values.Item2);


            return result;
        }

        // ZahlungsdatenAuslesen
        private Tuple<Index, string[]> Parameter_Monat_auslesen_und_Index_erstellen(string[] args)
        {
            Index index = new Index();

            if (args != null && args.Any())
            {
                index.Monat = args.First();
                return new Tuple<Index, string[]>(index, args.Skip(1).ToArray());
            }

            index.Monat = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            return new Tuple<Index, string[]>(index, args);
        }

        // ZahlungsdatenAuslesen
        private Index Parameter_Jahr_auslesen(Index index, string[] args)
        {
            if (args != null && args.Any())
            {
                index.Jahr = args.First();
                return index;
            }

            index.Jahr = DateTime.Now.Year.ToString();
            return index;
        }
    }
}
