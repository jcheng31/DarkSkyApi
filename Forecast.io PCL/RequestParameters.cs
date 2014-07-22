using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForecastIOPortable
{
    public enum Unit
    {
        US, // us
        SI, // si
        CA, // ca
        UK, // uk
        Auto // auto
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
}
