using System;
using System.Collections.Generic;
using CsvViewer.Shared;

namespace CsvViewer.Business
{
    public class Status
    {
        public Zustand<int> Seitenlaenge;
        public Zustand<int> AktuelleSeitenummer;
        public Zustand<List<CsvDatensatz>> CsvDatensaetze;

        public Status()
        {
            Seitenlaenge.Setze(10);
            AktuelleSeitenummer.Setze(1);
            CsvDatensaetze.Setze(new List<CsvDatensatz>());
        }
    }
}
