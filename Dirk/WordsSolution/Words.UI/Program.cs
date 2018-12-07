using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Words.Business;

namespace Words.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var eingabe = UserInteraktion.Bitte_User_um_Eingabe();

            var wordCounter = WordCount.Count_words(eingabe);

            UserInteraktion.Gebe_Ergebnis_aus(wordCounter);
        }
    }
}
