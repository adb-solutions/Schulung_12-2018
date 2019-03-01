using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Huk.FlowDesign.Tests
{
    [TestClass]
    public class WordCountProcessorTests
    {
        [TestMethod]
        public void SplitIntoWords_Normal_Text()
        {
            var wordCountProcessor = new Huk.FlowDesign.WordCountProcessor();
            string textToTest = "rote gelbe blaue blumen";

            IList<string> erwartetesErgebnis = new List<string>() { "rote", "gelbe", "blaue", "blumen" };

            IList<string> ergebnis = wordCountProcessor.SplitIntoWords(textToTest);

            CollectionAssert.AreEqual((List<string>)erwartetesErgebnis,(List<string>) ergebnis);

        }
        [TestMethod]
        public void SplitIntoWords_Empty_Text()
        {


        }
        [TestMethod]
        public void SplitIntoWords_Null_Text()
        {

        }
        [TestMethod]
        public void SplitIntoWords_specialCharakter_Text()
        {

        }
        [TestMethod]
        public void SplitIntoWords_specialCharakterOnly_Text()
        {

        }
    }
}
