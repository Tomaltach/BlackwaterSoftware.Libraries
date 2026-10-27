using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Europe
{
    internal static class EasternEurope
    {
        public static readonly Country Belarus = new(
            "Belarus",
            "+375",
            "BY",
            "BLR",
            Continent.Europe,
            Region.EasternEurope,
            "Belarusian Ruble",
            "BYN");

        public static readonly Country Bulgaria = new(
            "Bulgaria",
            "+359",
            "BG",
            "BGR",
            Continent.Europe,
            Region.EasternEurope,
            "Bulgarian Lev",
            "BGN");

        public static readonly Country Moldova = new(
            "Moldova",
            "+373",
            "MD",
            "MDA",
            Continent.Europe,
            Region.EasternEurope,
            "Moldovan Leu",
            "MDL");

        public static readonly Country Romania = new(
            "Romania",
            "+40",
            "RO",
            "ROU",
            Continent.Europe,
            Region.EasternEurope,
            "Romanian Leu",
            "RON");

        public static readonly Country Russia = new(
            "Russia",
            "+7",
            "RU",
            "RUS",
            Continent.Europe,
            Region.EasternEurope,
            "Russian Ruble",
            "RUB");

        public static readonly Country Ukraine = new(
            "Ukraine",
            "+380",
            "UA",
            "UKR",
            Continent.Europe,
            Region.EasternEurope,
            "Ukrainian Hryvnia",
            "UAH");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Belarus,
                Bulgaria,
                Moldova,
                Romania,
                Russia,
                Ukraine
            });
    }
}
