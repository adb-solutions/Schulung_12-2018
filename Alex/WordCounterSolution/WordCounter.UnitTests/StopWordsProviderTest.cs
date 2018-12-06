using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WordCounter.Provider;

namespace WordCounter.UnitTests
{
    [TestFixture]
    public class StopWordsProviderTest
    {
        [Test]
        public void Lese_StopwordsDatei_Erwarte_Zeilen()
        {
            string pathZuStopwords = $"{AppDomain.CurrentDomain.BaseDirectory}\\App_Data\\stopwords.txt";

            StopwordsProvider stopwordsProvider = new StopwordsProvider(pathZuStopwords);
            List<string> result = stopwordsProvider.Read_Stopwords();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(4));
        }

        [Test]
        public void Lese_LeereDatei_Erwarte_Null()
        {
            string pathZuStopwords = $"{AppDomain.CurrentDomain.BaseDirectory}\\App_Data\\leer.txt";

            StopwordsProvider stopwordsProvider = new StopwordsProvider(pathZuStopwords);
            List<string> result = stopwordsProvider.Read_Stopwords();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(0));
        }
    }
}
