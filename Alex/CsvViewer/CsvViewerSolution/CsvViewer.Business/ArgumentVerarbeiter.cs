using System;
using System.Runtime.CompilerServices;
using CsvViewer.Persistence;

[assembly: InternalsVisibleTo("CsvViewer.Tests")]
namespace CsvViewer.Business
{
    public class ArgumentVerarbeiter
    {
        public string Lese_Eingabeparameter(string[] args)
        {
            string pfad = Ermittle_Pfad(args);
            int seitenlaenge = Ermittle_Seitenlaenge(args);

            new DateiBereitsteller();
jhl
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
