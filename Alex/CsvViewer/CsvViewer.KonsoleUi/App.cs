using System;
using CsvViewer.Business;

namespace CsvViewer.KonsoleUi
{
    public class App
    {
        private string[] _args;
        private Ui ui;

        public App(string[] args)
        {
            _args = args;
        }

        public void Start()
        {
            Init();
            ui.Run(_args);
        }

        private void Init()
        {
            ui = new Ui();

            ui.Start += Ui_Start;
            ui.ErsteSeite += Ui_ErsteSeite;
            ui.LetzteSeite += Ui_LetzteSeite;
            ui.NaechsteSeite += Ui_NaechsteSeite;
            ui.VorherigeSeite += Ui_VorherigeSeite;
            ui.Exit += Ui_Exit;
        }

        void Ui_Exit(object sender, EventArgs e)
        {
        }


        void Ui_VorherigeSeite(object sender, EventArgs e)
        {
            Interaktionen interaktionen = new Interaktionen();
            var csvDatensaetze = interaktionen.Vorherige_Seite();

            ((Ui)sender).Zeige_CsvDatensaetze(csvDatensaetze);
        }


        void Ui_NaechsteSeite(object sender, EventArgs e)
        {
            Interaktionen interaktionen = new Interaktionen();
            var csvDatensaetze = interaktionen.Naechste_Seite();

            ((Ui)sender).Zeige_CsvDatensaetze(csvDatensaetze);
        }


        void Ui_LetzteSeite(object sender, EventArgs e)
        {
            Interaktionen interaktionen = new Interaktionen();
            var csvDatensaetze = interaktionen.Letzte_Seite();

            ((Ui)sender).Zeige_CsvDatensaetze(csvDatensaetze);
        }


        void Ui_ErsteSeite(object sender, EventArgs e)
        {
            Interaktionen interaktionen = new Interaktionen();
            var csvDatensaetze = interaktionen.Erste_Seite();

            ((Ui)sender).Zeige_CsvDatensaetze(csvDatensaetze);
        }


        private void Ui_Start(object sender, string[] e)
        {
            Interaktionen interaktionen = new Interaktionen();
            var csvDatensaetze = interaktionen.Start(e);

            ((Ui)sender).Zeige_CsvDatensaetze(csvDatensaetze);
        }
    }
}
