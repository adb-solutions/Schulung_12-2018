using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haushaltsbuch.Shared;
using Haushaltsbuch.Shared.BusinessModels;

namespace Haushaltsbuch.Business
{
    public class HaushaltsbuchRechner
    {
        public decimal KassenbestandBerechnen(List<Transaktion> transaktionen)
        {
            return 1;
        }




        public List<Kategorie> KategorienGesamtbetraegeBerechnen(List<Transaktion> transaktion)
        {
            List<Kategorie> kategorien = new List<Kategorie>();

            

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

        public decimal KategorieGesamtbetragBerechnen(object transaktionen)
        {
            throw new NotImplementedException();
        }
    }
}
