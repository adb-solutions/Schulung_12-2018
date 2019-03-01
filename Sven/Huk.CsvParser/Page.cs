using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huk.CsvParser
{
    public class Page
    {
        public string[] FieldNames { get; set; }
        public IEnumerable<IEnumerable<string>> Records { get; set; }
    }
}