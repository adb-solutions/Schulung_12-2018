using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huk.FlowDesign
{
    class UserInteraction
    {
        public string GetUserInput() {
            Console.Clear();
            Console.WriteLine("Bitte geben Sie einen Text ein:");
            var textInput =Console.ReadLine();
            return textInput;
        }

        public void ShowResult(WordCountResult wordCountResult) {

            Console.WriteLine(string.Format("Es wurden {0} Wörter gezählt", wordCountResult.CountWords));
        }
    }
}
