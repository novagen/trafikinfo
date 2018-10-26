# Trafikinfo
[![License][License-Image]][License-Url]
[![Build Status][Build-Status-Image]][Build-Status-Url]
[![NuGet][Nuget-Image]][Nuget-Url]
[![CodeFactor][CodeFactor-Image]][CodeFactor-Url]

C# library to fetch data from Trafikverket Trafikinfo API.

This is **not** an official library from Trafikverket.

You can find more information about the [API here](https://api.trafikinfo.trafikverket.se/API)

## Installation
`PM> Install-Package Trafikinfo`

## Example
Fetch information about Stockholm Central station.

```csharp
using(var api = new Trafikinfo(new Configuration { Key = "yoursecretkey", Referer = "https://www.yourdomain.com" }))
{
    var request = new Request();
    request.AddQuery(new Query(ObjectType.TrainStation));
    request.Queries[0].Filter.AddOperator(new FilterOperator(OperatorType.Equals, "LocationSignature", "cst"));

    var response = api.Request(request);
}
```

## Dependencies
The following dependencies are used.

- [Json.NET][JsonNET]
- [MightyLittleGeodesy][MightyLittleGeodesy]

## Tests
Tests are using [NUnit][NUnit-Url]

There is an example .runsettings included. Copy it to .runsettings and add your API-key in it. You can get a key at [Trafikverket](https://api.trafikinfo.trafikverket.se/).

[License-Url]: http://opensource.org/licenses/MIT
[License-Image]: https://img.shields.io/badge/License-MIT-blue.svg
[Build-Status-Url]: https://travis-ci.com/novagen/trafikinfo
[Build-Status-Image]: https://travis-ci.com/novagen/trafikinfo.svg?branch=master
[Nuget-Url]: https://www.nuget.org/packages/apparent.trafikinfo
[Nuget-Image]: https://img.shields.io/nuget/v/Apparent.Trafikinfo.svg
[MightyLittleGeodesy]: https://github.com/bjornsallarp/MightyLittleGeodesy
[JsonNET]: https://www.newtonsoft.com/json
[CodeFactor-Url]: https://www.codefactor.io/repository/github/novagen/trafikinfo
[CodeFactor-Image]: https://www.codefactor.io/repository/github/novagen/trafikinfo/badge
[NUnit-Url]: https://nunit.org/