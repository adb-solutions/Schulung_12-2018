using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haushaltsbuch.Shared.BusinessModels;

namespace Haushaltsbuch.Shared
{
    public class HaushaltsbuchEinzeln : IHaushaltsbuch
    {
        public HaushaltsbuchEinzeln(decimal kassenbestand, Kategorie kategorie, Zahlung typ)
        {
            Kassenbestand = kassenbestand;
            Kategorie = kategorie;
            Typ = typ;
        }

        public Zahlung Typ { get; set; }

        public decimal Kassenbestand { get; set; }

        public Kategorie Kategorie { get; set; }
    }
}
