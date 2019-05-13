using System;
using System.Collections.Generic;
using System.Linq;

namespace LOCcount.Business
{
    public class LOCCounter
    {
        private DateiBereitsteller _dateiBereitsteller;
        private ArgumentVerarbeiter _argumentVerarbeiter;

        public LOCCounter()
        { 
            _dateiBereitsteller = new DateiBereitsteller();
            _argumentVerarbeiter = new ArgumentVerarbeiter();
        }

        public void Count_LOC(
                                string[] args, 
                                Action<LOCStat> onLOCStat, 
                                Action onAbgeschlossen,
                                Action<string> onFehlerDateilesen,
                                Action<string> onFehlerDateienFinden)
        {
            string pfad = _argumentVerarbeiter.Ermittle_Pfad(args);

            _dateiBereitsteller.Quellcodedateien_finden(
                pfad,
                onDateiname: (dateiname) => {
                    _dateiBereitsteller.Lese_Dateiinhalt(
                        dateiname,
                        onErfolg: (zeilen) => {
                            var locstat = LOCStat_erstellen(dateiname, zeilen);
                            onLOCStat(locstat);
                        },
                        onFehler: (fehlerPfad) => {
                            onFehlerDateilesen(fehlerPfad);
                        }
                    );
                },
                onAbgeschlossen: onAbgeschlossen,
                onFehler: (dateiname) => {
                    onFehlerDateienFinden(dateiname);
                }
            );
        }

        public LOCStat LOCStat_erstellen(string dateiname, IEnumerable<string> zeilen)
        {
            var codezeilen = zeilen.Where(li => !string.IsNullOrWhiteSpace(li) && !li.Trim().StartsWith("//", StringComparison.OrdinalIgnoreCase));

            var result = new LOCStat()
            {
                Filename = dateiname,
                AnzahlZeilen = zeilen.Count(),
                AnzahlCodezeilen = codezeilen.Count()
            };

            return result;
        }
    }
}
