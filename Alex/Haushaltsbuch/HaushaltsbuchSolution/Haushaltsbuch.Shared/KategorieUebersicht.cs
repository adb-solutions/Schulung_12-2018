using System;
using System.Collections.Generic;
using Money;

namespace Haushaltsbuch.Shared
{
    public class KategorieUebersicht
    {
        public DateTime Datum { get; set; }

        public Money<decimal> Kassenbestand { get; set; }

        public List<Kategorie> Kategorien { get; set; }
    }
}
