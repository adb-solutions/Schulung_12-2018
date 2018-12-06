using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Provider
{
    public class StopwordsProvider
    {
        private readonly string _dateiPfad;

        public StopwordsProvider(string dateiPfad)
        {
            _dateiPfad = dateiPfad;
        } 

        public List<string> Read_Stopwords()
        {
            string[] zeilen = File.ReadAllLines(_dateiPfad);

            return zeilen.ToList();
        }
    }
}
