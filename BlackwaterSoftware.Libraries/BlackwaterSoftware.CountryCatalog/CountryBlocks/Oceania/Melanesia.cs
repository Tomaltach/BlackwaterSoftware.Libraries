using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Oceania
{
    internal static class Melanesia
    {
        public static readonly Country Fiji = new(
            "Fiji",
            "+679",
            "FJ",
            "FJI",
            Continent.Oceania,
            Region.Melanesia,
            "Fijian Dollar",
            "FJD");

        public static readonly Country NewCaledonia = new(
            "New Caledonia",
            "+687",
            "NC",
            "NCL",
            Continent.Oceania,
            Region.Melanesia,
            "CFP Franc",
            "XPF");

        public static readonly Country PapuaNewGuinea = new(
            "Papua New Guinea",
            "+675",
            "PG",
            "PNG",
            Continent.Oceania,
            Region.Melanesia,
            "Papua New Guinean Kina",
            "PGK");

        public static readonly Country SolomonIslands = new(
            "Solomon Islands",
            "+677",
            "SB",
            "SLB",
            Continent.Oceania,
            Region.Melanesia,
            "Solomon Islands Dollar",
            "SBD");

        public static readonly Country Vanuatu = new(
            "Vanuatu",
            "+678",
            "VU",
            "VUT",
            Continent.Oceania,
            Region.Melanesia,
            "Vanuatu Vatu",
            "VUV");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Fiji,
                NewCaledonia,
                PapuaNewGuinea,
                SolomonIslands,
                Vanuatu
            });
    }
}
