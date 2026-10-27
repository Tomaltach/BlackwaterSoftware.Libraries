using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Asia
{
    internal static class CentralAsia
    {
        public static readonly Country Kazakhstan = new(
            "Kazakhstan",
            "+7",
            "KZ",
            "KAZ",
            Continent.Asia,
            Region.CentralAsia,
            "Kazakhstani Tenge",
            "KZT");

        public static readonly Country Kyrgyzstan = new(
            "Kyrgyzstan",
            "+996",
            "KG",
            "KGZ",
            Continent.Asia,
            Region.CentralAsia,
            "Kyrgyzstani Som",
            "KGS");

        public static readonly Country Tajikistan = new(
            "Tajikistan",
            "+992",
            "TJ",
            "TJK",
            Continent.Asia,
            Region.CentralAsia,
            "Tajikistani Somoni",
            "TJS");

        public static readonly Country Turkmenistan = new(
            "Turkmenistan",
            "+993",
            "TM",
            "TKM",
            Continent.Asia,
            Region.CentralAsia,
            "Turkmenistani Manat",
            "TMT");

        public static readonly Country Uzbekistan = new(
            "Uzbekistan",
            "+998",
            "UZ",
            "UZB",
            Continent.Asia,
            Region.CentralAsia,
            "Uzbekistani Som",
            "UZS");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Kazakhstan,
                Kyrgyzstan,
                Tajikistan,
                Turkmenistan,
                Uzbekistan
            });
    }
}
