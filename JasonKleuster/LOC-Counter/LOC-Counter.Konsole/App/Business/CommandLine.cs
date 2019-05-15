using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOC_Counter.Konsole.App
{
    class CommandLine
    {
        public string GetPath(string[] args)
        {
            return args.First();
        }
    }
}
