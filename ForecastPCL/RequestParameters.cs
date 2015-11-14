namespace ForecastIOPortable
{
    using System;

    /// <summary>
    /// Units of measurement supported by the Forecast service.
    /// </summary>
    public enum Unit
    {
        /// <summary>
        /// US units of measurement.
        /// <para>
        /// Summaries containing temperature or snow accumulation units have
        /// their values in degrees Fahrenheit or inches (respectively).
        /// Nearest storm distance: Miles
        /// Precipitation intensity: Inches per hour
        /// Precipitation accumulation: Inches
        /// Temperature: Fahrenheit
        /// Dew Point: Fahrenheit
        /// Wind Speed: Miles per hour
        /// Pressure: Millibars
        /// Visibility: Miles
        /// </para>
        /// </summary>
        US,

        /// <summary>
        /// SI units of measurement.
        /// <para>
        /// Summaries containing temperature or snow accumulation units have
        /// their values in degrees Celsius or centimeters (respectively).
        /// Nearest storm distance: Kilometers
        /// Precipitation intensity: Millimeters per hour
        /// Precipitation accumulation: Centimeters
        /// Temperature: Celsius
        /// Dew Point: Celsius
        /// Wind Speed: Meters per second
        /// Pressure: Hectopascals (equivalent to millibars)
        /// Visibility: Kilometers
        /// </para>
        /// </summary>
        SI,

        /// <summary>
        /// Canadian units of measurement. The same as SI, but with 
        /// kilometers per hour used for Wind Speed.
        /// <para>
        /// Summaries containing temperature or snow accumulation units have
        /// their values in degrees Celsius or centimeters (respectively).
        /// Nearest storm distance: Kilometers
        /// Precipitation intensity: Millimeters per hour
        /// Precipitation accumulation: Centimeters
        /// Temperature: Celsius
        /// Dew Point: Celsius
        /// Wind Speed: Kilometers per hour
        /// Pressure: Hectopascals (equivalent to millibars)
        /// Visibility: Kilometers
        /// </para>
        /// </summary>
        CA,

        /// <summary>
        /// UK units of measurement. The same as SI, but with miles per
        /// hour used for Wind Speed.
        /// <para>
        /// Summaries containing temperature or snow accumulation units have
        /// their values in degrees Celsius or centimeters (respectively).
        /// Nearest storm distance: Kilometers
        /// Precipitation intensity: Millimeters per hour
        /// Precipitation accumulation: Centimeters
        /// Temperature: Celsius
        /// Dew Point: Celsius
        /// Wind Speed: Miles per hour
        /// Pressure: Hectopascals (equivalent to millibars)
        /// Visibility: Kilometers
        /// </para>
        /// </summary>
        UK,

        /// <summary>
        /// Automatically choose units of measurement based on geographic location.
        /// </summary>
        Auto
    }

    /// <summary>
    /// Data blocks that can have their ranges extended.
    /// </summary>
    public enum Extend
    {
        /// <summary>
        /// Extends the hourly forecast block to the next seven
        /// days from just the next two.
        /// <para>Ignored when making time machine requests.</para>
        /// </summary>
        Hourly
    }

    /// <summary>
    /// Data blocks that can be excluded from a request.
    /// </summary>
    public enum Exclude
    {
        /// <summary>
        /// The current data block, containing current weather conditions.
        /// </summary>
        Currently,

        /// <summary>
        /// The minutely data block, containing minute-by-minute data for
        /// the next hour.
        /// </summary>
        Minutely,

        /// <summary>
        /// The hourly data block, containing hour-by-hour data for
        /// the next two days (or the next week, if extended).
        /// </summary>
        Hourly,

        /// <summary>
        /// The daily data block, containing day-by-day data for
        /// the next week.
        /// </summary>
        Daily,

        /// <summary>
        /// A list of any severe weather alerts issued for the requested location.
        /// </summary>
        Alerts,

        /// <summary>
        /// Associated metadata related to the request.
        /// </summary>
        Flags
    }

    /// <summary>
    /// Languages that the service can return text summaries in.
    /// </summary>
    public enum Language
    {
        /// <summary>
        /// Arabic language.
        /// </summary>
        Arabic,

        /// <summary>
        /// Bosnian language.
        /// </summary>
        Bosnian,

        /// <summary>
        /// German language.
        /// </summary>
        German,

        /// <summary>
        /// Greek language.
        /// </summary>
        Greek,

        /// <summary>
        /// English language.
        /// </summary>
        English,

        /// <summary>
        /// Spanish language.
        /// </summary>
        Spanish,

        /// <summary>
        /// French language.
        /// </summary>
        French,

        /// <summary>
        /// Croatian language.
        /// </summary>
        Croatian,

        /// <summary>
        /// Italian language.
        /// </summary>
        Italian,

        /// <summary>
        /// Dutch language.
        /// </summary>
        Dutch,

        /// <summary>
        /// Polish language.
        /// </summary>
        Polish,

        /// <summary>
        /// Portuguese language.
        /// </summary>
        Portuguese,

        /// <summary>
        /// Russian language.
        /// </summary>
        Russian,

        /// <summary>
        /// Slovak language.
        /// </summary>
        Slovak,

        /// <summary>
        /// Swedish language.
        /// </summary>
        Swedish,

        /// <summary>
        /// Tetum language.
        /// </summary>
        Tetum,

        /// <summary>
        /// Turkish language.
        /// </summary>
        Turkish,

        /// <summary>
        /// Ukrainian language.
        /// </summary>
        Ukrainian,

        /// <summary>
        /// Pig Latin language.
        /// </summary>
        PigLatin,

        /// <summary>
        /// Simplified Chinese language.
        /// </summary>
        Chinese,

        /// <summary>
        /// Traditional Chinese language.
        /// </summary>
        TraditionalChinese
    }

    /// <summary>
    /// Extension methods for the request parameter enumerations.
    /// </summary>
    public static class ParameterExtensions
    {
        /// <summary>
        /// Gives the Forecast Service-friendly name for
        /// this parameter.
        /// </summary>
        /// <param name="self">
        /// The parameter to convert.
        /// </param>
        /// <returns>
        /// The service-friendly <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the parameter does not have a corresponding
        /// friendly name.
        /// </exception>
        public static string ToValue(this Unit self)
        {
            switch (self)
            {
                case Unit.US:
                    return "us";
                case Unit.SI:
                    return "si";
                case Unit.CA:
                    return "ca";
                case Unit.UK:
                    return "uk";
                case Unit.Auto:
                    return "auto";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Gives the Forecast Service-friendly name for
        /// this parameter.
        /// </summary>
        /// <param name="self">
        /// The parameter to convert.
        /// </param>
        /// <returns>
        /// The service-friendly <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the parameter does not have a corresponding
        /// friendly name.
        /// </exception>
        public static string ToValue(this Extend self)
        {
            switch (self)
            {
                case Extend.Hourly:
                    return "hourly";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Gives the Forecast Service-friendly name for
        /// this parameter.
        /// </summary>
        /// <param name="self">
        /// The parameter to convert.
        /// </param>
        /// <returns>
        /// The service-friendly <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the parameter does not have a corresponding
        /// friendly name.
        /// </exception>
        public static string ToValue(this Exclude self)
        {
            switch (self)
            {
                case Exclude.Currently:
                    return "currently";
                case Exclude.Minutely:
                    return "minutely";
                case Exclude.Hourly:
                    return "hourly";
                case Exclude.Daily:
                    return "daily";
                case Exclude.Alerts:
                    return "alerts";
                case Exclude.Flags:
                    return "flags";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Gives the Forecast Service-friendly name for
        /// this parameter.
        /// </summary>
        /// <param name="self">
        /// The parameter to convert.
        /// </param>
        /// <returns>
        /// The service-friendly <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the parameter does not have a corresponding
        /// friendly name.
        /// </exception>
        public static string ToValue(this Language self)
        {
            switch (self)
            {
                case Language.Arabic:
                    return "ar";
                case Language.Bosnian:
                    return "bs";
                case Language.German:
                    return "de";
                case Language.Greek:
                    return "el";
                case Language.English:
                    return "en";
                case Language.Spanish:
                    return "es";
                case Language.French:
                    return "fr";
                case Language.Croatian:
                    return "hr";
                case Language.Italian:
                    return "it";
                case Language.Dutch:
                    return "nl";
                case Language.Polish:
                    return "pl";
                case Language.Portuguese:
                    return "pt";
                case Language.Russian:
                    return "ru";
                case Language.Slovak:
                    return "sk";
                case Language.Swedish:
                    return "sv";
                case Language.Tetum:
                    return "tet";
                case Language.Turkish:
                    return "tr";
                case Language.Ukrainian:
                    return "uk";
                case Language.PigLatin:
                    return "x-pig-latin";
                case Language.Chinese:
                    return "zh";
                case Language.TraditionalChinese:
                    return "zh-tw";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}