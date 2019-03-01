using System;

namespace Huk.LocCount
{
    internal class CommandLineInterface
    {
        int totalSum = 0;
        int LocSum = 0;
        internal void ShowLocStat(LocStat currentLoc)
        {
            totalSum += currentLoc.TotalLines;
            LocSum += currentLoc.LinesOfCode;
            Console.WriteLine($"{currentLoc.Filename}\t->{currentLoc.TotalLines}\t->{currentLoc.LinesOfCode}");
        }
        internal void ShowTotal() {
            Console.WriteLine("Total:");
            Console.WriteLine($"\tLines:{totalSum}");
            Console.WriteLine($"\tLoC:{LocSum}");
        }

        internal void ShowError(string fehler)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Bei der Verabeitung von {fehler} ist ein aufgetreten, wird übergangen.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}