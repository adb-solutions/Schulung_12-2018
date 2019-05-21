using System;
using System.Diagnostics.Eventing.Reader;

namespace Haushaltsbuch.Shared
{
    public static class TransaktionTypKonvertierer
    {
        public static TransaktionTyp FromString(string typ)
        {
            switch (typ.ToLower())
            {
                case "einzahlung":
                    return TransaktionTyp.Einzahlung;
                case "auszahlung":
                    return TransaktionTyp.Auszahlung;
            }

            throw new ArgumentException("Unbekannter Transaktiontyp");
        }

        public static string AsString(TransaktionTyp typ)
        {
            switch (typ)
            {
                case TransaktionTyp.Einzahlung:
                    return "einzahlung";
                case TransaktionTyp.Auszahlung:
                    return "auszahlung";

                default:
                    throw new ArgumentOutOfRangeException("Transaktiontyp");
            }
        }

        public static void Ermittle_Typ(TransaktionTyp typ, Action istEinzahlung, Action istAuszahlung)
        {
            switch (typ)
            {
                case TransaktionTyp.Einzahlung:
                    istEinzahlung();
                    break;
                case TransaktionTyp.Auszahlung:
                    istAuszahlung();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Transaktiontyp");
            }
        }
    }
}
