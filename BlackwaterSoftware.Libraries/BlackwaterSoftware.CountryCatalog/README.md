
# BlackwaterSoftware.CountryCatalog

A lightweight .NET library providing a compiled catalogue of countries, including ISO 3166-1 codes, international calling codes, currency information, and geographic classifications.

CountryCatalog supports direct access to individual countries, fast lookups by ISO alpha-2 and alpha-3 codes, filtering by continent, region, and currency code, and general searches across country information.

All country data is bundled with the library. No external API calls, database, or runtime data downloads are required.

## Features

- Compiled catalogue of country information
- Direct access to individual countries, such as `Countries.Ireland` and `Countries.France`
- ISO 3166-1 alpha-2 and alpha-3 codes
- International calling codes
- Currency names and codes
- Continent and region classifications
- Fast, case-insensitive lookups by ISO2 and ISO3
- Filtering by continent, region, and currency
- Flexible search across country information
- Precomputed geographic groupings
- Offline operation

## Installation

Install the package from NuGet:

```bash
dotnet add package CountryCatalog
```

Alternatively, install it through Visual Studio:

1. Right-click your application project.
2. Select **Manage NuGet Packages**.
3. Search for `CountryCatalog`.
4. Select the package and click **Install**.

## Getting started

Import the package namespace:

```csharp
using CountryCatalog;
```

Replace the namespace above if your project uses a different namespace.

Retrieve all countries:

```csharp
IReadOnlyList<Country> countries = Countries.All;

foreach (Country country in countries)
{
    Console.WriteLine(
        $"{country.Name} ({country.Iso2}, {country.Iso3})");
}
```

## Access an individual country

CountryCatalog provides direct access to individual countries through the `Countries` class.

For example, to retrieve Ireland:

```csharp
Country ireland = Countries.Ireland;
```

You can access its properties directly:

```csharp
Console.WriteLine(ireland.Name);
Console.WriteLine(ireland.Iso2);
Console.WriteLine(ireland.Iso3);
Console.WriteLine(ireland.CallingCode);
Console.WriteLine(ireland.CurrencyName);
Console.WriteLine(ireland.CurrencyCode);
Console.WriteLine(ireland.ContinentName);
Console.WriteLine(ireland.RegionName);
```

Other examples include:

```csharp
Country france = Countries.France;
Country germany = Countries.Germany;
Country unitedKingdom = Countries.UnitedKingdom;
Country unitedStates = Countries.UnitedStates;
Country japan = Countries.Japan;
Country australia = Countries.Australia;
```

Direct access is useful when you already know which country you need and do not want to perform a lookup.

### How direct access works

The individual country properties expose the existing country definitions used to build the catalogue. They do not create a separate country instance each time they are accessed.

For example:

```csharp
Country ireland = Countries.Ireland;

Country? irelandByIso2 = Countries.FindByIso2("IE");
```

Both references point to the same country definition when the direct properties reference the existing definitions.

The country definitions are immutable records, making them suitable for sharing throughout an application.

## Look up countries by ISO code

If the country is not known in advance, retrieve it using its ISO code:

```csharp
Country? ireland = Countries.FindByIso2("IE");
Country? france = Countries.FindByIso3("FRA");
```

ISO2 and ISO3 lookups are case-insensitive.

If a country cannot be found, the lookup methods return `null`.

The lookup dictionaries are also available directly:

```csharp
Country? country = Countries.ByIso2.GetValueOrDefault("IE");
Country? countryByIso3 = Countries.ByIso3.GetValueOrDefault("IRL");
```

Both dictionaries use case-insensitive string comparison.

## Find countries by continent

```csharp
IReadOnlyList<Country> countries =
    Countries.FindByContinent(Continent.Europe);

foreach (Country country in countries)
{
    Console.WriteLine(country.Name);
}
```

Countries are returned alphabetically by name.

## Find countries by region

```csharp
IReadOnlyList<Country> countries =
    Countries.FindByRegion(Region.NorthernEurope);

foreach (Country country in countries)
{
    Console.WriteLine(country.Name);
}
```

Available values depend on the members defined by the `Continent` and `Region` enums.

## Find countries by currency

```csharp
IReadOnlyList<Country> countries =
    Countries.FindByCurrencyCode("EUR");

foreach (Country country in countries)
{
    Console.WriteLine(
        $"{country.Name} - {country.CurrencyName}");
}
```

Currency codes are matched case-insensitively, and surrounding whitespace is ignored.

If the supplied code is null, empty, or whitespace, an empty list is returned.

A currency may be used by multiple countries, so this method returns a list.

## Search the catalogue

```csharp
IReadOnlyList<Country> results = Countries.Search("united");

foreach (Country country in results)
{
    Console.WriteLine(country.Name);
}
```

