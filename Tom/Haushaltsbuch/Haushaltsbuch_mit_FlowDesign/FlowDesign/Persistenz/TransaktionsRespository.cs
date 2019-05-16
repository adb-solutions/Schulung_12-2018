using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using FlowDesign.Interaktionen;
using FlowDesign.Shared;

namespace FlowDesign.Persistenz
{
    public class TransaktionsRespository
    {
        private const string _pfad = "C:/temp/Haushaltsbuch.xml";

        internal void Speichern(Transaktion transaktion)
        {
            XMLSerialisierer.SerializieObject(_pfad, transaktion);
        }

        internal List<Transaktion> Lade_alle_Transaktionen()
        {
            string dateiInhalt = File.ReadAllText(_pfad);
            var eintraege = dateiInhalt.Split("<?xml version=\"1.0\"?>", StringSplitOptions.RemoveEmptyEntries);

            List<Transaktion> result = new List<Transaktion>();

            foreach (var eintrag in eintraege)
            {
                Transaktion temp = (Transaktion) XMLSerialisierer.DeserializeObject(eintrag, typeof(Transaktion));
                result.Add(temp);
            }

            return result;
        }

        internal List<Transaktion> Lade_alle_Transaktionen_vor_und_aus_dem_Zeitraum(DateTime datum)
        {
            throw new NotImplementedException();
        }
    }
}
