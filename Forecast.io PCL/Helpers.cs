using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForecastIOPortable
{
    public class Helpers
    {
        /// <summary>
        /// Converts Unix Time (seconds since January 1, 1970) to a DateTime object.
        /// </summary>
        /// <param name="secondsSince">
        /// Seconds since January 1, 1970.
        /// </param>
        /// <returns>
        /// <see cref="DateTime"/> representing the given Unix time.
        /// </returns>
        public static DateTime UnixTimeToDateTime(int secondsSince)
        {
            var baseTime = new DateTime(1970, 1, 1, 0, 0, 0);
            var converted = baseTime.AddSeconds(secondsSince);

            return converted;
        }

        /// <summary>
        /// Converts a DateTime object to Unix Time (seconds since January 1, 1970).
        /// </summary>
        /// <param name="time">The DateTime to convert.</param>
        /// <returns>The seconds since January 1, 1970.</returns>
        public static int DateTimeToUnixTime(DateTime time)
        {
            var baseTime = new DateTime(1970, 1, 1, 0, 0, 0);
            var seconds = time.Subtract(baseTime).TotalSeconds;

            return (int)seconds;
        }
    }
}
