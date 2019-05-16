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
            //args = new string[] { "einzahlung", "400" };
            //args = new string[] { "auszahlung", "5,99", "Restaurantbesuche", "Schokobecher" };
            //args = new string[] { "auszahlung", "01.01.2015", "700", "Miete" };
            //args = new string[] { "einzahlung", "01.01.2015", "400" };
            //args = new string[] { "übersicht" };
            //args = new string[] { "übersicht", "12", "2014" };
            //args = new string[] { "übersicht", "01", "2015" };

            //Hinweis: 228,02 wird in Datum {01.02.0228 00:00:00} geparsed
            //args = new string[] { "auszahlung", "228,02", "Sonstiges" };

            
            //args = new string[] { "einzahlung", "01.01.2015", "700" };
            args = new string[] { "auszahlung", "01.01.2015", "700", "Miete" };
#endif

            Ui.Start();

            Interaktionen interaktionen = new Interaktionen(new TransaktionenRepository("Buchungsdatenbank.data"), new Benutzerabfragen(Ui.Benutzerabfrage_Kategorie_neu_anlegen));

            interaktionen.Start(
                args, 
                onEinAuszahlung: (kassenbestand, aktuelleKategorie) => {
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
