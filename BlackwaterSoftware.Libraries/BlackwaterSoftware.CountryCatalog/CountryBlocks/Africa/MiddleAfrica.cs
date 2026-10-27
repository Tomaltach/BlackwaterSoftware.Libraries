using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Africa
{
    internal static class MiddleAfrica
    {
        public static readonly Country Angola = new(
            "Angola",
            "+244",
            "AO",
            "AGO",
            Continent.Africa,
            Region.MiddleAfrica,
            "Angolan Kwanza",
            "AOA");

        public static readonly Country Cameroon = new(
            "Cameroon",
            "+237",
            "CM",
            "CMR",
            Continent.Africa,
            Region.MiddleAfrica,
            "Central African CFA Franc",
            "XAF");

        public static readonly Country CentralAfricanRepublic = new(
            "Central African Republic",
            "+236",
            "CF",
            "CAF",
            Continent.Africa,
            Region.MiddleAfrica,
            "Central African CFA Franc",
            "XAF");

        public static readonly Country Chad = new(
            "Chad",
            "+235",
            "TD",
            "TCD",
            Continent.Africa,
            Region.MiddleAfrica,
            "Central African CFA Franc",
            "XAF");

        public static readonly Country RepublicOfTheCongo = new(
            "Republic of the Congo",
            "+242",
            "CG",
            "COG",
            Continent.Africa,
            Region.MiddleAfrica,
            "Central African CFA Franc",
            "XAF");

        public static readonly Country DemocraticRepublicOfTheCongo = new(
            "Democratic Republic of the Congo",
            "+243",
            "CD",
            "COD",
            Continent.Africa,
            Region.MiddleAfrica,
            "Congolese Franc",
            "CDF");

        public static readonly Country EquatorialGuinea = new(
            "Equatorial Guinea",
            "+240",
            "GQ",
            "GNQ",
            Continent.Africa,
            Region.MiddleAfrica,
            "Central African CFA Franc",
            "XAF");

        public static readonly Country Gabon = new(
            "Gabon",
            "+241",
            "GA",
            "GAB",
            Continent.Africa,
            Region.MiddleAfrica,
            "Central African CFA Franc",
            "XAF");

        public static readonly Country SaoTomeAndPrincipe = new(
            "São Tomé and Príncipe",
            "+239",
            "ST",
            "STP",
            Continent.Africa,
            Region.MiddleAfrica,
            "São Tomé and Príncipe Dobra",
            "STN");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Angola,
                Cameroon,
                CentralAfricanRepublic,
                Chad,
                RepublicOfTheCongo,
                DemocraticRepublicOfTheCongo,
                EquatorialGuinea,
                Gabon,
                SaoTomeAndPrincipe
            });
    }
}
