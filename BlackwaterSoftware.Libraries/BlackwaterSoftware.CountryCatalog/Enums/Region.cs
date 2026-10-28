namespace BlackwaterSoftware.CountryCatalog.Enums
{
    /// <summary>
    /// Represents a geographic region used to classify countries and territories
    /// in the catalog.
    /// </summary>
    /// <remarks>
    /// Regions are grouped within continents according to the catalog's
    /// geographic classification. These classifications are intended for
    /// catalog organisation and may differ from other regional classification
    /// systems.
    /// </remarks>
    public enum Region
    {
        #region Africa

        /// <summary>
        /// Northern Africa.
        /// </summary>
        NorthernAfrica,

        /// <summary>
        /// Western Africa.
        /// </summary>
        WesternAfrica,

        /// <summary>
        /// Middle Africa.
        /// </summary>
        MiddleAfrica,

        /// <summary>
        /// Eastern Africa.
        /// </summary>
        EasternAfrica,

        /// <summary>
        /// Southern Africa.
        /// </summary>
        SouthernAfrica,

        #endregion Africa

        #region Asia

        /// <summary>
        /// Central Asia.
        /// </summary>
        CentralAsia,

        /// <summary>
        /// Eastern Asia.
        /// </summary>
        EasternAsia,

        /// <summary>
        /// South-Eastern Asia.
        /// </summary>
        SouthEasternAsia,

        /// <summary>
        /// Southern Asia.
        /// </summary>
        SouthernAsia,

        /// <summary>
        /// Western Asia.
        /// </summary>
        WesternAsia,

        #endregion Asia

        #region Europe

        /// <summary>
        /// Central Europe.
        /// </summary>
        CentralEurope,

        /// <summary>
        /// Eastern Europe.
        /// </summary>
        EasternEurope,

        /// <summary>
        /// Northern Europe.
        /// </summary>
        NorthernEurope,

        /// <summary>
        /// Southern Europe.
        /// </summary>
        SouthernEurope,

        /// <summary>
        /// Western Europe.
        /// </summary>
        WesternEurope,

        #endregion Europe

        #region North America

        /// <summary>
        /// Northern America.
        /// </summary>
        NorthernAmerica,

        /// <summary>
        /// Central America.
        /// </summary>
        CentralAmerica,

        /// <summary>
        /// The Caribbean region.
        /// </summary>
        Caribbean,

        #endregion North America

        #region South America

        /// <summary>
        /// South America.
        /// </summary>
        SouthAmerica,

        #endregion South America

        #region Oceania

        /// <summary>
        /// Australia and New Zealand.
        /// </summary>
        AustraliaAndNewZealand,

        /// <summary>
        /// Melanesia.
        /// </summary>
        Melanesia,

        /// <summary>
        /// Micronesia.
        /// </summary>
        Micronesia,

        /// <summary>
        /// Polynesia.
        /// </summary>
        Polynesia

        #endregion Oceania
    }
}
