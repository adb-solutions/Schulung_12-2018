using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvViewer.Business
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

        //verschieben in Dateibereitsteller
        internal string Ermittle_Pfad(string[] args)
        {
            string pfad = Path.GetFullPath(args[0]);

            return pfad;
        }

        internal int Ermittle_Seitenlaenge(string[] args)
        {
            return args.Length > 1 ? int.Parse(args[1]) : Konstanten.StandardSeitenlaenge;
        }
    }
}
