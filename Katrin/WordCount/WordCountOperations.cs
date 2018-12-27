using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WordCount
{
    public class WordCountOperations
    {
        public ArrayList WordSplitter(string words)
        {
            var wordArray = new ArrayList(words.Split(' '));
            return wordArray;
        }

        public int WordCounter(ArrayList wordArray)
        {
            var count = wordArray.Count;
                return count;
        }

        public ArrayList FilterStopWords(ArrayList words, ArrayList stopwords)
        {
            var newArray = new ArrayList();
            for (int i = 0; i < words.Count; i++)
            {
                var helper = stopwords.Contains(words[i]);
                if (helper == false)
                {
                    newArray.Add(words[i]);
                }
            }
            return newArray;
        }
    }
}
