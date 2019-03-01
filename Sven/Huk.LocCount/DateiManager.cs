using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Huk.LocCount
{
    class DateiManager
    {
        public void QuellCodeDateien_finden(string Path, Action<string> DateiGefunden,Action<string> FehlerAction) {

            var basedir = new System.IO.DirectoryInfo(Path);
            try
            {
                var CsFiles = basedir.GetFiles("*.cs");
                foreach (var item in CsFiles)
                {
                    DateiGefunden(item.FullName);
                }
                var Dirs = basedir.GetDirectories();
                foreach (var item in Dirs)
                {
                    QuellCodeDateien_finden(item.FullName, DateiGefunden, FehlerAction);
                }
            }
            catch {

                FehlerAction(Path);

            }
        }
        public static void LeseDatei(string Filename,Action<string, string[]>SuccessAction, Action<string> FehlerAction) {

            try
            {
                var Lines = File.ReadAllLines(Filename);
                SuccessAction(Filename, Lines);
            }
            catch {

                FehlerAction(Filename);
            }
        }
    }
}
