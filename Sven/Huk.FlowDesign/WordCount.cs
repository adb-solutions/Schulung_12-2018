using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huk.FlowDesign
{
    public class WordCount
    {
        public WordCountResult CountWords(string textToCount) {

            
            var stopWordProvider = new StopWordProvider();
            var wordCountProcessor = new WordCountProcessor();

            var stopWordList = stopWordProvider.ReadStopWords();
            var textWordList = wordCountProcessor.SplitIntoWords(textToCount);

            textWordList = wordCountProcessor.FilterWords(textWordList, stopWordList);

            var result = wordCountProcessor.Count(textWordList);

            return result;

        }
    }
}
