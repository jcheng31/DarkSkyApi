# ForecastPCL

An unofficial C# Portable Class Library for the [Forecast.io](http://developer.forecast.io) weather service. Compatible with .NET 4.5, Windows 8/8.1, Windows Phone 8/8.1, .NET Core 1.0, Xamarin Android/iOS, and Universal Windows Apps.

## Installation

[NuGet](https://www.nuget.org/packages/ForecastIOPortable/): `Install-Package ForecastIOPortable`

## New in Version 2.5.0

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

## Quick Start

### Current Conditions

```c#
using ForecastIOPortable;

...

var client = new ForecastApi("YOUR API KEY HERE");
Forecast result = await client.GetWeatherDataAsync(37.8267, -122.423);

...
```

![](http://i.imgur.com/lLuBO0C.png)

Note that the Forecast.io service doesn't always return all fields for each region. In these cases, some properties may be null or zero.

### Conditions for a specific date

```c#
using ForecastIOPortable;

...

var client = new ForecastApi("YOUR API KEY HERE");

Forecast result = await client.GetTimeMachineWeatherAsync(37.8267, -122.423, DateTimeOffset.Now);

...
```

The `Helpers` class contains extension methods to convert a DateTimeOffset to Unix time, and back:

```c#

int unixTime = DateTimeOffset.Now.ToUnixTime();

DateTimeOffset date = unixTime.ToDateTimeOffset();
```

### API Usage Information

After making a request for data (be it current or historical), the ForecastApi instance's `ApiCallsMade` property will contain the number of calls made today, using the given API key. The property will be null if no requests have been made through the particular instance.

## Design

This library uses a client-oriented approach, instead of a request-response model: the `ForecastApi` object is intended to be an abstraction from which weather data (`Forecast`s) can be obtained.

`Forecast`s do contain all the fields that can appear in the raw JSON obtained through making a direct request to the web service, but exposes them through more .NET convention-friendly properties: for example, `precipIntensityMax` is exposed as `MaxPrecipitationIntensity`. These properties are (as shown here) sometimes more verbose, but were intended to match the style commonly used in .NET projects.

## Tests

NUnit is used for some simple integration tests with the actual web service. To run the tests, a valid API key must be added to the `app.config` file in the `ForecastPCL.Test` folder.
