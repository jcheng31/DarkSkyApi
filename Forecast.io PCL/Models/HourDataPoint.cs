using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ForecastIOPortable.Models
{
    [DataContract]
    public class HourDataPoint
    {
        [DataMember]
        private int time;

        [DataMember(Name = "Summary")]
        public string summary { get; set; }

        [DataMember(Name = "Icon")]
        public string icon { get; set; }

        [DataMember(Name = "PrecipitationIntensity")]
        public float precipIntensity { get; set; }

        [DataMember(Name = "PrecipitationProbability")]
        public float precipProbability { get; set; }

        [DataMember(Name = "Temperature")]
        public float temperature { get; set; }

        [DataMember(Name = "ApparentTemperature")]
        public float apparentTemperature { get; set; }

        [DataMember(Name = "DewPoint")]
        public float dewPoint { get; set; }

        [DataMember(Name = "Humidity")]
        public float humidity { get; set; }

        [DataMember(Name = "WindSpeed")]
        public float windSpeed { get; set; }

        [DataMember(Name = "WindBearing")]
        public float windBearing { get; set; }

        [DataMember(Name = "Visibility")]
        public float visibility { get; set; }

        [DataMember(Name = "CloudCover")]
        public float cloudCover { get; set; }

        [DataMember(Name = "Pressure")]
        public float pressure { get; set; }

        [DataMember(Name = "Ozone")]
        public float ozone { get; set; }
    }
}
