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
    public class ArgumentVerarbeiterTests
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var dir = Path.GetDirectoryName(typeof(ArgumentVerarbeiterTests).Assembly.Location);
            if (dir != null)
            {
                Environment.CurrentDirectory = dir;
                Directory.SetCurrentDirectory(dir);
            }
            else
                throw new Exception("Path.GetDirectoryName(typeof(TestingWithReferencedFiles).Assembly.Location) returned null");
        }

        [Test]
        [TestCase(new [] { "DemoDaten\\Datei1.csv" }, Konstanten.StandardSeitenlaenge)]
        [TestCase(new [] { "DemoDaten\\Datei1.csv", "18" }, 18)]
        [TestCase(new [] { "DemoDaten\\Datei2.csv", "5" }, 5)]
        [TestCase(new [] { "DemoDaten\\Test.csv", "20" }, 20)]
        public void Integration_Lese_Eingabeparameter_mitArgument_Erwarte_Erfolg(string[] args, int sollLaenge)
        {
            var verarbeiter = new ArgumentVerarbeiter();
            var result = verarbeiter.Lese_Eingabeparameter(args);
            
            var dir = Path.GetDirectoryName(typeof(ArgumentVerarbeiterTests).Assembly.Location);
            Assert.That(result, Is.EqualTo($"{dir}\\{args[0]}"));

            Assert.That(Status.Instanz.Seitenlaenge.Lade(), Is.EqualTo(sollLaenge));
        }

        [Test]
        [TestCase(new [] { "DemoDaten\\Datei1.csv" }, 1)]
        [TestCase(new [] { "DemoDaten\\Datei2.csv" }, 1)]
        [TestCase(new [] { "DemoDaten\\Test.csv" }, 1)]
        public void Integration_Lese_Eingabeparameter_ohneArgument_Erwarte_Erfolg(string[] args, int a)
        {
            var verarbeiter = new ArgumentVerarbeiter();
            var result = verarbeiter.Lese_Eingabeparameter(args);
            
            var dir = Path.GetDirectoryName(typeof(ArgumentVerarbeiterTests).Assembly.Location);
            Assert.That(result, Is.EqualTo($"{dir}\\{args[0]}"));

            Assert.That(Status.Instanz.Seitenlaenge.Lade(), Is.EqualTo(Konstanten.StandardSeitenlaenge));

        }

        [Test]
        [TestCase(new[] { "DemoDaten\\Datei1.csv" }, 1)]
        [TestCase(new[] { "DemoDaten\\Datei1.csv", "18" }, 1)]
        [TestCase(new[] { "DemoDaten\\Datei2.csv", "5" }, 1)]
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
