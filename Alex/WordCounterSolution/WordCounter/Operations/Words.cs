using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Operations
{
    public class Words
    {
        private char _delimiter_Leerzeichen = ' ';

        public List<string> Filter_Stopwords(List<string> words, List<string> stopwords)
        {
            List<string> result = new List<string>();

            if (words != null && words.Any())
            {
                foreach (var word in words)
                {
                    bool istKeinStopWord = !stopwords.Any(li => li.Equals(word, StringComparison.OrdinalIgnoreCase));
                    if (istKeinStopWord)
                    {
                        result.Add(word);
                    }
                }
            }
            

            //TODO Mit einem Linq Befehl möglich?
            //words.Where(word => stopwords.Any(word));

            return result;
        }

        public int Count(List<string> words)
        {
            int result = 0;

            if (words != null && words.Any())
            {
                result = words.Count;
            }

            return result;
        }

        public List<string> Split_into_Words(string text)
        {
            var result = text.Split(_delimiter_Leerzeichen).Where(word => word != string.Empty).ToList();
            
            return result;
        }
    }
}
