using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ForecastIOPortable.Models
{
    [DataContract]
    public class MinuteForecast
    {
        [DataMember(Name = "Summary")]
        public string summary { get; set; }

        [DataMember(Name = "Icon")]
        public string icon { get; set; }

        [DataMember(Name = "Minutes")]
        public IList<MinuteDataPoint> data { get; set; }
    }
}
