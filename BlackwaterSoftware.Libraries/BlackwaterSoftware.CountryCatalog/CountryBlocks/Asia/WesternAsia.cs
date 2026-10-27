using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Asia
{
    internal static class WesternAsia
    {
        public static readonly Country Armenia = new(
            "Armenia",
            "+374",
            "AM",
            "ARM",
            Continent.Asia,
            Region.WesternAsia,
            "Armenian Dram",
            "AMD");

        public static readonly Country Azerbaijan = new(
            "Azerbaijan",
            "+994",
            "AZ",
            "AZE",
            Continent.Asia,
            Region.WesternAsia,
            "Azerbaijani Manat",
            "AZN");

        public static readonly Country Bahrain = new(
            "Bahrain",
            "+973",
            "BH",
            "BHR",
            Continent.Asia,
            Region.WesternAsia,
            "Bahraini Dinar",
            "BHD");

        public static readonly Country Cyprus = new(
            "Cyprus",
            "+357",
            "CY",
            "CYP",
            Continent.Asia,
            Region.WesternAsia,
            "Euro",
            "EUR");

        public static readonly Country Georgia = new(
            "Georgia",
            "+995",
            "GE",
            "GEO",
            Continent.Asia,
            Region.WesternAsia,
            "Georgian Lari",
            "GEL");

        public static readonly Country Iraq = new(
            "Iraq",
            "+964",
            "IQ",
            "IRQ",
            Continent.Asia,
            Region.WesternAsia,
            "Iraqi Dinar",
            "IQD");

        public static readonly Country Israel = new(
            "Israel",
            "+972",
            "IL",
            "ISR",
            Continent.Asia,
            Region.WesternAsia,
            "Israeli New Shekel",
            "ILS");

        public static readonly Country Jordan = new(
            "Jordan",
            "+962",
            "JO",
            "JOR",
            Continent.Asia,
            Region.WesternAsia,
            "Jordanian Dinar",
            "JOD");

        public static readonly Country Kuwait = new(
            "Kuwait",
            "+965",
            "KW",
            "KWT",
            Continent.Asia,
            Region.WesternAsia,
            "Kuwaiti Dinar",
            "KWD");

        public static readonly Country Lebanon = new(
            "Lebanon",
            "+961",
            "LB",
            "LBN",
            Continent.Asia,
            Region.WesternAsia,
            "Lebanese Pound",
            "LBP");

        public static readonly Country Oman = new(
            "Oman",
            "+968",
            "OM",
            "OMN",
            Continent.Asia,
            Region.WesternAsia,
            "Omani Rial",
            "OMR");

        public static readonly Country Palestine = new(
            "Palestine",
            "+970",
            "PS",
            "PSE",
            Continent.Asia,
            Region.WesternAsia,
            "Israeli New Shekel",
            "ILS");

        public static readonly Country Qatar = new(
            "Qatar",
            "+974",
            "QA",
            "QAT",
            Continent.Asia,
            Region.WesternAsia,
            "Qatari Riyal",
            "QAR");

        public static readonly Country SaudiArabia = new(
            "Saudi Arabia",
            "+966",
            "SA",
            "SAU",
            Continent.Asia,
            Region.WesternAsia,
            "Saudi Riyal",
            "SAR");

        public static readonly Country Syria = new(
            "Syria",
            "+963",
            "SY",
            "SYR",
            Continent.Asia,
            Region.WesternAsia,
            "Syrian Pound",
            "SYP");

        public static readonly Country Turkey = new(
            "Türkiye",
            "+90",
            "TR",
            "TUR",
            Continent.Asia,
            Region.WesternAsia,
            "Turkish Lira",
            "TRY");

        public static readonly Country UnitedArabEmirates = new(
            "United Arab Emirates",
            "+971",
            "AE",
            "ARE",
            Continent.Asia,
            Region.WesternAsia,
            "UAE Dirham",
            "AED");

        public static readonly Country Yemen = new(
            "Yemen",
            "+967",
            "YE",
            "YEM",
            Continent.Asia,
            Region.WesternAsia,
            "Yemeni Rial",
            "YER");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Armenia,
                Azerbaijan,
                Bahrain,
                Cyprus,
                Georgia,
                Iraq,
                Israel,
                Jordan,
                Kuwait,
                Lebanon,
                Oman,
                Palestine,
                Qatar,
                SaudiArabia,
                Syria,
                Turkey,
                UnitedArabEmirates,
                Yemen
            });
    }
}
