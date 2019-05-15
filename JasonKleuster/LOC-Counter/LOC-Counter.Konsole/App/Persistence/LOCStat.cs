using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOC_Counter.Konsole.App.Persistence
{
    class LOCStat
    {
        public string Filename { get; set; } = string.Empty;

        public int Total { get; set; } = -1;

        public int LinesOfCode { get; set; } = -1;
    }
}
