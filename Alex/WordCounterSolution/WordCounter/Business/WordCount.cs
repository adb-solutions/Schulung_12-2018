using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Operations;
using WordCounter.Provider;

namespace WordCounter.Business
{
    public class WordCount
    {
        private readonly Words _words;
        private readonly StopwordsProvider _stopwordsProvider;

        public WordCount()
        {
            _words = new Words();
            _stopwordsProvider = new StopwordsProvider();
        }

        public WordCount(StopwordsProvider stopwordsProvider)
        {
            _words = new Words();
            _stopwordsProvider = stopwordsProvider;
        }

        public int Count_Words(string text)
        {
            List<string> words = _words.Split_into_Words(text);
            List<string> stopwords = _stopwordsProvider.Read_Stopwords();

            List<string> gefilterteWords = _words.Filter_Stopwords(words, stopwords);

            int result =_words.Count(gefilterteWords);

            return result;
        }
    }
}
