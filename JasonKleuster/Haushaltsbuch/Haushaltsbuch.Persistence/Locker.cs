using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Haushaltsbuch.Persistence
{
    public class Locker
    {
        private const string pfad = @"C:\Temp\Lock.txt";

        public void Lock_starten()
        {
            try
            {
                File.Create(pfad);
            }
            catch
            {
                throw new Exception("Fehler - Lock_starten");
            }
        }

        public void Lock_beenden()
        {
            //try
            //{
            //    File.Delete(pfad);
            //}
            //catch
            //{
            //    throw new Exception("Fehler - Lock_starten");
            //}
        }

        public void Check_for_locked(Action unlocked, Action locked)
        {
            if (File.Exists(pfad))
            {
                locked();
            }
            else if (!File.Exists(pfad))
            {
                unlocked();
            }
            else
            {
                throw new Exception("Fehler - Lock_starten");
            }
        }

        public void Warte()
        {
            Thread.Sleep(60);
        }
    }
}
