using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleApplication.Business;

namespace SimpleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Config
            string stopwordsFilePath = @"C:\Users\jakl\Documents\Home\Software\Schulung\Lieser\SimpleApplication\SimpleApplication\Config\stopwords.txt";


            // UI
            Console.Write("Enter your text: ");
            string text = Console.ReadLine();


            // Business
            WordCount wordCount = new WordCount();
            int counter = wordCount.Count_Words(text, stopwordsFilePath);


            //UI
            Console.Write("Number of Words: " + counter);
            Console.ReadKey();
        }
    }
}
