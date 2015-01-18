namespace ForecastIOPortable.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Metadata associated with a forecast.
    /// </summary>
    [DataContract]
    public class Flags
    {
        /// <summary>
        /// Gets or sets the IDs for each data source used to provide info for this forecast.
        /// </summary>
        [DataMember(Name = "sources")]
        public IList<string> Sources { get; set; }

        /// <summary>
        /// Gets or sets the IDs for each radar station used to provide info for this forecast.
        /// </summary>
        [DataMember(Name = "darksky-stations")]
        public IList<string> DarkSkyStations { get; set; } 

        /// <summary>
        /// Gets or sets the IDs for each DataPoint station used to provide info for this forecast.
        /// </summary>
        [DataMember(Name = "datapoint-stations")]
        public IList<string> DataPointStations { get; set; } 

        /// <summary>
        /// Gets or sets the IDs for each ISD station used to provide info for this forecast.
        /// </summary>
        [DataMember(Name = "isd-stations")]
        public IList<string> IsdStations { get; set; } 

        /// <summary>
        /// Gets or sets the IDs for each LAMP station used to provide info for this forecast.
        /// </summary>
        [DataMember(Name = "lamp-stations")]
        public IList<string> LampStations { get; set; } 

        /// <summary>
        /// Gets or sets the IDs for each METAR station used to provide info for this forecast.
        /// </summary>
        [DataMember(Name = "metar-stations")]
        public IList<string> MetarStations { get; set; }

        /// <summary>
        /// Gets or sets the IDs for each MADIS station used to provide info for this forecast.
        /// </summary>
        [DataMember(Name = "madis-stations")]
        public IList<string> MadisStations { get; set; } 

        /// <summary>
        /// Gets or sets the met.no license. If this is present, data from api.met.no was used to provide info for this forecast.
        /// </summary>
        [DataMember(Name = "metno-license")]
        public string MetnoLicense { get; set; }

        /// <summary>
        /// Gets or sets the type of units that are used for the data in this forecast.
        /// </summary>
        [DataMember(Name = "units")]
        public string Units { get; set; }
    }
}
