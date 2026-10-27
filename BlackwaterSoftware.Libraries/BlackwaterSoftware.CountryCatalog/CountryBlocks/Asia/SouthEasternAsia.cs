using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Asia
{
    internal static class SouthEasternAsia
    {
        public static readonly Country Brunei = new(
            "Brunei",
            "+673",
            "BN",
            "BRN",
            Continent.Asia,
            Region.SouthEasternAsia,
            "Brunei Dollar",
            "BND");

        public static readonly Country Cambodia = new(
            "Cambodia",
            "+855",
            "KH",
            "KHM",
            Continent.Asia,
            Region.SouthEasternAsia,
            "Cambodian Riel",
            "KHR");

        public static readonly Country Indonesia = new(
            "Indonesia",
            "+62",
            "ID",
            "IDN",
            Continent.Asia,
            Region.SouthEasternAsia,
            "Indonesian Rupiah",
            "IDR");

        public static readonly Country Laos = new(
            "Laos",
            "+856",
            "LA",
            "LAO",
            Continent.Asia,
            Region.SouthEasternAsia,
            "Lao Kip",
            "LAK");

        public static readonly Country Malaysia = new(
            "Malaysia",
            "+60",
            "MY",
            "MYS",
            Continent.Asia,
            Region.SouthEasternAsia,
            "Malaysian Ringgit",
            "MYR");

        public static readonly Country Myanmar = new(
            "Myanmar",
            "+95",
            "MM",
            "MMR",
            Continent.Asia,
            Region.SouthEasternAsia,
            "Myanmar Kyat",
            "MMK");

        public static readonly Country Philippines = new(
            "Philippines",
            "+63",
            "PH",
            "PHL",
            Continent.Asia,
            Region.SouthEasternAsia,
            "Philippine Peso",
            "PHP");

        public static readonly Country Singapore = new(
            "Singapore",
            "+65",
            "SG",
            "SGP",
            Continent.Asia,
            Region.SouthEasternAsia,
            "Singapore Dollar",
            "SGD");

        public static readonly Country Thailand = new(
            "Thailand",
            "+66",
            "TH",
            "THA",
            Continent.Asia,
            Region.SouthEasternAsia,
            "Thai Baht",
            "THB");

        public static readonly Country TimorLeste = new(
            "Timor-Leste",
            "+670",
            "TL",
            "TLS",
            Continent.Asia,
            Region.SouthEasternAsia,
            "United States Dollar",
            "USD");

        public static readonly Country Vietnam = new(
            "Vietnam",
            "+84",
            "VN",
            "VNM",
            Continent.Asia,
            Region.SouthEasternAsia,
            "Vietnamese Dong",
            "VND");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Brunei,
                Cambodia,
                Indonesia,
                Laos,
                Malaysia,
                Myanmar,
                Philippines,
                Singapore,
                Thailand,
                TimorLeste,
                Vietnam
            });
    }
}
