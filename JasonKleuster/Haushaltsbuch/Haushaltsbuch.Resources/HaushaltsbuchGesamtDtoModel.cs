using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.Resources
{
    class HaushaltsbuchGesamtDtoModel : IHaushaltsbuchDtoModel
    {
        public decimal Kassenbestand { get; set; }

        public string Monat { get; set; }

        public string Jahr { get; set; }

        public List<KategorieDtoModel> Kategorien { get; set; }
    }
}
