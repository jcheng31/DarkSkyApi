namespace ForecastIOPortable.Models
{
    using System;
    using System.Runtime.Serialization;

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
        /// Gets or sets a short text summary of this alert.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the moment in time at which this alert is no longer valid.
        /// </summary>
        public DateTimeOffset Expires
        {
            get
            {
                return this.expires.ToDateTimeOffset();
            }

            set
            {
                this.expires = value.ToUnixTime();
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
