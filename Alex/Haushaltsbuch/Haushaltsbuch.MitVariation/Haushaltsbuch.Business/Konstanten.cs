using System;
using NodaMoney;

namespace Haushaltsbuch.Business
{
    public static class Konstanten
    {
        public static readonly Currency DefaultWaehrung = Currency.FromCode("EUR");

        public static readonly string[] Unterstuetze_EingabeDatumsformate = { "dd.MM.yyyy", "dd.MM.yy", "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy"};
    }
}
