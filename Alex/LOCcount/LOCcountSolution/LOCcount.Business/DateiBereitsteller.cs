using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LOCcount.Business
{
    public class DateiBereitsteller
    {
        public void Lese_Dateiinhalt(string pfad, Action<IEnumerable<string>> onErfolg, Action<string> onFehler)
        {
            try
            {
                var zeilen = File.ReadAllLines(pfad, Encoding.UTF8);
                onErfolg(zeilen);
            }
            catch
            {
                onFehler(pfad);
            }
        }

        public void Quellcodedateien_finden(string pfad, Action<string> onDateiname, Action onAbgeschlossen, Action<string> onFehler)
        {
            Quellcodedateien_finden(pfad, onDateiname, onFehler);
            onAbgeschlossen();
        }

        private void Quellcodedateien_finden(string pfad, Action<string> onDateiname, Action<string> onFehler)
        {
            try
            {
                foreach (string datei in Directory.EnumerateFiles(pfad, "*.cs"))
                {
                    onDateiname(datei);
                }

                foreach (string ordner in Directory.GetDirectories(pfad))
                {
                    Quellcodedateien_finden(ordner, onDateiname, onFehler);
                }
            }
            catch
            {
                onFehler(pfad);
            }

        }
    }
}
