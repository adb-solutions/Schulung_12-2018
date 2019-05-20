using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Haushaltsbuch.Business;
using Haushaltsbuch.Shared.BusinessModels;

namespace Haushaltsbuch.Tests
{
    [TestFixture]
    public class ArgumentVerarbeiterTests
    {
        [Test]
        [TestCase(new[] { "12.05.2019", "57,99", "Freizeit" }, "2019-05-12")]
        [TestCase(new[] { "01.01.2019", "57,99", "Freizeit" }, "2019-01-01")]
        [TestCase(new[] { "31.12.1970", "57,99", "Freizeit" }, "1970-12-31")]
        public void Teste_Parameter_Datum_auslesen_erfolgreich(string[] inputArgs, string erwartet)
        {
            var transaktion = new Transaktion();

            ArgumentVerarbeiter verarbeiter = new ArgumentVerarbeiter();
            verarbeiter.Parameter_Datum_auslesen(inputArgs, transaktion);

            Assert.That(transaktion.Datum, Is.EqualTo(DateTime.Parse((erwartet))));
        }

        [Test]
        //[TestCase(new[] { "31.02.2019", "Freizeit" }, "")]
        //[TestCase(new[] { "bartwurst", "Freizeit" }, "")]
        //[TestCase(new[] { "10", "Freizeit" }, "")]
        //[TestCase(new[] { "5,99", "Freizeit" }, "")]
        [TestCase(new[] { "228,02", "Freizeit" }, "")]
        public void ParameterDatumAuslesen_ungueltiges_Datum_Erwarte_DateTimeNow(string[] inputArgs, string x)
        {
            var transaktion = new Transaktion();

            ArgumentVerarbeiter verarbeiter = new ArgumentVerarbeiter();
            verarbeiter.Parameter_Datum_auslesen(inputArgs, transaktion);

            Assert.That(transaktion.Datum.Year, Is.EqualTo(DateTime.Now.Year));
            Assert.That(transaktion.Datum.Month, Is.EqualTo(DateTime.Now.Month));
            Assert.That(transaktion.Datum.Day, Is.EqualTo(DateTime.Now.Day));
        }
    }
}
