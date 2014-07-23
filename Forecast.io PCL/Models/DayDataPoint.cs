using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForecastIOPortable.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class DayDataPoint
    {
        [DataMember(Name = "time")]
        private int UnixTime { get; set; }

        [DataMember(Name = "Summary")]
        public string summary { get; set; }

        [DataMember(Name = "Icon")]
        public string icon { get; set; }

        [DataMember]
        private int sunriseTime { get; set; }

        [DataMember]
        private int sunsetTime { get; set; }

        [DataMember(Name = "MoonPhase")]
        public float moonPhase { get; set; }

        [DataMember(Name = "PrecipitationIntensity")]
        public float precipIntensity { get; set; }

        [DataMember(Name = "MaxPrecipitationIntensity")]
        public float precipIntensityMax { get; set; }

        [DataMember(Name = "PrecipitationProbability")]
        public float precipProbability { get; set; }

        [DataMember(Name = "MinTemperature")]
        public float temperatureMin { get; set; }

        [DataMember]
        private int temperatureMinTime { get; set; }

        [DataMember(Name = "MaxTemperature")]
        public float temperatureMax { get; set; }

        [DataMember]
        private int temperatureMaxTime { get; set; }

        [DataMember(Name = "ApparentMinTemperature")]
        public float apparentTemperatureMin { get; set; }

        [DataMember]
        private int apparentTemperatureMinTime { get; set; }

        [DataMember(Name = "ApparentMaxTemperature")]
        public float apparentTemperatureMax { get; set; }

        [DataMember]
        private int apparentTemperatureMaxTime { get; set; }

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
