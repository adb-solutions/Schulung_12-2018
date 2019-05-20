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

            //string[] test = new string[] { "einzahlung", "13,99" };
            //string[] test = new string[] { "auszahlung", "19.05.2019", "15,99", "Einkauf", "Schokobecher" };
            string[] test = new string[] { "uebersicht", "Mai", "2019" };

            interaktion.Start(test, 
                onZahlung: transaktion =>
                {
                    var dtoModel = interaktion.Zahlung(transaktion);

                    if (dtoModel.Typ == Zahlung.Einzahlung)
                    {
                        view.EinzahlungAnzeigen(dtoModel);
                    }
                    else if (dtoModel.Typ == Zahlung.Auszahlung)
                    {
                        view.AuszahlungAnzeigen(dtoModel);
                    }
                },
                onIndex: index =>
                {
                    var dtoModel = interaktion.Index_anzeigen(index);

                    view.IndexAnzeigen(dtoModel);
                }
            );
        }
    }
}
