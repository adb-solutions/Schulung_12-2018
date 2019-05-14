using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Haushaltsbuch.Shared;
using Money;

namespace Haushaltsbuch.KonsoleUi
{
    public static class Ui
    {
        private static bool _isFirstRun = true;

        private static void Willkommen()
        {
            Meldung(@"██╗  ██╗ █████╗ ██╗   ██╗███████╗██╗  ██╗ █████╗ ██╗  ████████╗███████╗██████╗ ██╗   ██╗ ██████╗██╗  ██╗");
            Meldung(@"██║  ██║██╔══██╗██║   ██║██╔════╝██║  ██║██╔══██╗██║  ╚══██╔══╝██╔════╝██╔══██╗██║   ██║██╔════╝██║  ██║");
            Meldung(@"███████║███████║██║   ██║███████╗███████║███████║██║     ██║   ███████╗██████╔╝██║   ██║██║     ███████║");
            Meldung(@"██╔══██║██╔══██║██║   ██║╚════██║██╔══██║██╔══██║██║     ██║   ╚════██║██╔══██╗██║   ██║██║     ██╔══██║");
            Meldung(@"██║  ██║██║  ██║╚██████╔╝███████║██║  ██║██║  ██║███████╗██║   ███████║██████╔╝╚██████╔╝╚██████╗██║  ██║");
            Meldung(@"╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝╚═╝   ╚══════╝╚═════╝  ╚═════╝  ╚═════╝╚═╝  ╚═╝");

            Leerzeile();
            Meldung($"Herzlich Willkommen beim Haushaltsbuch - Version {typeof(Programm).Assembly.GetName().Version}");
            Aufrufmoeglichkeiten();
        }

        public static void Aufrufmoeglichkeiten()
        {
            Meldung("Folgende Aufrufe sind möglich:");
            Meldung("Einzahlung: hb einzahlung [datum] betrag");
            Meldung("Auszahlung: hb auszahlung [datum] betrag kategorie [memo]");
            Meldung("Übersicht: hb uebersicht");
            Leerzeile();
        }

        public static void Zeige_EinAuszahlung(Money<decimal> kassenbestand, Kategorie kategorie)
        {

        }

        public static void Zeige_Uebersicht(KategorieUebersicht)
        {

        }

        public static void Start()
        {
            if (_isFirstRun)
            {
                Willkommen();
            }
        }

        private static void Leerzeile()
        {
            Console.WriteLine();
        }

        private static void Meldung_ohne_Umbruch(string text)
        {
            Console.Write(text);
        }

        private static void Meldung(string text)
        {
            Console.WriteLine(text);
        }
    }
}
