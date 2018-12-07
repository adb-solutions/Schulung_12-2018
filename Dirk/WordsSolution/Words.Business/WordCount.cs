using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words.Business
{
    public static class WordCount
    {
        public static int Count_words(string text)
        {
            int wordCounter = int.MinValue;

            IEnumerable<string> word = WordCountOperations.Split_into_words(text);

            IEnumerable<string> stopword = StopwordsProvider.Read_stopwords();

            IEnumerable<string> filterWord = WordCountOperations.Filter(word, stopword);

            wordCounter = WordCountOperations.Count(filterWord);

            return wordCounter;
        }
    }
}
