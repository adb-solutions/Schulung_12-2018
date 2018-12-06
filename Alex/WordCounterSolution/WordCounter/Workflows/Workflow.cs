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
            UserInteraktion ui = new UserInteraktion();

            while (true)
            {
                ui.Start();

                string text = ui.Bitte_um_Texteingabe();
                int anzahlWords = wordCount.Count_Words(text);

                ui.Zeige_Anzahl_Woerter(anzahlWords);
                ui.Warte_und_Neustart();
            }
            
        }
    }
}
