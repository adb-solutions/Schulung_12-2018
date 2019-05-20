using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Haushaltsbuch.Shared.BusinessModels;
using Newtonsoft.Json;

namespace Haushaltsbuch.Persistence
{
    public class TransaktionenRepository
    {
        private const string pfad = @"C:\Temp\Transaktionen.txt";

        public void Speichern(Transaktion transaktion)
        {
            string jsonString = JsonConvert.SerializeObject(transaktion);
            File.AppendAllText(pfad, jsonString += "\r\n");
        }

        public List<Transaktion> Transaktionen_laden_by_Datum_and_Kategorie(DateTime datum, string kategorie)
        {
            var transaktionen = Transaktionen_laden();
            transaktionen = transaktionen.Where(li => li.Datum.Month.Equals(datum.Month) && li.Datum.Year.Equals(datum.Year) &&
                                                      li.Kategorie.Equals(kategorie)).ToList();
            return transaktionen;
        }

        public List<Transaktion> Transaktionen_laden_by_Datum(DateTime datum)
        {
            var transaktionen = Transaktionen_laden();
            transaktionen = transaktionen.Where(li => li.Datum.Month.Equals(datum.Month) && li.Datum.Year.Equals(datum.Year)).ToList();
            return transaktionen;
        }

        private List<Transaktion> Transaktionen_laden()
        {
            var jsonStrings = File.ReadAllLines(pfad);
            List<Transaktion> transaktionen = new List<Transaktion>();

            foreach (var item in jsonStrings)
            {
                Transaktion transaktion = JsonConvert.DeserializeObject<Transaktion>(item);
                transaktionen.Add(transaktion);
            }

            return transaktionen;
        }
    }
}
