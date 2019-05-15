using System;
using Newtonsoft.Json;
using NodaMoney;

namespace Haushaltsbuch.Shared
{
    public class Transaktion
    {
        public TransaktionTyp Typ { get; set; }

        public DateTime Datum { get; set; }

        public Money Betrag { get; set; }

        public string Kategorie { get; set; }

        public string Memotext { get; set; }

        public Transaktion(TransaktionTyp typ)
        {
            this.Typ = typ;
        }
    }
}
