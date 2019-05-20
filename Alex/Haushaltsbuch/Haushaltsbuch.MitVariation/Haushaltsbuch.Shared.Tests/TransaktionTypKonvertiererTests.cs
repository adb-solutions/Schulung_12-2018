using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Haushaltsbuch.Shared.Tests
{
    [TestFixture]
    public class TransaktionTypKonvertiererTests
    {
        [Test]
        [TestCase("einzahlung", TransaktionTyp.Einzahlung)]
        [TestCase("auszahlung", TransaktionTyp.Auszahlung)]
        [TestCase("Einzahlung", TransaktionTyp.Einzahlung)]
        [TestCase("Auszahlung", TransaktionTyp.Auszahlung)]
        public void String_to_Enum_Erwarte_Erfolg(string wert, TransaktionTyp erwartet)
        {
            var result = TransaktionTypKonvertierer.FromString(wert);
            Assert.That(result, Is.EqualTo(erwartet));
        }

        [Test]
        public void Unbekannter_String_to_Enum_Erwarte_Exception()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                delegate
                {
                    var result = TransaktionTypKonvertierer.FromString("unbekannt");

                });

            Assert.That(ex.Message, Is.EqualTo("Unbekannter Transaktiontyp"));
        }

        [Test]
        [TestCase(TransaktionTyp.Einzahlung, "einzahlung")]
        [TestCase(TransaktionTyp.Auszahlung, "auszahlung")]
        public void Enum_to_String_Erwarte_Erfolg(TransaktionTyp wert, string erwartet)
        {
            var result = TransaktionTypKonvertierer.AsString(wert);
            Assert.That(result, Is.EqualTo(erwartet));
        }

        [Test]
        public void Ermittle_Typ_Einzahlung_Erwarte_Erfolg()
        {
            var wert = TransaktionTyp.Einzahlung;

            bool ausgefuehrt = false;
            TransaktionTypKonvertierer.Ermittle_Typ(wert, () =>
            {
                ausgefuehrt = true;
            }, null);

            Assert.True(ausgefuehrt);
        }

        [Test]
        public void Ermittle_Typ_Auszahlung_Erwarte_Erfolg()
        {
            var wert = TransaktionTyp.Auszahlung;

            TransaktionTypKonvertierer.Ermittle_Typ(wert, () =>
            {
                Assert.Fail("Einzahlung erkannt");
            }, () =>
            {
                Assert.Pass();
            });
        }

        [Test]
        public void UnbekannterTyp_Ermittle_Typ_Erwarte_Exception()
        {
            NullReferenceException ex = Assert.Throws<NullReferenceException>(
                delegate
                {
                    TransaktionTypKonvertierer.Ermittle_Typ(TransaktionTyp.Einzahlung, null, null);

                });

            //Assert.That(ex.Message, Is.EqualTo("Unbekannter Transaktiontyp"));
        }
    }
}
