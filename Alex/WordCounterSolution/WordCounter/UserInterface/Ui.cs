using System;
using System.Threading;
using WordCounter.Business;
using WordCounter.Operations;
using WordCounter.Provider;

namespace WordCounter.UserInterface
{
    public class Ui
    {
        private readonly WordCount _businessLogik;
        private bool _isFirstRun;

        public Ui()
        {
            string pathZuStopwords = $"{AppDomain.CurrentDomain.BaseDirectory}\\App_Data\\stopwords.txt";

            Words words = new Words();
            StopwordsProvider stopwordsProvider = new StopwordsProvider(pathZuStopwords);
            _businessLogik = new WordCount(words, stopwordsProvider);
            _isFirstRun = true;
        }

        public void Willkommen()
        {
            

            Meldung(" __          __           _    _____                  _            ");
            Meldung(@" \ \        / /          | |  / ____|                | |           ");
            Meldung(@"  \ \  /\  / /__  _ __ __| | | |     ___  _   _ _ __ | |_ ___ _ __ ");
            Meldung(@"   \ \/  \/ / _ \| '__/ _` | | |    / _ \| | | | '_ \| __/ _ \ '__|");
            Meldung(@"    \  /\  / (_) | | | (_| | | |___| (_) | |_| | | | | ||  __/ |   ");
            Meldung(@"     \/  \/ \___/|_|  \__,_|  \_____\___/ \__,_|_| |_|\__\___|_|   ");
            Leerzeile();
        }

        public void Start()
        {
            if (_isFirstRun)
            {
                Willkommen();
            }

            Meldung("Herzlich Willkommen beim Word-Counter!");
            Meldung("Diese Anwendung zählt die Wörter Ihres eingegeben Textes.");
            Leerzeile();

            MeldungOhneUmbruch("Bitte geben Sie einen Text ein: ");
            string text = LeseZeileneingabe();

            var anzahlWords = _businessLogik.Count_Words(text);
            Meldung($"Anzahl der Wörter: {anzahlWords}");

            WarteUndNeustart();
        }

        public void WarteUndNeustart()
        {
            _isFirstRun = false;
            Thread.Sleep(3000);
            Console.WriteLine();
            Console.WriteLine();
            Start();
        }

        public void Leerzeile()
        {
            Console.WriteLine();
        }

        public string LeseZeileneingabe()
        {
            string eingabe = Console.ReadLine();

            return eingabe;
        }

        public void MeldungOhneUmbruch(string text)
        {
            Console.Write(text);
        }

        public void Meldung(string text)
        {
            Console.WriteLine(text);
        }
    }
}
