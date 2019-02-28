using CsvViewer.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvViewer.KonsolenUi
{
    public class UiEvents
    {
        private Interaktionen _interaktionen;

        public UiEvents(Interaktionen interaktionen)
        {
            _interaktionen = interaktionen;
        }

        public void Ui_Exit(object sender, EventArgs e)
        {
        }

        public void Ui_VorherigeSeite(object sender, EventArgs e)
        {
            if (Status.Instanz.AktuelleSeitenummer.Lade() > 1)
            {
                var csvDatensaetze = _interaktionen.Vorherige_Seite();
                ((Ui)sender).Zeige_CsvDatensaetze(csvDatensaetze);
            }
            else
            {
                ((Ui)sender).Zeige_Hinweis("Es wird bereits die erste Seite angezeigt.\r\nBitte wählen Sie eine andere Option.");
            }
        }
        
        public void Ui_NaechsteSeite(object sender, EventArgs e)
        {
            var csvDatensaetze = _interaktionen.Naechste_Seite();
            ((Ui)sender).Zeige_CsvDatensaetze(csvDatensaetze);
        }

        public void Ui_LetzteSeite(object sender, EventArgs e)
        {
            var csvDatensaetze = _interaktionen.Letzte_Seite();

            ((Ui)sender).Zeige_CsvDatensaetze(csvDatensaetze);
        }

        public void Ui_ErsteSeite(object sender, EventArgs e)
        {
            var csvDatensaetze = _interaktionen.Erste_Seite();

            ((Ui)sender).Zeige_CsvDatensaetze(csvDatensaetze);
        }

        public void Ui_Start(object sender, string[] e)
        {
            var csvDatensaetze = _interaktionen.Start(e);

            ((Ui)sender).Zeige_CsvDatensaetze(csvDatensaetze);
        }
    }
}
