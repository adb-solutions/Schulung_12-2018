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

        public Ui()
        {
            string pathZuStopwords = $"{AppDomain.CurrentDomain.BaseDirectory}\\App_Data\\stopwords.txt";

            Words words = new Words();
            StopwordsProvider stopwordsProvider = new StopwordsProvider(pathZuStopwords);
            _businessLogik = new WordCount(words, stopwordsProvider);
        }

        public void Start()
        {
            MeldungOhneUmbruch("Enter your text: ");
            string text = LeseZeileneingabe();

            var anzahlWords = _businessLogik.Count_Words(text);
            Meldung($"Number of words: {anzahlWords}");

            WarteUndNeustart();
        }

        public void WarteUndNeustart()
        {
            Thread.Sleep(3000);
            Console.WriteLine();
            Console.WriteLine();
            Start();
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
