using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WordCounter.Operations;

namespace WordCounter.UnitTests
{
    [TestFixture]
    public class WordsTest
    {
        private Words _words;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _words = new Words();
        }

        [Test]
        [TestCase(new[]{""}, 1)]
        [TestCase(new string[0], 0)]
        [TestCase(new[] { "Word1", "Word2", "Word3" }, 3)]
        public void Teste_Count_Erwarte_Erfolg(string[] words, int ergebnis)
        {
            int anzahl = _words.Count(words.ToList());

            Assert.That(anzahl, Is.EqualTo(ergebnis));
        }

        [Test]
        [TestCase("Marry", 1)]
        [TestCase("", 0)]
        [TestCase("Marry had a little lamb.", 5)]
        public void Teste_Split_into_Words_Erwarte_Erfolg(string text, int ergebnis)
        {
            List<string> woerter = _words.Split_into_Words(text);

            Assert.That(woerter.Count, Is.EqualTo(ergebnis));
        }


        [TestCase(new string[0], new[] { "a", "the", "on", "off" }, 0)]
        [TestCase(new[] { "a", "the", "on", "off" }, new[] { "a", "the", "on", "off" }, 0)]
        [TestCase(new[] { "Marry", "had", "no", "little", "lamb." }, new[] { "a", "the", "on", "off" }, 5)]
        [TestCase(new[] { "Marry", "Marry", "had", "no", "little", "lamb." }, new[] { "a", "the", "on", "off" }, 6)]
        [TestCase(new[] { "Marry", "had", "a", "little", "lamb." }, new[] { "a", "the", "on", "off" }, 4)]
        public void Teste_Filter_Stopwords_Erwarte_Erfolg(string[] words, string[] stopwords, int ergebnis)
        {
            List<string> gefilterteWoerter = _words.Filter_Stopwords(words.ToList(), stopwords.ToList());

            Assert.That(gefilterteWoerter.Count, Is.EqualTo(ergebnis));
        }
    }
}
