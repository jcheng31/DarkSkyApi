namespace ForecastIOPortable.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// An hour-by-hour forecast.
    /// </summary>
    [DataContract]
    public class HourlyForecast
    {
        /// <summary>
        /// Gets or sets a human-readable summary of the forecast.
        /// </summary>
        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets machine-readable text that can be used to select an icon to display.
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the individual hours that make up this forecast.
        /// </summary>
        [DataMember(Name = "data")]
        public IList<HourDataPoint> Hours { get; set; } 
    }
}
