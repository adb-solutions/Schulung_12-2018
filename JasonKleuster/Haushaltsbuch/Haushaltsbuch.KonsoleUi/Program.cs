using Haushaltsbuch.Business;
using Haushaltsbuch.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haushaltsbuch.Shared.BusinessModels;

namespace Haushaltsbuch.KonsoleUi
{
    class Program
    {
        static void Main(string[] args)
        {
            HaushaltsbuchInteraktionen interaktion = new HaushaltsbuchInteraktionen();
            KonsoleDesign view = new KonsoleDesign();

            //string[] argsTest = new string[] { "einzahlung", "13,99" };
            string[] argsTest = new string[] { "auszahlung", "19.05.2019", "15,99", "Einkauf", "Schokobecher" };
            //string[] argsTest = new string[] { "uebersicht", "Mai", "2019" };

            interaktion.Start(argsTest, 
                onZahlung: transaktion =>
                {
                    var dtoModel = interaktion.Zahlung(transaktion);

                    if (dtoModel.Typ == Zahlung.Einzahlung)
                    {
                        view.Einzahlung_anzeigen(dtoModel);
                    }
                    else if (dtoModel.Typ == Zahlung.Auszahlung)
                    {
                        view.Auszahlung_anzeigen(dtoModel);
                    }
                },
                onIndex: index =>
                {
                    var dtoModel = interaktion.Index_anzeigen(index);

                    view.Index_anzeigen(dtoModel);
                }
            );
        }
    }
}
