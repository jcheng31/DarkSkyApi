namespace ForecastPCL.Test
{
    using System.Collections.Generic;
    using System.Configuration;

    using ForecastIOPortable;

    using NUnit.Framework;

    /// <summary>
    /// Tests for the main ForecastApi class.
    /// </summary>
    [TestFixture]
    public class ApiTests
    {
        // These coordinates came from the Forecast API documentation,
        // and should return forecasts with all blocks.
        private const double AlcatrazLatitude = 37.8267;
        private const double AlcatrazLongitude = -122.423;

        /// <summary>
        /// API key to be used for testing. This should be specified in the
        /// test project's app.config file.
        /// </summary>
        private string apiKey;

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

        /// <summary>
        /// Checks that specifying a block to be excluded from the results
        /// will cause it to be null in the returned forecast.
        /// </summary>
        [Test]
        public async void ExclusionWorksCorrectly()
        {
            var client = new ForecastApi(this.apiKey);
            var exclusionList = new List<Exclude> { Exclude.Minutely };

            var result = await client.GetWeatherDataAsync(AlcatrazLatitude, AlcatrazLongitude, Unit.US, exclusionList);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Currently, Is.Not.Null);
            Assert.That(result.Minutely, Is.Null);
        }

        /// <summary>
        /// Checks that specifying multiple blocks to be excluded causes
        /// them to left out.
        /// </summary>
        [Test]
        public async void MultipleExclusionWorksCorrectly()
        {
            var client = new ForecastApi(this.apiKey);
            var exclusionList = new List<Exclude> { Exclude.Minutely, Exclude.Hourly, Exclude.Daily };

            var result = await client.GetWeatherDataAsync(AlcatrazLatitude, AlcatrazLongitude, Unit.US, exclusionList);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Currently, Is.Not.Null);
            Assert.That(result.Minutely, Is.Null);
            Assert.That(result.Hourly, Is.Null);
            Assert.That(result.Daily, Is.Null);
        }

        /// <summary>
        /// Checks that the service returns data using the specified units of measurement.
        /// </summary>
        [Test]
        public async void UnitsCanBeSpecified()
        {
            var client = new ForecastApi(this.apiKey);

            var result = await client.GetWeatherDataAsync(AlcatrazLatitude, AlcatrazLongitude, Unit.CA);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Flags.Units, Is.EqualTo(Unit.CA.ToValue()));
        }
    }
}
