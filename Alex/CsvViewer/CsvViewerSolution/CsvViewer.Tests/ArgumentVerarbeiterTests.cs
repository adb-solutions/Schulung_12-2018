using NUnit.Framework;
using CsvViewer.Persistence;

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
            new DateiBereitsteller();


            var verarbeiter = new ArgumentVerarbeiter();
            var result = verarbeiter.Lese_Eingabeparameter(args);
        }

        [Test]
        [TestCase(new object[] { "Datei.csv" })]
        [TestCase(new object[] { "Datei1.csv" })]
        [TestCase(new object[] { "Datei2.csv" })]
        [TestCase(new object[] { "Datei3.csv" })]
        public void Integration_Lese_Eingabeparameter_ohneArgument_Erwarte_Erfolg(string[] args)
        {
            var verarbeiter = new ArgumentVerarbeiter();
            var result = verarbeiter.Lese_Eingabeparameter(args);

            Assert.That(result, Is.EqualTo(Konstanten.StandardSeitenlaenge));
        }

        [Test]
        [TestCase(new object[] { "Datei.csv" })]
        [TestCase(new object[] { "Datei1.csv", "18" })]
        [TestCase(new object[] { "Datei2.csv", "5" })]
        [TestCase(new object[] { "Datei3.csv", "20" })]
        public void ErmittlePfad_mitArgument_Erwarte_Ok(string[] args)
        {
            var verarbeiter = new ArgumentVerarbeiter();
            var result = verarbeiter.Ermittle_Pfad(args);

            Assert.That(result, Is.EqualTo(args[0]));
        }

        [Test]
        [TestCase(new object[] { "Datei.csv" })]
        public void ErmittlePfad_ohneArgument_Erwarte_Standardlaenge(string[] args)
        {
            var verarbeiter = new ArgumentVerarbeiter();
            var result = verarbeiter.Ermittle_Pfad(args);

            Assert.That(result, Is.EqualTo(Konstanten.StandardSeitenlaenge));
        }
    }
}
