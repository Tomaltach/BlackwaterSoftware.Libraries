namespace BlackwaterSoftware.CountryCatalog.Enums
{
    /// <summary>
    /// Specifies the status of the identification codes assigned to a country
    /// or territory in the catalog.
    /// </summary>
    public enum CountryCodeStatus
    {
        /// <summary>
        /// Indicates that the country or territory uses official ISO 3166-1 codes.
        /// </summary>
        OfficialIso3166,

        /// <summary>
        /// Indicates that the country or territory uses codes assigned for
        /// user-assigned purposes rather than official ISO 3166-1 assignments.
        /// </summary>
        UserAssigned,

        /// <summary>
        /// Indicates that the code is exceptionally reserved under the relevant
        /// ISO 3166 code reservation arrangements.
        /// </summary>
        ExceptionallyReserved,

        /// <summary>
        /// Indicates that the code is custom-defined by the catalog or its
        /// data provider and is not represented as an official ISO 3166-1 code.
        /// </summary>
        Custom,

        /// <summary>
        /// Indicates that the code status has not yet been verified.
        /// </summary>
        Unverified
    }
}
