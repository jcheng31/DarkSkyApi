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
        public string summary;

        [DataMember(Name = "Icon")]
        public string icon;

        [DataMember(Name = "PrecipitationIntensity")]
        public float precipIntensity;

        [DataMember(Name = "PrecipitationProbability")]
        public float precipProbability;

        [DataMember(Name = "Temperature")]
        public float temperature;

        [DataMember(Name = "ApparentTemperature")]
        public float apparentTemperature;

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
