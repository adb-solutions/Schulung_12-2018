using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using FlowDesign.Shared;

namespace FlowDesign.Ui
{
    public static class UiM
    {
        private static bool _ersterStart = true;
        internal static void Start()
        {
            if (_ersterStart)
            {
                Willkommen();
            }
        }

        private static void Willkommen()
        {
            Console.WriteLine("Willkommen zum Haushaltsbuch!");
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
        }

        public static void UebersichtAusgeben(Uebersicht uebersicht)
        {
            throw new NotImplementedException();
        }

        public static void AuszahlungAusgeben(decimal kassenbestand, Kategorie kategorie)
        {
            throw new NotImplementedException();
        }

        public static void EinzahlungAusgeben(decimal kassenbestand)
        {
            throw new NotImplementedException();
        }
    }
}
