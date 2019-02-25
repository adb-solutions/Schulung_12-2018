using System;
using System.Collections;
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
        [TestCaseSource(nameof(TestCases_Lese_Eingabeparameter_mitArgument))]
        public void Lese_Eingabeparameter_mitArgument_Erwarte_Erfolg(string[] args, int sollLaenge)
        {
            var verarbeiter = new ArgumentVerarbeiter();
            var result = verarbeiter.Lese_Eingabeparameter(args);
            
            var dir = Path.GetDirectoryName(typeof(ArgumentVerarbeiterTests).Assembly.Location);
            Assert.That(result, Is.EqualTo($"{dir}{Path.DirectorySeparatorChar}{args[0]}"));

            Assert.That(Status.Instanz.Seitenlaenge.Lade(), Is.EqualTo(sollLaenge));
        }

        public static IEnumerable TestCases_Lese_Eingabeparameter_mitArgument
        {
            get
            {
                yield return new TestCaseData(new[] { $"DemoDaten{Path.DirectorySeparatorChar}besucher.csv" }, Konstanten.StandardSeitenlaenge);
                yield return new TestCaseData(new[] { $"DemoDaten{Path.DirectorySeparatorChar}besucher.csv", "18" }, 18);
                yield return new TestCaseData(new[] { $"DemoDaten{Path.DirectorySeparatorChar}personen.csv", "5" }, 5);
                yield return new TestCaseData(new[] { $"DemoDaten{Path.DirectorySeparatorChar}leer.csv", "20" }, 20);
            }
        }

        [Test]
        [TestCaseSource(nameof(TestCases_Lese_Eingabeparameter_ohneArgument))]
        public void Lese_Eingabeparameter_ohneArgument_Erwarte_Erfolg(string[] args, int a)
        {
            var verarbeiter = new ArgumentVerarbeiter();
            var result = verarbeiter.Lese_Eingabeparameter(args);

            var dir = Path.GetDirectoryName(typeof(ArgumentVerarbeiterTests).Assembly.Location);
            Assert.That(result, Is.EqualTo($"{dir}{Path.DirectorySeparatorChar}{args[0]}"));

            Assert.That(Status.Instanz.Seitenlaenge.Lade(), Is.EqualTo(Konstanten.StandardSeitenlaenge));
        }

        public static IEnumerable TestCases_Lese_Eingabeparameter_ohneArgument
        {
            get
            {
                yield return new TestCaseData(new[] { $"DemoDaten{Path.DirectorySeparatorChar}besucher.csv" }, 1);
                yield return new TestCaseData(new[] { $"DemoDaten{Path.DirectorySeparatorChar}personen.csv" }, 1);
                yield return new TestCaseData(new[] { $"DemoDaten{Path.DirectorySeparatorChar}leer.csv" }, 1);
            }
        }


        [Test]
        [TestCaseSource(nameof(TestCases_ErmittlePfad))]
        public void ErmittlePfad_Erwarte_Pfad(string[] args, int a)
        {
            var verarbeiter = new ArgumentVerarbeiter();
            var result = verarbeiter.Ermittle_Pfad(args);

            var dir = Path.GetDirectoryName(typeof(ArgumentVerarbeiterTests).Assembly.Location);
            Assert.That(result, Is.EqualTo($"{dir}{Path.DirectorySeparatorChar}{args[0]}"));
        }

        public static IEnumerable TestCases_ErmittlePfad
        {
            get
            {
                yield return new TestCaseData(new string[] { $"DemoDaten{Path.DirectorySeparatorChar}besucher.csv" }, 1);
                yield return new TestCaseData(new string[] { $"DemoDaten{Path.DirectorySeparatorChar}besucher.csv", "18" }, 1);
                yield return new TestCaseData(new string[] { $"DemoDaten{Path.DirectorySeparatorChar}personen.csv", "5" }, 1);
            }
        }

        [Test]
        [TestCase(new[] { "Unbekannt.csv" }, "Datei Unbekannt.csv nicht gefunden.")]
        public void ErmittlePfad_KeineDatei_Erwarte_Exception(string[] args, string erwartet)
        {
            var verarbeiter = new ArgumentVerarbeiter();

            Exception ex = Assert.Throws(typeof(FileNotFoundException),
            () =>
            {
                var result = verarbeiter.Ermittle_Pfad(args);
            });
            Assert.That(ex.Message, Is.EqualTo(erwartet));
        }
    }
}
