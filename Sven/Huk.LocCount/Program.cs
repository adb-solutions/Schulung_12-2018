using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huk.LocCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new LocCount();
            app.Start(args);
            Console.ReadLine();
        }
    }
}
