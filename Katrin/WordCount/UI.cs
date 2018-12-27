using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class UI
    {
        public string getUserInput()
        {
            Console.WriteLine("Enter your text:");
            return Console.ReadLine();
        }

        public void writeResult(int count)
        {
            Console.WriteLine("Number of words:" + count);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
