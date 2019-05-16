using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using FlowDesign.Shared;

namespace FlowDesign.Business
{
    class TypErmittler
    {
        internal static void Ermittle_Typ(TransaktionTyp typ, Action onIstAuszahlung, Action onIstEinzahlung)
        {
            if (typ == TransaktionTyp.Auszahlung)
            {
                onIstAuszahlung();
            }
            if (typ == TransaktionTyp.Einzahlung)
            {
                onIstEinzahlung();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Fehler beim Ermitteln des Typs");
            }
        }
    }
}