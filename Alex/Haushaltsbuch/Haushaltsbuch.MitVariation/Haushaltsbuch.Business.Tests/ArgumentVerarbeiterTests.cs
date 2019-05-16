using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Haushaltsbuch.Business.Tests
{
    [TestFixture]
    class ArgumentVerarbeiterTests
    {
        [Test]
        public void Test()
        {
            decimal a = decimal.Parse("5,99");

            decimal b = decimal.Parse("228,02");
            DateTime datum;
            DateTime.TryParse("228,02", out datum);
        }
    }
}
