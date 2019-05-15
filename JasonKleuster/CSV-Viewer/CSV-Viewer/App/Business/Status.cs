using System;
using System.Collections.Generic;
using CSV_Viewer.App.Daten;

namespace CSV_Viewer.App.Business
{
    public sealed class Status
    {
        public Zustand<int> Seitenlaenge = new Zustand<int>();
        public Zustand<int> AktuelleSeitenummer = new Zustand<int>();
        public Zustand<List<CsvDatensatz>> CsvDatensaetze = new Zustand<List<CsvDatensatz>>();

        private static Lazy<Status> lazy = new Lazy<Status>(() => new Status());

        public static Status Instanz
        {
            get { return lazy.Value; }
        }

        private Status()
        {
            Seitenlaenge.Setze(10);
            AktuelleSeitenummer.Setze(1);
            CsvDatensaetze.Setze(new List<CsvDatensatz>());
        }
    }
}
