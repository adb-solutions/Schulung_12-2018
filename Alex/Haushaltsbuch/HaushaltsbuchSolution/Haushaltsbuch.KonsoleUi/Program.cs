using System;
using Haushaltsbuch.Business;
using Haushaltsbuch.Persistence;
using Haushaltsbuch.Shared;
using Money;

namespace Haushaltsbuch.KonsoleUi
{
    public class Programm
    {
        public static void Main(string[] args)
        {
#if DEBUG
            args = new string[] { "einzahlung", "400" };
#endif

            new Interaktionen(new TransaktionenRepository("Buchungsdatenbank.data")).Start(
                args, 
                onEinAuszahlung: (tuple) => {
                    Money<decimal> kassenbestand = tuple.Item1;
                    Kategorie aktuelleKategorie = tuple.Item2;

                    Ui.Zeige_EinAuszahlung(kassenbestand, aktuelleKategorie);
                },
                onUebersicht: (kategorieUebersicht) => {
                    Ui.Zeige_Uebersicht(kategorieUebersicht);
                }
            );
        }
    }
}
