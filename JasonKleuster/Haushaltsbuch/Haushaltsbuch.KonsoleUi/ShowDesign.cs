using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haushaltsbuch.Shared;

namespace Haushaltsbuch.KonsoleUi
{
    public class ShowDesign
    {
        public void EinzahlungAnzeigen(HaushaltsbuchEinzeln viewModel)
        {
            Console.WriteLine();
            AttributAnzeigen("Kassenbestand", viewModel.Kassenbestand.ToString());

            Console.ReadKey();
        }

        public void AuszahlungAnzeigen(HaushaltsbuchEinzeln viewModel)
        {
            Console.WriteLine();
            AttributAnzeigen("Kassenbestand", viewModel.Kassenbestand.ToString());
            AttributAnzeigen(viewModel.Kategorie.Bezeichnung, viewModel.Kategorie.Gesamtbetrag.ToString());

            Console.ReadKey();
        }

        public void IndexAnzeigen(HaushaltsbuchGesamt viewModel)
        {
            Console.WriteLine();
            MonatJahrAnzeigen(viewModel.Monat, viewModel.Jahr);
            AttributAnzeigen("Kassenbestand", viewModel.Kassenbestand.ToString());

            foreach (var kategorie in viewModel.Kategorien)
            {
                AttributAnzeigen(kategorie.Bezeichnung, kategorie.Gesamtbetrag.ToString());
            }

            Console.ReadKey();
        }

        private void AttributAnzeigen(string bezeichnung, string wert)
        {
            Console.WriteLine($"{bezeichnung}: {wert}");
        }

        private void MonatJahrAnzeigen(string monat, string jahr)
        {
            Console.WriteLine($"{monat} {jahr}");
            Console.WriteLine($"---------------------------");
        }
    }
}
