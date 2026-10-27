using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Africa
{
    internal static class EasternAfrica
    {
        public static readonly Country Burundi = new(
            "Burundi",
            "+257",
            "BI",
            "BDI",
            Continent.Africa,
            Region.EasternAfrica,
            "Burundian Franc",
            "BIF");

        public static readonly Country Comoros = new(
            "Comoros",
            "+269",
            "KM",
            "COM",
            Continent.Africa,
            Region.EasternAfrica,
            "Comorian Franc",
            "KMF");

        public static readonly Country Djibouti = new(
            "Djibouti",
            "+253",
            "DJ",
            "DJI",
            Continent.Africa,
            Region.EasternAfrica,
            "Djiboutian Franc",
            "DJF");

        public static readonly Country Eritrea = new(
            "Eritrea",
            "+291",
            "ER",
            "ERI",
            Continent.Africa,
            Region.EasternAfrica,
            "Eritrean Nakfa",
            "ERN");

        public static readonly Country Ethiopia = new(
            "Ethiopia",
            "+251",
            "ET",
            "ETH",
            Continent.Africa,
            Region.EasternAfrica,
            "Ethiopian Birr",
            "ETB");

        public static readonly Country Kenya = new(
            "Kenya",
            "+254",
            "KE",
            "KEN",
            Continent.Africa,
            Region.EasternAfrica,
            "Kenyan Shilling",
            "KES");

        public static readonly Country Madagascar = new(
            "Madagascar",
            "+261",
            "MG",
            "MDG",
            Continent.Africa,
            Region.EasternAfrica,
            "Malagasy Ariary",
            "MGA");

        public static readonly Country Malawi = new(
            "Malawi",
            "+265",
            "MW",
            "MWI",
            Continent.Africa,
            Region.EasternAfrica,
            "Malawian Kwacha",
            "MWK");

        public static readonly Country Mauritius = new(
            "Mauritius",
            "+230",
            "MU",
            "MUS",
            Continent.Africa,
            Region.EasternAfrica,
            "Mauritian Rupee",
            "MUR");

        public static readonly Country Mozambique = new(
            "Mozambique",
            "+258",
            "MZ",
            "MOZ",
            Continent.Africa,
            Region.EasternAfrica,
            "Mozambican Metical",
            "MZN");

        public static readonly Country Rwanda = new(
            "Rwanda",
            "+250",
            "RW",
            "RWA",
            Continent.Africa,
            Region.EasternAfrica,
            "Rwandan Franc",
            "RWF");

        public static readonly Country Seychelles = new(
            "Seychelles",
            "+248",
            "SC",
            "SYC",
            Continent.Africa,
            Region.EasternAfrica,
            "Seychellois Rupee",
            "SCR");

        public static readonly Country Somalia = new(
            "Somalia",
            "+252",
            "SO",
            "SOM",
            Continent.Africa,
            Region.EasternAfrica,
            "Somali Shilling",
            "SOS");

        public static readonly Country SouthSudan = new(
            "South Sudan",
            "+211",
            "SS",
            "SSD",
            Continent.Africa,
            Region.EasternAfrica,
            "South Sudanese Pound",
            "SSP");

        public static readonly Country Tanzania = new(
            "Tanzania",
            "+255",
            "TZ",
            "TZA",
            Continent.Africa,
            Region.EasternAfrica,
            "Tanzanian Shilling",
            "TZS");

        public static readonly Country Uganda = new(
            "Uganda",
            "+256",
            "UG",
            "UGA",
            Continent.Africa,
            Region.EasternAfrica,
            "Ugandan Shilling",
            "UGX");

        public static readonly Country Zambia = new(
            "Zambia",
            "+260",
            "ZM",
            "ZMB",
            Continent.Africa,
            Region.EasternAfrica,
            "Zambian Kwacha",
            "ZMW");

        public static readonly Country Zimbabwe = new(
            "Zimbabwe",
            "+263",
            "ZW",
            "ZWE",
            Continent.Africa,
            Region.EasternAfrica,
            "Zimbabwe Gold",
            "ZWG");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Burundi,
                Comoros,
                Djibouti,
                Eritrea,
                Ethiopia,
                Kenya,
                Madagascar,
                Malawi,
                Mauritius,
                Mozambique,
                Rwanda,
                Seychelles,
                Somalia,
                SouthSudan,
                Tanzania,
                Uganda,
                Zambia,
                Zimbabwe
            });
    }
}
