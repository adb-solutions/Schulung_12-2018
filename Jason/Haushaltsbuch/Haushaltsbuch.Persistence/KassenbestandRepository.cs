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
                File.AppendAllText(pfad, "0");

                string kassenbestand;

                using (StreamReader streamReader = File.OpenText(pfad))
                {
                    kassenbestand = streamReader.ReadLine();
                }
                
                return Convert.ToDecimal(kassenbestand);
            }
            catch
            {
                throw new Exception("Fehler - Kassenbestand auslesen");
            }
        }

        public void Speichern(decimal kassenbestand)
        {
            try
            {
                if (File.Exists(pfad))
                {
                    using (FileStream fileStream = File.Create(pfad))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(kassenbestand.ToString("0.00"));
                        fileStream.Write(info, 0, info.Length);
                    }
                }
            }
            catch
            {
                throw new Exception("Fehler - Kassenbestand auslesen");
            }
        }
    }
}
