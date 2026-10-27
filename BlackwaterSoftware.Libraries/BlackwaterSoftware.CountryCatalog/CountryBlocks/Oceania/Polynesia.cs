using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Oceania
{
    internal static class Polynesia
    {
        public static readonly Country AmericanSamoa = new(
            "American Samoa",
            "+1-684",
            "AS",
            "ASM",
            Continent.Oceania,
            Region.Polynesia,
            "United States Dollar",
            "USD");

        public static readonly Country CookIslands = new(
            "Cook Islands",
            "+682",
            "CK",
            "COK",
            Continent.Oceania,
            Region.Polynesia,
            "New Zealand Dollar",
            "NZD");

        public static readonly Country FrenchPolynesia = new(
            "French Polynesia",
            "+689",
            "PF",
            "PYF",
            Continent.Oceania,
            Region.Polynesia,
            "CFP Franc",
            "XPF");

        public static readonly Country Niue = new(
            "Niue",
            "+683",
            "NU",
            "NIU",
            Continent.Oceania,
            Region.Polynesia,
            "New Zealand Dollar",
            "NZD");

        public static readonly Country PitcairnIslands = new(
            "Pitcairn Islands",
            "+64",
            "PN",
            "PCN",
            Continent.Oceania,
            Region.Polynesia,
            "New Zealand Dollar",
            "NZD");

        public static readonly Country Samoa = new(
            "Samoa",
            "+685",
            "WS",
            "WSM",
            Continent.Oceania,
            Region.Polynesia,
            "Samoan Tala",
            "WST");

        public static readonly Country Tokelau = new(
            "Tokelau",
            "+690",
            "TK",
            "TKL",
            Continent.Oceania,
            Region.Polynesia,
            "New Zealand Dollar",
            "NZD");

        public static readonly Country Tonga = new(
            "Tonga",
            "+676",
            "TO",
            "TON",
            Continent.Oceania,
            Region.Polynesia,
            "Tongan Pa'anga",
            "TOP");

        public static readonly Country Tuvalu = new(
            "Tuvalu",
            "+688",
            "TV",
            "TUV",
            Continent.Oceania,
            Region.Polynesia,
            "Australian Dollar",
            "AUD");

        public static readonly Country WallisAndFutuna = new(
            "Wallis and Futuna",
            "+681",
            "WF",
            "WLF",
            Continent.Oceania,
            Region.Polynesia,
            "CFP Franc",
            "XPF");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                AmericanSamoa,
                CookIslands,
                FrenchPolynesia,
                Niue,
                PitcairnIslands,
                Samoa,
                Tokelau,
                Tonga,
                Tuvalu,
                WallisAndFutuna
            });
    }
}
