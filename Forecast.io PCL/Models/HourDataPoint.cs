namespace ForecastIOPortable.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class HourDataPoint
    {
        [DataMember]
        private int time;

        public DateTime Time
        {
            get
            {
                return Helpers.UnixTimeToDateTime(this.time);
            }

            set
            {
                this.time = Helpers.DateTimeToUnixTime(value);
            }
        }

        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "precipIntensity")]
        public float PrecipitationIntensity { get; set; }

        [DataMember(Name = "precipProbability")]
        public float PrecipitationProbability { get; set; }

        [DataMember(Name = "temperature")]
        public float Temperature { get; set; }

        [DataMember(Name = "apparentTemperature")]
        public float ApparentTemperature { get; set; }

        [DataMember(Name = "dewPoint")]
        public float DewPoint { get; set; }

        [DataMember(Name = "humidity")]
        public float Humidity { get; set; }

        [DataMember(Name = "windSpeed")]
        public float WindSpeed { get; set; }

        [DataMember(Name = "windBearing")]
        public float WindBearing { get; set; }

        [DataMember(Name = "visibility")]
        public float Visibility { get; set; }

        [DataMember(Name = "cloudCover")]
        public float CloudCover { get; set; }

        [DataMember(Name = "pressure")]
        public float Pressure { get; set; }

        [DataMember(Name = "ozone")]
        public float Ozone { get; set; }
    }
}
