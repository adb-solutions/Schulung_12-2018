using System.Collections.Generic;

namespace SimpleApplication.Business
{
    public class WordCountOperations
    {
        public string[] Split_into_Words(string text)
        {
            string[] words = text.Split(' ');
            return words;
        }

        public List<string> Filter(string[] words, string[] stopwords)
        {
            List<string> wordList = new List<string>();

            foreach (var word in words)
            {
                bool stopped = false;

                foreach (var stopword in stopwords)
                {
                    if (word == stopword)
                    {
                        stopped = true;
                    }
                }

                if (!stopped)
                {
                    wordList.Add(word);
                }
            }

            return wordList;
        }

        public int Count(List<string> words)
        {
            int result = words.Count;
            return result;
        }
    }
}
