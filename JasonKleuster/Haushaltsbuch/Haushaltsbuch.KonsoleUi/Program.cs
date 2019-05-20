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
            ShowDesign view = new ShowDesign();

            string[] argsTest = new string[] {"auszahlung", "19.05.2019", "5,99", "Restaurant", "Schokobecher"};

            interaktion.Start(argsTest, 
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
