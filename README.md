# DarkSkyApi [![NuGet](https://img.shields.io/nuget/v/DarkSkyApi.svg?maxAge=2592000)]()

An unofficial C# library for the [Dark Sky](https://darksky.net/dev) weather service. 

Targets .NET Standard 1.1

Compatible with:
* .NET 4.5
* Mono 4.6
* Windows 8/8.1
* Windows Phone 8/8.1
* .NET Core 1.0
* Xamarin Android/iOS
* Universal Windows Apps.

## Installation

[NuGet](https://www.nuget.org/packages/DarkSkyApi/): `Install-Package DarkSkyApi`

## New in Version 3.2.1 (26 October 2017)

[Full Changelog](CHANGELOG.md)

* Add support for UV Index and UV Index Time properties. Thanks, [@rootasjey](https://github.com/rootasjey)!

## API documentation

[Official DarkSky documentation](https://darksky.net/dev/docs)

* [Imports](#imports)
* [Initialization](#initialization)
* [Current Conditions](#current-conditions)
  * [Simple current request](#simple-current-request)
  * [Custom units and language](#custom-units-and-language)
  * [Extends and excludes](#extends-and-excludes)
* [Time Machine](#time-machine)
  * [Simple time machine request](#simple-time-machine-request)
  * [Custom time machine request](#custom-time-machine-request)
* [Helpers](#helpers)
* [Data Results](#data-results)
  * [Currently Forecast](#currently-forecast)
  * [Daily Forecast](#daily-forecast)
  * [Hourly Forecast](#hourly-forecast)
  * [Minutely Forecast](#minutely-forecast)
* [API Usage Information](#api-usage-information)

### Imports

After installing the package, first import the library.

```csharp
using DarkSkyApi;
using DarkSkyApi.Models;
```

### Initialization

Then you'll need to initialize a new client with a DarkSky API key

```csharp
var client = new DarkSkyService("YOUR API KEY HERE");
```

If you don't know how to get a free API key, see the [Get an API key](#get-a-personal-api-key) section.

### Current Conditions

#### Simple current request

```csharp
// Simple forecast with latitude (37.8267) and a longitude (-122.423)
Forecast forecast = await client.GetWeatherDataAsync(37.8267, -122.423);
```

#### Custom units and language

```csharp
// You can also specify units and language
Forecast forecastFR = await client.GetWeatherDataAsync(48.859, 2.206976, Unit.SI, Language.French);
```

#### Extends and excludes

```csharp
Forecast forecastExtended = await client.GetWeatherDataAsync(
    latitude: 37.8267, 
    longitude: -122.423, 
    unit: Unit.SI, 
    extends: new IList<Extend>() { Extend.Hourly }
    excludes: new IList<Exclude>() { Exclude.Daily, Exclude.Flags }
    language: Language.French);
```

When the `extends` parameter is present, 
the request returns hour-by-hour data for the next 168 hours, instead of the next 48.

With `excludes` parameter, you can exclude some data block as:

* Currently
* Minutely
* Hourly
* Daily
* Alerts
* Flags

### Time Machine

With the `GetTimeMachineWeatherAsync(...)` method, you can get conditions for a specific date.

#### Simple time machine request

```csharp
Forecast result = await client.GetTimeMachineWeatherAsync(37.8267, -122.423, DateTimeOffset.Now);
```

#### Custom time machine request

Same as `GetWeatherDataAsync(...)` method, `GetTimeMachineWeatherAsync(...)` method
has overloads. You can add `Unit`, `Language`, `IList<Extend>`, `IList<Exclude>` parameters.

```csharp
Forecast result = await client.GetTimeMachineWeatherAsync(
    latitude: 37.8267, 
    longitude: -122.423, 
    date: DateTimeOffset.Now,
    unit: Unit.SI,
    extends: new IList<Extend> () { Extend.Hours },
    excludes: new IList<Excludes>() { Excludes.Hours },
    language: Language.English);
```

### Helpers

The `Helpers` class contains extension methods to convert a DateTimeOffset to Unix time, and back:

```csharp
int unixTime = DateTimeOffset.Now.ToUnixTime();
DateTimeOffset date = unixTime.ToDateTimeOffset();
```

### Data Results

The `GetWeatherDataAsync(...)` and `GetTimeMachineWeatherAsync(...)` methods
returns various data:


![](./screenshot.png)

Let's say you've the following line:

```csharp
Forecast dataResult = await client.GetWeatherDataAsync(37.8267, -122.423);
```

Basically, the data result is structured like this:

#### Currently Forecast

`Forecast.Currently` has a `CurrentDataPoint` object.
This object has properties like `temperature`, `cloudCover` and a lot more:

```csharp
public class CurrentDataPoint {
    public string Summary;
    public string Icon;
    public float NearestStormDistance;
    public float NearestStormBearing;
    public float PrecipitationIntensit;
    public float PrecipitationProbability;
    public string PrecipitationType;
    public float Temperature;
    public float ApparentTemperature;
    public float DewPoint;
    public float Humidity;
    public float Humidity;
    public float WindSpeed;
    public float WindBearing;
    public float Visibility;
    public float CloudCover;
    public float Pressure;
    public float Ozone;
    public float UVIndex;
}
```

#### Daily Forecast

`Forecast.Daily` has a `DailyForecast` object which has the following values:

```csharp
public class DailyForecast {
    public string Summary; // summary of the forecast
    public string Icon; // used to select an icon to display
    public IList<DayDataPoint> Days; // individual days that make up this forecast
}
```

`DayDataPoint` has similar properties with `CurrentDataPoint` in addition:

```csharp
class DayDataPoint {
    ... // similar DayDataPoint values

    // A value representing the fractional part of the lunation number
    // of the given day. Can be thought of as the "percentage complete" of the current
    // lunar month.
    public float MoonPhase;

    // The maximum expected precipitation intensity.
    public float MaxPrecipitationIntensity;

    // The time at which the maximum expected precipitation intensity occurs.
    public DateTimeOffset MaxPrecipitationIntensityTime;

    // The minimum (lowest) temperature for the day.
    public float MinTemperature;

    // The time at which the minimum (lowest) temperature occurs.
    public DateTimeOffset MinTemperatureTime;

    // The maximum (highest) temperature for the day.
    public float MaxTemperature;

    // The time at which the maximum (highest) temperature occurs.
    public DateTimeOffset MaxTemperatureTime;

    // The apparent ("feels like") minimum temperature.
    public float ApparentMinTemperature;

    // The time at which the apparent minimum temperature occurs.
    public DateTimeOffset ApparentMinTemperatureTime;

    // The apparent ("feels like") maximum temperature.
    public float ApparentMaxTemperature;

    // The time at which the apparent maximum temperature occurs.
    public DateTimeOffset ApparentMaxTemperatureTime;
}
```

#### Hourly Forecast

`Forecast.Hourly` has a `HourlyForecast` object which has the following values:

```csharp
public class HourlyForecast {
    public string Summary; // summary of the forecast
    public string Icon; // used to select an icon to display
    public IList<HourDataPoint> Hours; // individual hours that make up this forecast
}
```

`HourDataPoint` has similar properties with `CurrentDataPoint`.

#### Minutely Forecast

`Forecast.Minutely` has a `MinutelyForecast` object which has the following values:

```csharp
public class MinutelyForecast {
    public string Summary; // summary of the forecast
    public string Icon; // used to select an icon to display
    public IList<MinuteDataPoint> Minutes; // individual hours that make up this forecast
}
```

`MinuteDataPoint` has the following properties:

```csharp
class MinuteDataPoint {
    // Unix time at which this data point applies.
    public DateTimeOffset Time;

    // Average expected precipitation assuming any precipitation occurs.
    public float PrecipitationIntensity;
    
    // Probability of precipitation (from 0 to 1).
    public float PrecipitationProbability;

    // Type of precipitation
    public string PrecipitationType;
}
```


⚠️ **NOTE:** The Dark Sky service doesn't always return all fields for each region. 
In these cases, some properties may be `null` or `0`.

If you want detailed information about response format, 
see the [official DarkSky documentation.](https://darksky.net/dev/docs#response-format)

### API Usage Information

After making a request for data (be it current or historical), the DarkSkyService instance's `ApiCallsMade` property will contain the number of calls made today, using the given API key. The property will be null if no requests have been made through the particular instance.

```csharp
// Total calls made so far for the current API key
var totalCalls = client.ApiCallsMade;
```

## Design

This library uses a client-oriented approach, instead of a request-response model: the `DarkSkyService` object is intended to be an abstraction from which weather data (`Forecast`s) can be obtained.

`Forecast` do contain all the fields that can appear in the raw JSON obtained through making a direct request to the web service, but exposes them through more .NET convention-friendly properties: for example, `precipIntensityMax` is exposed as `MaxPrecipitationIntensity`. These properties are (as shown here) sometimes more verbose, but were intended to match the style commonly used in .NET projects.

## Tests

NUnit is used for some simple integration tests with the actual web service. To run the tests, a valid API key must be added to the `app.config` file in the `DarkSkyService.Test` folder.


## Get a personal API key

If you want to get your personal API key from Unsplash:

1. Login or Register a new account on [DarkSky](https://darksky.net/dev/login?next=/account)
2. On the account page, you'll get your Secret Key
3. Copy and paste the key when you create a new client:

```csharp
var client = new DarkSkyService("YOUR API KEY HERE");
```
