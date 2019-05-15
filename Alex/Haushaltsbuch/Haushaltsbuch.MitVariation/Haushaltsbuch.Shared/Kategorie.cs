using System;
using NodaMoney;

namespace Haushaltsbuch.Shared
{
    public class Kategorie
    {
        public Money Summe { get; set; }

        public string Bezeichnung { get; set; }

        public Kategorie(string bezeichnung, Money summe)
        {
            Bezeichnung = bezeichnung;
            Summe = summe;
        }

    }
}
