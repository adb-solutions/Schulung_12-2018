using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CsvViewer.Shared;

namespace CsvViewer.KonsoleUi
{
    public class Ui
    {
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
                
                ausgabe += $"{inhalt.PadRight(breite, ' ')}|";
                ausgabeBottom += $"{"".PadRight(breite, '-')}+";
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
                    
                    ausgabe += $"{inhalt.PadRight(breite, ' ')}|";
                }

                Console.WriteLine(ausgabe);
            }
        }

        public string Lese_Zeichen()
        {
            var key = Console.ReadKey();
            Console.Clear();
            var result = key.KeyChar.ToString().ToUpper();

            return result;
        }

        public void Zeige_Hinweis(string nachricht)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(nachricht);
            
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Zeige_Fehler(string nachricht)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(nachricht);
            Thread.Sleep(2000);

            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
        }

        public void Zeige_Auswahl_Moeglichkeiten()
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
