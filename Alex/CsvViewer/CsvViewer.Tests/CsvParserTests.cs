using System;
using System.Collections.Generic;
using System.Linq;
using CsvViewer.Business;
using CsvViewer.Shared;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class CsvParserTests : TestBase
    {
        [Test]
        public void Zerlege_Csv_in_CsvDatensaetze_Erwarte_Erfolg()
        {
            List<CsvDatensatz> erwarte = new List<CsvDatensatz>();
            erwarte.Add(new CsvDatensatz(new List<string>() { "Jopi", "55", "03.04.2010 00:00:00", "Wanne-Eikel" }));
            erwarte.Add(new CsvDatensatz(new List<string>() { "Pumuckl", "70", "15.08.2010 00:00:00", "Bottrop" }));
            erwarte.Add(new CsvDatensatz(new List<string>() { "Hanna", "89", "19.01.2011 00:00:00", "Essen" }));

            List<string> zeilen = new List<string>();
            zeilen.Add("Jopi;55;03.04.2010 00:00:00;Wanne-Eikel");
            zeilen.Add("Pumuckl;70;15.08.2010 00:00:00;Bottrop");
            zeilen.Add("Hanna;89;19.01.2011 00:00:00;Essen");


            CsvParser parser = new CsvParser();
            List<CsvDatensatz> result = parser.Zerlege_Csv_in_CsvDatensaetze(zeilen).ToList();

            Assert.That(result.Count, Is.EqualTo(erwarte.Count));

            string[] sarray = new string[] { "a", "b", "c" };
            Assert.That(new string[] { "c", "a", "b" }, Is.EquivalentTo(sarray));

            for(int i = 0; i < result.Count; i++)
            {
                var erwartet = erwarte[i].Werte.ToArray();
                var elem = result[i].Werte.ToArray();

                Assert.That(elem, Is.EquivalentTo(erwartet));
            }
        }
    }
}
