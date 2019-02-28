using System;
using System.Threading;
using CsvViewer.Business;

namespace CsvViewer.KonsolenUi
{
    public class App
    {
        public event EventHandler<string[]> Start;
        public event EventHandler NaechsteSeite;
        public event EventHandler VorherigeSeite;
        public event EventHandler ErsteSeite;
        public event EventHandler LetzteSeite;
        public event EventHandler Exit;

        private string[] _args;
        private Ui _ui;

        public App(string[] args)
        {
            _args = args;
        }

        public void Run()
        {
            Init();
            Main(_args);
        }
        
        private void Init()
        {
            _ui = new Ui();
            UiEvents events = new UiEvents(new Interaktionen());

            Start += events.Ui_Start;
            ErsteSeite += events.Ui_ErsteSeite;
            LetzteSeite += events.Ui_LetzteSeite;
            NaechsteSeite += events.Ui_NaechsteSeite;
            VorherigeSeite += events.Ui_VorherigeSeite;
            Exit += events.Ui_Exit;
        }

        private void Main(string[] args)
        {
            Start(_ui, args);

            bool isRunning = true;
            while (isRunning)
            {
                _ui.Zeige_Auswahl_Moeglichkeiten();
                var key = _ui.Lese_Zeichen();
                
                switch (key)
                {
                    case "N":
                        NaechsteSeite(_ui, EventArgs.Empty);
                        break;

                    case "P":
                        VorherigeSeite(_ui, EventArgs.Empty);
                        break;

                    case "F":
                        ErsteSeite(_ui, EventArgs.Empty);
                        break;

                    case "L":
                        LetzteSeite(_ui, EventArgs.Empty);
                        break;

                    case "X":
                        Exit(_ui, EventArgs.Empty);
                        isRunning = false;
                        break;

                    default:
                        _ui.Zeige_Fehler("Ihre Eingabe wurde nicht erkannt.\r\nBitte versuchen Sie es erneut.");
                        ErsteSeite(_ui, EventArgs.Empty);
                        break;
                }
            }
        }

    }
}
