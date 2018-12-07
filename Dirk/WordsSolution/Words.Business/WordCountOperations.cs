using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words.Business
{
    public static class WordCountOperations
    {
        public static IEnumerable<string> Split_into_words(string text)
        {
            var splittedText = text.Split(' ');

            return splittedText;
        }

        public static IEnumerable<string> Filter(IEnumerable<string> word, IEnumerable<string> stopword)
        {
            IEnumerable<string> filteredWords = word.Except(stopword);

            return filteredWords;
        }

        public static int Count(IEnumerable<string> word)
        {
            int wordCounter = word.Count();

            return wordCounter;
        }
    }
}
