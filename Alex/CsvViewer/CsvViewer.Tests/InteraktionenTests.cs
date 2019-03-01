using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvViewer.Business;
using CsvViewer.Shared;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class InteraktionenTests : TestBase
    {
        [TestCase(new[] { "DemoDaten/besucher.csv" }, 11)]
        [TestCase(new[] { "DemoDaten/besucher.csv", "3" }, 4)]
        [TestCase(new[] { "DemoDaten/personen.csv", "5" }, 6)]
        public void Start_Erwarte_Erfolg(string[] args, int sollLaenge)
        {
            Interaktionen interaktionen = new Interaktionen();
            var result = interaktionen.Start(args);

            Assert.That(result.Count, Is.EqualTo(sollLaenge));

            Assert.That(Status.Instanz.AktuelleSeitenummer.Lade(), Is.EqualTo(1));
        }

        [TestCase(new[] { "DemoDaten/leer.csv", "20" }, 0)]
        public void Start_mit_leerer_Datei_Erwarte_Exception(string[] args, int x)
        {
            Interaktionen interaktionen = new Interaktionen();

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                var result = interaktionen.Start(args);
            });

            Assert.That(ex.Message, Is.EqualTo("Es wurden keine Datensätze übermittelt."));
            Assert.That(Status.Instanz.AktuelleSeitenummer.Lade(), Is.EqualTo(1));
        }

        [Test]
        [TestCaseSource(nameof(TestCases_NaechsteSeite))]
        public void NaechsteSeite_Erwarte_Erfolg(string[] args, int sollLaenge, List<CsvDatensatz> erwarteteListe)
        {
            Interaktionen interaktionen = new Interaktionen();
            interaktionen.Start(args);
            var result = interaktionen.Naechste_Seite();

            Assert.That(result.Count, Is.EqualTo(sollLaenge));
            Assert.That(Status.Instanz.AktuelleSeitenummer.Lade(), Is.EqualTo(2));

            for (int i = 0; i < result.Count; i++)
            {
                var element = result.ElementAt(i);
                var erwartet = erwarteteListe.ElementAt(i);

                Assert.That(JsonConvert.SerializeObject(element), Is.EqualTo(JsonConvert.SerializeObject(erwartet)));
            }
        }

        public static IEnumerable TestCases_NaechsteSeite
        {
            get
            {
                yield return new TestCaseData(new[] { "DemoDaten/besucher.csv", "3" }, 4, new List<CsvDatensatz>
                                    {
                                        new CsvDatensatz(new List<string> { "Name", "Alter", "Letzter Besuch", "Ort"}),
                                        new CsvDatensatz(new List<string> { "Jupp", "35", "19.10.2009 00:00:00", "Berlin"}),
                                        new CsvDatensatz(new List<string> { "Jopi", "99", "16.04.2011 00:00:00", "Wanne-Eikel"}),
                                        new CsvDatensatz(new List<string> { "Pumuckl", "53", "18.03.2010 00:00:00", "Bottrop"})

                                    });

                yield return new TestCaseData(new[] { "DemoDaten/personen.csv", "5" }, 6, new List<CsvDatensatz>
                                    {
                                        new CsvDatensatz(new List<string> { "Name", "Vorname","Strasse","Ort","Alter"}),
                                        new CsvDatensatz(new List<string> { "Nielsen", "Keane", "851-1918 Morbi St.", "Wilmington", "12"}),
                                        new CsvDatensatz(new List<string> { "Underwood", "Cassidy", "Ap #267-5405 Faucibus Rd.", "La Palma", "67"}),
                                        new CsvDatensatz(new List<string> { "Dickerson", "Finn", "Ap #563-8001 Est. Avenue", "San Bernardino", "52"}),
                                        new CsvDatensatz(new List<string> { "Bonner", "Alexa", "Ap #566-2220 Eget Avenue", "St. George", "87"}),
                                        new CsvDatensatz(new List<string> { "Bates", "Amal", "1158 Vulputate, St.", "Santa Monica", "48"})
                                    });
            }
        }



    }
}
