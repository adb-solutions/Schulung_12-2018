using Haushaltsbuch.Business;
using Haushaltsbuch.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.KonsoleUi
{
    class Program
    {
        static void Main(string[] args)
        {
            HaushaltsbuchInteraktionen interaktion = new HaushaltsbuchInteraktionen();
            IHaushaltsbuch dtoModel = interaktion.Start(args);

            if (dtoModel.GetType() == typeof(HaushaltsbuchEinzeln))
            {

            }
            else if (dtoModel.GetType() == typeof(HaushaltsbuchGesamt))
            {

            }
            else
            {
                // FEHLER
            }


        }
    }
}
