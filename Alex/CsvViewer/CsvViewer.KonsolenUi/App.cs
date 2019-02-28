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
        private bool _isRunning = true;

        public App(string[] args)
        {
            _args = args;
        }

        public void Run()
        {
            Init();
            OnStart(_args);
            Main();
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

        private void Main()
        {
            while (_isRunning)
            {
                _ui.Zeige_Auswahl_Moeglichkeiten();

                string key = _ui.Lese_Zeichen();
                switch (key)
                {
                    case "N":
                        OnNaechsteSeite();
                        break;

                    case "P":
                        OnVorherigeSeite();
                        break;

                    case "F":
                        OnErsteSeite();
                        break;

                    case "L":
                        OnLetzteSeite();
                        break;

                    case "X":
                        OnExit();
                        
                        break;

                    default:
                        OnEingabeNichtErkannt();
                        break;
                }
            }
        }

        private void OnStart(string[] args)
        {
            Start?.Invoke(_ui, args);
        }

        protected virtual void OnEingabeNichtErkannt()
        {
            _ui.Zeige_Fehler("Ihre Eingabe wurde nicht erkannt.\r\nBitte versuchen Sie es erneut.");
            OnErsteSeite();
        }

        protected virtual void OnExit()
        {
            _isRunning = false;
            Exit?.Invoke(_ui, EventArgs.Empty);
        }

        protected virtual void OnLetzteSeite()
        {
            LetzteSeite?.Invoke(_ui, EventArgs.Empty);
        }

        protected virtual void OnErsteSeite()
        {
            ErsteSeite?.Invoke(_ui, EventArgs.Empty);
        }

        protected virtual void OnVorherigeSeite()
        {
            VorherigeSeite?.Invoke(_ui, EventArgs.Empty);
        }

        protected virtual void OnNaechsteSeite()
        {
            NaechsteSeite?.Invoke(_ui, EventArgs.Empty);
        }

    }
}
