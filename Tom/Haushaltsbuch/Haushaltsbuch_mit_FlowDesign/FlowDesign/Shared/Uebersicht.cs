using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesign.Shared
{
    public class Uebersicht
    {
        public DateTime Datum { get; set; }
        public List<Kategorie> Kategorien { get; set; }
        public decimal Kassenbestand { get; set; }
        public Uebersicht(in DateTime datum, List<Kategorie> alleKategorien, decimal kategorienKassenbestand)
        {
            this.Datum = datum;
            this.Kategorien = alleKategorien;
            this.Kassenbestand = kategorienKassenbestand;
        }
    }
}
