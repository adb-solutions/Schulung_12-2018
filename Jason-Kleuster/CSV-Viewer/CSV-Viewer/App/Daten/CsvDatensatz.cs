using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Viewer.App.Daten
{
    public class CsvDatensatz
    {
        public List<string> Werte { get; set; } = new List<string>();

        public CsvDatensatz()
        {

        }

        public CsvDatensatz(List<string> werte)
        {
            Werte = werte;
        }
    }
}
