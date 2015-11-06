namespace ForecastIOPortable.Models
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The weather conditions for a particular hour.
    /// </summary>
    [DataContract]
    public class HourDataPoint
    {
        /// <summary>
        /// Unix time at which this data point applies.
        /// </summary>
        [DataMember]
        private int time;

        /// <summary>
        /// Gets or sets the time of this data point.
        /// </summary>
        public DateTimeOffset Time
        {
            get
            {
                return this.time.ToDateTimeOffset();
            }

            set
            {
                this.time = value.ToUnixTime();
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
        /// Gets or sets the average expected precipitation assuming any precipitation occurs.
        /// </summary>
        [DataMember(Name = "precipIntensity")]
        public float PrecipitationIntensity { get; set; }

        /// <summary>
        /// Gets or sets the probability of precipitation (from 0 to 1).
        /// </summary>
        [DataMember(Name = "precipProbability")]
        public float PrecipitationProbability { get; set; }

		/// <summary>
		/// Gets or sets the type of precipitation.
		/// </summary>
		[DataMember(Name = "precipType")]
		public string PrecipitationType { get; set; }

		/// <summary>
		/// Gets or sets the temperature.
		/// </summary>
		[DataMember(Name = "temperature")]
        public float Temperature { get; set; }

        /// <summary>
        /// Gets or sets the apparent ("feels like") temperature.
        /// </summary>
        [DataMember(Name = "apparentTemperature")]
        public float ApparentTemperature { get; set; }

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
