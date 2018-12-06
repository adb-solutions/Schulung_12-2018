using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Operations
{
    public class Words
    {
        private const char DelimiterLeerzeichen = ' ';

        public List<string> Filter_Stopwords(List<string> words, List<string> stopwords)
        {
            List<string> result = words.Except(stopwords).ToList();

            return result;
        }

        public int Count(List<string> words)
        {
            return words.Count;
        }

        public List<string> Split_into_Words(string text)
        {
            var result = text.Split(new [] {DelimiterLeerzeichen}, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            return result;
        }
    }
}
