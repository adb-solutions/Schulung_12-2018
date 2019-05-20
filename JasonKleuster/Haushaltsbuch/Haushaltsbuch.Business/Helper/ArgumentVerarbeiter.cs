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
        public void ParameterAktionBestimmen(string[] args, 
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

        public Transaktion ZahlungsdatenAuslesen(string[] args)
        {
            var values = ParametAktionAuslesenUndTransaktionErstellen(args);
            values = ParameterDatumAuslesen(values.Item1, values.Item2);
            values = ParameterBetragAuslesen(values.Item1, values.Item2);
            values = ParameterKategorieAuslesen(values.Item1, values.Item2); 
            var result = ParameterMemoAuslesen(values.Item1, values.Item2); 

            return result;
        }

        // ZahlungsdatenAuslesen
        private Tuple<string[], Transaktion> ParametAktionAuslesenUndTransaktionErstellen(string[] args)
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
        internal Tuple<string[], Transaktion> ParameterDatumAuslesen(string[] args, Transaktion transaktion)
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
        private Tuple<string[], Transaktion> ParameterBetragAuslesen(string[] args, Transaktion transaktion)
        {
            decimal betrag = decimal.Parse(args.First());
            transaktion.Wert = betrag;

            return new Tuple<string[], Transaktion>(args.Skip(1).ToArray(), transaktion);
        }

        // ZahlungsdatenAuslesen
        private Tuple<string[], Transaktion> ParameterKategorieAuslesen(string[] args, Transaktion transaktion)
        {
            if (args != null && args.Any())
            {
                transaktion.Kategorie = args.First();
                return new Tuple<string[], Transaktion>(args.Skip(1).ToArray(), transaktion);
            }

            return new Tuple<string[], Transaktion>(null, transaktion);
        }

        // ZahlungsdatenAuslesen
        private Transaktion ParameterMemoAuslesen(string[] args, Transaktion transaktion)
        {
            if (args != null && args.Any())
            {
                transaktion.Memotext = args.First();
                return transaktion;
            }

            return transaktion;
        }



        public Index IndexdatenAuslesen(string[] args)
        {
            var values = ParameterMonatAuslesenUndIndexErstellen(args);
            var result = ParameterJahrAuslesen(values.Item1, values.Item2);


            return result;
        }

        // ZahlungsdatenAuslesen
        private Tuple<Index, string[]> ParameterMonatAuslesenUndIndexErstellen(string[] args)
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
        private Index ParameterJahrAuslesen(Index index, string[] args)
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
