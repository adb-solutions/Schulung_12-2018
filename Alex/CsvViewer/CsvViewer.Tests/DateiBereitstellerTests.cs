using System;
using System.IO;
using CsvViewer.Persistence;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class DateiBereitstellerTests : TestBase
    {
        [Test]
        [TestCase("DemoDaten","besucher.csv", 1001)]
        [TestCase("DemoDaten","personen.csv", 201)]
        [TestCase("DemoDaten","leer.csv", 0)]
        public void Lese_Dateiinhalt_Erwarte_Anzahl_Zeile(string ordner, string dateiname, int erwarteAnzahlZeilen)
        {
            string relPfad = GetRelativePfad(ordner, dateiname);
            string pfad = Path.GetFullPath(relPfad);

            DateiBereitsteller provider = new DateiBereitsteller();
            var zeilen = provider.Lese_Dateiinhalt(pfad);

            Assert.That(zeilen.Count, Is.EqualTo(erwarteAnzahlZeilen));
        }
    }
}
