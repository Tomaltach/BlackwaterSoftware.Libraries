using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Europe
{
    internal static class WesternEurope
    {
        public static readonly Country Belgium = new(
            "Belgium",
            "+32",
            "BE",
            "BEL",
            Continent.Europe,
            Region.WesternEurope,
            "Euro",
            "EUR");

        public static readonly Country France = new(
            "France",
            "+33",
            "FR",
            "FRA",
            Continent.Europe,
            Region.WesternEurope,
            "Euro",
            "EUR");

        public static readonly Country Luxembourg = new(
            "Luxembourg",
            "+352",
            "LU",
            "LUX",
            Continent.Europe,
            Region.WesternEurope,
            "Euro",
            "EUR");

        public static readonly Country Monaco = new(
            "Monaco",
            "+377",
            "MC",
            "MCO",
            Continent.Europe,
            Region.WesternEurope,
            "Euro",
            "EUR");

        public static readonly Country Netherlands = new(
            "Netherlands",
            "+31",
            "NL",
            "NLD",
            Continent.Europe,
            Region.WesternEurope,
            "Euro",
            "EUR");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Belgium,
                France,
                Luxembourg,
                Monaco,
                Netherlands
            });
    }
}
