using System.Collections.Generic;

namespace SimpleApplication.Business
{
    public class WordCount
    {
        public int Count_Words(string text, string stopwordsFilePath)
        {
            WordCountOperations operations = new WordCountOperations();
            StopwordsProvider provider = new StopwordsProvider();

            string[] words = operations.Split_into_Words(text);
            string[] stopwords = provider.ReadStopwords(stopwordsFilePath);

            List<string> wordList = operations.Filter(words, stopwords);

            int result = operations.Count(wordList);

            return result;
        }
    }
}
