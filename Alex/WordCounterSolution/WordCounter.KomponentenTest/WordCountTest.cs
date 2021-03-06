﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using WordCounter.Business;
using WordCounter.Operations;
using WordCounter.Provider;

namespace WordCounter.KomponentenTest
{
    [TestFixture()]
    public class WordCountTest
    {
        [Test]
        [TestCase("Marry Marry had a little lamb.", 5)]
        //[TestCase("Marry had a little lamb.", 4)]
        //[TestCase("", 0)]
        public void Teste_Marry_Erwarte_Erfolg(string eingabe, int erwartetesErgebnis)
        {
            Words words = new Words();
            StopwordsProvider stopwordsProvider = new StopwordsProvider();

            int cntWords = new WordCount().Count_Words(eingabe);

            Assert.That(cntWords, Is.EqualTo(erwartetesErgebnis));
        }
    }
}
