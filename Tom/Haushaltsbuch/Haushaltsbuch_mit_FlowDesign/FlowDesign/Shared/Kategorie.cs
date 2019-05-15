using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesign.Shared
{
    class Kategorie
    {
        public Kategorie(decimal summe, string bezeichnung)
        {
            this.Summe = summe;
            this.Bezeichnung = bezeichnung;
        }
        public decimal Summe { get; set; }
        public string Bezeichnung { get; set; }
    }
}
