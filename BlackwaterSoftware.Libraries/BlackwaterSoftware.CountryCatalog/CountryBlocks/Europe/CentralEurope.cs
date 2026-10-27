using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Europe
{
    internal static class CentralEurope
    {
        public static readonly Country Austria = new(
            "Austria",
            "+43",
            "AT",
            "AUT",
            Continent.Europe,
            Region.CentralEurope,
            "Euro",
            "EUR");

        public static readonly Country Czechia = new(
            "Czechia",
            "+420",
            "CZ",
            "CZE",
            Continent.Europe,
            Region.CentralEurope,
            "Czech Koruna",
            "CZK");

        public static readonly Country Germany = new(
            "Germany",
            "+49",
            "DE",
            "DEU",
            Continent.Europe,
            Region.CentralEurope,
            "Euro",
            "EUR");

        public static readonly Country Hungary = new(
            "Hungary",
            "+36",
            "HU",
            "HUN",
            Continent.Europe,
            Region.CentralEurope,
            "Hungarian Forint",
            "HUF");

        public static readonly Country Liechtenstein = new(
            "Liechtenstein",
            "+423",
            "LI",
            "LIE",
            Continent.Europe,
            Region.CentralEurope,
            "Swiss Franc",
            "CHF");

        public static readonly Country Poland = new(
            "Poland",
            "+48",
            "PL",
            "POL",
            Continent.Europe,
            Region.CentralEurope,
            "Polish Zloty",
            "PLN");

        public static readonly Country Slovakia = new(
            "Slovakia",
            "+421",
            "SK",
            "SVK",
            Continent.Europe,
            Region.CentralEurope,
            "Euro",
            "EUR");

        public static readonly Country Slovenia = new(
            "Slovenia",
            "+386",
            "SI",
            "SVN",
            Continent.Europe,
            Region.CentralEurope,
            "Euro",
            "EUR");

        public static readonly Country Switzerland = new(
            "Switzerland",
            "+41",
            "CH",
            "CHE",
            Continent.Europe,
            Region.CentralEurope,
            "Swiss Franc",
            "CHF");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Austria,
                Czechia,
                Germany,
                Hungary,
                Liechtenstein,
                Poland,
                Slovakia,
                Slovenia,
                Switzerland
            });
    }
}
