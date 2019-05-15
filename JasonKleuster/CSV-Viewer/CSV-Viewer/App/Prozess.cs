using System;
using System.Collections.Generic;
using CSV_Viewer.App.Business;
using CSV_Viewer.App.Daten;
using CSV_Viewer.App.View;

namespace CSV_Viewer.App
{
    class Prozess
    {
        private Display _view = null;
        private Interaktionen _interaktionen = null;

        public Prozess()
        {
            _view = new Display();
            _interaktionen = new Interaktionen();
        }

        public void Start(string[] args)
        {
            List<CsvDatensatz> datensaetze = new List<CsvDatensatz>();

            datensaetze = _interaktionen.Start(args);
            
            bool wiederholen = true;
            do
            {
                string eingabe = _view.Show(datensaetze);
                datensaetze = HandleEvent(eingabe);

            } while (wiederholen);
        }

        private List<CsvDatensatz> HandleEvent(string entry)
        {
            Interaktionen interatkion = new Interaktionen();
            List<CsvDatensatz> daten = null;

            switch (entry)
            {
                case "F":
                    daten = interatkion.ErsteSeite();
                    break;
                case "N":
                    daten = interatkion.NaechsteSeite();
                    break;
                case "P":
                    daten = interatkion.VorherigeSeite();
                    break;
                case "L":
                    daten = interatkion.LetzeSeite();
                    break;
                case "E":
                    Console.Clear();
                    Console.WriteLine("Das Programm wird beendet.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ein Fehler ist aufgetreten.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
            }

            return daten;
        }
    }
}
