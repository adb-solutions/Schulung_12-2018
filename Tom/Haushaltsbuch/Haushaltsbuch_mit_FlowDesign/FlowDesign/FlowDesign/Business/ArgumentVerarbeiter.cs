using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlowDesign.Business
{
    class ArgumentVerarbeiter
    {
        public string leseErstenParameter(string input)
        {
            return Regex.Split(input.TrimStart(), @"[\s]")[0];
        }

        public void operationsAuswahl(string operation)
        {

        }

        public DateTime entnehmeZeit(string input)
        {
            DateTime datum = DateTime.Now.ToString("yyyy");
            return datum;
        }
    }
}