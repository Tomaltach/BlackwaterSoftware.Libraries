using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.CountryBlocks.Africa
{
    internal static class WesternAfrica
    {
        public static readonly Country Benin = new(
            "Benin",
            "+229",
            "BJ",
            "BEN",
            Continent.Africa,
            Region.WesternAfrica,
            "West African CFA Franc",
            "XOF");

        public static readonly Country BurkinaFaso = new(
            "Burkina Faso",
            "+226",
            "BF",
            "BFA",
            Continent.Africa,
            Region.WesternAfrica,
            "West African CFA Franc",
            "XOF");

        public static readonly Country CaboVerde = new(
            "Cabo Verde",
            "+238",
            "CV",
            "CPV",
            Continent.Africa,
            Region.WesternAfrica,
            "Cape Verdean Escudo",
            "CVE");

        public static readonly Country CoteDIvoire = new(
            "Côte d'Ivoire", "+225", "CI", "CIV",
            Continent.Africa, Region.WesternAfrica,
            "West African CFA Franc", "XOF");

        public static readonly Country TheGambia = new(
            "The Gambia", "+220", "GM", "GMB",
            Continent.Africa, Region.WesternAfrica,
            "Gambian Dalasi", "GMD");

        public static readonly Country Ghana = new(
            "Ghana", "+233", "GH", "GHA",
            Continent.Africa, Region.WesternAfrica,
            "Ghanaian Cedi", "GHS");

        public static readonly Country Guinea = new(
            "Guinea", "+224", "GN", "GIN",
            Continent.Africa, Region.WesternAfrica,
            "Guinean Franc", "GNF");

        public static readonly Country GuineaBissau = new(
            "Guinea-Bissau", "+245", "GW", "GNB",
            Continent.Africa, Region.WesternAfrica,
            "West African CFA Franc", "XOF");

        public static readonly Country Liberia = new(
            "Liberia", "+231", "LR", "LBR",
            Continent.Africa, Region.WesternAfrica,
            "Liberian Dollar", "LRD");

        public static readonly Country Mali = new(
            "Mali", "+223", "ML", "MLI",
            Continent.Africa, Region.WesternAfrica,
            "West African CFA Franc", "XOF");

        public static readonly Country Mauritania = new(
            "Mauritania", "+222", "MR", "MRT",
            Continent.Africa, Region.WesternAfrica,
            "Mauritanian Ouguiya", "MRU");

        public static readonly Country Niger = new(
            "Niger", "+227", "NE", "NER",
            Continent.Africa, Region.WesternAfrica,
            "West African CFA Franc", "XOF");

        public static readonly Country Nigeria = new(
            "Nigeria", "+234", "NG", "NGA",
            Continent.Africa, Region.WesternAfrica,
            "Nigerian Naira", "NGN");

        public static readonly Country Senegal = new(
            "Senegal", "+221", "SN", "SEN",
            Continent.Africa, Region.WesternAfrica,
            "West African CFA Franc", "XOF");

        public static readonly Country SierraLeone = new(
            "Sierra Leone", "+232", "SL", "SLE",
            Continent.Africa, Region.WesternAfrica,
            "Sierra Leonean Leone", "SLE");

        public static readonly Country Togo = new(
            "Togo", "+228", "TG", "TGO",
            Continent.Africa, Region.WesternAfrica,
            "West African CFA Franc", "XOF");

        public static IReadOnlyList<Country> All { get; } =
            Array.AsReadOnly(new[]
            {
                Benin,
                BurkinaFaso,
                CaboVerde,
                CoteDIvoire,
                TheGambia,
                Ghana,
                Guinea,
                GuineaBissau,
                Liberia,
                Mali,
                Mauritania,
                Niger,
                Nigeria,
                Senegal,
                SierraLeone,
                Togo
            });
    }
}
