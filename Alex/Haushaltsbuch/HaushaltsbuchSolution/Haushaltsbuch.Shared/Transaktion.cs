using System;
using Money;

namespace Haushaltsbuch.Shared
{
    public class Transaktion
    {
        public TransaktionTyp Typ { get; set; }

        public DateTime Datum { get; set; }

        public Money<decimal> Betrag { get; set; }

        public string Kategorie { get; set; }

        public string Memotext { get; set; }
    }
}
