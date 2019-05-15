using System;
using System.Collections.Generic;
using NodaMoney;

namespace Haushaltsbuch.Shared
{
    public class KategorieUebersicht
    {
        public DateTime Datum { get; set; }

        public Money Kassenbestand { get; set; }

        public List<Kategorie> Kategorien { get; set; }
    }
}
