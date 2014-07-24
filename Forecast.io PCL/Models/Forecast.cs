using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForecastIOPortable.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Forecast
    {
        [DataMember(Name = "latitude")]
        public float Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public float Longitude { get; set; }

        [DataMember(Name = "timezone")]
        public string TimeZone { get; set; }

        [DataMember(Name = "currently")]
        public CurrentDataPoint Currently { get; set; }

        [DataMember(Name = "minutely")]
        public MinuteForecast Minutely { get; set; }

        [DataMember(Name = "hourly")]
        public HourForecast Hourly { get; set; }

        [DataMember(Name = "flags")]
        public Flags Flags { get; set; }
    }
}
