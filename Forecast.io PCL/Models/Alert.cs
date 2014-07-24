using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForecastIOPortable.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Alert
    {
        /// <summary>
        /// Gets or sets a short text summary of this alert.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Unix time at which this alert will expire.
        /// </summary>
        [DataMember]
        private int expires;

        /// <summary>
        /// Gets or sets the date and time at which this alert is no longer valid.
        /// </summary>
        public DateTime Expires
        {
            get
            {
                return Helpers.UnixTimeToDateTime(this.expires);
            }

            set
            {
                this.expires = Helpers.DateTimeToUnixTime(value);
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
