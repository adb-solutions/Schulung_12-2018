using System;
using System.Collections.Generic;
using System.Linq;
using CsvViewer.Shared;

namespace CsvViewer.KonsoleUi
{
    public class Ui
    {
        public event EventHandler<string[]> Start;
        public event EventHandler NaechsteSeite;
        public event EventHandler VorherigeSeite;
        public event EventHandler ErsteSeite;
        public event EventHandler LetzteSeite;
        public event EventHandler Exit;

        public void Run(string[] args)
        {
            Start.Invoke(this, args);

            bool isRunning = true;
            while(isRunning)
            {
                Zeige_Auswahl_Moeglichkeiten();
                var key = Console.ReadKey();

                switch (key.ToString().ToUpper())
                {
                    case "N":
                        NaechsteSeite.Invoke(this, EventArgs.Empty);
                        break;

                    case "P":
                        VorherigeSeite.Invoke(this, EventArgs.Empty);
                        break;

                    case "F":
                        VorherigeSeite.Invoke(this, EventArgs.Empty);
                        break;

                    case "L":
                        VorherigeSeite.Invoke(this, EventArgs.Empty);
                        break;

                    case "X":
                        Exit.Invoke(this, EventArgs.Empty);
                        isRunning = false;
                        break;
                }
            }
        }

        public void Zeige_CsvDatensaetze(List<CsvDatensatz> csvDatensaetze)
        {
            List<int> spaltenBreiten = ErmittleSpaltenBreiten(csvDatensaetze);
            Print_Kopfzeile(spaltenBreiten, csvDatensaetze.FirstOrDefault());
            Print_Eintraege(spaltenBreiten, csvDatensaetze.Skip(1).ToList());
        }

        private List<int> ErmittleSpaltenBreiten(List<CsvDatensatz> csvDatensaetze)  
        {
            List<int> result = new List<int>();

            int anzahlSpalten = csvDatensaetze.FirstOrDefault().Werte.Count;
            for(int i = 0; i < anzahlSpalten; i++)
            {
                int max = csvDatensaetze.Max(li => li.Werte.ElementAt(i).Length);
                result.Add(max);
            }

            return result;
        }

        private void Print_Kopfzeile(List<int> spaltenBreiten, CsvDatensatz kopfzeile)
        {
            string ausgabe = string.Empty;
            string ausgabeBottom = string.Empty;

            for(int i = 0; i < kopfzeile.Werte.Count; i++)
            {
                var inhalt = kopfzeile.Werte.ElementAt(i);
                int breite = spaltenBreiten.ElementAt(i);

                ausgabe = $"{inhalt.PadLeft(inhalt.Count() - breite, ' ')}|";
                ausgabeBottom = $"{"".PadLeft(breite, '-')}+";
            }

            Console.WriteLine(ausgabe);
            Console.WriteLine(ausgabeBottom);
        }

        private void Print_Eintraege(List<int> spaltenBreiten, List<CsvDatensatz> eintraege)
        {
            foreach(var eintrag in eintraege)
            {
                string ausgabe = string.Empty;

                for (int i = 0; i < eintrag.Werte.Count; i++)
                {
                    var inhalt = eintrag.Werte.ElementAt(i);
                    int breite = spaltenBreiten.ElementAt(i);

                    ausgabe = $"{inhalt.PadLeft(inhalt.Count() - breite, ' ')}|";
                }

                Console.WriteLine(ausgabe);
            }
        }

        private void Zeige_Auswahl_Moeglichkeiten()
        {
            List<string> moeglichkeiten = new List<string>();
            moeglichkeiten.Add("N(ext page");
            moeglichkeiten.Add("P(revious page");
            moeglichkeiten.Add("F(irst page");
            moeglichkeiten.Add("L(ast page");
            moeglichkeiten.Add("eX(it");

            Console.WriteLine(string.Join(", ", moeglichkeiten));
        }
    }
}
