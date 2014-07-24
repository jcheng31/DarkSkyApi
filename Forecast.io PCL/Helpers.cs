namespace ForecastIOPortable
{
    using System;

    /// <summary>
    /// Various helper methods.
    /// </summary>
    public class Helpers
    {
        /// <summary>
        /// DateTime representing 0 Unix time: January 1, 1970, GMT.
        /// </summary>
        private static readonly DateTime BaseUnixTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Converts Unix Time (seconds since January 1, 1970 GMT) to a DateTime object.
        /// </summary>
        /// <param name="secondsSince">
        /// Seconds since January 1, 1970.
        /// </param>
        /// <returns>
        /// <see cref="DateTime"/> representing the given Unix time.
        /// </returns>
        public static DateTime UnixTimeToDateTime(int secondsSince)
        {
            var converted = BaseUnixTime.AddSeconds(secondsSince);

            return converted;
        }

        /// <summary>
        /// Converts a DateTime object to Unix Time (seconds since January 1, 1970).
        /// </summary>
        /// <param name="time">The DateTime to convert.</param>
        /// <returns>The seconds since January 1, 1970.</returns>
        public static int DateTimeToUnixTime(DateTime time)
        {
            var seconds = time.Subtract(BaseUnixTime).TotalSeconds;

            return (int)seconds;
        }
    }
}
