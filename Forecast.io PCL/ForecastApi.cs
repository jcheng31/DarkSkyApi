using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForecastIOPortable
{
    public class ForecastApi
    {
        private string apiKey;

        public ForecastApi(string key)
        {
            this.apiKey = key;
        }
    }
}
