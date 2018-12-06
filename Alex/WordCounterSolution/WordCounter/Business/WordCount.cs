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
        private Words _words;
        private StopwordsProvider _stopwordsProvider;

        public WordCount(Words words, StopwordsProvider stopwordsProvider)
        {
            _words = words;
            _stopwordsProvider = stopwordsProvider;
        }

        public int Count_Words(string text)
        {
            List<string> words = _words.Split_into_Words(text);
            List<string> stopwords = _stopwordsProvider.Read_Stopwords();

            List<string> gefilterteWords = _words.Filter_Stopwords(words, stopwords);

            var result =_words.Count(gefilterteWords);

            return result;
        }
    }
}
