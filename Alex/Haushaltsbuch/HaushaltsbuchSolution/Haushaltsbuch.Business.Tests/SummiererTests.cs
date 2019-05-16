using System;
using System.Collections.Generic;
using System.Linq;
using Haushaltsbuch.Shared;
using NodaMoney;
using NUnit.Framework;

namespace Haushaltsbuch.Business.Tests
{
    [TestFixture]
    public class SummiererTests
    {
        [Test]
        public void Kassenbestand_Erwarte_Erfolg()
        {
            var datum = new DateTime(2019, 4, 10);

            var transaktionen = new List<Transaktion> {
                new Transaktion(TransaktionTyp.Einzahlung) {
                    Datum = new DateTime(2019, 3, 1),
                    Betrag = new Money(100.0)
                },
                new Transaktion(TransaktionTyp.Einzahlung) {
                    Datum = new DateTime(2019, 4, 9),
                    Betrag = new Money(100.0)
                },
                new Transaktion(TransaktionTyp.Auszahlung) {
                    Datum = new DateTime(2019, 4, 10),
                    Betrag = new Money(30.0)
                },
                new Transaktion(TransaktionTyp.Auszahlung) { //Wird ignoriert, weil es nächster Monat ist
                    Datum = new DateTime(2019, 5, 11),
                    Betrag = new Money(30.0)
                }
            };

            var kassenbestand = Summierer.Ermittle_Kassenbestand(datum, transaktionen);

            Assert.That(kassenbestand, Is.EqualTo(new Money(170)));
        }

        [Test]
        [TestCase("2019-05-10", new[] { "Miete;30" })]
        public void Ermittle_alle_Kategorien_Erwarte_Erfolg(string datumString, string[] erwarteteKategorien)
        {
            DateTime datum = DateTime.Parse(datumString);

            var transaktionen = new List<Transaktion> {
                new Transaktion(TransaktionTyp.Einzahlung) {        
                    Datum = new DateTime(2019, 5, 1),               
                    Betrag = new Money(50.0)
                },
                new Transaktion(TransaktionTyp.Auszahlung) {
                    Datum = new DateTime(2019, 5, 5),
                    Kategorie = "Miete",
                    Betrag = new Money(10.0)
                },
                new Transaktion(TransaktionTyp.Auszahlung) { 
                    Datum = new DateTime(2019, 4, 5),
                    Kategorie = "Miete",
                    Betrag = new Money(10.0)
                },
                new Transaktion(TransaktionTyp.Auszahlung) {
                    Datum = new DateTime(2019, 5, 11),
                    Kategorie = "Restaurantbesuche",
                    Betrag = new Money(20.0)
                },
                new Transaktion(TransaktionTyp.Auszahlung) { 
                    Datum = new DateTime(2019, 5, 15),       
                    Kategorie = "miete",
                    Betrag = new Money(20.0)
                }
            };

            List<Kategorie> ermittelteKategorien = Summierer.Ermittle_alle_Kategorien(datum, transaktionen);
            foreach(Kategorie kategorie in ermittelteKategorien)
            {
                var erwartet = erwarteteKategorien.FirstOrDefault(li => li.Equals(kategorie.Bezeichnung));
                if(erwartet == null)
                {
                    Assert.Fail("Kategorie " + kategorie.Bezeichnung + " nicht in Erwartet-Array gefunden");
                }

                var elements = erwartet.Split(';');

                Assert.That(kategorie.Bezeichnung, Is.EqualTo(elements[0]));
                Assert.That(kategorie.Summe, Is.EqualTo(new Money(decimal.Parse(elements[1]))));
            }
        }

        [Test]
        [TestCase( "2019-05-10", "Miete", 30)]
        [TestCase("2019-05-01", "Restaurantbesuche", 20)]
        [TestCase("2019-04-10", "Miete", 10)]
        [TestCase("2019-03-10", "Miete", 0)]
        public void Ermittle_Kategorie_Erwarte_Erfolg(string datumString, string kategorie, decimal erwartet)
        {
            DateTime datum = DateTime.Parse(datumString);

            var transaktionen = new List<Transaktion> {
                new Transaktion(TransaktionTyp.Einzahlung) {        // Kommentarbeispiel für [TestCase( "2019-05-10", "Miete", 30)]
                    Datum = new DateTime(2019, 5, 1),               // Ignoriert > Einzahlung
                    Betrag = new Money(50.0)
                },
                new Transaktion(TransaktionTyp.Auszahlung) {        // Berücksichtigt
                    Datum = new DateTime(2019, 5, 5),
                    Kategorie = "Miete",
                    Betrag = new Money(10.0)
                },
                new Transaktion(TransaktionTyp.Auszahlung) {        // Ignoriert > Anderer Monat
                    Datum = new DateTime(2019, 4, 5),
                    Kategorie = "Miete",
                    Betrag = new Money(10.0)
                },
                new Transaktion(TransaktionTyp.Auszahlung) {        // Ignoriert > Andere Kategorie
                    Datum = new DateTime(2019, 5, 11),
                    Kategorie = "Restaurantbesuche",
                    Betrag = new Money(20.0)
                },
                new Transaktion(TransaktionTyp.Auszahlung) {        // Berücksichtig, ob wohl Kategorie kleingeschrieben 
                    Datum = new DateTime(2019, 5, 15),              // und Datum hinter wunschdatum, ist aber selber Monat
                    Kategorie = "miete",
                    Betrag = new Money(20.0)
                }
            };

            Kategorie ermittelteKategorie = Summierer.Ermittle_Kategorie(kategorie, datum, transaktionen);

            Assert.That(ermittelteKategorie.Bezeichnung, Is.EqualTo(kategorie));
            Assert.That(ermittelteKategorie.Summe, Is.EqualTo(new Money(erwartet)));
        }
    }
}
