using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.NorthAmerica
{
    internal static class NorthernAmerica
    {
        public static readonly Country Bermuda = new(
            "Bermuda",
            "+1-441",
            "BM",
            "BMU",
            Continent.NorthAmerica,
            Region.NorthernAmerica,
            "Bermudian Dollar",
            "BMD");

        public static readonly Country Canada = new(
            "Canada",
            "+1",
            "CA",
            "CAN",
            Continent.NorthAmerica,
            Region.NorthernAmerica,
            "Canadian Dollar",
            "CAD");

        public static readonly Country Greenland = new(
            "Greenland",
            "+299",
            "GL",
            "GRL",
            Continent.NorthAmerica,
            Region.NorthernAmerica,
            "Danish Krone",
            "DKK");

        public static readonly Country SaintPierreAndMiquelon = new(
            "Saint Pierre and Miquelon",
            "+508",
            "PM",
            "SPM",
            Continent.NorthAmerica,
            Region.NorthernAmerica,
            "Euro",
            "EUR");

        public static readonly Country UnitedStates = new(
            "United States",
            "+1",
            "US",
            "USA",
            Continent.NorthAmerica,
            Region.NorthernAmerica,
            "United States Dollar",
            "USD");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Bermuda,
                Canada,
                Greenland,
                SaintPierreAndMiquelon,
                UnitedStates
            });
    }
}
