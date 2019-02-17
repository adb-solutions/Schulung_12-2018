using System;
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
