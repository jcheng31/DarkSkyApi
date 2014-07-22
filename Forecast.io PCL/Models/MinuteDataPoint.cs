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

        [DataMember(Name = "PrecipitationIntensity")]
        public float precipIntensity;

        [DataMember(Name = "PrecipitationProbability")]
        public float precipProbability;
    }
}
