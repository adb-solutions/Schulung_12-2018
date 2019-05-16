using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FlowDesign.Shared
{
    class Transaktion
    {
        public TransaktionTyp Typ { get; set; }

        public DateTime ZahlungsDatum { get; set; }

        public decimal Betrag { get; set; }

        public string Kategorie { get; set; }

        public string Bemerkung { get; set; }
    }
}
