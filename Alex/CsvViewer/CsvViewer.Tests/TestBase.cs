using System;
using System.IO;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    public class TestBase
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var dir = Path.GetDirectoryName(typeof(ArgumentVerarbeiterTests).Assembly.Location);
            if (dir != null)
            {
                Environment.CurrentDirectory = dir;
                Directory.SetCurrentDirectory(dir);
            }
            else
                throw new Exception("Path.GetDirectoryName(typeof(ArgumentVerarbeiterTests).Assembly.Location) returned null");
        }

        public string GetRelativePfad(string ordner, string dateiname)
        {
            var x = Path.DirectorySeparatorChar;
            return $"{ordner}{Path.DirectorySeparatorChar}{dateiname}";
        }
    }
}
