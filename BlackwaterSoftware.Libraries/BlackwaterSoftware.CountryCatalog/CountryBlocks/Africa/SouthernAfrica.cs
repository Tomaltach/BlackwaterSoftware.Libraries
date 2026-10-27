using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Africa
{
    internal static class SouthernAfrica
    {
        public static readonly Country Botswana = new(
            "Botswana",
            "+267",
            "BW",
            "BWA",
            Continent.Africa,
            Region.SouthernAfrica,
            "Botswana Pula",
            "BWP");

        public static readonly Country Eswatini = new(
            "Eswatini",
            "+268",
            "SZ",
            "SWZ",
            Continent.Africa,
            Region.SouthernAfrica,
            "Swazi Lilangeni",
            "SZL");

        public static readonly Country Lesotho = new(
            "Lesotho",
            "+266",
            "LS",
            "LSO",
            Continent.Africa,
            Region.SouthernAfrica,
            "Lesotho Loti",
            "LSL");

        public static readonly Country Namibia = new(
            "Namibia",
            "+264",
            "NA",
            "NAM",
            Continent.Africa,
            Region.SouthernAfrica,
            "Namibian Dollar",
            "NAD");

        public static readonly Country SouthAfrica = new(
            "South Africa",
            "+27",
            "ZA",
            "ZAF",
            Continent.Africa,
            Region.SouthernAfrica,
            "South African Rand",
            "ZAR");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Botswana,
                Eswatini,
                Lesotho,
                Namibia,
                SouthAfrica
            });
    }
}
