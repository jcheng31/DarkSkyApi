namespace ForecastIOPortable.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// A forecast for a particular location.
    /// Models the response returned by the service.
    /// </summary>
    [DataContract]
    public class Forecast
    {
        /// <summary>
        /// Gets or sets the latitude of this forecast.
        /// </summary>
        [DataMember(Name = "latitude")]
        public float Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of this forecast.
        /// </summary>
        [DataMember(Name = "longitude")]
        public float Longitude { get; set; }

        /// <summary>
        /// Gets or sets the IANA time zone name for this location.
        /// </summary>
        [DataMember(Name = "timezone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets the time zone offset, in hours from GMT.
        /// </summary>
        [DataMember(Name = "offset")]
        public double TimeZoneOffset { get; set; }

        /// <summary>
        /// Gets or sets the current conditions at the requested location.
        /// </summary>
        [DataMember(Name = "currently")]
        public CurrentDataPoint Currently { get; set; }

        /// <summary>
        /// Gets or sets the minute-by-minute conditions for the next hour.
        /// </summary>
        [DataMember(Name = "minutely")]
        public MinutelyForecast Minutely { get; set; }

        /// <summary>
        /// Gets or sets the hour-by-hour conditions for the next two days.
        /// </summary>
        [DataMember(Name = "hourly")]
        public HourlyForecast Hourly { get; set; }

        /// <summary>
        /// Gets or sets the daily conditions for the next week.
        /// </summary>
        [DataMember(Name = "daily")]
        public DailyForecast Daily { get; set; }

        /// <summary>
        /// Gets or sets the metadata (flags) associated with this forecast.
        /// </summary>
        [DataMember(Name = "flags")]
        public Flags Flags { get; set; }

        /// <summary>
        /// Gets or sets any weather alerts related to this location.
        /// </summary>
        [DataMember(Name = "alerts")]
        public IList<Alert> Alerts { get; set; }
    }
}
