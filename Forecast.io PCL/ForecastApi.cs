using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForecastIOPortable
{
    public class ForecastApi
    {
        private string apiKey;

        private const string currentConditionsUrl = "https://api.forecast.io/forecast/{0}/{1},{2}?units={3}&extend={4}&exclude={5}&lang={6}";
        private const string specificTimeConditionsUrl = "https://api.forecast.io/forecast/{0}/{1},{2},{3?units={4}&extend={5}&exclude={6}&lang={7}";

        public ForecastApi(string key)
        {
            this.apiKey = key;
        }
    }
}
