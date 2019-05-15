using System;
using System.Collections.Generic;
using System.IO;

namespace LOC_Counter.Konsole.App.Persistence
{
    class FileAccess
    {
        public void FindSourceCodeFile(string pfad, 
            Action<string> onVorhanden, 
            Action onKeineWeiteren)
        {

            var dateien = Directory.GetFiles(pfad, "*.cs");
            foreach (var datei in dateien)
            {
                onVorhanden(datei);
            }

            onVorhanden("");


            onKeineWeiteren();
        }

        public List<string> ReadFile(string filename)
        {
            List<string> zeilen = new List<string>();

            return zeilen;
        }
    }
}
