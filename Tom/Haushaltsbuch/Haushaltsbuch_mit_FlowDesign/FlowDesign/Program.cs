using System;
using System.Runtime.CompilerServices;
using FlowDesign.Interaktionen;
using FlowDesign.Persistenz;
using FlowDesign.Ui;

[assembly: InternalsVisibleTo("FlowDesign.UnitTests")]
namespace FlowDesign 
{
    class Program
    {
        public static void Main(string[] args)
        {
            UiM.Start();
            new Interaktion(new TransaktionsRespository()).Start(args, 
                ausgangFuerEinzahlung: (kassenbestand) => {
                    UiM.EinzahlungAusgeben(kassenbestand);
                },
                ausgangFuerAuszahlung: (kassenbestand, kategorie) => {

                    UiM.AuszahlungAusgeben(kassenbestand, kategorie);
                }, 
                onUebersicht: (uebersicht) => {

                    UiM.UebersichtAusgeben(uebersicht);
                }
            );
        }
    }
}
