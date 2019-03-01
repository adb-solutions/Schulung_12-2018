using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huk.FlowDesign
{
    public class StopWordProvider
    {
        const string stopFileName = "StopWords.txt";

        public IList<string> ReadStopWords() {
            var result = new List<string>();

            System.IO.FileInfo stopFileInfo = new System.IO.FileInfo(stopFileName); ;
            System.IO.TextReader reader = stopFileInfo.OpenText(); ;

            try
            {
                    while (((System.IO.StreamReader)reader).EndOfStream == false)
                    {
                        string word = reader.ReadLine();


                        result.Add(word.Trim());
                    }
               
            }
            catch { } //TODO: Catch überarbeiten
            finally {
                if (reader != null)
                    reader.Dispose();

            }
            return result;

        }
    }
}
