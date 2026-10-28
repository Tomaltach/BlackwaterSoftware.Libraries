using BlackwaterSoftware.CountryCatalog.CountryBlocks.Africa;
using BlackwaterSoftware.CountryCatalog.CountryBlocks.Asia;
using BlackwaterSoftware.CountryCatalog.CountryBlocks.Europe;
using BlackwaterSoftware.CountryCatalog.CountryBlocks.NorthAmerica;
using BlackwaterSoftware.CountryCatalog.CountryBlocks.Oceania;
using BlackwaterSoftware.CountryCatalog.CountryBlocks.SouthAmerica;
using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;
using System.Collections.Frozen;

namespace BlackwaterSoftware.CountryCatalog
{
    /// <summary>
    /// Provides access to the catalog of countries and territories, including
    /// ISO 3166-1 codes, geographic classifications, calling codes, and currency
    /// information.
    /// </summary>
    /// <remarks>
    /// The catalog includes countries and territories grouped by continent and
    /// region. Country records can be retrieved using ISO codes, geographic
    /// classifications, or currency codes, or by searching across supported fields.
    /// </remarks>
    public static class Countries
    {
        private static readonly Country[] _all =
        [
            #region Africa
            .. NorthernAfrica.All,
            .. WesternAfrica.All,
            .. MiddleAfrica.All,
            .. EasternAfrica.All,
            .. SouthernAfrica.All,
            #endregion Africa
            #region Asia
            .. CentralAsia.All,
            .. EasternAsia.All,
            .. SouthEasternAsia.All,
            .. SouthernAsia.All,
            .. WesternAsia.All,
            #endregion Asia
            #region Europe
            .. CentralEurope.All,
            .. EasternEurope.All,
            .. NorthernEurope.All,
            .. SouthernEurope.All,
            .. WesternEurope.All,
            #endregion Europe
            #region North America
            .. NorthernAmerica.All,
            .. CentralAmerica.All,
            .. Caribbean.All,
            #endregion North America
            #region South America
            .. SouthAmerica.All,
            #endregion South America
            #region Oceania
            .. AustraliaAndNewZealand.All,
            .. Melanesia.All,
            .. Micronesia.All,
            .. Polynesia.All
            #endregion Oceania
        ];

        /// <summary>
        /// Gets all countries and territories in the catalog.
        /// </summary>
        /// <remarks>
        /// The collection is read-only and follows the catalog's defined
        /// initialization order. Use <see cref="Search(string)"/> to retrieve
        /// matching entries in alphabetical order.
        /// </remarks>
        public static IReadOnlyList<Country> All { get; } = Array.AsReadOnly(_all);

