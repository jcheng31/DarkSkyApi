using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastPCL.Test
{
    using ForecastIOPortable;

    using NUnit.Framework;

    [TestFixture]
    class HelperTests
    {
        [Test]
        public void ConvertZero()
        {
            var expected = new DateTime(1970, 1, 1, 0, 0, 0);
            var actual = Helpers.UnixTimeToDateTime(0);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ConvertSpecificDate()
        {
            var expected = new DateTime(2014, 7, 23, 3, 40, 49);
            var actual = Helpers.UnixTimeToDateTime(1406086849);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
