using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Business;
using WordCounter.Interaktionen;

namespace WordCounter.Workflows
{
    public static class Workflow
    {
        public static void Start()
        {
            WordCount wordCount = new WordCount();

            while (true)
            {
                Ui.Start();

                string text = Ui.Bitte_um_Texteingabe();
                int anzahlWords = wordCount.Count_Words(text);

                Ui.Zeige_Anzahl_Woerter(anzahlWords);
                Ui.Warte_und_Neustart();
            }
            
        }
    }
}
