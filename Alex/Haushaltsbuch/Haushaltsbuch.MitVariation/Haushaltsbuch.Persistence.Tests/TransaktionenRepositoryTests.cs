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
        public void Speichere_Eintrag_Erwarte_Erfolg()
        {
            Transaktion neuerEintrag = new Transaktion(TransaktionTyp.Einzahlung)
            {
                Datum = DateTime.Now,
                Betrag = new Money(0.01)
            };
            _repository.Add_und_Speichern(neuerEintrag);


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
            _repository.Add_und_Speichern(neuerEintrag);

            var transaktionen = _repository.Lade();

            Assert.That(transaktionen.Count, Is.GreaterThan(0));
        }
    }
}
