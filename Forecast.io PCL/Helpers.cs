using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForecastIOPortable
{
    public class Helpers
    {
        public static DateTime UnixTimeToDateTime(int secondsSince)
        {
            var baseTime = new DateTime(1970, 1, 1, 0, 0, 0);
            var converted = baseTime.AddSeconds(secondsSince);

            return converted;
        }
    }
}
