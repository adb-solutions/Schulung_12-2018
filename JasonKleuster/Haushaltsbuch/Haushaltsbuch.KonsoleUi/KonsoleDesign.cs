using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haushaltsbuch.Shared;

namespace Haushaltsbuch.KonsoleUi
{
    public class KonsoleDesign
    {
        public void Einzahlung_anzeigen(HaushaltsbuchEinzeln viewModel)
        {
            Console.WriteLine();
            Attribut_anzeigen("Kassenbestand", viewModel.Kassenbestand.ToString());

            Console.ReadKey();
        }

        public void Auszahlung_anzeigen(HaushaltsbuchEinzeln viewModel)
        {
            Console.WriteLine();
            Attribut_anzeigen("Kassenbestand", viewModel.Kassenbestand.ToString());
            Attribut_anzeigen(viewModel.Kategorie.Bezeichnung, viewModel.Kategorie.Gesamtbetrag.ToString());

            Console.ReadKey();
        }

        public void Index_anzeigen(HaushaltsbuchGesamt viewModel)
        {
            Console.WriteLine();
            Monat_und_Jahr_anzeigen(viewModel.Monat, viewModel.Jahr);
            Attribut_anzeigen("Kassenbestand", viewModel.Kassenbestand.ToString());

            foreach (var kategorie in viewModel.Kategorien)
            {
                Attribut_anzeigen(kategorie.Bezeichnung, kategorie.Gesamtbetrag.ToString());
            }

            Console.ReadKey();
        }

        private void Attribut_anzeigen(string bezeichnung, string wert)
        {
            Console.WriteLine($"{bezeichnung}: {wert}");
        }

        private void Monat_und_Jahr_anzeigen(string monat, string jahr)
        {
            Console.WriteLine($"{monat} {jahr}");
            Console.WriteLine($"---------------------------");
        }
    }
}
