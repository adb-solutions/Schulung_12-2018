using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huk.FlowDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInteraction = new UserInteraction();
            var wordCount = new WordCount();

            var userInputText = userInteraction.GetUserInput();
            var wordCountResult = wordCount.CountWords(userInputText);
            userInteraction.ShowResult(wordCountResult);

        }
    }
}
