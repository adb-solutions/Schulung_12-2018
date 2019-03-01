using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSV_Viewer.App.Daten;

namespace CSV_Viewer.App.Business
{
    public class CsvWandler
    {
        private const char CsvDelimiter = ';';

        public IEnumerable<CsvDatensatz> Zerlege_Csv_in_CsvDatensaetze(List<string> zeilen)
        {
            //Kurzvariante via LINQ
            IEnumerable<CsvDatensatz> result = zeilen.Select(zeile =>
                new CsvDatensatz(
                    zeile.Split(CsvWandler.CsvDelimiter).ToList()
                )
            );
            return result;
        }
    }
}
