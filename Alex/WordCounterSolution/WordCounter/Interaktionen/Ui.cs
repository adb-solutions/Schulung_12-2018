using System;
using System.Threading;
using WordCounter.Business;

namespace WordCounter.Interaktionen
{
    public static class Ui
    {
        private static bool _isFirstRun = true;
        
        private static void Willkommen()
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

        public static void Start()
        {
            if (_isFirstRun)
            {
                Willkommen();
            }
        }

        public static void Zeige_Anzahl_Woerter(int anzahlWords)
        {
            Meldung($"Anzahl der Wörter: {anzahlWords}");
        }

        public static string Bitte_um_Texteingabe()
        {
            Meldung_ohne_Umbruch("Bitte geben Sie einen Text ein: ");
            string eingabe = Console.ReadLine();

            return eingabe;
        }

        public static void Warte_und_Neustart()
        {
            _isFirstRun = false;
            Thread.Sleep(3000);
            Console.WriteLine();
            Console.WriteLine();
            Start();
        }

        private static void Leerzeile()
        {
            Console.WriteLine();
        }

        private static void Meldung_ohne_Umbruch(string text)
        {
            Console.Write(text);
        }

        private static void Meldung(string text)
        {
            Console.WriteLine(text);
        }
    }
}
