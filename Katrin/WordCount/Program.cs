using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        //die UI-Geschichten könnten nochmal außerhalb in einer Program.cs als Main ausgelagert werden
        static void Main(string[] args)
        {
            UI Userinput = new UI();
            var userinput = Userinput.getUserInput();

            WordCount WordInstance = new WordCount();

            var WordCount = WordInstance.Start(userinput);
            Userinput.writeResult(WordCount);

        }
    }
}
