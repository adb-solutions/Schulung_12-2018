using System;
using FlowDesign.Business;
using FlowDesign.Persistenz;
using FlowDesign.Shared;
using NUnit.Framework;

namespace FlowDesign.UnitTests
{
    [TestFixture]
    public class ArgumentVerarbeiterTest
    {
        [Test]
        [TestCase("01.05.2019", "2019-05-01")]
        [TestCase("01.04.2019", "2019-04-01")]
        [TestCase("30.03.2019", "2019-03-30")]
        [TestCase("01.01.1970", "1970-01-01")]
        public void Ergaenze_Datum_korrektes_Datum_Erwarte_Erfolg(string testDatum, string erwartetesDatum)
        {
            Transaktion t = new Transaktion();
            string[] datumTemp =  new string[] {"a", "b"};

            var werte = ArgumentVerarbeiter.Ergaenze_Datum(t, datumTemp);
            Assert.That(werte.Item1.ZahlungsDatum, Is.EqualTo(DateTime.Parse(erwartetesDatum)));
        }

        [Test]
        [TestCase("30.02.2019")]
        [TestCase("leberkäse")]
        [TestCase("50")]
        [TestCase("510")]
        [TestCase("10")]
        [TestCase("5.30")]
        public void Ergaenze_Datum_ungueltiges_Datum_Erwarte_Aktuelles_Datum(string testDatum)
        {
            //DateTime datum = ArgumentVerarbeiter.Ergaenze_Datum(testDatum);

            //Assert.That(datum.Year, Is.EqualTo(DateTime.Now.Year));
            //Assert.That(datum.Month, Is.EqualTo(DateTime.Now.Month));
            //Assert.That(datum.Day, Is.EqualTo(DateTime.Now.Day));
        }

        [Test]
        public void Ergaenze_Datum_falsches_Datum_Erwarte_Misserfolg()
        {
            //DateTime datum = ArgumentVerarbeiter.Ergaenze_Datum("01.01.2019");

            //Assert.That(datum, Is.Not.EqualTo(new DateTime(2019, 05, 01)));
        }
    }
}
