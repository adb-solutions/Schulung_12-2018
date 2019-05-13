using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haushaltsbuch.Business;

namespace Haushaltsbuch
{
    class Program
    {
        static void Main(string[] args)
        {
            Buchfuehrung _buchfuehrung = new Buchfuehrung();

            while (true)
            {
                BenutzerInteraktion.Start();

                string text = BenutzerInteraktion.bitteUmEingabe();
                int operation = Buchfuehrung.entscheideOperation(text);
                


            }
        }
    }
}
