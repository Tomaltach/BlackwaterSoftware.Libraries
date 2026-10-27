using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Oceania
{
    internal static class AustraliaAndNewZealand
    {
        public static readonly Country Australia = new(
            "Australia",
            "+61",
            "AU",
            "AUS",
            Continent.Oceania,
            Region.AustraliaAndNewZealand,
            "Australian Dollar",
            "AUD");

        public static readonly Country ChristmasIsland = new(
            "Christmas Island",
            "+61",
            "CX",
            "CXR",
            Continent.Oceania,
            Region.AustraliaAndNewZealand,
            "Australian Dollar",
            "AUD");

        public static readonly Country CocosIslands = new(
            "Cocos (Keeling) Islands",
            "+61",
            "CC",
            "CCK",
            Continent.Oceania,
            Region.AustraliaAndNewZealand,
            "Australian Dollar",
            "AUD");

        public static readonly Country HeardIslandAndMcDonaldIslands = new(
            "Heard Island and McDonald Islands",
            "+672",
            "HM",
            "HMD",
            Continent.Oceania,
            Region.AustraliaAndNewZealand,
            "Australian Dollar",
            "AUD");

        public static readonly Country NewZealand = new(
            "New Zealand",
            "+64",
            "NZ",
            "NZL",
            Continent.Oceania,
            Region.AustraliaAndNewZealand,
            "New Zealand Dollar",
            "NZD");

        public static readonly Country NorfolkIsland = new(
            "Norfolk Island",
            "+672",
            "NF",
            "NFK",
            Continent.Oceania,
            Region.AustraliaAndNewZealand,
            "Australian Dollar",
            "AUD");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Australia,
                ChristmasIsland,
                CocosIslands,
                HeardIslandAndMcDonaldIslands,
                NewZealand,
                NorfolkIsland
            });
    }
}
