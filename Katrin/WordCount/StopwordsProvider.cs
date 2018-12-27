using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class StopwordsProvider
    {
        public string getStopWords()
        {
            string strstopwords;
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Cheshire\source\repos\WordCount\WordCount\Stopwords.txt");
            strstopwords = file.ReadLine();
            file.Close();
            return strstopwords;
        }
    }
}
