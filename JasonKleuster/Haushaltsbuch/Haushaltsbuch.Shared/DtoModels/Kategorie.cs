using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.Shared
{
    public class Kategorie
    {
        public Kategorie(string bezeichnung, decimal gesamtbetrag)
        {
            Bezeichnung = bezeichnung;
            Gesamtbetrag = gesamtbetrag;
        }

        public string Bezeichnung { get; set; }

        public decimal Gesamtbetrag { get; set; }
    }
}
