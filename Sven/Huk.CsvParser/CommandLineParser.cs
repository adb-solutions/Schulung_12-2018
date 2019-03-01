using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huk.CsvParser
{
    class CommandLineParser
    {
        public string FilePath { get; set; }
        public int RowsPerPage { get; set; } = 10;
        public static CommandLineParser Parse(string[] args) {
            var ParserResult = new CommandLineParser();
            if (args.Length == 0)
                throw new ArgumentException("Es wurden keine Kommandozeilenparameter übergeben");

            var path = args[0];

            if (!System.IO.File.Exists(path))
                throw new ArgumentException($"Datei {path} wurde nicht gefunden");
            else
                ParserResult.FilePath = path;

            if (args.Length == 2)
            {
                ParserResult.RowsPerPage = int.Parse(args[1]);
            }
            return ParserResult;
        }
    }
}
