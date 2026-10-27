using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Africa
{
    internal static class NorthernAfrica
    {
        public static readonly Country Algeria = new(
            "Algeria",
            "+213",
            "DZ",
            "DZA",
            Continent.Africa,
            Region.NorthernAfrica,
            "Algerian Dinar",
            "DZD");

        public static readonly Country Egypt = new(
            "Egypt",
            "+20",
            "EG",
            "EGY",
            Continent.Africa,
            Region.NorthernAfrica,
            "Egyptian Pound",
            "EGP");

        public static readonly Country Libya = new(
            "Libya",
            "+218",
            "LY",
            "LBY",
            Continent.Africa,
            Region.NorthernAfrica,
            "Libyan Dinar",
            "LYD");

        public static readonly Country Morocco = new(
            "Morocco",
            "+212",
            "MA",
            "MAR",
            Continent.Africa,
            Region.NorthernAfrica,
            "Moroccan Dirham",
            "MAD");

        public static readonly Country Sudan = new(
            "Sudan",
            "+249",
            "SD",
            "SDN",
            Continent.Africa,
            Region.NorthernAfrica,
            "Sudanese Pound",
            "SDG");

        public static readonly Country Tunisia = new(
            "Tunisia",
            "+216",
            "TN",
            "TUN",
            Continent.Africa,
            Region.NorthernAfrica,
            "Tunisian Dinar",
            "TND");

        public static readonly Country WesternSahara = new(
            "Western Sahara",
            "+212",
            "EH",
            "ESH",
            Continent.Africa,
            Region.NorthernAfrica,
            "Moroccan Dirham",
            "MAD",
            CountryWeight.Lowest,
            CountryCodeStatus.ExceptionallyReserved);

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Algeria,
                Egypt,
                Libya,
                Morocco,
                Sudan,
                Tunisia,
                WesternSahara
            });
    }
}
