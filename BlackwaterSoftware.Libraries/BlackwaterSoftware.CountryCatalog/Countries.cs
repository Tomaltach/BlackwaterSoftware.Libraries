using BlackwaterSoftware.CountryCatalog.CountryBlocks.Africa;
using BlackwaterSoftware.CountryCatalog.CountryBlocks.Asia;
using BlackwaterSoftware.CountryCatalog.CountryBlocks.Europe;
using BlackwaterSoftware.CountryCatalog.CountryBlocks.NorthAmerica;
using BlackwaterSoftware.CountryCatalog.CountryBlocks.Oceania;
using BlackwaterSoftware.CountryCatalog.CountryBlocks.SouthAmerica;
using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;
using System.Collections.Frozen;

namespace BlackwaterSoftware.CountryCatalog
{
    public static class Countries
    {
        private static readonly Country[] _all =
        [
            #region Africa
            .. NorthernAfrica.All,
            .. WesternAfrica.All,
            .. MiddleAfrica.All,
            .. EasternAfrica.All,
            .. SouthernAfrica.All,
            #endregion Africa
            #region Asia
            .. CentralAsia.All,
            .. EasternAsia.All,
            .. SouthEasternAsia.All,
            .. SouthernAsia.All,
            .. WesternAsia.All,
            #endregion Asia
            #region Europe
            .. CentralEurope.All,
            .. EasternEurope.All,
            .. NorthernEurope.All,
            .. SouthernEurope.All,
            .. WesternEurope.All,
            #endregion Europe
            #region North America
            .. NorthernAmerica.All,
            .. CentralAmerica.All,
            .. Caribbean.All,
            #endregion North America
            #region South America
            .. SouthAmerica.All,
            #endregion South America
            #region Oceania
            .. AustraliaAndNewZealand.All,
            .. Melanesia.All,
            .. Micronesia.All,
            .. Polynesia.All
            #endregion Oceania
        ];
        public static IReadOnlyList<Country> All { get; } = Array.AsReadOnly(_all);

        #region FrozenDictionary
        private static readonly FrozenDictionary<string, Country> ByIso2 = _all.ToFrozenDictionary(
            c => c.Iso2,
            StringComparer.OrdinalIgnoreCase);

        private static readonly FrozenDictionary<string, Country> ByIso3 = _all.ToFrozenDictionary(
            c => c.Iso3,
            StringComparer.OrdinalIgnoreCase);

        private static readonly FrozenDictionary<Continent, Country[]> ByContinent = _all
            .GroupBy(c => c.Continent)
            .ToFrozenDictionary(
                group => group.Key,
                group => group.OrderBy(c => c.Name)
            .ToArray());

        private static readonly FrozenDictionary<Region, Country[]> ByRegion = _all
            .GroupBy(c => c.Region)
            .ToFrozenDictionary(
                group => group.Key,
                group => group.OrderBy(c => c.Name)
            .ToArray());

        private static readonly FrozenDictionary<Continent,FrozenDictionary<Region, IReadOnlyList<Country>>> ByContinentAndRegion = _all
            .GroupBy(c => c.Continent)
            .ToFrozenDictionary(
                continentGroup => continentGroup.Key,
                continentGroup => continentGroup
                .GroupBy(c => c.Region)
                .ToFrozenDictionary(
                    regionGroup => regionGroup.Key,
                    regionGroup => (IReadOnlyList<Country>)Array
                        .AsReadOnly(regionGroup.OrderBy(c => c.Name)
                .ToArray())));
        #endregion FrozenDictionary

        public static Country? FindByIso2(string iso2) => ByIso2.GetValueOrDefault(iso2);

        public static Country? FindByIso3(string iso3) => ByIso3.GetValueOrDefault(iso3);

        public static IReadOnlyList<Country> FindByContinent(Continent continent)
        {
            return ByContinent.TryGetValue(continent, out var countries)
                ? Array.AsReadOnly(countries)
                : Array.Empty<Country>();
        }

        public static IReadOnlyList<Country> FindByRegion(Region region)
        {
            return ByRegion.TryGetValue(region, out var countries)
                ? Array.AsReadOnly(countries)
                : Array.Empty<Country>();
        }

        public static IReadOnlyList<Country> FindByCurrencyCode(string? currencyCode)
        {
            if (string.IsNullOrWhiteSpace(currencyCode))
                return Array.Empty<Country>();

            return Array.AsReadOnly(_all
                .Where(c => string.Equals(
                    c.CurrencyCode,
                    currencyCode.Trim(),
                    StringComparison.OrdinalIgnoreCase))
                .OrderBy(c => c.Name)
                .ToArray());
        }

        public static IReadOnlyList<Country> Search(string? query)
        {
            if (string.IsNullOrWhiteSpace(query)) return All;

            query = query.Trim();

            return Array.AsReadOnly(_all
                .Where(c =>
                    c.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    c.Iso2.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    c.Iso3.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    c.CallingCode.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    c.CurrencyCode.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    c.CurrencyName.Contains(query, StringComparison.OrdinalIgnoreCase))
                .OrderBy(c => c.Name)
                .ToArray());
        }
    }
}
