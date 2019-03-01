using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvViewer.Business;
using CsvViewer.Shared;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class SeitenBereitstellerTests : TestBase
    {
        List<CsvDatensatz> demoDaten = new List<CsvDatensatz>
                                        {
                                            new CsvDatensatz(new List<string> { "Name", "Alter", "Letzter Besuch", "Ort"}),
                                            new CsvDatensatz(new List<string> { "Peter", "69", "01.08.2010 00:00:00", "Köln"}),
                                            new CsvDatensatz(new List<string> { "Paul", "97", "25.03.2011 00:00:00", "München"}),
                                            new CsvDatensatz(new List<string> { "Maria", "74", "12.09.2010 00:00:00", "Hamburg"}),

                                            new CsvDatensatz(new List<string> { "Jupp", "35", "19.10.2009 00:00:00", "Berlin"}),
                                            new CsvDatensatz(new List<string> { "Jopi", "99", "16.04.2011 00:00:00", "Wanne-Eikel"}),
                                            new CsvDatensatz(new List<string> { "Pumuckl", "53", "18.03.2010 00:00:00", "Bottrop"}),

                                            new CsvDatensatz(new List<string> { "Hanna", "85", "19.12.2010 00:00:00", "Essen"}),
                                            new CsvDatensatz(new List<string> { "Jakob", "84", "11.12.2010 00:00:00", "Wuppertal"}),
                                            new CsvDatensatz(new List<string> { "Stefan", "51", "04.03.2010 00:00:00", "Köln"}),

                                            new CsvDatensatz(new List<string> { "Karli", "51", "04.03.2010 00:00:00", "München"}),
                                            new CsvDatensatz(new List<string> { "Mike", "9", "11.03.2009 00:00:00", "Hamburg"}),
                                            new CsvDatensatz(new List<string> { "Mausi", "30", "07.09.2009 00:00:00", "Berlin"}),

                                            new CsvDatensatz(new List<string> { "Peter", "6", "15.02.2009 00:00:00", "Wanne-Eikel"}),
                                            new CsvDatensatz(new List<string> { "Paul", "66", "12.07.2010 00:00:00", "Bottrop"}),
                                            new CsvDatensatz(new List<string> { "Maria", "10", "23.03.2009 00:00:00", "Essen"}),

                                            new CsvDatensatz(new List<string> { "Jupp", "5", "04.02.2009 00:00:00", "Wuppertal"}),
                                            new CsvDatensatz(new List<string> { "Jopi", "43", "28.12.2009 00:00:00", "Köln"}),
                                            new CsvDatensatz(new List<string> { "Pumuckl", "24", "14.07.2009 00:00:00", "München"}),

                                            new CsvDatensatz(new List<string> { "Hanna", "37", "04.11.2009 00:00:00", "Hamburg"}),
                                            new CsvDatensatz(new List<string> { "Jakob", "8", "05.03.2009 00:00:00", "Berlin"})
                                        };

        [Test]
        [TestCase(3, 7)]
        [TestCase(4, 5)]
        public void Ermittle_Seitennummer_Letzte_Seite_Erwarte_Erfolg(int seitenlaenge, int erwartet)
        {
            var seitenBereitsteller = new SeitenBereitsteller();
            int result = seitenBereitsteller.Ermittle_Seitennummer_Letzte_Seite(demoDaten, seitenlaenge);

            Assert.That(result, Is.EqualTo(erwartet));
        }

        [Test]
        public void Filtere_Seite_innerhalb_des_Geltungsbereich_Erwarte_konkrete_Elemente()
        {
            var seitenBereitsteller = new SeitenBereitsteller();
            List<CsvDatensatz> result = seitenBereitsteller.Filtere_Seite(demoDaten, 3, 3);

            Assert.That(result.Count, Is.EqualTo(3 + 1));

            List<CsvDatensatz> erwarteteListe = new List<CsvDatensatz>
            {
                new CsvDatensatz(new List<string> { "Name", "Alter", "Letzter Besuch", "Ort"}),
                new CsvDatensatz(new List<string> {"Hanna", "85", "19.12.2010 00:00:00", "Essen"}),
                new CsvDatensatz(new List<string> {"Jakob", "84", "11.12.2010 00:00:00", "Wuppertal"}),
                new CsvDatensatz(new List<string> { "Stefan", "51", "04.03.2010 00:00:00", "Köln"})
            };

            for (int i = 0; i < result.Count; i++)
            {
                var element = result.ElementAt(i);
                var erwartet = erwarteteListe.ElementAt(i);

                Assert.That(JsonConvert.SerializeObject(element), Is.EqualTo(JsonConvert.SerializeObject(erwartet)));
            }
        }

        [Test]
        public void Filtere_Seite_ueber_Geltungsbereich_hinaus_Erwarte_konkrete_Elemente()
        {
            var seitenBereitsteller = new SeitenBereitsteller();
            List<CsvDatensatz> result = seitenBereitsteller.Filtere_Seite(demoDaten, 3, 7);


            Assert.That(result.Count, Is.EqualTo(2 + 1));

            List<CsvDatensatz> erwarteteListe = new List<CsvDatensatz>
            {
                new CsvDatensatz(new List<string> { "Name", "Alter", "Letzter Besuch", "Ort"}),
                new CsvDatensatz(new List<string> { "Hanna", "37", "04.11.2009 00:00:00", "Hamburg"}),
                new CsvDatensatz(new List<string> { "Jakob", "8", "05.03.2009 00:00:00", "Berlin"})
            };

            for (int i = 0; i < result.Count; i++)
            {
                var element = result.ElementAt(i);
                var erwartet = erwarteteListe.ElementAt(i);

                Assert.That(JsonConvert.SerializeObject(element), Is.EqualTo(JsonConvert.SerializeObject(erwartet)));
            }

        }

        [Test]
        public void Filtere_Seite_ausserhalb_Geltungsbereich_Erwarte_nur_Kopfzeile()
        {
            var seitenBereitsteller = new SeitenBereitsteller();
            List<CsvDatensatz> result = seitenBereitsteller.Filtere_Seite(demoDaten, 3, 8);


            Assert.That(result.Count, Is.EqualTo(1));

            List<CsvDatensatz> erwarteteListe = new List<CsvDatensatz>
            {
                new CsvDatensatz(new List<string> { "Name", "Alter", "Letzter Besuch", "Ort"})
            };

            for (int i = 0; i < result.Count; i++)
            {
                var element = result.ElementAt(i);
                var erwartet = erwarteteListe.ElementAt(i);

                Assert.That(JsonConvert.SerializeObject(element), Is.EqualTo(JsonConvert.SerializeObject(erwartet)));
            }
        }

        [Test]
        public void Filtere_Seite_mit_leeren_Daten_Erwarte_Exception()
        {
            var seitenBereitsteller = new SeitenBereitsteller();

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                List<CsvDatensatz> result = seitenBereitsteller.Filtere_Seite(new List<CsvDatensatz>(), 3, 8);
            });

            Assert.That(ex.Message, Is.EqualTo("Es wurden keine Datensätze übermittelt."));
        }

        [Test]
        [TestCase(10, 1, 11)]
        [TestCase(10, 2, 11)]
        [TestCase(3, 7, 3)]
        [TestCase(3, 8, 1)]
        public void Filtere_Seite_Erwarte_angegebene_Anzahl(int seitenlaenge, int gewuenschteSeite, int erwarteteAnzahl)
        {
            var seitenBereitsteller = new SeitenBereitsteller();
            List<CsvDatensatz> result = seitenBereitsteller.Filtere_Seite(demoDaten, seitenlaenge, gewuenschteSeite);

            Assert.That(result.Count, Is.EqualTo(erwarteteAnzahl));
        }
    }
}
