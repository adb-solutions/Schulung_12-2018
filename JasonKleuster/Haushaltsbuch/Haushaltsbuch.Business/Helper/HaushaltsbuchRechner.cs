﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haushaltsbuch.Shared;
using Haushaltsbuch.Shared.BusinessModels;

namespace Haushaltsbuch.Business
{
    public class HaushaltsbuchRechner
    {
        public decimal KassenbestandBerechnen(List<Transaktion> transaktionen)
        {
            return 1;
        }




        public List<Kategorie> KategorienGesamtbetraegeBerechnen(List<Transaktion> transaktion)
        {
            List<Kategorie> kategorien = new List<Kategorie>();

            

            return kategorien;
        }


        public DateTime DatumErmitteln(Index index)
        {
            

            return DateTime.Now;
        }

        public decimal KategorieGesamtbetragBerechnen(object transaktionen)
        {
            throw new NotImplementedException();
        }
    }
}
