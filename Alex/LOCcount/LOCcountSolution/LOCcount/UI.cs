using System;
using LOCcount.Business;

namespace LOCcount
{
    public class UI
    {
        private int anzahlZeilen = 0;
        private int anzahlCodezeilen = 0;

        public void Anzeige(string text)
        {
            Console.WriteLine(text);
        }

        public void OnLOCStat(LOCStat locstat) {
            anzahlZeilen += locstat.AnzahlZeilen;
            anzahlCodezeilen += locstat.AnzahlCodezeilen;

            Anzeige($"{locstat.Filename} {locstat.AnzahlZeilen}, {locstat.AnzahlCodezeilen}");
        }

        public void OnAbgeschlossen () {
            Anzeige($"Total:\r\n\tLine:{anzahlZeilen}\r\n\tLOC: {anzahlCodezeilen}\r\n");
        }

        public void OnFehlerDateilesen(string dateiname) {
            Anzeige($"Datei {dateiname} konnte nicht gelesen werden");
        }

        public void OnFehlerDateienFinden (string pfad) {
            Anzeige($"Pfad {pfad} konnte nicht gelesen werden");
        }
    }
}
