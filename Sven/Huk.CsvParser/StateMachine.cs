using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huk.CsvParser
{
    class StateMachine
    {
        public List<IEnumerable<string>> Records { get; private set; }
        public string[] FieldNames { get; private set; }
        public int RowsPerPage { get; private set; }
        public int CurrentPage { get; set; } = 0;
        public void Initialize(List<IEnumerable<string>> NativeRecords, int rowsPerPage) {

            FieldNames = NativeRecords.First().ToArray();
            Records=NativeRecords.Skip(1).ToList();
            RowsPerPage = rowsPerPage;
        }
    }
}
