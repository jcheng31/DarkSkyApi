namespace ForecastIOPortable.Models
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The weather conditions for a particular day.
    /// </summary>
    [DataContract]
    public class DayDataPoint
    {
        /// <summary>
        /// Unix time at which this data point applies.
        /// </summary>
        [DataMember]
        private int time;

        /// <summary>
        /// Unix time of the last sunrise before the solar noon closest to local noon on
        /// the given day.
        /// </summary>
        [DataMember]
        private int sunriseTime;

        /// <summary>
        /// Unix time of the first sunset after the solar noon closest to local noon on
        /// the given day.
        /// </summary>
        [DataMember]
        private int sunsetTime;

        /// <summary>
        /// Unix time at which the maximum expected precipitation occurs.
        /// </summary>
        [DataMember]
        private int precipIntensityMaxTime;

        /// <summary>
        /// Unix time at which the maximum temperature occurs.
        /// </summary>
        [DataMember]
        private int temperatureMaxTime;

        /// <summary>
        /// Unix time at which the lowest temperature occurs.
        /// </summary>
        [DataMember]
        private int temperatureMinTime;

        /// <summary>
        /// Unix time at which the apparent minimum temperature occurs.
        /// </summary>
        [DataMember]
        private int apparentTemperatureMinTime;

        /// <summary>
        /// Unix time at which the apparent maximum temperature occurs.
        /// </summary>
        [DataMember]
        private int apparentTemperatureMaxTime;

        /// <summary>
        /// Gets or sets the time of this data point.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a human-readable summary of this data point.
        /// </summary>
        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets machine-readable text that can be used to select an icon to display.
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the time of the first sunset after the solar noon closest to local noon
        /// on the given day.
        /// </summary>
        public DateTime SunsetTime
        {
            get
            {
                return Helpers.UnixTimeToDateTime(this.sunsetTime);
            }

            set
            {
                this.sunsetTime = Helpers.DateTimeToUnixTime(value);
            }
        }

        /// <summary>
        /// Gets or sets the time of the last sunrise before the solar noon closest to local noon
        /// on the given day.
        /// </summary>
        public DateTime SunriseTime
        {
            get
            {
                return Helpers.UnixTimeToDateTime(this.sunriseTime);
            }

            set
            {
                this.sunriseTime = Helpers.DateTimeToUnixTime(value);
            }
        }

        /// <summary>
        /// Gets or sets a value representing the fractional part of the lunation number
        /// of the given day. Can be thought of as the "percentage complete" of the current
        /// lunar month.
        /// </summary>
        [DataMember(Name = "moonPhase")]
        public float MoonPhase { get; set; }

        /// <summary>
        /// Gets or sets the average expected precipitation assuming any precipitation occurs.
        /// </summary>
        [DataMember(Name = "precipIntensity")]
        public float PrecipitationIntensity { get; set; }

        /// <summary>
        /// Gets or sets the maximum expected precipitation intensity.
        /// </summary>
        [DataMember(Name = "precipIntensityMax")]
        public float MaxPrecipitationIntensity { get; set; }

        /// <summary>
        /// Gets or sets the time at which the maximum expected precipitation intensity occurs.
        /// </summary>
        public DateTime MaxPrecipitationIntensityTime
        {
            get
            {
                return Helpers.UnixTimeToDateTime(this.precipIntensityMaxTime);
            }

            set
            {
                this.precipIntensityMaxTime = Helpers.DateTimeToUnixTime(value);
            }
        }

        /// <summary>
        /// Gets or sets the probability of precipitation (from 0 to 1).
        /// </summary>
        [DataMember(Name = "precipProbability")]
        public float PrecipitationProbability { get; set; }

        /// <summary>
        /// Gets or sets the minimum (lowest) temperature for the day.
        /// </summary>
        [DataMember(Name = "temperatureMin")]
        public float MinTemperature { get; set; }

        /// <summary>
        /// Gets or sets the time at which the minimum (lowest) temperature occurs.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the maximum (highest) temperature for the day.
        /// </summary>
        [DataMember(Name = "temperatureMax")]
        public float MaxTemperature { get; set; }

        /// <summary>
        /// Gets or sets the time at which the maximum (highest) temperature occurs.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the apparent ("feels like") minimum temperature.
        /// </summary>
        [DataMember(Name = "apparentTemperatureMin")]
        public float ApparentMinTemperature { get; set; }

        /// <summary>
        /// Gets or sets the time at which the apparent minimum temperature occurs.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the apparent ("feels like") maximum temperature.
        /// </summary>
        [DataMember(Name = "apparentTemperatureMax")]
        public float ApparentMaxTemperature { get; set; }

        /// <summary>
        /// Gets or sets the time at which the apparent maximum temperature occurs.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the dew point.
        /// </summary>
        [DataMember(Name = "dewPoint")]
        public float DewPoint { get; set; }

        /// <summary>
        /// Gets or sets the relative humidity (from 0 to 1).
        /// </summary>
        [DataMember(Name = "humidity")]
        public float Humidity { get; set; }

        /// <summary>
        /// Gets or sets the wind speed.
        /// </summary>
        [DataMember(Name = "windSpeed")]
        public float WindSpeed { get; set; }

        /// <summary>
        /// Gets or sets the direction (in degrees) the wind is coming from.
        /// </summary>
        [DataMember(Name = "windBearing")]
        public float WindBearing { get; set; }

        /// <summary>
        /// Gets or sets the average visibility (capped at 10 miles).
        /// </summary>
        [DataMember(Name = "visibility")]
        public float Visibility { get; set; }

        /// <summary>
        /// Gets or sets the percentage of cloud cover (from 0 to 1).
        /// </summary>
        [DataMember(Name = "cloudCover")]
        public float CloudCover { get; set; }

        /// <summary>
        /// Gets or sets the sea-level air pressure.
        /// </summary>
        [DataMember(Name = "pressure")]
        public float Pressure { get; set; }

        /// <summary>
        /// Gets or sets the columnar density of total atmospheric ozone, in Dobson units.
        /// </summary>
        [DataMember(Name = "ozone")]
        public float Ozone { get; set; }
    }
}
