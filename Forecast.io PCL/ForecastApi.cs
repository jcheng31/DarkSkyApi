namespace ForecastIOPortable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.Serialization.Json;
    using System.Threading.Tasks;
    using ForecastIOPortable.Models;

    /// <summary>
    /// The Forecast.IO service. Returns weather data for given locations,
    /// and provides API usage information.
    /// </summary>
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
        private const string SpecificTimeConditionsUrl = "https://api.forecast.io/forecast/{0}/{1},{2},{3}?units={4}&extend={5}&exclude={6}&lang={7}";

        /// <summary>
        /// The API key to use in all requests.
        /// </summary>
        private readonly string apiKey;

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
        
        /// <summary>
        /// Gets the number of API calls made today using the given API key.
        /// <para>This property will be null until a request has been made.</para>
        /// </summary>
        public int? ApiCallsMade { get; private set; }

        /// <summary>
        /// Asynchronously retrieves weather data for a particular latitude and longitude.
        /// </summary>
        /// <param name="latitude">
        /// The latitude to retrieve data for.
        /// </param>
        /// <param name="longitude">
        /// The longitude to retrieve data for.
        /// </param>
        /// <returns>
        /// A <see cref="Forecast"/> with the requested data, or null if the data was corrupted.
        /// </returns>
        public async Task<Forecast> GetWeatherDataAsync(double latitude, double longitude)
        {
            return await this.GetWeatherDataAsync(latitude, longitude, Unit.US, new Extend[0], new Exclude[0], Language.English);
        }

        /// <summary>
        /// Asynchronously retrieves weather data for a particular latitude and longitude.
        /// <para>Allows specification of units of measurement.</para>
        /// </summary>
        /// <param name="latitude">
        /// The latitude to retrieve data for.
        /// </param>
        /// <param name="longitude">
        /// The longitude to retrieve data for.
        /// </param>
        /// <param name="units">
        /// The units of measurement to use.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> for a <see cref="Forecast"/> with the requested data, or null if the data was corrupted.
        /// </returns>
        public async Task<Forecast> GetWeatherDataAsync(double latitude, double longitude, Unit units)
        {
            return await this.GetWeatherDataAsync(latitude, longitude, units, new Extend[0], new Exclude[0], Language.English);
        }

        /// <summary>
        /// Asynchronously retrieves weather data for a particular latitude and longitude.
        /// <para>Allows specification of units of measurement and blocks to be excluded.</para>
        /// </summary>
        /// <param name="latitude">
        /// The latitude to retrieve data for.
        /// </param>
        /// <param name="longitude">
        /// The longitude to retrieve data for.
        /// </param>
        /// <param name="units">
        /// The units of measurement to use.
        /// </param>
        /// <param name="excludes">
        /// Any blocks that should be excluded from the request.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> for a <see cref="Forecast"/> with the requested data, or null if the data was corrupted.
        /// </returns>
        public async Task<Forecast> GetWeatherDataAsync(
            double latitude,
            double longitude,
            Unit units,
            IList<Exclude> excludes)
        {
            return await this.GetWeatherDataAsync(latitude, longitude, units, new Extend[0], excludes, Language.English);
        }

        /// <summary>
        /// Asynchronously retrieves weather data for a particular latitude and longitude.
        /// <para>
        /// Allows specification of units of measurement and the language to be used
        /// in summary text.
        /// </para>
        /// </summary>
        /// <param name="latitude">
        /// The latitude to retrieve data for.
        /// </param>
        /// <param name="longitude">
        /// The longitude to retrieve data for.
        /// </param>
        /// <param name="units">
        /// The units of measurement to use.
        /// </param>
        /// <param name="language">
        /// The language to use for summaries.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> for a <see cref="Forecast"/> with the requested data, or null if the data was corrupted.
        /// </returns>
        public async Task<Forecast> GetWeatherDataAsync(
            double latitude,
            double longitude,
            Unit units,
            Language language)
        {
            return await this.GetWeatherDataAsync(latitude, longitude, units, new Extend[0], new Exclude[0], language);
        }

        /// <summary>
        /// Asynchronously retrieves weather data for a particular latitude and longitude.
        /// <para>Allows specification of units of measurement, language used, extended hourly forecasts,
        /// and exclusion of data blocks.</para>
        /// </summary>
        /// <param name="latitude">
        /// The latitude to retrieve data for.
        /// </param>
        /// <param name="longitude">
        /// The longitude to retrieve data for.
        /// </param>
        /// <param name="unit">
        /// The units of measurement to use.
        /// </param>
        /// <param name="extends">
        /// The type of forecast to retrieve extended results for. Currently limited to hourly blocks.
        /// </param>
        /// <param name="excludes">
        /// Any blocks that should be excluded from the request.
        /// </param>
        /// <param name="language">
        /// The language to use for summaries.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> for a <see cref="Forecast"/> with the requested data, or null if the data was corrupted.
        /// </returns>
        /// <exception cref="HttpRequestException">
        /// Thrown when the service returned anything other than a 200 (Status OK) code.
        /// </exception>
        public async Task<Forecast> GetWeatherDataAsync(
            double latitude,
            double longitude,
            Unit unit,
            IList<Extend> extends,
            IList<Exclude> excludes,
            Language language)
        {
            this.ThrowExceptionIfApiKeyInvalid();

            var compressionHandler = GetCompressionHandler();

            var unitValue = unit.ToValue();
            var extendList = string.Join(",", extends.Select(x => x.ToValue()));
            var excludeList = string.Join(",", excludes.Select(x => x.ToValue()));
            var languageValue = language.ToValue();

            var formattedRequest = string.Format(
                CurrentConditionsUrl,
                this.apiKey,
                latitude,
                longitude,
                unitValue,
                extendList,
                excludeList,
                languageValue);

            using (var client = new HttpClient(compressionHandler))
            {
                var response = await client.GetAsync(formattedRequest);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException("Couldn't retrieve data: status " + response.StatusCode);
                }

                this.UpdateApiCallsMade(response);

                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var serializer = new DataContractJsonSerializer(typeof(Forecast));
                    var result = serializer.ReadObject(responseStream);

                    return result as Forecast;
                }
            }
        }
        
        /// <summary>
        /// Creates a HttpClientHandler that supports compression for responses.
        /// </summary>
        /// <returns>
        /// The <see cref="HttpClientHandler"/> with compression support.
        /// </returns>
        private static HttpClientHandler GetCompressionHandler()
        {
            var compressionHandler = new HttpClientHandler();
            if (compressionHandler.SupportsAutomaticDecompression)
            {
                compressionHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            }

            return compressionHandler;
        }

        /// <summary>
        /// Updates the number of API calls made using the value provided
        /// in the response to a weather data request.
        /// </summary>
        /// <param name="response">
        /// Response received after successfully requesting weather data.
        /// </param>
        private void UpdateApiCallsMade(HttpResponseMessage response)
        {
            IEnumerable<string> apiCallHeaderValues;
            if (response.Headers.TryGetValues("X-Forecast-API-Calls", out apiCallHeaderValues))
            {
                this.ApiCallsMade = int.Parse(apiCallHeaderValues.First());
            }
        }

        /// <summary>
        /// Checks if the user provided a non-null API key during initialization,
        /// and throws an exception if not.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the API key is null or the empty string.
        /// </exception>
        private void ThrowExceptionIfApiKeyInvalid()
        {
            if (string.IsNullOrEmpty(this.apiKey))
            {
                throw new InvalidOperationException("No API key was given.");
            }
        }
    }
}
