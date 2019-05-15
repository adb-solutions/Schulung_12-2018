using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOC_Counter.Konsole.App;

namespace LOC_Counter.Konsole
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[] { @"C:\Temp\Code" };

            Process process = new Process();
            process.Start(args);
        }
    }
}
