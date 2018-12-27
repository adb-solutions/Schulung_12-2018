using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class WordCount
    {
        public int Start(string userinput)
        {
            WordCountOperations Operator = new WordCountOperations();
            var WordArray = Operator.WordSplitter(userinput);

            StopwordsProvider Provider = new StopwordsProvider();
            string stopwords = Provider.getStopWords();
            var StopWordArray = Operator.WordSplitter(stopwords);

            var WordCount = Operator.WordCounter(Operator.FilterStopWords(WordArray, StopWordArray));
            return WordCount;

        }
    }
}
