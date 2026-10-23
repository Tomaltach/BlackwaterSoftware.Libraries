using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Extensions;

namespace BlackwaterSoftware.CountryCatalog.Models
{
    public sealed record Country(
        string Name,
        string CallingCode,
        string Iso2,
        string Iso3,
        Continent Continent,
        Region Region,
        string CurrencyName,
        string CurrencyCode,
        CountryWeight Weight = CountryWeight.Lowest)
    {
        public string ContinentName => Continent.ToDisplayName();
        public string RegionName => Region.ToDisplayName();
    }
}
