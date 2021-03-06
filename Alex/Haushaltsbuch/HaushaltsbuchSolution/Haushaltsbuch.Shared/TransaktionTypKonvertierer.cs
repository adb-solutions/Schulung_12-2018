﻿using System;
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
    }
}
