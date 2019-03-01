using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huk.CsvParser
{
    class CommandLineUserInterface
    {
        public event EventHandler FirstPage;
        public event EventHandler NextPage;
        public event EventHandler PreviousPage;
        public event EventHandler LastPage;
        public event EventHandler Exit;

        public void Show(Page page2View)
        {
            Console.Clear();
            Dictionary<string, int> maxFieldValues = determineMax(page2View);
          
            ShowHeader(maxFieldValues);
            //TODO:hier weiter
           
        }

        private  void ShowHeader(Dictionary<string, int> maxFieldValues)
        {
            int all = maxFieldValues.Count + maxFieldValues.Values.Sum();
            Console.WriteLine(new string('*', all));
            foreach (KeyValuePair<string, int> field in maxFieldValues)
            {
                Console.Write('*');
                Console.Write(field.Key);
                Console.Write(new string(' ', field.Value - field.Key.Length));
            }
            Console.WriteLine("*");
            Console.WriteLine(new string('*', all));

        }

        private static Dictionary<string, int> determineMax(Page page2View)
        {
            Dictionary<string, int> maxFieldValues = new Dictionary<string, int>();
            for (int i = 0; i < page2View.FieldNames.Length; i++)
            {
                maxFieldValues.Add(page2View.FieldNames[i], page2View.Records.Max(T => T.ToArray()[i].Length));
            }
            return maxFieldValues;
        }
    }
}
