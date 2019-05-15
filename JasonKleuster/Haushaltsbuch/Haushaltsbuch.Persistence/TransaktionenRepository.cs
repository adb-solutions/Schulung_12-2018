using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haushaltsbuch.Shared.BusinessModels;

namespace Haushaltsbuch.Persistence
{
    public class TransaktionenRepository
    {
        public void Speichern(Transaktion transaktion)
        {
            throw new NotImplementedException();
        }

        public List<Transaktion> TransaktionenLadenByDatumAndKategorie(DateTime datum, string kategorie)
        {
            throw new NotImplementedException();
        }

        public List<Transaktion> TransaktionenLadenByDatum(DateTime datum)
        {
            throw new NotImplementedException();
        }
    }
}
