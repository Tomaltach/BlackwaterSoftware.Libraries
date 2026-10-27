using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Europe
{
    internal static class NorthernEurope
    {
        public static readonly Country Denmark = new(
            "Denmark",
            "+45",
            "DK",
            "DNK",
            Continent.Europe,
            Region.NorthernEurope,
            "Danish Krone",
            "DKK");

        public static readonly Country Estonia = new(
            "Estonia",
            "+372",
            "EE",
            "EST",
            Continent.Europe,
            Region.NorthernEurope,
            "Euro",
            "EUR");

        public static readonly Country Finland = new(
            "Finland",
            "+358",
            "FI",
            "FIN",
            Continent.Europe,
            Region.NorthernEurope,
            "Euro",
            "EUR");

        public static readonly Country Iceland = new(
            "Iceland",
            "+354",
            "IS",
            "ISL",
            Continent.Europe,
            Region.NorthernEurope,
            "Icelandic Krona",
            "ISK");

        public static readonly Country Ireland = new(
            "Ireland",
            "+353",
            "IE",
            "IRL",
            Continent.Europe,
            Region.NorthernEurope,
            "Euro",
            "EUR");

        public static readonly Country Latvia = new(
            "Latvia",
            "+371",
            "LV",
            "LVA",
            Continent.Europe,
            Region.NorthernEurope,
            "Euro",
            "EUR");

        public static readonly Country Lithuania = new(
            "Lithuania",
            "+370",
            "LT",
            "LTU",
            Continent.Europe,
            Region.NorthernEurope,
            "Euro",
            "EUR");

        public static readonly Country Norway = new(
            "Norway",
            "+47",
            "NO",
            "NOR",
            Continent.Europe,
            Region.NorthernEurope,
            "Norwegian Krone",
            "NOK");

        public static readonly Country Sweden = new(
            "Sweden",
            "+46",
            "SE",
            "SWE",
            Continent.Europe,
            Region.NorthernEurope,
            "Swedish Krona",
            "SEK");

        public static readonly Country UnitedKingdom = new(
            "United Kingdom",
            "+44",
            "GB",
            "GBR",
            Continent.Europe,
            Region.NorthernEurope,
            "Pound Sterling",
            "GBP");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Denmark,
                Estonia,
                Finland,
                Iceland,
                Ireland,
                Latvia,
                Lithuania,
                Norway,
                Sweden,
                UnitedKingdom
            });
    }
}
