using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.Business
{
    public class Benutzerabfragen
    {
        public Func<string, bool> Benutzerabfrage_Kategorie_neu_anlegen { get; set; }

        public Benutzerabfragen(Func<string, bool> benutzerabfrage_Kategorie_neu_anlegen)
        {
            Benutzerabfrage_Kategorie_neu_anlegen = benutzerabfrage_Kategorie_neu_anlegen;
        }
    }
}
