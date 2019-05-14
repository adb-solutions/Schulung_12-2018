using System;
using Money;

namespace Haushaltsbuch.Shared
{
    public class Kategorie
    {
        public Money<decimal> Summe { get; set; }

        public string Bezeichnung { get; set; }
    }
}
