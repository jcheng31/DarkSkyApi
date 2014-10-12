namespace ForecastIOPortable.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// A minute-by-minute forecast.
    /// </summary>
    [DataContract]
    public class MinutelyForecast
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
        /// Gets or sets the individual minutes that make up this forecast.
        /// </summary>
        [DataMember(Name = "data")]
        public IList<MinuteDataPoint> Minutes { get; set; }
    }
}
