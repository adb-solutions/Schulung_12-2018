using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Viewer.App.Daten
{
    public class DateiBereitsteller
    {
        public List<string> Lese_Dateiinhalt(string pfad)
        {
            var zeilen = File.ReadAllLines(pfad, Encoding.UTF8);
            return zeilen.Where(li => !string.IsNullOrEmpty(li)).ToList();
        }
    }
}
