using System;
using LOCcount.Business;

namespace LOCcount
{
    class MainClass
    {
        public static void Main(string[] args)
        {
#if DEBUG
            //args = new string[] { "/Users/UseAlba/Documents/workspace/TFS" };
            args = new string[] { "/shared/CsvViewer" };
#endif

            var ui = new UI();
            new LOCCounter().Count_LOC(
                    args, 
                    onLOCStat: ui.OnLOCStat, 
                    onAbgeschlossen: ui.OnAbgeschlossen,
                    onFehlerDateilesen: ui.OnFehlerDateilesen,
                    onFehlerDateienFinden: ui.OnFehlerDateienFinden
            );
        }
    }
}
