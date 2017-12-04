using System;
using System.Runtime.Serialization;

namespace DarkSkyApi.Models
{
    /// <summary>
    /// An severe weather alert issued by a weather service for a particular location.
    /// </summary>
    [DataContract]
    public class Alert
    {
        /// <summary>
        /// Unix time at which this alert will expire.
        /// </summary>
        [DataMember]
        private int expires;

        /// <summary>
        /// Unix time at which this alert was issued.
        /// </summary>
        [DataMember]
        private int time;

        /// <summary>
        /// The severity of this alert, as a string.
        /// </summary>
        [DataMember]
        private string severity;

        /// <summary>
        /// Gets or sets a short text summary of this alert.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets the severity of this weather alert.
        /// </summary>
        public Severity Severity
        {
            get
            {
                return AlertSeverity.FromString(severity);
            }
        }

        /// <summary>
        /// Gets or sets the moment in time at which this alert was issued.
        /// </summary>
        public DateTimeOffset Time
        {
            get
            {
                return time.ToDateTimeOffset();
            }

            set
            {
                time = value.ToUnixTime();
            }
        }

        /// <summary>
        /// Gets or sets the regions covered by this alert.
        /// </summary>
        [DataMember(Name = "regions")]
        public string[] Regions { get; set; }

        /// <summary>
        /// Gets or sets the moment in time at which this alert is no longer valid.
        /// </summary>
        public DateTimeOffset Expires
        {
            get
            {
                return expires.ToDateTimeOffset();
            }

            set
            {
                expires = value.ToUnixTime();
            }
        }

        /// <summary>
        /// Gets or sets the text description of this alert.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a URI to the alert's details.
        /// </summary>
        [DataMember(Name = "uri")]
        public string Uri { get; set; }
    }
}
