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

        [DataMember]
        private int sunriseTime;

        [DataMember]
        private int sunsetTime;

        [DataMember(Name = "moonPhase")]
        public float MoonPhase { get; set; }

        [DataMember(Name = "precipIntensity")]
        public float PrecipitationIntensity { get; set; }

        [DataMember(Name = "precipIntensityMax")]
        public float MaxPrecipitationIntensity { get; set; }

        [DataMember(Name = "precipProbability")]
        public float PrecipitationProbability { get; set; }

        [DataMember(Name = "temperatureMin")]
        public float MinTemperature { get; set; }

        [DataMember]
        private int temperatureMinTime;

        public DateTime MinTemperatureTime
        {
            get
            {
                return Helpers.UnixTimeToDateTime(this.temperatureMinTime);
            }

            set
            {
                this.temperatureMinTime = Helpers.DateTimeToUnixTime(value);
            }
        }

        [DataMember(Name = "temperatureMax")]
        public float MaxTemperature { get; set; }

        [DataMember]
        private int temperatureMaxTime;

        public DateTime MaxTemperatureTime
        {
            get
            {
                return Helpers.UnixTimeToDateTime(this.temperatureMaxTime);
            }

            set
            {
                this.temperatureMaxTime = Helpers.DateTimeToUnixTime(value);
            }
        }

        [DataMember(Name = "apparentTemperatureMin")]
        public float ApparentMinTemperature { get; set; }

        [DataMember]
        private int apparentTemperatureMinTime;

        public DateTime ApparentMinTemperatureTime
        {
            get
            {
                return Helpers.UnixTimeToDateTime(this.apparentTemperatureMinTime);
            }

            set
            {
                this.apparentTemperatureMinTime = Helpers.DateTimeToUnixTime(value);
            }
        }

        [DataMember(Name = "apparentTemperatureMax")]
        public float ApparentMaxTemperature { get; set; }

        [DataMember]
        private int apparentTemperatureMaxTime;

        public DateTime ApparentMaxTemperatureTime
        {
            get
            {
                return Helpers.UnixTimeToDateTime(this.apparentTemperatureMaxTime);
            }

            set
            {
                this.apparentTemperatureMaxTime = Helpers.DateTimeToUnixTime(value);
            }
        }

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
