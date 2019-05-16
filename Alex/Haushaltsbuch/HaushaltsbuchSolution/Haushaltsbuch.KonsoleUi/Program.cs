using System;
using Haushaltsbuch.Business;
using Haushaltsbuch.Persistence;
using Haushaltsbuch.Shared;
using NodaMoney;

namespace Haushaltsbuch.KonsoleUi
{
    public class Programm
    {
        public static void Main(string[] args)
        {
#if DEBUG
            args = new string[] { "einzahlung", "400" };
            //args = new string[] { "auszahlung", "5,99", "Restaurantbesuche", "Schokobecher" };
            //args = new string[] { "auszahlung", "01.01.2015", "700", "Miete" };
            //args = new string[] { "einzahlung", "01.01.2015", "400" };
            //args = new string[] { "übersicht" };
            //args = new string[] { "übersicht", "12", "2014" };
            //args = new string[] { "übersicht", "01", "2015" };
#endif

            Ui.Start();

            new Interaktionen(new TransaktionenRepository("Buchungsdatenbank.data")).Start(
                args, 
                onEinAuszahlung: (tuple) => {
                    Money kassenbestand = tuple.Item1;
                    Kategorie aktuelleKategorie = tuple.Item2;

                    Ui.Zeige_EinAuszahlung(kassenbestand, aktuelleKategorie);
                },
                onUebersicht: (kategorieUebersicht) => {
                    Ui.Zeige_Uebersicht(kategorieUebersicht);
                }
            );

            Ui.Ende();
        }
    }
}