        #region FrozenDictionary
        /// <summary>
        /// Gets the country catalog indexed by ISO 3166-1 alpha-2 codes.
        /// </summary>
        /// <remarks>
        /// Keys are matched using ordinal, case-insensitive comparison.
        /// </remarks>
        public static readonly FrozenDictionary<string, Country> ByIso2 = _all.ToFrozenDictionary(
            c => c.Iso2,
            StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Gets the country catalog indexed by ISO 3166-1 alpha-3 codes.
        /// </summary>
        /// <remarks>
        /// Keys are matched using ordinal, case-insensitive comparison.
        /// </remarks>
        public static readonly FrozenDictionary<string, Country> ByIso3 = _all.ToFrozenDictionary(
            c => c.Iso3,
            StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Gets countries and territories grouped by continent.
        /// </summary>
        /// <remarks>
        /// Each array is ordered alphabetically by country name.
        /// The dictionary is frozen, but the arrays stored as values are mutable.
        /// </remarks>
        public static readonly FrozenDictionary<Continent, Country[]> ByContinent = _all
            .GroupBy(c => c.Continent)
            .ToFrozenDictionary(
                group => group.Key,
                group => group.OrderBy(c => c.Name)
            .ToArray());

        /// <summary>
        /// Gets countries and territories grouped by geographic region.
        /// </summary>
        /// <remarks>
        /// Each array is ordered alphabetically by country name.
        /// The dictionary is frozen, but the arrays stored as values are mutable.
        /// </remarks>
        public static readonly FrozenDictionary<Region, Country[]> ByRegion = _all
            .GroupBy(c => c.Region)
            .ToFrozenDictionary(
                group => group.Key,
                group => group.OrderBy(c => c.Name)
            .ToArray());

        /// <summary>
        /// Gets countries and territories grouped by continent and then by region.
        /// </summary>
        /// <remarks>
        /// Country collections within each region are ordered alphabetically
        /// by country name. The nested dictionaries are frozen, and the country
        /// collections are exposed as read-only lists.
        /// </remarks>
        public static readonly FrozenDictionary<Continent,FrozenDictionary<Region, IReadOnlyList<Country>>> ByContinentAndRegion = _all
            .GroupBy(c => c.Continent)
            .ToFrozenDictionary(
                continentGroup => continentGroup.Key,
                continentGroup => continentGroup
                .GroupBy(c => c.Region)
                .ToFrozenDictionary(
                    regionGroup => regionGroup.Key,
                    regionGroup => (IReadOnlyList<Country>)Array
                        .AsReadOnly(regionGroup.OrderBy(c => c.Name)
                .ToArray())));
        #endregion FrozenDictionary

        /// <summary>
        /// Finds a country or territory using its ISO 3166-1 alpha-2 code.
        /// </summary>
        /// <param name="iso2">
        /// The two-letter ISO code to look up. The comparison is case-insensitive.
        /// </param>
        /// <returns>
        /// The matching country or territory, or <see langword="null"/> if no
        /// matching code exists.
        /// </returns>
        public static Country? FindByIso2(string iso2) => ByIso2.GetValueOrDefault(iso2);

        /// <summary>
        /// Finds a country or territory using its ISO 3166-1 alpha-3 code.
        /// </summary>
        /// <param name="iso3">
        /// The three-letter ISO code to look up. The comparison is case-insensitive.
        /// </param>
        /// <returns>
        /// The matching country or territory, or <see langword="null"/> if no
        /// matching code exists.
        /// </returns>
        public static Country? FindByIso3(string iso3) => ByIso3.GetValueOrDefault(iso3);

        /// <summary>
        /// Gets all countries and territories assigned to a specified continent.
        /// </summary>
        /// <param name="continent">The continent to search.</param>
        /// <returns>
        /// A read-only list of matching entries ordered alphabetically by name,
        /// or an empty list if the continent has no entries.
        /// </returns>
        public static IReadOnlyList<Country> FindByContinent(Continent continent)
        {
            return ByContinent.TryGetValue(continent, out var countries)
                ? Array.AsReadOnly(countries)
                : Array.Empty<Country>();
        }

        /// <summary>
        /// Gets all countries and territories assigned to a specified region.
        /// </summary>
        /// <param name="region">The geographic region to search.</param>
        /// <returns>
        /// A read-only list of matching entries ordered alphabetically by name,
        /// or an empty list if the region has no entries.
        /// </returns>
        public static IReadOnlyList<Country> FindByRegion(Region region)
        {
            return ByRegion.TryGetValue(region, out var countries)
                ? Array.AsReadOnly(countries)
                : Array.Empty<Country>();
        }

        /// <summary>
        /// Finds countries and territories using their currency code.
        /// </summary>
        /// <param name="currencyCode">
        /// The currency code to search for. Leading and trailing whitespace
        /// is ignored, and the comparison is case-insensitive.
        /// </param>
        /// <returns>
        /// A read-only list of matching entries ordered alphabetically by name.
        /// Returns an empty list if the input is null, empty, whitespace, or
        /// does not match any currency code.
        /// </returns>
        public static IReadOnlyList<Country> FindByCurrencyCode(string? currencyCode)
        {
            if (string.IsNullOrWhiteSpace(currencyCode))
                return Array.Empty<Country>();

            return Array.AsReadOnly(_all
                .Where(c => string.Equals(
                    c.CurrencyCode,
                    currencyCode.Trim(),
                    StringComparison.OrdinalIgnoreCase))
                .OrderBy(c => c.Name)
                .ToArray());
        }

        /// <summary>
        /// Searches the country catalog by name, ISO code, calling code,
        /// currency code, or currency name.
        /// </summary>
        /// <param name="query">
        /// The text to search for. Matching is case-insensitive, and leading
        /// and trailing whitespace is ignored.
        /// </param>
        /// <returns>
        /// A read-only list of matching entries ordered alphabetically by name.
        /// If the query is null, empty, or whitespace, returns all entries
        /// in the catalog's defined initialization order.
        /// </returns>
        /// <remarks>
        /// The search uses substring matching. It does not perform fuzzy
        /// matching or search fields that are not listed above.
        /// </remarks>
        public static IReadOnlyList<Country> Search(string? query)
        {
            if (string.IsNullOrWhiteSpace(query)) return All;

            query = query.Trim();

            return Array.AsReadOnly(_all
                .Where(c =>
                    c.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    c.Iso2.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    c.Iso3.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    c.CallingCode.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    c.CurrencyCode.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    c.CurrencyName.Contains(query, StringComparison.OrdinalIgnoreCase))
                .OrderBy(c => c.Name)
                .ToArray());
        }

        #region Individual Countries

        #region Africa

        #region Northern Africa

        /// <summary>
        /// Gets the country of Algeria.
        /// </summary>
        public static Country Algeria => NorthernAfrica.Algeria;

        /// <summary>
        /// Gets the country of Egypt.
        /// </summary>
        public static Country Egypt => NorthernAfrica.Egypt;

        /// <summary>
        /// Gets the country of Libya.
        /// </summary>
        public static Country Libya => NorthernAfrica.Libya;

        /// <summary>
        /// Gets the country of Morocco.
        /// </summary>
        public static Country Morocco => NorthernAfrica.Morocco;

        /// <summary>
        /// Gets the country of Sudan.
        /// </summary>
        public static Country Sudan => NorthernAfrica.Sudan;

        /// <summary>
        /// Gets the country of Tunisia.
        /// </summary>
        public static Country Tunisia => NorthernAfrica.Tunisia;

        /// <summary>
        /// Gets the territory of Western Sahara.
        /// </summary>
        public static Country WesternSahara => NorthernAfrica.WesternSahara;

        #endregion Northern Africa

        #region Western Africa

        /// <summary>
        /// Gets the country of Benin.
        /// </summary>
        public static Country Benin => WesternAfrica.Benin;

        /// <summary>
        /// Gets the country of Burkina Faso.
        /// </summary>
        public static Country BurkinaFaso => WesternAfrica.BurkinaFaso;

        /// <summary>
        /// Gets the country of Cabo Verde.
        /// </summary>
        public static Country CaboVerde => WesternAfrica.CaboVerde;

        /// <summary>
        /// Gets the country of Côte d'Ivoire.
        /// </summary>
        public static Country CoteDIvoire => WesternAfrica.CoteDIvoire;

        /// <summary>
        /// Gets the country of The Gambia.
        /// </summary>
        public static Country TheGambia => WesternAfrica.TheGambia;

        /// <summary>
        /// Gets the country of Ghana.
        /// </summary>
        public static Country Ghana => WesternAfrica.Ghana;

        /// <summary>
        /// Gets the country of Guinea.
        /// </summary>
        public static Country Guinea => WesternAfrica.Guinea;

        /// <summary>
        /// Gets the country of Guinea-Bissau.
        /// </summary>
        public static Country GuineaBissau => WesternAfrica.GuineaBissau;

        /// <summary>
        /// Gets the country of Liberia.
        /// </summary>
        public static Country Liberia => WesternAfrica.Liberia;

        /// <summary>
        /// Gets the country of Mali.
        /// </summary>
        public static Country Mali => WesternAfrica.Mali;

        /// <summary>
        /// Gets the country of Mauritania.
        /// </summary>
        public static Country Mauritania => WesternAfrica.Mauritania;

        /// <summary>
        /// Gets the country of Niger.
        /// </summary>
        public static Country Niger => WesternAfrica.Niger;

        /// <summary>
        /// Gets the country of Nigeria.
        /// </summary>
        public static Country Nigeria => WesternAfrica.Nigeria;

        /// <summary>
        /// Gets the country of Senegal.
        /// </summary>
        public static Country Senegal => WesternAfrica.Senegal;

        /// <summary>
        /// Gets the country of Sierra Leone.
        /// </summary>
        public static Country SierraLeone => WesternAfrica.SierraLeone;

        /// <summary>
        /// Gets the country of Togo.
        /// </summary>
        public static Country Togo => WesternAfrica.Togo;

        #endregion Western Africa

        #region Middle Africa

        /// <summary>
        /// Gets the country of Angola.
        /// </summary>
        public static Country Angola => MiddleAfrica.Angola;

        /// <summary>
        /// Gets the country of Cameroon.
        /// </summary>
        public static Country Cameroon => MiddleAfrica.Cameroon;

        /// <summary>
        /// Gets the country of the Central African Republic.
        /// </summary>
        public static Country CentralAfricanRepublic => MiddleAfrica.CentralAfricanRepublic;

        /// <summary>
        /// Gets the country of Chad.
        /// </summary>
        public static Country Chad => MiddleAfrica.Chad;

        /// <summary>
        /// Gets the Republic of the Congo.
        /// </summary>
        public static Country RepublicOfTheCongo => MiddleAfrica.RepublicOfTheCongo;

        /// <summary>
        /// Gets the Democratic Republic of the Congo.
        /// </summary>
        public static Country DemocraticRepublicOfTheCongo => MiddleAfrica.DemocraticRepublicOfTheCongo;

        /// <summary>
        /// Gets the country of Equatorial Guinea.
        /// </summary>
        public static Country EquatorialGuinea => MiddleAfrica.EquatorialGuinea;

        /// <summary>
        /// Gets the country of Gabon.
        /// </summary>
        public static Country Gabon => MiddleAfrica.Gabon;

        /// <summary>
        /// Gets the country of São Tomé and Príncipe.
        /// </summary>
        public static Country SaoTomeAndPrincipe => MiddleAfrica.SaoTomeAndPrincipe;

        #endregion Middle Africa

        #region Eastern Africa

        /// <summary>
        /// Gets the country of Burundi.
        /// </summary>
        public static Country Burundi => EasternAfrica.Burundi;

        /// <summary>
        /// Gets the country of Comoros.
        /// </summary>
        public static Country Comoros => EasternAfrica.Comoros;

        /// <summary>
        /// Gets the country of Djibouti.
        /// </summary>
        public static Country Djibouti => EasternAfrica.Djibouti;

        /// <summary>
        /// Gets the country of Eritrea.
        /// </summary>
        public static Country Eritrea => EasternAfrica.Eritrea;

        /// <summary>
        /// Gets the country of Ethiopia.
        /// </summary>
        public static Country Ethiopia => EasternAfrica.Ethiopia;

        /// <summary>
        /// Gets the country of Kenya.
        /// </summary>
        public static Country Kenya => EasternAfrica.Kenya;

        /// <summary>
        /// Gets the country of Madagascar.
        /// </summary>
        public static Country Madagascar => EasternAfrica.Madagascar;

        /// <summary>
        /// Gets the country of Malawi.
        /// </summary>
        public static Country Malawi => EasternAfrica.Malawi;

        /// <summary>
        /// Gets the country of Mauritius.
        /// </summary>
        public static Country Mauritius => EasternAfrica.Mauritius;

        /// <summary>
        /// Gets the country of Mozambique.
        /// </summary>
        public static Country Mozambique => EasternAfrica.Mozambique;

        /// <summary>
        /// Gets the country of Rwanda.
        /// </summary>
        public static Country Rwanda => EasternAfrica.Rwanda;

        /// <summary>
        /// Gets the country of Seychelles.
        /// </summary>
        public static Country Seychelles => EasternAfrica.Seychelles;

        /// <summary>
        /// Gets the country of Somalia.
        /// </summary>
        public static Country Somalia => EasternAfrica.Somalia;

        /// <summary>
        /// Gets the country of South Sudan.
        /// </summary>
        public static Country SouthSudan => EasternAfrica.SouthSudan;

        /// <summary>
        /// Gets the country of Tanzania.
        /// </summary>
        public static Country Tanzania => EasternAfrica.Tanzania;

        /// <summary>
        /// Gets the country of Uganda.
        /// </summary>
        public static Country Uganda => EasternAfrica.Uganda;

        /// <summary>
        /// Gets the country of Zambia.
        /// </summary>
        public static Country Zambia => EasternAfrica.Zambia;

        /// <summary>
        /// Gets the country of Zimbabwe.
        /// </summary>
        public static Country Zimbabwe => EasternAfrica.Zimbabwe;

        #endregion Eastern Africa

        #region Southern Africa

        /// <summary>
        /// Gets the country of Botswana.
        /// </summary>
        public static Country Botswana => SouthernAfrica.Botswana;

        /// <summary>
        /// Gets the country of Eswatini.
        /// </summary>
        public static Country Eswatini => SouthernAfrica.Eswatini;

        /// <summary>
        /// Gets the country of Lesotho.
        /// </summary>
        public static Country Lesotho => SouthernAfrica.Lesotho;

        /// <summary>
        /// Gets the country of Namibia.
        /// </summary>
        public static Country Namibia => SouthernAfrica.Namibia;

        /// <summary>
        /// Gets the country of South Africa.
        /// </summary>
        public static Country SouthAfrica => SouthernAfrica.SouthAfrica;

        #endregion Southern Africa

        #endregion Africa

        #region Asia

        #region Central Asia

        /// <summary>
        /// Gets the country of Kazakhstan.
        /// </summary>
        public static Country Kazakhstan => CentralAsia.Kazakhstan;

        /// <summary>
        /// Gets the country of Kyrgyzstan.
        /// </summary>
        public static Country Kyrgyzstan => CentralAsia.Kyrgyzstan;

        /// <summary>
        /// Gets the country of Tajikistan.
        /// </summary>
        public static Country Tajikistan => CentralAsia.Tajikistan;

        /// <summary>
        /// Gets the country of Turkmenistan.
        /// </summary>
        public static Country Turkmenistan => CentralAsia.Turkmenistan;

        /// <summary>
        /// Gets the country of Uzbekistan.
        /// </summary>
        public static Country Uzbekistan => CentralAsia.Uzbekistan;

        #endregion Central Asia

        #region Eastern Asia

        /// <summary>
        /// Gets the country of China.
        /// </summary>
        public static Country China => EasternAsia.China;

        /// <summary>
        /// Gets the country of Japan.
        /// </summary>
        public static Country Japan => EasternAsia.Japan;

        /// <summary>
        /// Gets the country of Mongolia.
        /// </summary>
        public static Country Mongolia => EasternAsia.Mongolia;

        /// <summary>
        /// Gets the country of North Korea.
        /// </summary>
        public static Country NorthKorea => EasternAsia.NorthKorea;

        /// <summary>
        /// Gets the country of South Korea.
        /// </summary>
        public static Country SouthKorea => EasternAsia.SouthKorea;

        /// <summary>
        /// Gets Taiwan.
        /// </summary>
        public static Country Taiwan => EasternAsia.Taiwan;

        #endregion Eastern Asia

        #region South-Eastern Asia

        /// <summary>
        /// Gets the country of Brunei.
        /// </summary>
        public static Country Brunei => SouthEasternAsia.Brunei;

        /// <summary>
        /// Gets the country of Cambodia.
        /// </summary>
        public static Country Cambodia => SouthEasternAsia.Cambodia;

        /// <summary>
        /// Gets the country of Indonesia.
        /// </summary>
        public static Country Indonesia => SouthEasternAsia.Indonesia;

        /// <summary>
        /// Gets the country of Laos.
        /// </summary>
        public static Country Laos => SouthEasternAsia.Laos;

        /// <summary>
        /// Gets the country of Malaysia.
        /// </summary>
        public static Country Malaysia => SouthEasternAsia.Malaysia;

        /// <summary>
        /// Gets the country of Myanmar.
        /// </summary>
        public static Country Myanmar => SouthEasternAsia.Myanmar;

        /// <summary>
        /// Gets the country of the Philippines.
        /// </summary>
        public static Country Philippines => SouthEasternAsia.Philippines;

        /// <summary>
        /// Gets the country of Singapore.
        /// </summary>
        public static Country Singapore => SouthEasternAsia.Singapore;

        /// <summary>
        /// Gets the country of Thailand.
        /// </summary>
        public static Country Thailand => SouthEasternAsia.Thailand;

        /// <summary>
        /// Gets the country of Timor-Leste.
        /// </summary>
        public static Country TimorLeste => SouthEasternAsia.TimorLeste;

        /// <summary>
        /// Gets the country of Vietnam.
        /// </summary>
        public static Country Vietnam => SouthEasternAsia.Vietnam;

        #endregion South-Eastern Asia

        #region Southern Asia

        /// <summary>
        /// Gets the country of Afghanistan.
        /// </summary>
        public static Country Afghanistan => SouthernAsia.Afghanistan;

        /// <summary>
        /// Gets the country of Bangladesh.
        /// </summary>
        public static Country Bangladesh => SouthernAsia.Bangladesh;

        /// <summary>
        /// Gets the country of Bhutan.
        /// </summary>
        public static Country Bhutan => SouthernAsia.Bhutan;

        /// <summary>
        /// Gets the country of India.
        /// </summary>
        public static Country India => SouthernAsia.India;

        /// <summary>
        /// Gets the country of Iran.
        /// </summary>
        public static Country Iran => SouthernAsia.Iran;

        /// <summary>
        /// Gets the country of Maldives.
        /// </summary>
        public static Country Maldives => SouthernAsia.Maldives;

        /// <summary>
        /// Gets the country of Nepal.
        /// </summary>
        public static Country Nepal => SouthernAsia.Nepal;

        /// <summary>
        /// Gets the country of Pakistan.
        /// </summary>
        public static Country Pakistan => SouthernAsia.Pakistan;

        /// <summary>
        /// Gets the country of Sri Lanka.
        /// </summary>
        public static Country SriLanka => SouthernAsia.SriLanka;

        #endregion Southern Asia

        #region Western Asia

        /// <summary>
        /// Gets the country of Armenia.
        /// </summary>
        public static Country Armenia => WesternAsia.Armenia;

        /// <summary>
        /// Gets the country of Azerbaijan.
        /// </summary>
        public static Country Azerbaijan => WesternAsia.Azerbaijan;

        /// <summary>
        /// Gets the country of Bahrain.
        /// </summary>
        public static Country Bahrain => WesternAsia.Bahrain;

        /// <summary>
        /// Gets the country of Cyprus.
        /// </summary>
        public static Country Cyprus => WesternAsia.Cyprus;

        /// <summary>
        /// Gets the country of Georgia.
        /// </summary>
        public static Country Georgia => WesternAsia.Georgia;

        /// <summary>
        /// Gets the country of Iraq.
        /// </summary>
        public static Country Iraq => WesternAsia.Iraq;

        /// <summary>
        /// Gets the country of Israel.
        /// </summary>
        public static Country Israel => WesternAsia.Israel;

        /// <summary>
        /// Gets the country of Jordan.
        /// </summary>
        public static Country Jordan => WesternAsia.Jordan;

        /// <summary>
        /// Gets the country of Kuwait.
        /// </summary>
        public static Country Kuwait => WesternAsia.Kuwait;

        /// <summary>
        /// Gets the country of Lebanon.
        /// </summary>
        public static Country Lebanon => WesternAsia.Lebanon;

        /// <summary>
        /// Gets the country of Oman.
        /// </summary>
        public static Country Oman => WesternAsia.Oman;

        /// <summary>
        /// Gets Palestine.
        /// </summary>
        public static Country Palestine => WesternAsia.Palestine;

        /// <summary>
        /// Gets the country of Qatar.
        /// </summary>
        public static Country Qatar => WesternAsia.Qatar;

        /// <summary>
        /// Gets the country of Saudi Arabia.
        /// </summary>
        public static Country SaudiArabia => WesternAsia.SaudiArabia;

        /// <summary>
        /// Gets the country of Syria.
        /// </summary>
        public static Country Syria => WesternAsia.Syria;

        /// <summary>
        /// Gets the country of Turkey.
        /// </summary>
        public static Country Turkey => WesternAsia.Turkey;

        /// <summary>
        /// Gets the country of the United Arab Emirates.
        /// </summary>
        public static Country UnitedArabEmirates => WesternAsia.UnitedArabEmirates;

        /// <summary>
        /// Gets the country of Yemen.
        /// </summary>
        public static Country Yemen => WesternAsia.Yemen;

        #endregion Western Asia

        #endregion Asia

        #region Europe

        #region Central Europe

        /// <summary>
        /// Gets the country of Austria.
        /// </summary>
        public static Country Austria => CentralEurope.Austria;

        /// <summary>
        /// Gets the country of Czechia.
        /// </summary>
        public static Country Czechia => CentralEurope.Czechia;

        /// <summary>
        /// Gets the country of Germany.
        /// </summary>
        public static Country Germany => CentralEurope.Germany;

        /// <summary>
        /// Gets the country of Hungary.
        /// </summary>
        public static Country Hungary => CentralEurope.Hungary;

        /// <summary>
        /// Gets the country of Liechtenstein.
        /// </summary>
        public static Country Liechtenstein => CentralEurope.Liechtenstein;

        /// <summary>
        /// Gets the country of Poland.
        /// </summary>
        public static Country Poland => CentralEurope.Poland;

        /// <summary>
        /// Gets the country of Slovakia.
        /// </summary>
        public static Country Slovakia => CentralEurope.Slovakia;

        /// <summary>
        /// Gets the country of Slovenia.
        /// </summary>
        public static Country Slovenia => CentralEurope.Slovenia;

        /// <summary>
        /// Gets the country of Switzerland.
        /// </summary>
        public static Country Switzerland => CentralEurope.Switzerland;

        #endregion Central Europe

        #region Eastern Europe

        /// <summary>
        /// Gets the country of Belarus.
        /// </summary>
        public static Country Belarus => EasternEurope.Belarus;

        /// <summary>
        /// Gets the country of Bulgaria.
        /// </summary>
        public static Country Bulgaria => EasternEurope.Bulgaria;

        /// <summary>
        /// Gets the country of Moldova.
        /// </summary>
        public static Country Moldova => EasternEurope.Moldova;

        /// <summary>
        /// Gets the country of Romania.
        /// </summary>
        public static Country Romania => EasternEurope.Romania;

        /// <summary>
        /// Gets the country of Russia.
        /// </summary>
        public static Country Russia => EasternEurope.Russia;

        /// <summary>
        /// Gets the country of Ukraine.
        /// </summary>
        public static Country Ukraine => EasternEurope.Ukraine;

        #endregion Eastern Europe

        #region Northern Europe

        /// <summary>
        /// Gets the country of Denmark.
        /// </summary>
        public static Country Denmark => NorthernEurope.Denmark;

        /// <summary>
        /// Gets the country of Estonia.
        /// </summary>
        public static Country Estonia => NorthernEurope.Estonia;

        /// <summary>
        /// Gets the country of Finland.
        /// </summary>
        public static Country Finland => NorthernEurope.Finland;

        /// <summary>
        /// Gets the country of Iceland.
        /// </summary>
        public static Country Iceland => NorthernEurope.Iceland;

        /// <summary>
        /// Gets the country of Ireland.
        /// </summary>
        public static Country Ireland => NorthernEurope.Ireland;

        /// <summary>
        /// Gets the country of Latvia.
        /// </summary>
        public static Country Latvia => NorthernEurope.Latvia;

        /// <summary>
        /// Gets the country of Lithuania.
        /// </summary>
        public static Country Lithuania => NorthernEurope.Lithuania;

        /// <summary>
        /// Gets the country of Norway.
        /// </summary>
        public static Country Norway => NorthernEurope.Norway;

        /// <summary>
        /// Gets the country of Sweden.
        /// </summary>
        public static Country Sweden => NorthernEurope.Sweden;

        /// <summary>
        /// Gets the country of the United Kingdom.
        /// </summary>
        public static Country UnitedKingdom => NorthernEurope.UnitedKingdom;

        #endregion Northern Europe

        #region Southern Europe

        /// <summary>
        /// Gets the country of Albania.
        /// </summary>
        public static Country Albania => SouthernEurope.Albania;

        /// <summary>
        /// Gets the country of Andorra.
        /// </summary>
        public static Country Andorra => SouthernEurope.Andorra;

        /// <summary>
        /// Gets the country of Bosnia and Herzegovina.
        /// </summary>
        public static Country BosniaAndHerzegovina => SouthernEurope.BosniaAndHerzegovina;

        /// <summary>
        /// Gets the country of Croatia.
        /// </summary>
        public static Country Croatia => SouthernEurope.Croatia;

        /// <summary>
        /// Gets the country of Greece.
        /// </summary>
        public static Country Greece => SouthernEurope.Greece;

        /// <summary>
        /// Gets the country of Italy.
        /// </summary>
        public static Country Italy => SouthernEurope.Italy;

        /// <summary>
        /// Gets Kosovo.
        /// </summary>
        public static Country Kosovo => SouthernEurope.Kosovo;

        /// <summary>
        /// Gets the country of Malta.
        /// </summary>
        public static Country Malta => SouthernEurope.Malta;

        /// <summary>
        /// Gets the country of Montenegro.
        /// </summary>
        public static Country Montenegro => SouthernEurope.Montenegro;

        /// <summary>
        /// Gets the country of North Macedonia.
        /// </summary>
        public static Country NorthMacedonia => SouthernEurope.NorthMacedonia;

        /// <summary>
        /// Gets the country of Portugal.
        /// </summary>
        public static Country Portugal => SouthernEurope.Portugal;

        /// <summary>
        /// Gets the country of San Marino.
        /// </summary>
        public static Country SanMarino => SouthernEurope.SanMarino;

        /// <summary>
        /// Gets the country of Serbia.
        /// </summary>
        public static Country Serbia => SouthernEurope.Serbia;

        /// <summary>
        /// Gets the country of Spain.
        /// </summary>
        public static Country Spain => SouthernEurope.Spain;

        /// <summary>
        /// Gets Vatican City.
        /// </summary>
        public static Country VaticanCity => SouthernEurope.VaticanCity;

        #endregion Southern Europe

        #region Western Europe

        /// <summary>
        /// Gets the country of Belgium.
        /// </summary>
        public static Country Belgium => WesternEurope.Belgium;

        /// <summary>
        /// Gets the country of France.
        /// </summary>
        public static Country France => WesternEurope.France;

        /// <summary>
        /// Gets the country of Luxembourg.
        /// </summary>
        public static Country Luxembourg => WesternEurope.Luxembourg;

        /// <summary>
        /// Gets the country of Monaco.
        /// </summary>
        public static Country Monaco => WesternEurope.Monaco;

        /// <summary>
        /// Gets the country of the Netherlands.
        /// </summary>
        public static Country Netherlands => WesternEurope.Netherlands;

        #endregion Western Europe

        #endregion Europe

        #region North America

        #region Northern America

        /// <summary>
        /// Gets the territory of Bermuda.
        /// </summary>
        public static Country Bermuda => NorthernAmerica.Bermuda;

        /// <summary>
        /// Gets the country of Canada.
        /// </summary>
        public static Country Canada => NorthernAmerica.Canada;

        /// <summary>
        /// Gets the autonomous territory of Greenland.
        /// </summary>
        public static Country Greenland => NorthernAmerica.Greenland;

        /// <summary>
        /// Gets the French overseas collectivity of Saint Pierre and Miquelon.
        /// </summary>
        public static Country SaintPierreAndMiquelon => NorthernAmerica.SaintPierreAndMiquelon;

        /// <summary>
        /// Gets the country of the United States.
        /// </summary>
        public static Country UnitedStates => NorthernAmerica.UnitedStates;

        #endregion Northern America

        #region Central America

        /// <summary>
        /// Gets the country of Belize.
        /// </summary>
        public static Country Belize => CentralAmerica.Belize;

        /// <summary>
        /// Gets the country of Costa Rica.
        /// </summary>
        public static Country CostaRica => CentralAmerica.CostaRica;

        /// <summary>
        /// Gets the country of El Salvador.
        /// </summary>
        public static Country ElSalvador => CentralAmerica.ElSalvador;

        /// <summary>
        /// Gets the country of Guatemala.
        /// </summary>
        public static Country Guatemala => CentralAmerica.Guatemala;

        /// <summary>
        /// Gets the country of Honduras.
        /// </summary>
        public static Country Honduras => CentralAmerica.Honduras;

        /// <summary>
        /// Gets the country of Nicaragua.
        /// </summary>
        public static Country Nicaragua => CentralAmerica.Nicaragua;

        /// <summary>
        /// Gets the country of Panama.
        /// </summary>
        public static Country Panama => CentralAmerica.Panama;

        #endregion Central America

        #region Caribbean

        /// <summary>
        /// Gets the British Overseas Territory of Anguilla.
        /// </summary>
        public static Country Anguilla => Caribbean.Anguilla;

        /// <summary>
        /// Gets the country of Antigua and Barbuda.
        /// </summary>
        public static Country AntiguaAndBarbuda => Caribbean.AntiguaAndBarbuda;

        /// <summary>
        /// Gets the constituent country of the Kingdom of the Netherlands, Aruba.
        /// </summary>
        public static Country Aruba => Caribbean.Aruba;

        /// <summary>
        /// Gets the country of the Bahamas.
        /// </summary>
        public static Country Bahamas => Caribbean.Bahamas;

        /// <summary>
        /// Gets the country of Barbados.
        /// </summary>
        public static Country Barbados => Caribbean.Barbados;

        /// <summary>
        /// Gets the Caribbean islands of Bonaire, Sint Eustatius, and Saba, which are special municipalities of the Netherlands.
        /// </summary>
        public static Country BonaireSintEustatiusAndSaba => Caribbean.BonaireSintEustatiusAndSaba;

        /// <summary>
        /// Gets the British Overseas Territory of the British Virgin Islands.
        /// </summary>
        public static Country BritishVirginIslands => Caribbean.BritishVirginIslands;

        /// <summary>
        /// Gets the British Overseas Territory of the Cayman Islands.
        /// </summary>
        public static Country CaymanIslands => Caribbean.CaymanIslands;

        /// <summary>
        /// Gets the country of Cuba.
        /// </summary>
        public static Country Cuba => Caribbean.Cuba;

        /// <summary>
        /// Gets the constituent country of the Kingdom of the Netherlands, Curaçao.
        /// </summary>
        public static Country Curacao => Caribbean.Curacao;

        /// <summary>
        /// Gets the country of Dominica.
        /// </summary>
        public static Country Dominica => Caribbean.Dominica;

        /// <summary>
        /// Gets the country of the Dominican Republic.
        /// </summary>
        public static Country DominicanRepublic => Caribbean.DominicanRepublic;

        /// <summary>
        /// Gets the country of Grenada.
        /// </summary>
        public static Country Grenada => Caribbean.Grenada;

        /// <summary>
        /// Gets Guadeloupe, an overseas department and region of France.
        /// </summary>
        public static Country Guadeloupe => Caribbean.Guadeloupe;

        /// <summary>
        /// Gets the country of Haiti.
        /// </summary>
        public static Country Haiti => Caribbean.Haiti;

        /// <summary>
        /// Gets the country of Jamaica.
        /// </summary>
        public static Country Jamaica => Caribbean.Jamaica;

        /// <summary>
        /// Gets Martinique, an overseas department and region of France.
        /// </summary>
        public static Country Martinique => Caribbean.Martinique;

        /// <summary>
        /// Gets the British Overseas Territory of Montserrat.
        /// </summary>
        public static Country Montserrat => Caribbean.Montserrat;

        /// <summary>
        /// Gets the territory of Puerto Rico, an unincorporated territory of the United States.
        /// </summary>
        public static Country PuertoRico => Caribbean.PuertoRico;

        /// <summary>
        /// Gets the French overseas collectivity of Saint Barthélemy.
        /// </summary>
        public static Country SaintBarthelemy => Caribbean.SaintBarthelemy;

        /// <summary>
        /// Gets the country of Saint Kitts and Nevis.
        /// </summary>
        public static Country SaintKittsAndNevis => Caribbean.SaintKittsAndNevis;

        /// <summary>
        /// Gets the country of Saint Lucia.
        /// </summary>
        public static Country SaintLucia => Caribbean.SaintLucia;

        /// <summary>
        /// Gets the French overseas collectivity of Saint Martin.
        /// </summary>
        public static Country SaintMartin => Caribbean.SaintMartin;

        /// <summary>
        /// Gets the country of Saint Vincent and the Grenadines.
        /// </summary>
        public static Country SaintVincentAndTheGrenadines => Caribbean.SaintVincentAndTheGrenadines;

        /// <summary>
        /// Gets Sint Maarten, a constituent country of the Kingdom of the Netherlands.
        /// </summary>
        public static Country SintMaarten => Caribbean.SintMaarten;

        /// <summary>
        /// Gets the country of Trinidad and Tobago.
        /// </summary>
        public static Country TrinidadAndTobago => Caribbean.TrinidadAndTobago;

        /// <summary>
        /// Gets the British Overseas Territory of the Turks and Caicos Islands.
        /// </summary>
        public static Country TurksAndCaicosIslands => Caribbean.TurksAndCaicosIslands;

        /// <summary>
        /// Gets the United States Virgin Islands, an unincorporated territory of the United States.
        /// </summary>
        public static Country UnitedStatesVirginIslands => Caribbean.UnitedStatesVirginIslands;

        #endregion Caribbean

        #endregion North America

        #region South America

        #region South America

        /// <summary>
        /// Gets the country of Argentina.
        /// </summary>
        public static Country Argentina => SouthAmerica.Argentina;

        /// <summary>
        /// Gets the country of Bolivia.
        /// </summary>
        public static Country Bolivia => SouthAmerica.Bolivia;

        /// <summary>
        /// Gets the country of Brazil.
        /// </summary>
        public static Country Brazil => SouthAmerica.Brazil;

        /// <summary>
        /// Gets the country of Chile.
        /// </summary>
        public static Country Chile => SouthAmerica.Chile;

        /// <summary>
        /// Gets the country of Colombia.
        /// </summary>
        public static Country Colombia => SouthAmerica.Colombia;

        /// <summary>
        /// Gets the country of Ecuador.
        /// </summary>
        public static Country Ecuador => SouthAmerica.Ecuador;

        /// <summary>
        /// Gets the British Overseas Territory of the Falkland Islands.
        /// </summary>
        public static Country FalklandIslands => SouthAmerica.FalklandIslands;

        /// <summary>
        /// Gets French Guiana, an overseas department and region of France.
        /// </summary>
        public static Country FrenchGuiana => SouthAmerica.FrenchGuiana;

        /// <summary>
        /// Gets the country of Guyana.
        /// </summary>
        public static Country Guyana => SouthAmerica.Guyana;

        /// <summary>
        /// Gets the country of Paraguay.
        /// </summary>
        public static Country Paraguay => SouthAmerica.Paraguay;

        /// <summary>
        /// Gets the country of Peru.
        /// </summary>
        public static Country Peru => SouthAmerica.Peru;

        /// <summary>
        /// Gets the country of Suriname.
        /// </summary>
        public static Country Suriname => SouthAmerica.Suriname;

        /// <summary>
        /// Gets the country of Uruguay.
        /// </summary>
        public static Country Uruguay => SouthAmerica.Uruguay;

        /// <summary>
        /// Gets the country of Venezuela.
        /// </summary>
        public static Country Venezuela => SouthAmerica.Venezuela;

        #endregion South America

        #endregion South America

        #region Oceania

        #region Australia and New Zealand

        /// <summary>
        /// Gets the country of Australia.
        /// </summary>
        public static Country Australia => AustraliaAndNewZealand.Australia;

        /// <summary>
        /// Gets the external territory of Christmas Island, an Australian territory.
        /// </summary>
        public static Country ChristmasIsland => AustraliaAndNewZealand.ChristmasIsland;

        /// <summary>
        /// Gets the external territory of the Cocos (Keeling) Islands, an Australian territory.
        /// </summary>
        public static Country CocosIslands => AustraliaAndNewZealand.CocosIslands;

        /// <summary>
        /// Gets the external territory of Heard Island and McDonald Islands, an Australian territory.
        /// </summary>
        public static Country HeardIslandAndMcDonaldIslands => AustraliaAndNewZealand.HeardIslandAndMcDonaldIslands;

        /// <summary>
        /// Gets the country of New Zealand.
        /// </summary>
        public static Country NewZealand => AustraliaAndNewZealand.NewZealand;

        /// <summary>
        /// Gets the external territory of Norfolk Island, an Australian territory.
        /// </summary>
        public static Country NorfolkIsland => AustraliaAndNewZealand.NorfolkIsland;

        #endregion Australia and New Zealand

        #region Melanesia

        /// <summary>
        /// Gets the country of Fiji.
        /// </summary>
        public static Country Fiji => Melanesia.Fiji;

        /// <summary>
        /// Gets New Caledonia, a French overseas collectivity.
        /// </summary>
        public static Country NewCaledonia => Melanesia.NewCaledonia;

        /// <summary>
        /// Gets the country of Papua New Guinea.
        /// </summary>
        public static Country PapuaNewGuinea => Melanesia.PapuaNewGuinea;

        /// <summary>
        /// Gets the country of the Solomon Islands.
        /// </summary>
        public static Country SolomonIslands => Melanesia.SolomonIslands;

        /// <summary>
        /// Gets the country of Vanuatu.
        /// </summary>
        public static Country Vanuatu => Melanesia.Vanuatu;

        #endregion Melanesia

        #region Micronesia

        /// <summary>
        /// Gets the country of the Federated States of Micronesia.
        /// </summary>
        public static Country FederatedStatesOfMicronesia => Micronesia.FederatedStatesOfMicronesia;

        /// <summary>
        /// Gets Guam, an unincorporated territory of the United States.
        /// </summary>
        public static Country Guam => Micronesia.Guam;

        /// <summary>
        /// Gets the country of Kiribati.
        /// </summary>
        public static Country Kiribati => Micronesia.Kiribati;

        /// <summary>
        /// Gets the country of the Marshall Islands.
        /// </summary>
        public static Country MarshallIslands => Micronesia.MarshallIslands;

        /// <summary>
        /// Gets the country of Nauru.
        /// </summary>
        public static Country Nauru => Micronesia.Nauru;

        /// <summary>
        /// Gets the Northern Mariana Islands, a commonwealth in political union with the United States.
        /// </summary>
        public static Country NorthernMarianaIslands => Micronesia.NorthernMarianaIslands;

        /// <summary>
        /// Gets the country of Palau.
        /// </summary>
        public static Country Palau => Micronesia.Palau;

        #endregion Micronesia

        #region Polynesia

        /// <summary>
        /// Gets American Samoa, an unincorporated territory of the United States.
        /// </summary>
        public static Country AmericanSamoa => Polynesia.AmericanSamoa;

        /// <summary>
        /// Gets the self-governing Cook Islands, in free association with New Zealand.
        /// </summary>
        public static Country CookIslands => Polynesia.CookIslands;

        /// <summary>
        /// Gets French Polynesia, an overseas collectivity of France.
        /// </summary>
        public static Country FrenchPolynesia => Polynesia.FrenchPolynesia;

        /// <summary>
        /// Gets Niue, a self-governing state in free association with New Zealand.
        /// </summary>
        public static Country Niue => Polynesia.Niue;

        /// <summary>
        /// Gets the Pitcairn Islands, a British Overseas Territory.
        /// </summary>
        public static Country PitcairnIslands => Polynesia.PitcairnIslands;

        /// <summary>
        /// Gets the country of Samoa.
        /// </summary>
        public static Country Samoa => Polynesia.Samoa;

        /// <summary>
        /// Gets Tokelau, a dependent territory of New Zealand.
        /// </summary>
        public static Country Tokelau => Polynesia.Tokelau;

        /// <summary>
        /// Gets the country of Tonga.
        /// </summary>
        public static Country Tonga => Polynesia.Tonga;

        /// <summary>
        /// Gets the country of Tuvalu.
        /// </summary>
        public static Country Tuvalu => Polynesia.Tuvalu;

        /// <summary>
        /// Gets Wallis and Futuna, a French overseas collectivity.
        /// </summary>
        public static Country WallisAndFutuna => Polynesia.WallisAndFutuna;

        #endregion Polynesia

        #endregion Oceania

        #endregion Individual Countries
    }
}
