using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Asia
{
    internal static class SouthernAsia
    {
        public static readonly Country Afghanistan = new(
            "Afghanistan",
            "+93",
            "AF",
            "AFG",
            Continent.Asia,
            Region.SouthernAsia,
            "Afghan Afghani",
            "AFN");

        public static readonly Country Bangladesh = new(
            "Bangladesh",
            "+880",
            "BD",
            "BGD",
            Continent.Asia,
            Region.SouthernAsia,
            "Bangladeshi Taka",
            "BDT");

        public static readonly Country Bhutan = new(
            "Bhutan",
            "+975",
            "BT",
            "BTN",
            Continent.Asia,
            Region.SouthernAsia,
            "Bhutanese Ngultrum",
            "BTN");

        public static readonly Country India = new(
            "India",
            "+91",
            "IN",
            "IND",
            Continent.Asia,
            Region.SouthernAsia,
            "Indian Rupee",
            "INR");

        public static readonly Country Iran = new(
            "Iran",
            "+98",
            "IR",
            "IRN",
            Continent.Asia,
            Region.SouthernAsia,
            "Iranian Rial",
            "IRR");

        public static readonly Country Maldives = new(
            "Maldives",
            "+960",
            "MV",
            "MDV",
            Continent.Asia,
            Region.SouthernAsia,
            "Maldivian Rufiyaa",
            "MVR");

        public static readonly Country Nepal = new(
            "Nepal",
            "+977",
            "NP",
            "NPL",
            Continent.Asia,
            Region.SouthernAsia,
            "Nepalese Rupee",
            "NPR");

        public static readonly Country Pakistan = new(
            "Pakistan",
            "+92",
            "PK",
            "PAK",
            Continent.Asia,
            Region.SouthernAsia,
            "Pakistani Rupee",
            "PKR");

        public static readonly Country SriLanka = new(
            "Sri Lanka",
            "+94",
            "LK",
            "LKA",
            Continent.Asia,
            Region.SouthernAsia,
            "Sri Lankan Rupee",
            "LKR");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Afghanistan,
                Bangladesh,
                Bhutan,
                India,
                Iran,
                Maldives,
                Nepal,
                Pakistan,
                SriLanka
            });
    }
}
