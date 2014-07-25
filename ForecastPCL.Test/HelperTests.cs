namespace ForecastPCL.Test
{
    using System;
    using ForecastIOPortable;
    using NUnit.Framework;

    /// <summary>
    /// Unit tests for the Helpers class.
    /// </summary>
    [TestFixture]
    public class HelperTests
    {
        /// <summary>
        /// Tests conversion of 0 Unix time to a DateTime object.
        /// Ensures we're using the correct base time.
        /// </summary>
        [Test]
        public void ConvertZero()
        {
            var expected = new DateTime(1970, 1, 1, 0, 0, 0);
            var actual = Helpers.UnixTimeToDateTime(0);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests conversion of a particular date and time in Unix time to a known DateTime.
        /// Ensures such conversion works as it should.
        /// </summary>
        [Test]
        public void ConvertSpecificDate()
        {
            var expected = new DateTime(2014, 7, 23, 3, 40, 49);
            var actual = Helpers.UnixTimeToDateTime(1406086849);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests conversion of a DateTime set to the Unix base back to an integer.
        /// Ensures we're using the correct base time.
        /// </summary>
        [Test]
        public void ConvertBackZero()
        {
            var expected = 0;
            var actual = Helpers.DateTimeToUnixTime(new DateTime(1970, 1, 1, 0, 0, 0));

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests conversion of a known DateTime back to an integer.
        /// Ensures such conversion works as it should.
        /// </summary>
        [Test]
        public void ConvertBackSpecificDate()
        {
            var expected = 1406086849;
            var actual = Helpers.DateTimeToUnixTime(new DateTime(2014, 7, 23, 3, 40, 49));

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
