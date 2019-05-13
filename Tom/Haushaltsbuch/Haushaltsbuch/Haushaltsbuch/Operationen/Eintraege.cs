using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Haushaltsbuch.Operationen
{
    class Eintraege
    {
        public double _betrag { get; }
        public string _kategorie { get; }
        public string _beschreibung { get; }

        public Eintraege(double betrag, string kategorie)
        {
            _betrag = betrag;
            _kategorie = kategorie;
        }

        public Eintraege(double betrag, string kategorie, string beschreibung)
        {
            _betrag = betrag;
            _kategorie = kategorie;
            _beschreibung = beschreibung;
        }
    }
}