Search is case-insensitive and checks:

- Country name
- ISO2 code
- ISO3 code
- Calling code
- Currency code
- Currency name

Examples:

```csharp
Countries.Search("united");
Countries.Search("IRL");
Countries.Search("353");
Countries.Search("EUR");
Countries.Search("Euro");
```

Partial matches are supported. A null, empty, or whitespace query returns the complete catalogue.

Non-empty search results are ordered alphabetically by country name.

## Country model

Each entry is represented by the `Country` record:

```csharp
public sealed record Country(
    string Name,
    string CallingCode,
    string Iso2,
    string Iso3,
    Continent Continent,
    Region Region,
    string CurrencyName,
    string CurrencyCode,
    CountryWeight Weight = CountryWeight.Lowest,
    CountryCodeStatus CodeStatus = CountryCodeStatus.OfficialIso3166)
{
    public string ContinentName => Continent.ToDisplayName();
    public string RegionName => Region.ToDisplayName();

    public bool HasOfficialIso3166Codes =>
        CodeStatus == CountryCodeStatus.OfficialIso3166;

    public bool HasUserAssignedCodes =>
        CodeStatus == CountryCodeStatus.UserAssigned;
}
```

### Properties

| Property | Description |
|---|---|
| `Name` | Country name |
| `CallingCode` | International telephone calling code |
| `Iso2` | ISO 3166-1 alpha-2 code |
| `Iso3` | ISO 3166-1 alpha-3 code |
| `Continent` | Continent enum value |
| `Region` | Geographic region enum value |
| `CurrencyName` | Currency name |
| `CurrencyCode` | Currency code |
| `Weight` | Country weight or ordering metadata |
| `CodeStatus` | Classification of the country codes |
| `ContinentName` | Display name derived from the continent |
| `RegionName` | Display name derived from the region |
| `HasOfficialIso3166Codes` | Whether the entry is classified as using official ISO codes |
| `HasUserAssignedCodes` | Whether the entry is classified as using user-assigned codes |

Example:

```csharp
Country country = Countries.Ireland;

Console.WriteLine(country.Name);
Console.WriteLine(country.ContinentName);
Console.WriteLine(country.RegionName);

if (country.HasOfficialIso3166Codes)
{
    Console.WriteLine("Uses official ISO 3166 codes.");
}
```

## ISO code status

CountryCatalog distinguishes official ISO 3166-1 codes from other code assignments through `CountryCodeStatus`.

```csharp
if (country.HasOfficialIso3166Codes)
{
    // The entry is classified as using official ISO 3166 codes.
}

if (country.HasUserAssignedCodes)
{
    // The entry is classified as using user-assigned codes.
}
```

The default status is `CountryCodeStatus.OfficialIso3166`.

Applications requiring strict ISO code validation should check the code status rather than assuming every entry represents an officially assigned ISO code.

## Geographic groupings

Countries are organised into the following regions:

- **Africa:** Northern Africa, Western Africa, Middle Africa, Eastern Africa, Southern Africa
- **Asia:** Central Asia, Eastern Asia, South-Eastern Asia, Southern Asia, Western Asia
- **Europe:** Central Europe, Eastern Europe, Northern Europe, Southern Europe, Western Europe
- **North America:** Northern America, Central America, Caribbean
- **South America:** South America
- **Oceania:** Australia and New Zealand, Melanesia, Micronesia, Polynesia

The library exposes precomputed geographic groupings:

```csharp
Countries.ByContinent
Countries.ByRegion
Countries.ByContinentAndRegion
```

For example, retrieve countries grouped by continent:

```csharp
IReadOnlyDictionary<Continent, Country[]> countriesByContinent =
    Countries.ByContinent;
```

Or access a specific continent and region grouping:

```csharp
IReadOnlyDictionary<Region, IReadOnlyList<Country>> europeanRegions =
    Countries.ByContinentAndRegion[Continent.Europe];
```

## Performance and data access

CountryCatalog uses `FrozenDictionary` instances for ISO2 and ISO3 lookups, with case-insensitive key comparison.

Continent, region, and combined continent-region groupings are precomputed for repeated access.

Individual country properties expose the existing country definitions, avoiding the need to search the catalogue when the required country is already known.

The catalogue is bundled with the package and does not require a database or network connection.

Country data changes are distributed through package releases.

## Requirements

CountryCatalog requires a .NET target framework compatible with the package version you install.

Refer to the package metadata for the exact supported frameworks.

## Versioning

CountryCatalog follows semantic versioning:

- Patch releases: backward-compatible corrections and data fixes
- Minor releases: backward-compatible additions
- Major releases: breaking public API changes

Review release notes when upgrading.

## License

See the repository's license file for the applicable terms of use and distribution.
