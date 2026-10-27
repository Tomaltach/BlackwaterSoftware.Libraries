using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.SouthAmerica
{
    internal static class SouthAmerica
    {
        public static readonly Country Argentina = new(
            "Argentina",
            "+54",
            "AR",
            "ARG",
            Continent.SouthAmerica,
            Region.SouthAmerica,
            "Argentine Peso",
            "ARS");

        public static readonly Country Bolivia = new(
            "Bolivia",
            "+591",
            "BO",
            "BOL",
            Continent.SouthAmerica,
            Region.SouthAmerica,
            "Bolivian Boliviano",
            "BOB");

        public static readonly Country Brazil = new(
            "Brazil",
            "+55",
            "BR",
            "BRA",
            Continent.SouthAmerica,
            Region.SouthAmerica,
            "Brazilian Real",
            "BRL");

        public static readonly Country Chile = new(
            "Chile",
            "+56",
            "CL",
            "CHL",
            Continent.SouthAmerica,
            Region.SouthAmerica,
            "Chilean Peso",
            "CLP");

        public static readonly Country Colombia = new(
            "Colombia",
            "+57",
            "CO",
            "COL",
            Continent.SouthAmerica,
            Region.SouthAmerica,
            "Colombian Peso",
            "COP");

        public static readonly Country Ecuador = new(
            "Ecuador",
            "+593",
            "EC",
            "ECU",
            Continent.SouthAmerica,
            Region.SouthAmerica,
            "United States Dollar",
            "USD");

        public static readonly Country FalklandIslands = new(
            "Falkland Islands",
            "+500",
            "FK",
            "FLK",
            Continent.SouthAmerica,
            Region.SouthAmerica,
            "Falkland Islands Pound",
            "FKP");

        public static readonly Country FrenchGuiana = new(
            "French Guiana",
            "+594",
            "GF",
            "GUF",
            Continent.SouthAmerica,
            Region.SouthAmerica,
            "Euro",
            "EUR");

        public static readonly Country Guyana = new(
            "Guyana",
            "+592",
            "GY",
            "GUY",
            Continent.SouthAmerica,
            Region.SouthAmerica,
            "Guyanese Dollar",
            "GYD");

        public static readonly Country Paraguay = new(
            "Paraguay",
            "+595",
            "PY",
            "PRY",
            Continent.SouthAmerica,
            Region.SouthAmerica,
            "Paraguayan Guarani",
            "PYG");

        public static readonly Country Peru = new(
            "Peru",
            "+51",
            "PE",
            "PER",
            Continent.SouthAmerica,
            Region.SouthAmerica,
            "Peruvian Sol",
            "PEN");

        public static readonly Country Suriname = new(
            "Suriname",
            "+597",
            "SR",
            "SUR",
            Continent.SouthAmerica,
            Region.SouthAmerica,
            "Surinamese Dollar",
            "SRD");

        public static readonly Country Uruguay = new(
            "Uruguay",
            "+598",
            "UY",
            "URY",
            Continent.SouthAmerica,
            Region.SouthAmerica,
            "Uruguayan Peso",
            "UYU");

        public static readonly Country Venezuela = new(
            "Venezuela",
            "+58",
            "VE",
            "VEN",
            Continent.SouthAmerica,
            Region.SouthAmerica,
            "Venezuelan Bolívar",
            "VES");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Argentina,
                Bolivia,
                Brazil,
                Chile,
                Colombia,
                Ecuador,
                FalklandIslands,
                FrenchGuiana,
                Guyana,
                Paraguay,
                Peru,
                Suriname,
                Uruguay,
                Venezuela
            });
    }
}
