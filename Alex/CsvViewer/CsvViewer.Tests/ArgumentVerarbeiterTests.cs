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
        [Test]
        [TestCase(new object[] { "Datei.csv" })]
        [TestCase(new object[] { "Datei1.csv", "18" })]
        [TestCase(new object[] { "Datei2.csv", "5" })]
        [TestCase(new object[] { "Datei3.csv", "20" })]
        public void Integration_Lese_Eingabeparameter_mitArgument_Erwarte_Erfolg(string[] args)
        {

            var verarbeiter = new ArgumentVerarbeiter();
            var result = verarbeiter.Lese_Eingabeparameter(args);
        }

        [Test]
        [TestCase(new[] { "Word1", "Word2", "Word3" }, 1)]
        [TestCase(new [] { "Datei1.csv" }, 1)]
        [TestCase(new [] { "Datei2.csv" }, 1)]
        [TestCase(new [] { "Datei3.csv" }, 1)]
        public void Integration_Lese_Eingabeparameter_ohneArgument_Erwarte_Erfolg(string[] args, int a)
        {
            var verarbeiter = new ArgumentVerarbeiter();
            var result = verarbeiter.Lese_Eingabeparameter(args);

            Assert.That(result, Is.EqualTo(Konstanten.StandardSeitenlaenge));
        }

        [Test]
        [TestCase(new[] { "DemoDaten\\Datei1.csv" }, 1)]
        [TestCase(new[] { "DemoDaten\\Datei1.csv", "18" }, 1)]
        [TestCase(new[] { "DemoDaten\\Datei2.csv", "5" }, 1)]
        public void ErmittlePfad_Erwarte_Pfad(string[] args, int a)
        {
            var x = File.Exists("/Users/UseAlba/Documents/workspace/TFSOnline/Schulung_12-2018/Alex/CsvViewer/CsvViewer.Tests/bin/Debug/DemoDaten/Test.csv");
            var xx = new FileInfo("/Users/UseAlba/Documents/workspace/TFSOnline/Schulung_12-2018/Alex/CsvViewer/CsvViewer.Tests/bin/Debug/DemoDaten/Test.csv");



            var verarbeiter = new ArgumentVerarbeiter();
            var result = verarbeiter.Ermittle_Pfad(args);

            Assert.That(result, Is.EqualTo(args[0]));
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
