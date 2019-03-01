using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huk.LocCount
{
    class LocCount
    {
        CommandLineInterface ui = new CommandLineInterface();
        public void Start(string[] args) {
            var Path = CommandLineArgProcessor.PfadErmitteln(args);
            var dateiManager = new DateiManager();
            dateiManager.QuellCodeDateien_finden(Path, DateiErmittelt,Fehlerausgabe);
            ui.ShowTotal();
        }
        internal void DateiErmittelt(string Dateiname) {

             DateiManager.LeseDatei(Dateiname,LoCStatErstellen,Fehlerausgabe);

        }
        
        internal void Fehlerausgabe(string Fehler) {
            ui.ShowError(Fehler);

        }
        internal void LoCStatErstellen(string Dateiname, string[] Zeilen) {
            var currentLoc = LocStatManager.ErstelleLoCStat(Dateiname, Zeilen);
            ui.ShowLocStat(currentLoc);

        }
    }
}
