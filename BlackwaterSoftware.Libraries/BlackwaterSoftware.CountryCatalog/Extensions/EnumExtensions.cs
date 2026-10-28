using BlackwaterSoftware.CountryCatalog.Enums;

namespace BlackwaterSoftware.CountryCatalog.Extensions
{
    /// <summary>
    /// Provides extension methods for converting catalog enums into
    /// human-readable display names.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the human-readable display name of a continent.
        /// </summary>
        /// <param name="continent">
        /// The continent whose display name is required.
        /// </param>
        /// <returns>
        /// The display name of the specified continent.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The specified value is not a recognised <see cref="Continent"/> member.
        /// </exception>
        public static string ToDisplayName(this Continent continent)
        {
            return continent switch
            {
                Continent.Africa => "Africa",
                Continent.Asia => "Asia",
                Continent.Europe => "Europe",
                Continent.NorthAmerica => "North America",
                Continent.SouthAmerica => "South America",
                Continent.Oceania => "Oceania",
                Continent.Antarctica => "Antarctica",
                _ => throw new ArgumentOutOfRangeException(nameof(continent), continent, null)
            };
        }

        /// <summary>
        /// Gets the human-readable display name of a geographic region.
        /// </summary>
        /// <param name="region">
        /// The region whose display name is required.
        /// </param>
        /// <returns>
        /// The display name of the specified region.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The specified value is not a recognised <see cref="Region"/> member.
        /// </exception>
        public static string ToDisplayName(this Region region)
        {
            return region switch
            {
                Region.NorthernAfrica => "Northern Africa",
                Region.WesternAfrica => "Western Africa",
                Region.MiddleAfrica => "Middle Africa",
                Region.EasternAfrica => "Eastern Africa",
                Region.SouthernAfrica => "Southern Africa",

                Region.CentralAsia => "Central Asia",
                Region.EasternAsia => "Eastern Asia",
                Region.SouthEasternAsia => "South Eastern Asia",
                Region.SouthernAsia => "Southern Asia",
                Region.WesternAsia => "Western Asia",

                Region.EasternEurope => "Eastern Europe",
                Region.NorthernEurope => "Northern Europe",
                Region.SouthernEurope => "Southern Europe",
                Region.WesternEurope => "Western Europe",

                Region.NorthernAmerica => "Northern America",
                Region.CentralAmerica => "Central America",
                Region.Caribbean => "Caribbean",

                Region.SouthAmerica => "South America",

                Region.AustraliaAndNewZealand => "Australia and New Zealand",
                Region.Melanesia => "Melanesia",
                Region.Micronesia => "Micronesia",
                Region.Polynesia => "Polynesia",
                _ => throw new ArgumentOutOfRangeException(nameof(region), region, null)
            };
        }
    }
}