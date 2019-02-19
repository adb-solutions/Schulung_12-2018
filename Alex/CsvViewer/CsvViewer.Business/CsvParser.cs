using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvViewer.Shared;

namespace CsvViewer.Business
{
    public class CsvParser
    {
        private const char CsvDelimiter = ';';

        public IEnumerable<CsvDatensatz> Zerlege_Csv_in_CsvDatensaetze(List<string> zeilen)
        {
            //Lange Variante via foreach
            /*
            List<CsvDatensatz> result = new List<CsvDatensatz>();
            foreach(var zeile in zeilen)
            {
                var werte = zeile.Split(CsvParser.CsvDelimiter);

                CsvDatensatz datensatz = new CsvDatensatz(werte.ToList());
                result.Add(datensatz);
            }
            */

            //Lange Variante via yield return
            /*
            foreach(var zeile in zeilen)
            {
                var werte = zeile.Split(CsvParser.CsvDelimiter);

                CsvDatensatz datensatz = new CsvDatensatz(werte.ToList());
                yield return datensatz;
            }
            */

            //Kurzvariante via LINQ
            IEnumerable<CsvDatensatz> result =  zeilen.Select(zeile => 
                                                new CsvDatensatz(
                                                    zeile.Split(CsvParser.CsvDelimiter).ToList()
                                                )
                                            );
            return result;
        }
    }
}
