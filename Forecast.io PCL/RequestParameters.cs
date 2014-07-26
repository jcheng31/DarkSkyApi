namespace ForecastIOPortable
{
    using System;

    public enum Unit
    {
        US, // us

        SI, // si

        CA, // ca

        UK, // uk

        Auto // auto
    }




    public enum Extend
    {
        Hourly // hourly
    }

    public enum Exclude
    {
        Currently, // currently

        Minutely, // minutely

        Hourly, // hourly

        Daily, // daily

        Alerts, // alerts

        Flags // flags
    }

    public enum Language
    {
        German, // de

        English, // en

        Spanish, // es

        French, // fr

        Dutch, // nl

        Tetum // tet
    }

    public static class ParameterExtensions
    {
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

        public static string ToValue(this Language self)
        {
            switch (self)
            {
                case Language.German:
                    return "de";
                case Language.English:
                    return "en";
                case Language.Spanish:
                    return "es";
                case Language.French:
                    return "fr";
                case Language.Dutch:
                    return "nl";
                case Language.Tetum:
                    return "tet";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}