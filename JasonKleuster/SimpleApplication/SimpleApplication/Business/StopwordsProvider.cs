using System.IO;

namespace SimpleApplication.Business
{
    public class StopwordsProvider
    {
        public string[] ReadStopwords(string stopwordsFilePath)
        {
            string stopwordsText = File.ReadAllText(stopwordsFilePath);

            string[] stopwords = stopwordsText.Split(';');
            return stopwords;
        }
    }
}
