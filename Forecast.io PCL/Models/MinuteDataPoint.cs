using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ForecastIOPortable.Models
{
    [DataContract]
    public class MinuteDataPoint
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

        [DataMember(Name = "precipIntensity")]
        public float PrecipitationIntensity { get; set; }

        [DataMember(Name = "precipProbability")]
        public float PrecipitationProbability { get; set; }
    }
}
