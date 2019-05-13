using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign.Ui
{
    public class Ausgabe
    {
        static private bool _erstmaligeAusfuehrung = true;
        public void Start()
        {
            if (_erstmaligeAusfuehrung)
            {
                Willkommen();
            }
        }

        static private void Willkommen()
        {
            Console.WriteLine("Haushaltsbuch");
            Console.WriteLine("_____________");
            Console.WriteLine();
            Console.WriteLine("Einzahlung/Auszahlung/Uebersicht");
            Console.WriteLine("Datum");
            Console.WriteLine("Betrag");
            Console.WriteLine("Kategorie");
            Console.WriteLine("Beschreibung");
            Console.WriteLine("------------");
            _erstmaligeAusfuehrung = false;
        }

        private void bitteUmEingabe()
        {
            Console.Clear();
            Console.WriteLine("Bitte geben Sie Ihre letzte Transaktion ein oder frage Sie nach der Übersicht eines bestimmten Monats");
        }
    }
}
