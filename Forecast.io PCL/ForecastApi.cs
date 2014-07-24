using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForecastIOPortable
{
    public class ForecastApi
    {
        /// <summary>
        /// The API endpoint to retrieve current weather conditions.
        /// {0} - API key.
        /// {1} - Latitude.
        /// {2} - Longitude.
        /// {3} - Units.
        /// {4} - Extends hourly data to include the next 7 days (if "hourly" is given).
        /// {5} - Any blocks to be excluded from the results.
        /// {6} - The language to be used in text summaries.
        /// </summary>
        private const string CurrentConditionsUrl = "https://api.forecast.io/forecast/{0}/{1},{2}?units={3}&extend={4}&exclude={5}&lang={6}";

        /// <summary>
        /// The API endpoint to retrieve weather conditions at a particular date and time.
        /// {0} - API key.
        /// {1} - Latitude.
        /// {2} - Longitude.
        /// {3} - Time to retrieve, either Unix time or [YYYY]-[MM]-[DD]T[HH]:[MM]:[SS].
        /// {4} - Units.
        /// {5} - Extends hourly data to include the next 7 days (if "hourly" is given).
        /// {6} - Any blocks to be excluded from the results.
        /// {7} - The language to be used in text summaries. 
        /// </summary>
        private const string SpecificTimeConditionsUrl = "https://api.forecast.io/forecast/{0}/{1},{2},{3?units={4}&extend={5}&exclude={6}&lang={7}";

        /// <summary>
        /// The API key to use in all requests.
        /// </summary>
        private string apiKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="ForecastApi"/> class.
        /// </summary>
        /// <param name="key">
        /// The API key to use.
        /// </param>
        public ForecastApi(string key)
        {
            this.apiKey = key;
        }
    }
}
