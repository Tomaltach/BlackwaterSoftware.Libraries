using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.NorthAmerica
{
    internal static class CentralAmerica
    {
        public static readonly Country Belize = new(
            "Belize",
            "+501",
            "BZ",
            "BLZ",
            Continent.NorthAmerica,
            Region.CentralAmerica,
            "Belize Dollar",
            "BZD");

        public static readonly Country CostaRica = new(
            "Costa Rica",
            "+506",
            "CR",
            "CRI",
            Continent.NorthAmerica,
            Region.CentralAmerica,
            "Costa Rican Colon",
            "CRC");

        public static readonly Country ElSalvador = new(
            "El Salvador",
            "+503",
            "SV",
            "SLV",
            Continent.NorthAmerica,
            Region.CentralAmerica,
            "United States Dollar",
            "USD");

        public static readonly Country Guatemala = new(
            "Guatemala",
            "+502",
            "GT",
            "GTM",
            Continent.NorthAmerica,
            Region.CentralAmerica,
            "Guatemalan Quetzal",
            "GTQ");

        public static readonly Country Honduras = new(
            "Honduras",
            "+504",
            "HN",
            "HND",
            Continent.NorthAmerica,
            Region.CentralAmerica,
            "Honduran Lempira",
            "HNL");

        public static readonly Country Nicaragua = new(
            "Nicaragua",
            "+505",
            "NI",
            "NIC",
            Continent.NorthAmerica,
            Region.CentralAmerica,
            "Nicaraguan Cordoba",
            "NIO");

        public static readonly Country Panama = new(
            "Panama",
            "+507",
            "PA",
            "PAN",
            Continent.NorthAmerica,
            Region.CentralAmerica,
            "Panamanian Balboa",
            "PAB");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Belize,
                CostaRica,
                ElSalvador,
                Guatemala,
                Honduras,
                Nicaragua,
                Panama
            });
    }
}
