using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace ForecastPCL.Test
{
    using System;
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

        private const double MumbaiLatitude = 18.975;
        private const double MumbaiLongitude = 72.825833;

        /// <summary>
        /// API key to be used for testing. This should be specified in the
        /// test project's app.config file.
        /// </summary>
        private string apiKey;

        /// <summary>
        /// Sets up all tests by retrieving the API key from app.config.
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            apiKey = ConfigurationManager.AppSettings["ApiKey"];
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
        public async Task ValidKeyRetrievesData()
        {
            var client = new ForecastApi(apiKey);

            var result = await client.GetWeatherDataAsync(AlcatrazLatitude, AlcatrazLongitude);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Currently, Is.Not.Null);
        }
        
        /// <summary>
        /// Checks that a request can be made for a non-US location.
        /// Added to test GitHub issue 6.
        /// </summary>
        [Test]
        public async Task NonUSDataCanBeRetrieved()
        {
            var client = new ForecastApi(apiKey);

            var result = await client.GetWeatherDataAsync(MumbaiLatitude, MumbaiLongitude);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Currently, Is.Not.Null);
        }

        /// <summary>
        /// Checks that requests can be made with Unit.SI.
        /// </summary>
        [Test]
        public async Task UnitSIWorksCorrectly()
        {
            var client = new ForecastApi(apiKey);

            var result = await client.GetWeatherDataAsync(MumbaiLatitude, MumbaiLongitude, Unit.SI);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Currently, Is.Not.Null);
        }

        /// <summary>
        /// Checks that requests can be made with Unit.UK.
        /// </summary>
        public async Task UnitUKWorksCorrectly()
        {
            var client = new ForecastApi(apiKey);

            var result = await client.GetWeatherDataAsync(MumbaiLatitude, MumbaiLongitude, Unit.UK);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Currently, Is.Not.Null);
        }

        /// <summary>
        /// Checks that specifying a block to be excluded from the results
        /// will cause it to be null in the returned forecast.
        /// </summary>
        [Test]
        public async Task ExclusionWorksCorrectly()
        {
            var client = new ForecastApi(apiKey);
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
        public async Task MultipleExclusionWorksCorrectly()
        {
            var client = new ForecastApi(apiKey);
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
        public async Task UnitsCanBeSpecified()
        {
            var client = new ForecastApi(apiKey);

            var result = await client.GetWeatherDataAsync(AlcatrazLatitude, AlcatrazLongitude, Unit.CA);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Flags.Units, Is.EqualTo(Unit.CA.ToValue()));
        }

        /// <summary>
        /// Checks that retrieving data for a past date works correctly.
        /// </summary>
        [Test]
        public async Task CanRetrieveForThePast()
        {
            var client = new ForecastApi(apiKey);
            var date = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0));

            var result = await client.GetTimeMachineWeatherAsync(AlcatrazLatitude, AlcatrazLongitude, date);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Currently, Is.Not.Null);
        }

        /// <summary>
        /// Checks that specifying a block to be excluded from forecasts for past dates
        /// will cause it to be null in the returned forecast.
        /// </summary>
        [Test]
        public async Task TimeMachineExclusionWorksCorrectly()
        {
            var client = new ForecastApi(apiKey);
            var date = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0));
            var exclusionList = new List<Exclude> { Exclude.Hourly };

            var result = await client.GetTimeMachineWeatherAsync(AlcatrazLatitude, AlcatrazLongitude, date, Unit.US, exclusionList);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Currently, Is.Not.Null);
            Assert.That(result.Hourly, Is.Null);
        }

        /// <summary>
        /// Checks that the service returns data using the specified units of measurement.
        /// </summary>
        [Test]
        public async Task TimeMachineUnitsCanBeSpecified()
        {
            var client = new ForecastApi(apiKey);
            var date = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0));

            var result = await client.GetTimeMachineWeatherAsync(AlcatrazLatitude, AlcatrazLongitude, date, Unit.CA);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Flags.Units, Is.EqualTo(Unit.CA.ToValue()));
        }

        [Test]
        public async Task TimeMachineWorksWithCommaDecimalSeperator()
        {
            var client = new ForecastApi(apiKey);
            var date = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0));

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
            var result = await client.GetTimeMachineWeatherAsync(AlcatrazLatitude, AlcatrazLongitude, date, Unit.CA);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Currently, Is.Not.Null);
        }

        [Test]
        public async Task TimeMachineWorksWithPeriodDecimalSeperator()
        {
            var client = new ForecastApi(apiKey);
            var date = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0));

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            var result = await client.GetTimeMachineWeatherAsync(AlcatrazLatitude, AlcatrazLongitude, date, Unit.CA);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Currently, Is.Not.Null);
        }

        [Test]
        public async Task WorksWithCommaDecimalSeperator()
        {
            var client = new ForecastApi(apiKey);

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
            var result = await client.GetWeatherDataAsync(AlcatrazLatitude, AlcatrazLongitude);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Currently, Is.Not.Null);
        }

        [Test]
        public async Task WorksWithPeriodDecimalSeperator()
        {
            var client = new ForecastApi(apiKey);

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            var result = await client.GetWeatherDataAsync(AlcatrazLatitude, AlcatrazLongitude);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Currently, Is.Not.Null);
        }
    }
}
