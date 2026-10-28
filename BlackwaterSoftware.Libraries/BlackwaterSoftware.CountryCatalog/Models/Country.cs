using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Extensions;

namespace BlackwaterSoftware.CountryCatalog.Models
{
    /// <summary>
    /// Represents a country or territory in the catalog, including its
    /// identification codes, geographic classification, calling code,
    /// currency information, and code status.
    /// </summary>
    /// <param name="Name">
    /// The name of the country or territory.
    /// </param>
    /// <param name="CallingCode">
    /// The international telephone calling code, including any leading
    /// plus sign or other formatting used by the catalog.
    /// </param>
    /// <param name="Iso2">
    /// The ISO 3166-1 alpha-2 two-letter code, or the catalog's assigned
    /// code where applicable.
    /// </param>
    /// <param name="Iso3">
    /// The ISO 3166-1 alpha-3 three-letter code, or the catalog's assigned
    /// code where applicable.
    /// </param>
    /// <param name="Continent">
    /// The continent to which the country or territory is assigned
    /// in the catalog.
    /// </param>
    /// <param name="Region">
    /// The geographic region to which the country or territory is assigned
    /// in the catalog.
    /// </param>
    /// <param name="CurrencyName">
    /// The name of the currency associated with the country or territory
    /// in the catalog.
    /// </param>
    /// <param name="CurrencyCode">
    /// The currency code associated with the country or territory.
    /// </param>
    /// <param name="Weight">
    /// The relative weight assigned to the country or territory, as defined
    /// by <see cref="CountryWeight"/>. Defaults to
    /// <see cref="CountryWeight.Lowest"/>.
    /// </param>
    /// <param name="CodeStatus">
    /// Indicates whether the country or territory uses official ISO 3166-1
    /// codes or user-assigned codes. Defaults to
    /// <see cref="CountryCodeStatus.OfficialIso3166"/>.
    /// </param>
    public sealed record Country(
        string Name,
        string CallingCode,
        string Iso2,
        string Iso3,
        Continent Continent,
        Region Region,
        string CurrencyName,
        string CurrencyCode,
        CountryWeight Weight = CountryWeight.Lowest,
        CountryCodeStatus CodeStatus = CountryCodeStatus.OfficialIso3166)
    {
        /// <summary>
        /// Gets the display name of the continent.
        /// </summary>
        /// <remarks>
        /// The value is derived from <see cref="Continent"/> using
        /// <c>ToDisplayName()</c>.
        /// </remarks>
        public string ContinentName => Continent.ToDisplayName();

        /// <summary>
        /// Gets the display name of the geographic region.
        /// </summary>
        /// <remarks>
        /// The value is derived from <see cref="Region"/> using
        /// <c>ToDisplayName()</c>.
        /// </remarks>
        public string RegionName => Region.ToDisplayName();

        /// <summary>
        /// Gets a value indicating whether the country or territory has
        /// official ISO 3166-1 codes.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if <see cref="CodeStatus"/> is
        /// <see cref="CountryCodeStatus.OfficialIso3166"/>;
        /// otherwise, <see langword="false"/>.
        /// </value>
        public bool HasOfficialIso3166Codes => CodeStatus == CountryCodeStatus.OfficialIso3166;

        /// <summary>
        /// Gets a value indicating whether the country or territory uses
        /// user-assigned codes.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if <see cref="CodeStatus"/> is
        /// <see cref="CountryCodeStatus.UserAssigned"/>;
        /// otherwise, <see langword="false"/>.
        /// </value>
        public bool HasUserAssignedCodes => CodeStatus == CountryCodeStatus.UserAssigned;
    }
}
