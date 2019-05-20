using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.Persistence
{
    public class KassenbestandRepository
    {
        private const string pfad = @"C:\Temp\Kassenbestand.txt";

        public decimal Lade()
        {
            try
            {
                if (File.Exists(pfad))
                {
                    using (FileStream fs = File.Create(pfad))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                        fs.Write(info, 0, info.Length);
                    }
                }

                using (StreamReader sr = File.OpenText(pfad))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }

                return null;
            }
            catch
            {
                throw new Exception("Fehler - Kassenbestand auslesen");
            }
        }
    }
}
