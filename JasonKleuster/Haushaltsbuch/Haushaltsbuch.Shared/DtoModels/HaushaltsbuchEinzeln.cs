using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.Shared
{
    public class HaushaltsbuchEinzeln : IHaushaltsbuch
    {
        public HaushaltsbuchEinzeln(decimal kassenbestand, Kategorie dtoModel)
        {
            Kassenbestand = kassenbestand;
            Kategorie = dtoModel;
        }

        public decimal Kassenbestand { get; set; }

        public Kategorie Kategorie { get; set; }
    }
}
