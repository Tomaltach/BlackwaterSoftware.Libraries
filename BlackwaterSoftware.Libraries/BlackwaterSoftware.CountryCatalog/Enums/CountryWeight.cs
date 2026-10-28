namespace BlackwaterSoftware.CountryCatalog.Enums
{
    /// <summary>
    /// Defines the default relative weight assigned to a country or territory
    /// in the catalog.
    /// </summary>
    /// <remarks>
    /// These values can be used by applications as a starting point for
    /// prioritisation or ranking. They do not prescribe how an application
    /// must order or display countries.
    /// </remarks>
    public enum CountryWeight
    {
        /// <summary>
        /// Represents the highest default priority.
        /// </summary>
        Top = 1,

        /// <summary>
        /// Represents the middle default priority.
        /// </summary>
        Middle = 2,

        /// <summary>
        /// Represents the lowest default priority.
        /// </summary>
        Lowest = 3
    }
}
