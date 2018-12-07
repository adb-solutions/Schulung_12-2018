using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Words.Business;

namespace Words.Test
{
    [TestFixture]
    [Category("StopwordsProvider")]
    public class StopwordsProviderTests
    {

        [Test]
        public void ReadStopwords_DateiExisitiertUndLeer_ErwarteLeerenInhalt()
        {
            string filePath = @"C:\Temp\stopwords.txt";

            var file = File.Create(filePath);
            file.Close();

            IEnumerable<string> fileContent = StopwordsProvider.Read_stopwords();

            Assert.That(fileContent.Count(), Is.EqualTo(0));
        }

        [Test]
        public void ReadStopwords_DateiExisitiertNicht_ErwarteFileNotFoundException()
        {
            string filePath = @"C:\Temp\stopwords.txt";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
           
            //Act
            ActualValueDelegate<object> testDelegate = () => StopwordsProvider.Read_stopwords();

            //Assert
            Assert.That(testDelegate, Throws.TypeOf<FileNotFoundException>());
        }

        [Test]
        public void ReadStopwords_DateiExisitiertUndHat2Woerter_ErwarteInhaltMit2Woertern()
        {
            string filePath = @"C:\Temp\stopwords.txt";
            string[] lines = { "a", "on" };

            File.WriteAllLines(filePath, lines);

            IEnumerable<string> fileContent = StopwordsProvider.Read_stopwords();

            Assert.That(fileContent.Count(), Is.EqualTo(2));
        }
    }
}
