namespace ForecastIOPortable
{
    using System;

    /// <summary>
    /// Various helper methods.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// DateTime representing 0 Unix time: January 1, 1970, GMT.
        /// </summary>
        private static readonly DateTimeOffset BaseUnixTime = new DateTimeOffset(1970, 1, 1, 0, 0, 0, new TimeSpan());

        /// <summary>
        /// Converts Unix Time (seconds since January 1, 1970 UTC) to a DateTimeOffset object.
        /// </summary>
        /// <param name="secondsSince">
        /// Seconds since January 1, 1970.
        /// </param>
        /// <returns>
        /// <see cref="DateTime"/> representing the given Unix time.
        /// </returns>
        public static DateTimeOffset ToDateTimeOffset(this int secondsSince)
        {
            var converted = BaseUnixTime.AddSeconds(secondsSince);

            return converted;
        }

        /// <summary>
        /// Converts this DateTimeOffset to Unix time (seconds since January 1, 1970 UTC).
        /// </summary>
        /// <param name="time"></param>
        /// <returns>The number of seconds since January 1, 1970 UTC.</returns>
        public static int ToUnixTime(this DateTimeOffset time)
        {
            var seconds = time.Subtract(BaseUnixTime).TotalSeconds;

            return (int)seconds;
        }
    }
}
