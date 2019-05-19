using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haushaltsbuch.Shared;
using NodaMoney;
using NUnit.Framework;

namespace Haushaltsbuch.Business.Tests
{
    [TestFixture]
    class ArgumentVerarbeiterTests
    {
        [Test]
        [Ignore("Skip, dient nur zu Anschauung von DateTime.TryParse Problem")]
        public void DateTime_TryParse_String_228_komma_02_zu_DateTime_Erwarte_Fehlgeschlagen()
        {
            DateTime datum;
            bool parsenErfolgreich = DateTime.TryParse("228,02", out datum);
            Assert.False(parsenErfolgreich);
        }

        [Test]
        [Ignore("Skip, dient nur zu Anschauung von DateTime.TryParse Problem")]
        public void DateTime_TryParseExact_String_228_komma_02_zu_DateTime_Erwarte_Fehlgeschlagen()
        {
            string[] unterstuetze_EingabeDatumsformate = {"dd.MM.yyyy"};

            DateTime datum;
            bool parsenErfolgreich = DateTime.TryParseExact("228,02", unterstuetze_EingabeDatumsformate, null,
                DateTimeStyles.None, out datum);
            Assert.False(parsenErfolgreich);
        }

        [Test]
        [TestCase(new string[] {"einzahlung", "400"}, TransaktionTyp.Einzahlung, new string[] {"400"})]
        [TestCase(new string[] {"auszahlung", "5,99", "Restaurantbesuche", "Schokobecher"}, TransaktionTyp.Auszahlung,
            new string[] {"5,99", "Restaurantbesuche", "Schokobecher"})]
        public void Erstelle_Transaktion_aus_Typ(string[] args, TransaktionTyp erwartet, string[] erwartetArgs)
        {
            Tuple<Transaktion, string[]> result = ArgumentVerarbeiter.Erstelle_Transaktion_aus_Typ(args);
            Assert.That(result.Item1.Typ, Is.EqualTo(erwartet));
            Assert.That(result.Item2, Is.EqualTo(erwartetArgs));
        }

        [Test]
        public void Ist_Uebersicht_Kommando_Erwarte_uebersicht_und_kuerzeres_args()
        {
            ArgumentVerarbeiter.Ist_Uebersicht_Kommando(new string[] { "übersicht", "12", "2019" }, 
                onIstUebersicht: (argsUebersicht) =>
                {
                    Assert.That(argsUebersicht, Is.EqualTo(new string[] { "12", "2019" }));
                }, 
                onIstEinAuszahlung: (argsEinAuszahlung) =>
                {
                    Assert.Fail("Ein-/Auszahlung erkannt");
                }
            );
        }

        [Test]
        public void Ist_Uebersicht_Kommando_Erwarte_auszahlung()
        {
            string[] args = new string[] {"auszahlung", "5,99", "Restaurantbesuche", "Schokobecher"};
            ArgumentVerarbeiter.Ist_Uebersicht_Kommando(args,
                onIstUebersicht: (argsUebersicht) =>
                {
                    Assert.Fail("Uebersichtskommando erkannt");
                },
                onIstEinAuszahlung: (argsEinAuszahlung) =>
                {
                    Assert.That(argsEinAuszahlung, Is.EqualTo(args));
                    Assert.That(argsEinAuszahlung.First(), Is.EqualTo("auszahlung"));
                }
            );
        }

        [Test]
        public void Ist_Uebersicht_Kommando_Erwarte_einzahlung()
        {
            string[] args = new string[] { "einzahlung", "5,99" };
            ArgumentVerarbeiter.Ist_Uebersicht_Kommando(args,
                onIstUebersicht: (argsUebersicht) =>
                {
                    Assert.Fail("Uebersichtskommando erkannt");
                },
                onIstEinAuszahlung: (argsEinAuszahlung) =>
                {
                    Assert.That(argsEinAuszahlung, Is.EqualTo(args));
                    Assert.That(argsEinAuszahlung.First(), Is.EqualTo("einzahlung"));
                }
            );
        }

        [Test]
        public void Erstelle_Datum_aus_Eingabeparameter_Erwarte_Erfolg()
        {
            string[] args = new string[] {"12", "2019"};
            var result = ArgumentVerarbeiter.Erstelle_Datum_aus_Eingabeparameter(args);
            Assert.That(result, Is.EqualTo(new DateTime(2019,12, 01)));
        }

        [Test]
        public void Erstelle_Transaktion_aus_Eingabeparameter_Erwarte_Erfolg()
        {
            Transaktion erwartet = new Transaktion(TransaktionTyp.Auszahlung)
            {
                Betrag = new Money(700),
                Datum = new DateTime(2015,1,1),
                Kategorie = "Miete",
                Memotext = "Beispieltext 123",
            };
            var args = new string[] { "auszahlung", "01.01.2015", "700", "Miete", "Beispieltext 123" };

            var result = ArgumentVerarbeiter.Erstelle_Transaktion_aus_Eingabeparameter(args);

            Assert.That(result.Betrag, Is.EqualTo(erwartet.Betrag));
            Assert.That(result.Datum, Is.EqualTo(erwartet.Datum));
            Assert.That(result.Kategorie, Is.EqualTo(erwartet.Kategorie));
            Assert.That(result.Memotext, Is.EqualTo(erwartet.Memotext));
            Assert.That(result.Typ, Is.EqualTo(erwartet.Typ));
        }
    }
}
