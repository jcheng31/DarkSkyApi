namespace ForecastPCL.Test
{
    using System.Configuration;

    using ForecastIOPortable;

    using NUnit.Framework;

    /// <summary>
    /// Tests for the main ForecastApi class.
    /// </summary>
    [TestFixture]
    public class ApiTests
    {
        private string apiKey;

        // These coordinates came from the Forecast API documentation,
        // and should return forecasts with all blocks.
        private const double AlcatrazLatitude = 37.8267;
        private const double AlcatrazLongitude = -122.423;


        [TestFixtureSetUp]
        public void SetUp()
        {
            this.apiKey = ConfigurationManager.AppSettings["ApiKey"];
        }

        /// <summary>
        /// Checks that attempting to retrieve data with a null API key throws
        /// an exception.
        /// </summary>
        [Test]
        public void NullKeyThrowsException()
        {
            var client = new ForecastApi(null);
            Assert.That(async () => await client.GetWeatherDataAsync(AlcatrazLatitude, AlcatrazLongitude), Throws.InvalidOperationException);
        }

        /// <summary>
        /// Checks that attempting to retrieve data with an empty string as the
        /// API key throws an exception.
        /// </summary>
        [Test]
        public void EmptyKeyThrowsException()
        {
            var client = new ForecastApi(string.Empty);
            Assert.That(async () => await client.GetWeatherDataAsync(AlcatrazLatitude, AlcatrazLongitude), Throws.InvalidOperationException);
        }

        /// <summary>
        /// Checks that using a valid API key will allow requests to be made.
        /// <para>An API key can be specified in the project's app.config file.</para>
        /// </summary>
        [Test]
        public async void ValidKeyRetrievesData()
        {
            var client = new ForecastApi(this.apiKey);

            var result = await client.GetWeatherDataAsync(AlcatrazLatitude, AlcatrazLongitude);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Currently, Is.Not.Null);
        }


            var result = await client.GetWeatherDataAsync(1, 1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Currently, Is.Not.Null);
        }
    }
}
