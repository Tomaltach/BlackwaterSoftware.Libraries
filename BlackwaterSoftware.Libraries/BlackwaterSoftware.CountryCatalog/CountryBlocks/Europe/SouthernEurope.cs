using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Europe
{
    internal static class SouthernEurope
    {
        public static readonly Country Albania = new(
            "Albania",
            "+355",
            "AL",
            "ALB",
            Continent.Europe,
            Region.SouthernEurope,
            "Albanian Lek",
            "ALL");

        public static readonly Country Andorra = new(
            "Andorra",
            "+376",
            "AD",
            "AND",
            Continent.Europe,
            Region.SouthernEurope,
            "Euro",
            "EUR");

        public static readonly Country BosniaAndHerzegovina = new(
            "Bosnia and Herzegovina",
            "+387",
            "BA",
            "BIH",
            Continent.Europe,
            Region.SouthernEurope,
            "Convertible Mark",
            "BAM");

        public static readonly Country Croatia = new(
            "Croatia",
            "+385",
            "HR",
            "HRV",
            Continent.Europe,
            Region.SouthernEurope,
            "Euro",
            "EUR");

        public static readonly Country Greece = new(
            "Greece",
            "+30",
            "GR",
            "GRC",
            Continent.Europe,
            Region.SouthernEurope,
            "Euro",
            "EUR");

        public static readonly Country Italy = new(
            "Italy",
            "+39",
            "IT",
            "ITA",
            Continent.Europe,
            Region.SouthernEurope,
            "Euro",
            "EUR");

        public static readonly Country Kosovo = new(
            "Kosovo",
            "+383",
            "XK",
            "XKX",
            Continent.Europe,
            Region.SouthernEurope,
            "Euro",
            "EUR",
            CountryWeight.Lowest,
            CountryCodeStatus.UserAssigned);

        public static readonly Country Malta = new(
            "Malta",
            "+356",
            "MT",
            "MLT",
            Continent.Europe,
            Region.SouthernEurope,
            "Euro",
            "EUR");

        public static readonly Country Montenegro = new(
            "Montenegro",
            "+382",
            "ME",
            "MNE",
            Continent.Europe,
            Region.SouthernEurope,
            "Euro",
            "EUR");

        public static readonly Country NorthMacedonia = new(
            "North Macedonia",
            "+389",
            "MK",
            "MKD",
            Continent.Europe,
            Region.SouthernEurope,
            "Macedonian Denar",
            "MKD");

        public static readonly Country Portugal = new(
            "Portugal",
            "+351",
            "PT",
            "PRT",
            Continent.Europe,
            Region.SouthernEurope,
            "Euro",
            "EUR");

        public static readonly Country SanMarino = new(
            "San Marino",
            "+378",
            "SM",
            "SMR",
            Continent.Europe,
            Region.SouthernEurope,
            "Euro",
            "EUR");

        public static readonly Country Serbia = new(
            "Serbia",
            "+381",
            "RS",
            "SRB",
            Continent.Europe,
            Region.SouthernEurope,
            "Serbian Dinar",
            "RSD");

        public static readonly Country Spain = new(
            "Spain",
            "+34",
            "ES",
            "ESP",
            Continent.Europe,
            Region.SouthernEurope,
            "Euro",
            "EUR");

        public static readonly Country VaticanCity = new(
            "Vatican City",
            "+379",
            "VA",
            "VAT",
            Continent.Europe,
            Region.SouthernEurope,
            "Euro",
            "EUR");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Albania,
                Andorra,
                BosniaAndHerzegovina,
                Croatia,
                Greece,
                Italy,
                Kosovo,
                Malta,
                Montenegro,
                NorthMacedonia,
                Portugal,
                SanMarino,
                Serbia,
                Spain,
                VaticanCity
            });
    }
}
