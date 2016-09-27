namespace ForecastPCL.Test
{
    using System;
    using System.Configuration;
    using System.Threading.Tasks;

    using DarkSkyApi;

    using NUnit.Framework;

    [TestFixture]
    public class LanguageTests
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

        /// <summary>
        /// Sets up all tests by retrieving the API key from app.config.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            apiKey = ConfigurationManager.AppSettings["ApiKey"];
        }

        [Test]
        public void AllLanguagesHaveValues()
        {
            foreach (Language language in Enum.GetValues(typeof(Language)))
            {
                Assert.That(() => language.ToValue(), Throws.Nothing);
            }
        }

        [Test]
        public async Task UnicodeLanguageIsSupported()
        {
            var client = new ForecastApi(apiKey);
            var result = await client.GetWeatherDataAsync(AlcatrazLatitude, AlcatrazLongitude, Unit.Auto, Language.Chinese);
            Assert.That(result, Is.Not.Null);
        }
    }
}
