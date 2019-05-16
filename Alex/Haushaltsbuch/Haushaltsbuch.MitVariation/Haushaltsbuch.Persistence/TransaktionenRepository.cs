using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Haushaltsbuch.Shared;
using Newtonsoft.Json;

namespace Haushaltsbuch.Persistence
{
    public class TransaktionenRepository
    {
        private readonly string _datenbank;

        public TransaktionenRepository(string dateiname)
        {
            _datenbank = dateiname;
        }

        public void Kategorie_existiert(string kategorie, Action onJa, Action onNein)
        {
            List<Transaktion> alleTransaktionen = Lade();
            if (alleTransaktionen.Any(transaktion =>
                transaktion.Typ == TransaktionTyp.Auszahlung &&
                transaktion.Kategorie.Equals(kategorie, StringComparison.OrdinalIgnoreCase)))
            {
                onJa();
            }
            else
            {
                onNein();
            }
        }

        public void Add_und_Speichern(Transaktion transaktion)
        {
            string jsonString = JsonConvert.SerializeObject(transaktion);
            File.AppendAllLines(_datenbank, new string[] { jsonString });
        }

        public List<Transaktion> Lade()
        {
            List<Transaktion> result = new List<Transaktion>();
            if (!File.Exists(_datenbank))
            {
                return result;
            }

            string[] datensaetze = File.ReadAllLines(_datenbank);
            foreach (var datensatz in datensaetze)
            {
                Transaktion transaktion = JsonConvert.DeserializeObject<Transaktion>(datensatz);
                result.Add(transaktion);
            }

            return result;
        }
    }
}
