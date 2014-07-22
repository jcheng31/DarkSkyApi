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
        [DataMember]
        private int time;

        [DataMember(Name = "Summary")]
        public string summary;

        [DataMember(Name = "Icon")]
        public string icon;

        [DataMember]
        private int sunriseTime;

        [DataMember]
        private int sunsetTime;

        [DataMember(Name = "MoonPhase")]
        public float moonPhase;

        [DataMember(Name = "PrecipitationIntensity")]
        public float precipIntensity;

        [DataMember(Name = "MaxPrecipitationIntensity")]
        public float precipIntensityMax;

        [DataMember(Name = "PrecipitationProbability")]
        public float precipProbability;

        [DataMember(Name = "MinTemperature")]
        public float temperatureMin;

        [DataMember]
        private int temperatureMinTime;

        [DataMember(Name = "MaxTemperature")]
        public float temperatureMax;

        [DataMember]
        private int temperatureMaxTime;

        [DataMember(Name = "ApparentMinTemperature")]
        public float apparentTemperatureMin;

        [DataMember]
        private int apparentTemperatureMinTime;

        [DataMember(Name = "ApparentMaxTemperature")]
        public float apparentTemperatureMax;

        [DataMember]
        private int apparentTemperatureMaxTime;

        [DataMember(Name = "DewPoint")]
        public float dewPoint;

        [DataMember(Name = "Humidity")]
        public float humidity;

        [DataMember(Name = "WindSpeed")]
        public float windSpeed;

        [DataMember(Name = "WindBearing")]
        public float windBearing;

        [DataMember(Name = "Visibility")]
        public float visibility;

        [DataMember(Name = "CloudCover")]
        public float cloudCover;

        [DataMember(Name = "Pressure")]
        public float pressure;

        [DataMember(Name = "Ozone")]
        public float ozone;
    }
}
