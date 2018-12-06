using System;
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
        public void Teste_Marry_Erwarte_Erfolg(string eingabe, int erwartetesErgebnis)
        {
            string pathZuStopwords = $"{AppDomain.CurrentDomain.BaseDirectory}\\App_Data\\stopwords.txt";

            Words words = new Words();
            StopwordsProvider stopwordsProvider = new StopwordsProvider(pathZuStopwords);

            int cntWords = new WordCount(words, stopwordsProvider).Count_Words(eingabe);

            Assert.That(cntWords, Is.EqualTo(erwartetesErgebnis));
        }
    }
}
