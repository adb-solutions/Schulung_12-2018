using System;
using System.IO;
using System.Linq;
using Haushaltsbuch.Shared;
using Newtonsoft.Json;
using NodaMoney;
using NUnit.Framework;

namespace Haushaltsbuch.Persistence.Tests
{
    [TestFixture]
    public class TransaktionenRepositoryTests
    {
        private const string _testDatenbank = "TransaktionenRepositoryTestsDb.data";
        private TransaktionenRepository _repository;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            if(File.Exists(_testDatenbank))
            {
                File.Delete(_testDatenbank);
            }

            _repository = new TransaktionenRepository(_testDatenbank);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _repository.Dispose();
        }

        [Test]
        public void Kategorie_existiert_Erwarte_Exisitiert()
        {
            string demoKat = "Test_fuer_Kat_exisitiert";
            Transaktion neuerEintrag = new Transaktion(TransaktionTyp.Auszahlung)
            {
                Datum = DateTime.Now,
                Betrag = new Money(0.01),
                Kategorie = demoKat
            };
            _repository.Datensatz_hinzufuegen(neuerEintrag);

            _repository.Kategorie_existiert(demoKat, () =>
            {
                Assert.Pass();
            }, () =>
            {
                Assert.Fail($"Kategorie {demoKat} existiert nicht.");
            });
        }

        [Test]
        public void Kategorie_existiert_Erwarte_Exisitiert_Nicht()
        {
            string demoKat = "Test_fuer_Kat_exisitiert_nicht";

            _repository.Kategorie_existiert(demoKat, () =>
            {
                Assert.Fail($"Kategorie {demoKat} existiert.");
            }, () =>
            {
                Assert.Pass();
            });
        }

        [Test]
        public void Speichere_Eintrag_Erwarte_Erfolg()
        {
            Transaktion neuerEintrag = new Transaktion(TransaktionTyp.Einzahlung)
            {
                Datum = DateTime.Now,
                Betrag = new Money(0.01)
            };
            _repository.Datensatz_hinzufuegen(neuerEintrag);


            string[] datensaetze = File.ReadAllLines(_testDatenbank);

            Assert.That(datensaetze.Last(), Is.EqualTo(JsonConvert.SerializeObject(neuerEintrag)));
        }

        [Test]
        public void Lade_Eintrag_Erwarte_Erfolg()
        {
            Transaktion neuerEintrag = new Transaktion(TransaktionTyp.Einzahlung)
            {
                Datum = DateTime.Now,
                Betrag = new Money(0.01)
            };
            _repository.Datensatz_hinzufuegen(neuerEintrag);

            var transaktionen = _repository.Lade();

            Assert.That(transaktionen.Count, Is.GreaterThan(0));
        }
    }
}
