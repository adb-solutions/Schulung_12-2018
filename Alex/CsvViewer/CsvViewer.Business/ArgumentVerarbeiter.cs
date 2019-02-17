using System;
using System.Collections.Generic;
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

            return pfad;
        }

        internal string Ermittle_Pfad(string[] args)
        {
            return args[0];
        }

        internal int Ermittle_Seitenlaenge(string[] args)
        {
            return args.Length > 1 ? int.Parse(args[1]) : Konstanten.StandardSeitenlaenge;
        }
    }
}
