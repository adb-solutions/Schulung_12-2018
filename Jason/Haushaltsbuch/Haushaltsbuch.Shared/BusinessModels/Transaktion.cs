using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.Shared.BusinessModels
{
    public class Transaktion
    {
        public Zahlung Typ { get; set; }

        public DateTime Datum { get; set; } = DateTime.Now;

        public decimal Wert { get; set; } = 0;

        public string Kategorie { get; set; } = string.Empty;

        public string Memotext { get; set; } = string.Empty;
    }

    public enum Zahlung
    {
        Einzahlung = 10,
        Auszahlung = 20
    }
}
