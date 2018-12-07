using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words.Business
{
    public static class StopwordsProvider
    {

        public static IEnumerable<string> Read_stopwords()
        {
            var fileContent = File.ReadAllLines(@"C:\Temp\stopwords.txt");

            return fileContent;
        }
    }
}
