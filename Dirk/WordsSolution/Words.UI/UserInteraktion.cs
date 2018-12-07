using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words.UI
{
    public static class UserInteraktion
    {
        public static string Bitte_User_um_Eingabe()
        {
            Console.WriteLine("WordCount");
            Console.WriteLine("Enter your text:");

            var eingabe = Console.ReadLine();

            return eingabe;
        }

        public static void Gebe_Ergebnis_aus(int wordCounter)
        {
            Console.WriteLine($"Number of words: {wordCounter}");
            Console.ReadKey();
        }
    }
}
