using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvViewer.Business
{
    public class Zustand<T>
    {
        private T zustand;

        public void Setze(T zustand)
        {
            this.zustand = zustand;
        }

        public T Lade()
        {
            return zustand;
        }
    }
}
