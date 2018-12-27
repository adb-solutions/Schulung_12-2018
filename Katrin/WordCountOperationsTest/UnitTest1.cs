using NUnit.Framework;
using WordCount;
using System.Collections;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void TestSplitter()
        {
            string eingabe = "ich bin eine Eingabe";
            var anzahl = new WordCountOperations();
            var ergebnis = anzahl.WordSplitter(eingabe);
            ArrayList List = new ArrayList { "ich", "bin", "eine", "Eingabe" };
            Assert.AreEqual(List, ergebnis);

        }
        [Test]
        //[Testcase("hallo du", 2)]
        //public void TestCounter(string eingabe, int erwartetesErgebnis)
        public void TestCounter()
        {
            ArrayList List = new ArrayList { "hallo", "du", "da" };
            var anzahl = new WordCountOperations();
            var ergebnis = anzahl.WordCounter(List);
            Assert.AreEqual(3, ergebnis);
        }

        [Test]
        //[TestCase(new ArrayList {"hallo, du"}, new ArrayList {"du"})]
        public void TestFilter()
        {
            ArrayList List1 = new ArrayList { "hallo", "du", "da" };
            ArrayList List2 = new ArrayList { "du"};
            var anzahl = new WordCountOperations();
            var ergebnis = anzahl.FilterStopWords(List1, List2);
            Assert.AreEqual(2, ergebnis.Count);
        }
    }
}