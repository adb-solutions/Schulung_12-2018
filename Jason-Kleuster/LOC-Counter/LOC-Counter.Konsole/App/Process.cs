using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LOC_Counter.Konsole.App.Business;
using LOC_Counter.Konsole.App.Persistence;

namespace LOC_Counter.Konsole.App
{
    class Process
    {
        public void Start(string[] args)
        {
            Interactor interactor = new Interactor();

            int totalLines = 0;
            int totalLinesOfCode = 0;

            interactor.CountLinesOfCode(args,
                onFileAccessError: (filename) =>
                {
                    // UI
                },
                onFolderAccessError: (pfad) => 
                {
                    // UI
                },
                onSuccess: (locStat) =>
                {
                    // UI end
             
                    Console.WriteLine($"");
                    totalLines += locStat.Total;
                    totalLinesOfCode += locStat.LinesOfCode;
                },
                onComplete: () =>
                {
                    
                }
            );
        }
    }
}
