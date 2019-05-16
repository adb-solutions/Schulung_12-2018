using System;
using System.Collections.Generic;
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
        public string[] ParameterAktionBestimmen(string[] args, Action<string[]> onZahlung, Action<string[]> onIndex)
        {
            return args;
        }

        public Transaktion ZahlungsdatenAuslesen(string[] args)
        {
            var values = ParameterAktionAuslesenUndTransaktionErstellen(args);
            values = ParameterDatumAuslesen(values.args, values.transaktion);
            values = ParameterBetragAuslesen(values.args, values.transaktion);
            values = ParameterKategorieAuslesen(values.args, values.transaktion); 
            var result = ParameterMemoAuslesen(values.args, values.transaktion); 

            return result;
        }

        // ZahlungsdatenAuslesen
        private (string[] args, Transaktion transaktion) ParameterAktionAuslesenUndTransaktionErstellen(string[] args)
        {
            Transaktion transaktion = new Transaktion();

            return (args, transaktion);
        }

        // ZahlungsdatenAuslesen
        internal (string[] args, Transaktion transaktion) ParameterDatumAuslesen(string[] args, Transaktion transaktion)
        {
            string temp = args[0];

            DateTime ergebnis;

            if (DateTime.TryParseExact(temp, "dd.MM.yyyy", null, DateTimeStyles.None, out ergebnis))
            {
                transaktion.Datum = ergebnis;
                return (args.Skip(1).ToArray(), transaktion);
            }
            else
            {
                transaktion.Datum = DateTime.Now;
                return (args, transaktion);
            }
        }

        // ZahlungsdatenAuslesen
        private (string[] args, Transaktion transaktion) ParameterBetragAuslesen(string[] args, Transaktion transaktion)
        {


            return (args, transaktion);
        }

        // ZahlungsdatenAuslesen
        private (string[] args, Transaktion transaktion) ParameterKategorieAuslesen(string[] args, Transaktion transaktion)
        {


            return (args, transaktion);
        }

        // ZahlungsdatenAuslesen
        private Transaktion ParameterMemoAuslesen(string[] args, Transaktion transaktion)
        {


            return transaktion;
        }



        public Index IndexdatenAuslesen(string[] args)
        {
            var values = ParameterMonatAuslesenUndIndexErstellen(args);
            var result = ParameterJahrAuslesen(values.args, values.index);


            return result;
        }

        // ZahlungsdatenAuslesen
        private (string[] args, Index index) ParameterMonatAuslesenUndIndexErstellen(string[] args)
        {
            Index index = new Index();

            return (args, index);
        }

        // ZahlungsdatenAuslesen
        private Index ParameterJahrAuslesen(string[] args, Index index)
        {


            return index;
        }
    }
}
