using System;
using System.Threading;
using WordCounter.Business;

namespace WordCounter.Interaktionen
{
    public class UserInteraktion
    {
        private static bool _isFirstRun;

        public UserInteraktion()
        {
            _isFirstRun = true;
        }

        private void Willkommen()
        {
            Meldung(" __          __           _    _____                  _            ");
            Meldung(@" \ \        / /          | |  / ____|                | |           ");
            Meldung(@"  \ \  /\  / /__  _ __ __| | | |     ___  _   _ _ __ | |_ ___ _ __ ");
            Meldung(@"   \ \/  \/ / _ \| '__/ _` | | |    / _ \| | | | '_ \| __/ _ \ '__|");
            Meldung(@"    \  /\  / (_) | | | (_| | | |___| (_) | |_| | | | | ||  __/ |   ");
            Meldung(@"     \/  \/ \___/|_|  \__,_|  \_____\___/ \__,_|_| |_|\__\___|_|   ");
            Leerzeile();
            Meldung("Herzlich Willkommen beim Word-Counter!");
            Meldung("Diese Anwendung zählt die Wörter Ihres eingegeben Textes.");
            Leerzeile();
        }

        public void Start()
        {
            if (_isFirstRun)
            {
                Willkommen();
            }
        }

        public void Zeige_Anzahl_Woerter(int anzahlWords)
        {
            Meldung($"Anzahl der Wörter: {anzahlWords}");
        }

        public string Bitte_um_Texteingabe()
        {
            Meldung_ohne_Umbruch("Bitte geben Sie einen Text ein: ");
            string eingabe = Console.ReadLine();

            return eingabe;
        }

        public void Warte_und_Neustart()
        {
            _isFirstRun = false;
            Thread.Sleep(3000);
            Console.WriteLine();
            Console.WriteLine();
            Start();
        }

        private void Leerzeile()
        {
            Console.WriteLine();
        }

        private void Meldung_ohne_Umbruch(string text)
        {
            Console.Write(text);
        }

        private void Meldung(string text)
        {
            Console.WriteLine(text);
        }
    }
}
