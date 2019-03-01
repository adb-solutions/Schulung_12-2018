using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOC_Counter.Konsole.App.Persistence
{
    class LinesOfCode
    {
        public LOCStat CreateLinesOfCodeStat(List<string> zeilen)
        {
            LOCStat locStat = new LOCStat()
            {
                Filename = "",
                Total = 1,
                LinesOfCode = 1,
            };

            return locStat;
        }
    }
}
