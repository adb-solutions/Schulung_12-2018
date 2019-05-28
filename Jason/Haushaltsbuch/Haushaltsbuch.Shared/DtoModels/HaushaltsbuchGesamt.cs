using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.Shared
{
    public class HaushaltsbuchGesamt : IHaushaltsbuch

    { 
        public HaushaltsbuchGesamt(DateTime datum, decimal kassenbestand, List<Kategorie> kategorien)
        {
            DateTimeFormatInfo info = new DateTimeFormatInfo();
            Monat = info.GetMonthName(datum.Month);
            Jahr = datum.Year.ToString();
            Kassenbestand = kassenbestand;
            Kategorien = kategorien;
        }

        public string Monat { get; set; }

        public string Jahr { get; set; }

        public decimal Kassenbestand { get; set; }

        public List<Kategorie> Kategorien { get; set; }
    }
}
