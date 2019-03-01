using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huk.LocCount
{
    static class LocStatManager
    {
        public static LocStat ErstelleLoCStat(string Dateiname, string[] Zeilen)
        {
            var regExp = new System.Text.RegularExpressions.Regex(@"^\s+$|^\s*\/\/", System.Text.RegularExpressions.RegexOptions.Multiline);

            var locStat = new LocStat() { Filename = Dateiname, TotalLines = Zeilen.Length };
            var matches = regExp.Matches(string.Join("\r\n", Zeilen));
            locStat.LinesOfCode = locStat.TotalLines - matches.Count;

            return locStat;
        }
        public static void ErstelleLoCStat(string Dateiname, string[] Zeilen, Action<LocStat> SuccessAction) {

            var tmp = ErstelleLoCStat(Dateiname, Zeilen);
            SuccessAction(tmp);
        }
    }
}
