using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LOCcount
{
    public class DateiBereitsteller
    {
        public IEnumerable<string> Lese_Dateiinhalt(string pfad)
        {
            var zeilen = File.ReadAllLines(pfad, Encoding.UTF8);
            return zeilen;
        }
    }
}
