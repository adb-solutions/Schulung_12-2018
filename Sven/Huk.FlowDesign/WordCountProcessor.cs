using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huk.FlowDesign
{
    public class WordCountProcessor
    {
        private static char[] splitCharacters = new char[] { ' ', ',', '.', '!', ';','?' };

        public IList<string> SplitIntoWords(string textToSplit) {

            List<string> WordList = new List<string>();

            if (!string.IsNullOrEmpty(textToSplit)) {
                var WordArray= textToSplit.Split(splitCharacters, StringSplitOptions.RemoveEmptyEntries);
                WordList.AddRange(WordArray);

            }

            return WordList;

        }
        public WordCountResult Count(IList<string> WordsToCount) {

            var result = new WordCountResult();
            result.CountWords = WordsToCount.Count;

            return result;

        }
        public IList<string> FilterWords(IList<string> WordsToFilter, IList<string> FilterWords) {

           var filteredWords= WordsToFilter.Where(T => !FilterWords.Contains(T));

            return filteredWords.ToList();
        }
    }
}
