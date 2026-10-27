using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Asia
{
    internal static class EasternAsia
    {
        public static readonly Country China = new(
            "China",
            "+86",
            "CN",
            "CHN",
            Continent.Asia,
            Region.EasternAsia,
            "Chinese Yuan",
            "CNY");

        public static readonly Country Japan = new(
            "Japan",
            "+81",
            "JP",
            "JPN",
            Continent.Asia,
            Region.EasternAsia,
            "Japanese Yen",
            "JPY");

        public static readonly Country Mongolia = new(
            "Mongolia",
            "+976",
            "MN",
            "MNG",
            Continent.Asia,
            Region.EasternAsia,
            "Mongolian Tögrög",
            "MNT");

        public static readonly Country NorthKorea = new(
            "North Korea",
            "+850",
            "KP",
            "PRK",
            Continent.Asia,
            Region.EasternAsia,
            "North Korean Won",
            "KPW");

        public static readonly Country SouthKorea = new(
            "South Korea",
            "+82",
            "KR",
            "KOR",
            Continent.Asia,
            Region.EasternAsia,
            "South Korean Won",
            "KRW");

        public static readonly Country Taiwan = new(
            "Taiwan",
            "+886",
            "TW",
            "TWN",
            Continent.Asia,
            Region.EasternAsia,
            "New Taiwan Dollar",
            "TWD");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                China,
                Japan,
                Mongolia,
                NorthKorea,
                SouthKorea,
                Taiwan
            });
    }
}
