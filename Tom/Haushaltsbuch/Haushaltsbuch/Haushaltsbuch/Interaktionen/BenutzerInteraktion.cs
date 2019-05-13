using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch
{
    class BenutzerInteraktion
    {
        private static bool _isFirstRun = true;

        public static void Start()
        {
            if (_isFirstRun)
            {
                Willkommen();
            }
        }

        public static void Willkommen()
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
            _isFirstRun = false;
        }

        public static string bitteUmEingabe()
        {
            Console.WriteLine("Bitte geben Sie einen Text ein");
            string eingabe = Console.ReadLine();

            return eingabe;
        }

        public static void ausgabeUebersicht(string Ausgabe)
        {

        }
    }
}
