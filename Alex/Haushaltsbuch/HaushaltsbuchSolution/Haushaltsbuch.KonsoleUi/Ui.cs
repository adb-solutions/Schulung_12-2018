using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.Versioning;
using Haushaltsbuch.KonsoleUi.Helper;
using Haushaltsbuch.Shared;
using NodaMoney;

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
            Meldung($"╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝╚═╝   ╚══════╝╚═════╝  ╚═════╝  ╚═════╝╚═╝  ╚═╝ v{VersionsHelper.GetVersionsnummer(Assembly.GetAssembly(typeof(Programm)))}");
            
            Leerzeile();
            //Aufrufmoeglichkeiten();
        }

        public static void Aufrufmoeglichkeiten()
        {
            Meldung("Folgende Aufrufe sind möglich:");
            Meldung("\ta) Einzahlung tätigen:\thb einzahlung [datum] betrag");
            Meldung("\tb) Auszahlung tätigen:\thb auszahlung [datum] betrag kategorie [memo]");
            Meldung("\tc) Übersicht anzeigen:\thb uebersicht");
            Leerzeile();
        }

        public static void Ende()
        {
            Meldung(@"========================================================================================================");
        }

        public static void Zeige_EinAuszahlung(Money kassenbestand, Kategorie kategorie)
        {
            Leerzeile();
            Meldung($"Kassenbestand: {kassenbestand.Amount} {kassenbestand.Currency.Code}");

            if(kategorie != null && ! string.IsNullOrEmpty(kategorie.Bezeichnung))
            {
                Meldung($"{kategorie.Bezeichnung}: {kategorie.Summe.Amount} {kategorie.Summe.Currency.Code}");
            }
        }

        public static void Zeige_Uebersicht(KategorieUebersicht uebersicht)
        {
            Leerzeile();

            var monatsName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(uebersicht.Datum.Month);
            Meldung($"{monatsName} {uebersicht.Datum.Year}");
            Meldung("--------------------");
            Meldung($"Kassenbestand: {uebersicht.Kassenbestand.Amount} {uebersicht.Kassenbestand.Currency.Code}");

            foreach(var kategorie in uebersicht.Kategorien)
            {
                Meldung($"{kategorie.Bezeichnung}: {kategorie.Summe.Amount} {kategorie.Summe.Currency.Code}");
            }
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
