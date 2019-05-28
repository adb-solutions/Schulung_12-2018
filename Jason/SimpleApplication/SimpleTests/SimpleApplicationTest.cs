using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleApplication.Business;

namespace SimpleTests
{
    [TestClass]
    public class SimpleApplicationTest
    {
        [TestMethod]
        public void Teste_Count_Words()
        {
            WordCount wordCount = new WordCount();

            wordCount.Count_Words();

            Assert.That(5);
        }
    }
}
