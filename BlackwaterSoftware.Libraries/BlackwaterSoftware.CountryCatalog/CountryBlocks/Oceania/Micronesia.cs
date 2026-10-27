using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Oceania
{
    internal static class Micronesia
    {
        public static readonly Country FederatedStatesOfMicronesia = new(
            "Federated States of Micronesia",
            "+691",
            "FM",
            "FSM",
            Continent.Oceania,
            Region.Micronesia,
            "United States Dollar",
            "USD");

        public static readonly Country Guam = new(
            "Guam",
            "+1-671",
            "GU",
            "GUM",
            Continent.Oceania,
            Region.Micronesia,
            "United States Dollar",
            "USD");

        public static readonly Country Kiribati = new(
            "Kiribati",
            "+686",
            "KI",
            "KIR",
            Continent.Oceania,
            Region.Micronesia,
            "Australian Dollar",
            "AUD");

        public static readonly Country MarshallIslands = new(
            "Marshall Islands",
            "+692",
            "MH",
            "MHL",
            Continent.Oceania,
            Region.Micronesia,
            "United States Dollar",
            "USD");

        public static readonly Country Nauru = new(
            "Nauru",
            "+674",
            "NR",
            "NRU",
            Continent.Oceania,
            Region.Micronesia,
            "Australian Dollar",
            "AUD");

        public static readonly Country NorthernMarianaIslands = new(
            "Northern Mariana Islands",
            "+1-670",
            "MP",
            "MNP",
            Continent.Oceania,
            Region.Micronesia,
            "United States Dollar",
            "USD");

        public static readonly Country Palau = new(
            "Palau",
            "+680",
            "PW",
            "PLW",
            Continent.Oceania,
            Region.Micronesia,
            "United States Dollar",
            "USD");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                FederatedStatesOfMicronesia,
                Guam,
                Kiribati,
                MarshallIslands,
                Nauru,
                NorthernMarianaIslands,
                Palau
            });
    }
}
