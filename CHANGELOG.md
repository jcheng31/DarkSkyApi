## New in Version 2.6.0 (11 July 2016)
- Precipitation Type was missing from CurrentDataPoint. Oops. It's there now.

## New in Version 2.5.0 (02 July 2016)
- Added support for languages added to Forecast.io since September 2015:
  - Belarusian
  - Czech
  - Hungarian
  - Indonesian
  - Icelandic
  - Cornish
  - Norwegian Bokmal
  - Serbian
- **[Internal]** Added a missing `Async` to the name of an async method, pruned redundant `this`s. Thanks, [@IEvangelist](https://github.com/IEvangelist)!

## New in Version 2.4.0 (01 June 2016)
- Fixed .NET Native issues ([see #13](https://github.com/jcheng31/ForecastPCL/issues/13)) by re-creating the solution and project files.
- Dropped support for Silverlight.
- Added support for .NET Core 1.0, Xamarin Android/iOS.
- Updated Microsoft.Bcl and Microsoft.Net.Http dependencies.

## New in Version 2.3.1 (18 November 2015)
- Rebuilt the project in Release mode (thanks, [@bklabs](https://github.com/bklabs)!)

## New in Version 2.3.0 (14 November 2015)
* Added missing Precipitation Type field (thanks, [@lynnroth](https://github.com/lynnroth)!)
* Additional language support: Greek, Croatian, Ukrainian, and Traditional Chinese.

## New in Version 2.2 (09 August 2015)
* Added support for Universal Windows Apps (repackaged NuGet package correctly).
* Additional language support: Arabic, Slovak, Swedish, Turkish, Chinese.

## New in Version 2.0 (18 January 2015)
* Replaced `DateTime`s with `DateTimeOffset`s throughout.
    * Removed the static methods in `Helpers` that converted between `DateTime` and `int`, replacing them with extension methods on `DateTimeOffset` and `int` instead.
* Removed spaces from the project, solution, and assembly names (thanks to @grendello)
* Fixed `IList<string>` being used instead of `string` for `MetnoLicense` (thanks to @FourTonMantis)
* Added support for new languages: Bosnian, Portuguese, Italian, Pig Latin, Russian, and Polish.
