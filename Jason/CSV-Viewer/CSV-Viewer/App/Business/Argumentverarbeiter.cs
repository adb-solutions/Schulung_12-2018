using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Viewer.App.Business
{
    public class ArgumentVerarbeiter
    {
        public string Lese_Eingabeparameter(string[] args)
        {
            string pfad = Ermittle_Pfad(args);
            int seitenlaenge = Ermittle_Seitenlaenge(args);

            Status.Instanz.Seitenlaenge.Setze(seitenlaenge);

            return pfad;
        }

        internal string Ermittle_Pfad(string[] args)
        {
            string pfad = Path.GetFullPath(args[0]);

            bool dateiNichtGefunden = !File.Exists(pfad);
            if (dateiNichtGefunden)
            {
                throw new FileNotFoundException($"Datei {args[0]} nicht gefunden.");
            }

            return pfad;
        }

        internal int Ermittle_Seitenlaenge(string[] args)
        {
            return args.Length > 1 ? int.Parse(args[1]) : Konstanten.StandardSeitenlaenge;
        }
    }
}
