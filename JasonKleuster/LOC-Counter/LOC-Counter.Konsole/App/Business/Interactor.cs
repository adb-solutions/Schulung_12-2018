using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOC_Counter.Konsole.App.Persistence;

namespace LOC_Counter.Konsole.App.Business
{
    class Interactor
    {
        public void CountLinesOfCode(string[] args, 
            Action<LOCStat> onSuccess, 
            Action onComplete,
            Action<string> onFileAccessError,
            Action<string> onFolderAccessError)
        {
            CommandLine command = new CommandLine();
            FileAccess fileAccess = new FileAccess();
            LinesOfCode loc = new LinesOfCode();


            string path = command.GetPath(args);

            fileAccess.FindSourceCodeFile(path, 
                onVorhanden: (filename) =>
                {
                    var lines = fileAccess.ReadFile(filename);
                    loc.CreateLinesOfCodeStat(lines);
                },
                onKeineWeiteren: () =>
                {

                }
            );
        }
    }
}
