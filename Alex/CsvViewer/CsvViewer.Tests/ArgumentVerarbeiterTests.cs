using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvViewer.Business;
using CsvViewer.Persistence;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class ArgumentVerarbeiterTests : TestBase
    {
        [Test]
        [TestCase(new [] { "DemoDaten\\besucher.csv" }, Konstanten.StandardSeitenlaenge)]
        [TestCase(new [] { "DemoDaten\\besucher.csv", "18" }, 18)]
        [TestCase(new [] { "DemoDaten\\personen.csv", "5" }, 5)]
        [TestCase(new [] { "DemoDaten\\leer.csv", "20" }, 20)]
        public void Integration_Lese_Eingabeparameter_mitArgument_Erwarte_Erfolg(string[] args, int sollLaenge)
        {
            var verarbeiter = new ArgumentVerarbeiter();
            var result = verarbeiter.Lese_Eingabeparameter(args);
            
            var dir = Path.GetDirectoryName(typeof(ArgumentVerarbeiterTests).Assembly.Location);
            Assert.That(result, Is.EqualTo($"{dir}\\{args[0]}"));

            Assert.That(Status.Instanz.Seitenlaenge.Lade(), Is.EqualTo(sollLaenge));
        }

        [Test]
        [TestCase(new [] { "DemoDaten\\besucher.csv" }, 1)]
        [TestCase(new [] { "DemoDaten\\personen.csv" }, 1)]
        [TestCase(new [] { "DemoDaten\\leer.csv" }, 1)]
        public void Integration_Lese_Eingabeparameter_ohneArgument_Erwarte_Erfolg(string[] args, int a)
        {
            var verarbeiter = new ArgumentVerarbeiter();
            var result = verarbeiter.Lese_Eingabeparameter(args);
            
            var dir = Path.GetDirectoryName(typeof(ArgumentVerarbeiterTests).Assembly.Location);
            Assert.That(result, Is.EqualTo($"{dir}\\{args[0]}"));

            Assert.That(Status.Instanz.Seitenlaenge.Lade(), Is.EqualTo(Konstanten.StandardSeitenlaenge));

        }

        [Test]
        [TestCase(new[] { "DemoDaten\\besucher.csv" }, 1)]
        [TestCase(new[] { "DemoDaten\\besucher.csv", "18" }, 1)]
        [TestCase(new[] { "DemoDaten\\personen.csv", "5" }, 1)]
        public void ErmittlePfad_Erwarte_Pfad(string[] args, int a)
        {
            var verarbeiter = new ArgumentVerarbeiter();
            var result = verarbeiter.Ermittle_Pfad(args);

            var dir = Path.GetDirectoryName(typeof(ArgumentVerarbeiterTests).Assembly.Location);
            Assert.That(result, Is.EqualTo($"{dir}\\{args[0]}"));
        }

        [Test]
        [TestCase(new[] { "Unbekannt.csv" }, 1)]
        public void ErmittlePfad_KeineDatei_Erwarte_Exception(string[] args, int a)
        {
            var verarbeiter = new ArgumentVerarbeiter();

            Assert.Throws(typeof(FileNotFoundException), 
            code: () => {
                var result = verarbeiter.Ermittle_Pfad(args);
            });
        }
    }
}
