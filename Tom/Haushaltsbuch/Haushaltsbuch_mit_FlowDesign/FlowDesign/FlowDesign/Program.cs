using FlowDesign.Ui;
using FlowDesign.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            var ausgabe = new Ausgabe();
            var eingabe = new Eingabe();
            ausgabe.Start();
            string ersterParameter = eingabe.leseEingabe();

            var av = new ArgumentVerarbeiter();
            string auswahl = av.leseErstenParameter(ersterParameter);
            DateTime Zeitpunkt = av.entnehmeZeit(eingabe);

            av.operationsAuswahl(auswahl);
        }
    }
}