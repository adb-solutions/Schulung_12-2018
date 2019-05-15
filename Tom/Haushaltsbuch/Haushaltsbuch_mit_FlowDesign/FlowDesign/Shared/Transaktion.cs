using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesign.Shared
{
    class Transaktion
    {
        
        public TransaktionTyp Typ { get; set; }

        public DateTime Zahlungsdatum = new DateTime();
        public decimal Betrag { get; set; }
        public string Kategorie { get; set; }
        public string Bemerkung { get; set; }


    }
}
