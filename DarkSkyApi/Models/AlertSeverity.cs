using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSkyApi.Models
{
    /// <summary>
    /// Represents the severity of a weather alert.
    /// </summary>
    public enum Severity
    {
        /// <summary>
        /// This alert indicates that individuals should be aware of potentially severe weather.
        /// </summary>
        Advisory,

        /// <summary>
        /// This alert indicates that individuals should prepare for potentially severe weather.
        /// </summary>
        Watch,

        /// <summary>
        /// This alert indicates that individuals should take immediate action to protect themselves
        /// and others from potentially severe weather.
        /// </summary>
        Warning,

        /// <summary>
        /// The severity of this alert is not recognized by DarkSkyApi.
        /// </summary>
        Unknown
    }

    public static class AlertSeverity
    {
        public static Severity FromString(string severity)
        {
            switch (severity)
            {
                case "advisory":
                    return Severity.Advisory;
                case "watch":
                    return Severity.Watch;
                case "warning":
                    return Severity.Warning;
                default:
                    return Severity.Unknown;
            }
        }

        public static string ToValue(this Severity severity)
        {
            switch (severity)
            {
                case Severity.Advisory:
                    return "advisory";
                case Severity.Watch:
                    return "watch";
                case Severity.Warning:
                    return "warning";
                default:
                    return "unknown";
            }
        }
    }
}
