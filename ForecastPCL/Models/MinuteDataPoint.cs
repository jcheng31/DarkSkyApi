namespace ForecastIOPortable.Models
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The weather conditions for a particular minute.
    /// </summary>
    [DataContract]
    public class MinuteDataPoint
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
	}
}
