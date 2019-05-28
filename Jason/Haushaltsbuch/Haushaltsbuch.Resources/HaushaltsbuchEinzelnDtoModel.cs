using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.Resources
{
    public class HaushaltsbuchEinzelnDtoModel : IHaushaltsbuchDtoModel
    {
        public decimal Kassenbestand { get; set; }

        public KategorieDtoModel Kategorie { get; set; }
    }
}
