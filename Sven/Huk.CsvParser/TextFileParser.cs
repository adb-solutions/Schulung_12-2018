using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huk.CsvParser
{
    class TextFileParser
    {
         char[] delemiter = new char[] { ';', ',' };
        public TextFileParser(string filePath)
        {
            this.FilePath = filePath;
        }
        public string FilePath { get; private set; }
        private string[] getAllLines() => System.IO.File.ReadAllLines(FilePath);
        public List<IEnumerable<string>> GetNativeRecordsWithHeader() {

            var lst = new List<IEnumerable<string>>();
            var lines = getAllLines();
            lines.ToList().ForEach(T => lst.Add(T.Split(delemiter)));

            return lst;
        }
    }
}
