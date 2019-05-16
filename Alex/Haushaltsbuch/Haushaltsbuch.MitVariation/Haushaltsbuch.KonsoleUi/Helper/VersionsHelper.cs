using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.KonsoleUi.Helper
{
    public static class VersionsHelper
    {
        public static string GetVersionsnummer(Assembly assembly)
        {
            string result = string.Empty;

            string assemblyVersion = assembly.GetName().Version.ToString();

            var temp = assemblyVersion.Split('.');
            if (temp != null && temp.Length >= 3)
            {
                result = $"{temp.ElementAt(0)}.{temp.ElementAt(1)}.{temp.ElementAt(2)}";
            }

            return result;
        }
    }
}
