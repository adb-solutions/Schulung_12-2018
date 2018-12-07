using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Words.Business;

namespace Words.Test
{
    [TestFixture]
    [Category("WordCountOperations")]
    public class WordCountOprationsTests
    {

        [Test]
        public void Count_ListeMit3Worten_ErwarteWert4()
        {
            IEnumerable<string> testString = new List<string>()
            {
                "Mein",
                "kleiner",
                "realer",
                "Satz"
            };

            var wordCounter = WordCountOperations.Count(testString);

            Assert.That(wordCounter, Is.EqualTo(4));
        }

        [Test]
        public void Count_ListeOhneWorten_ErwarteWert0()
        {
            IEnumerable<string> testString = new List<string>();

            var wordCounter = WordCountOperations.Count(testString);

            Assert.That(wordCounter, Is.EqualTo(0));
        }
    }
}
