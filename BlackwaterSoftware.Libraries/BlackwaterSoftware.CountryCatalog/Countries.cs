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
        public static IReadOnlyList<Country> All { get; } = Array.AsReadOnly(_all);

        #region FrozenDictionary
        public static readonly FrozenDictionary<string, Country> ByIso2 = _all.ToFrozenDictionary(
            c => c.Iso2,
            StringComparer.OrdinalIgnoreCase);

        public static readonly FrozenDictionary<string, Country> ByIso3 = _all.ToFrozenDictionary(
            c => c.Iso3,
            StringComparer.OrdinalIgnoreCase);

        public static readonly FrozenDictionary<Continent, Country[]> ByContinent = _all
            .GroupBy(c => c.Continent)
            .ToFrozenDictionary(
                group => group.Key,
                group => group.OrderBy(c => c.Name)
            .ToArray());

        public static readonly FrozenDictionary<Region, Country[]> ByRegion = _all
            .GroupBy(c => c.Region)
            .ToFrozenDictionary(
                group => group.Key,
                group => group.OrderBy(c => c.Name)
            .ToArray());

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

        public static Country? FindByIso2(string iso2) => ByIso2.GetValueOrDefault(iso2);

        public static Country? FindByIso3(string iso3) => ByIso3.GetValueOrDefault(iso3);

        public static IReadOnlyList<Country> FindByContinent(Continent continent)
        {
            return ByContinent.TryGetValue(continent, out var countries)
                ? Array.AsReadOnly(countries)
                : Array.Empty<Country>();
        }

        public static IReadOnlyList<Country> FindByRegion(Region region)
        {
            return ByRegion.TryGetValue(region, out var countries)
                ? Array.AsReadOnly(countries)
                : Array.Empty<Country>();
        }

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
        public static Country Algeria => NorthernAfrica.Algeria;
        public static Country Egypt => NorthernAfrica.Egypt;
        public static Country Libya => NorthernAfrica.Libya;
        public static Country Morocco => NorthernAfrica.Morocco;
        public static Country Sudan => NorthernAfrica.Sudan;
        public static Country Tunisia => NorthernAfrica.Tunisia;
        public static Country WesternSahara => NorthernAfrica.WesternSahara;
        #endregion Northern Africa

        #region Western Africa
        public static Country Benin => WesternAfrica.Benin;
        public static Country BurkinaFaso => WesternAfrica.BurkinaFaso;
        public static Country CaboVerde => WesternAfrica.CaboVerde;
        public static Country CoteDIvoire => WesternAfrica.CoteDIvoire;
        public static Country TheGambia => WesternAfrica.TheGambia;
        public static Country Ghana => WesternAfrica.Ghana;
        public static Country Guinea => WesternAfrica.Guinea;
        public static Country GuineaBissau => WesternAfrica.GuineaBissau;
        public static Country Liberia => WesternAfrica.Liberia;
        public static Country Mali => WesternAfrica.Mali;
        public static Country Mauritania => WesternAfrica.Mauritania;
        public static Country Niger => WesternAfrica.Niger;
        public static Country Nigeria => WesternAfrica.Nigeria;
        public static Country Senegal => WesternAfrica.Senegal;
        public static Country SierraLeone => WesternAfrica.SierraLeone;
        public static Country Togo => WesternAfrica.Togo;
        #endregion Western Africa

        #region Middle Africa
        public static Country Angola => MiddleAfrica.Angola;
        public static Country Cameroon => MiddleAfrica.Cameroon;
        public static Country CentralAfricanRepublic => MiddleAfrica.CentralAfricanRepublic;
        public static Country Chad => MiddleAfrica.Chad;
        public static Country RepublicOfTheCongo => MiddleAfrica.RepublicOfTheCongo;
        public static Country DemocraticRepublicOfTheCongo => MiddleAfrica.DemocraticRepublicOfTheCongo;
        public static Country EquatorialGuinea => MiddleAfrica.EquatorialGuinea;
        public static Country Gabon => MiddleAfrica.Gabon;
        public static Country SaoTomeAndPrincipe => MiddleAfrica.SaoTomeAndPrincipe;
        #endregion Middle Africa

        #region Eastern Africa
        public static Country Burundi => EasternAfrica.Burundi;
        public static Country Comoros => EasternAfrica.Comoros;
        public static Country Djibouti => EasternAfrica.Djibouti;
        public static Country Eritrea => EasternAfrica.Eritrea;
        public static Country Ethiopia => EasternAfrica.Ethiopia;
        public static Country Kenya => EasternAfrica.Kenya;
        public static Country Madagascar => EasternAfrica.Madagascar;
        public static Country Malawi => EasternAfrica.Malawi;
        public static Country Mauritius => EasternAfrica.Mauritius;
        public static Country Mozambique => EasternAfrica.Mozambique;
        public static Country Rwanda => EasternAfrica.Rwanda;
        public static Country Seychelles => EasternAfrica.Seychelles;
        public static Country Somalia => EasternAfrica.Somalia;
        public static Country SouthSudan => EasternAfrica.SouthSudan;
        public static Country Tanzania => EasternAfrica.Tanzania;
        public static Country Uganda => EasternAfrica.Uganda;
        public static Country Zambia => EasternAfrica.Zambia;
        public static Country Zimbabwe => EasternAfrica.Zimbabwe;
        #endregion Eastern Africa

        #region Southern Africa
        public static Country Botswana => SouthernAfrica.Botswana;
        public static Country Eswatini => SouthernAfrica.Eswatini;
        public static Country Lesotho => SouthernAfrica.Lesotho;
        public static Country Namibia => SouthernAfrica.Namibia;
        public static Country SouthAfrica => SouthernAfrica.SouthAfrica;
        #endregion Southern Africa

        #endregion Africa

        #region Asia

        #region Central Asia
        public static Country Kazakhstan => CentralAsia.Kazakhstan;
        public static Country Kyrgyzstan => CentralAsia.Kyrgyzstan;
        public static Country Tajikistan => CentralAsia.Tajikistan;
        public static Country Turkmenistan => CentralAsia.Turkmenistan;
        public static Country Uzbekistan => CentralAsia.Uzbekistan;
        #endregion Central Asia

        #region Eastern Asia
        public static Country China => EasternAsia.China;
        public static Country Japan => EasternAsia.Japan;
        public static Country Mongolia => EasternAsia.Mongolia;
        public static Country NorthKorea => EasternAsia.NorthKorea;
        public static Country SouthKorea => EasternAsia.SouthKorea;
        public static Country Taiwan => EasternAsia.Taiwan;
        #endregion Eastern Asia

        #region South-Eastern Asia
        public static Country Brunei => SouthEasternAsia.Brunei;
        public static Country Cambodia => SouthEasternAsia.Cambodia;
        public static Country Indonesia => SouthEasternAsia.Indonesia;
        public static Country Laos => SouthEasternAsia.Laos;
        public static Country Malaysia => SouthEasternAsia.Malaysia;
        public static Country Myanmar => SouthEasternAsia.Myanmar;
        public static Country Philippines => SouthEasternAsia.Philippines;
        public static Country Singapore => SouthEasternAsia.Singapore;
        public static Country Thailand => SouthEasternAsia.Thailand;
        public static Country TimorLeste => SouthEasternAsia.TimorLeste;
        public static Country Vietnam => SouthEasternAsia.Vietnam;
        #endregion South-Eastern Asia

        #region Southern Asia
        public static Country Afghanistan => SouthernAsia.Afghanistan;
        public static Country Bangladesh => SouthernAsia.Bangladesh;
        public static Country Bhutan => SouthernAsia.Bhutan;
        public static Country India => SouthernAsia.India;
        public static Country Iran => SouthernAsia.Iran;
        public static Country Maldives => SouthernAsia.Maldives;
        public static Country Nepal => SouthernAsia.Nepal;
        public static Country Pakistan => SouthernAsia.Pakistan;
        public static Country SriLanka => SouthernAsia.SriLanka;
        #endregion Southern Asia

        #region Western Asia
        public static Country Armenia => WesternAsia.Armenia;
        public static Country Azerbaijan => WesternAsia.Azerbaijan;
        public static Country Bahrain => WesternAsia.Bahrain;
        public static Country Cyprus => WesternAsia.Cyprus;
        public static Country Georgia => WesternAsia.Georgia;
        public static Country Iraq => WesternAsia.Iraq;
        public static Country Israel => WesternAsia.Israel;
        public static Country Jordan => WesternAsia.Jordan;
        public static Country Kuwait => WesternAsia.Kuwait;
        public static Country Lebanon => WesternAsia.Lebanon;
        public static Country Oman => WesternAsia.Oman;
        public static Country Palestine => WesternAsia.Palestine;
        public static Country Qatar => WesternAsia.Qatar;
        public static Country SaudiArabia => WesternAsia.SaudiArabia;
        public static Country Syria => WesternAsia.Syria;
        public static Country Turkey => WesternAsia.Turkey;
        public static Country UnitedArabEmirates => WesternAsia.UnitedArabEmirates;
        public static Country Yemen => WesternAsia.Yemen;
        #endregion Western Asia

        #endregion Asia

        #region Europe

        #region Central Europe
        public static Country Austria => CentralEurope.Austria;
        public static Country Czechia => CentralEurope.Czechia;
        public static Country Germany => CentralEurope.Germany;
        public static Country Hungary => CentralEurope.Hungary;
        public static Country Liechtenstein => CentralEurope.Liechtenstein;
        public static Country Poland => CentralEurope.Poland;
        public static Country Slovakia => CentralEurope.Slovakia;
        public static Country Slovenia => CentralEurope.Slovenia;
        public static Country Switzerland => CentralEurope.Switzerland;
        #endregion Central Europe

        #region Eastern Europe
        public static Country Belarus => EasternEurope.Belarus;
        public static Country Bulgaria => EasternEurope.Bulgaria;
        public static Country Moldova => EasternEurope.Moldova;
        public static Country Romania => EasternEurope.Romania;
        public static Country Russia => EasternEurope.Russia;
        public static Country Ukraine => EasternEurope.Ukraine;
        #endregion Eastern Europe

        #region Northern Europe
        public static Country Denmark => NorthernEurope.Denmark;
        public static Country Estonia => NorthernEurope.Estonia;
        public static Country Finland => NorthernEurope.Finland;
        public static Country Iceland => NorthernEurope.Iceland;
        public static Country Ireland => NorthernEurope.Ireland;
        public static Country Latvia => NorthernEurope.Latvia;
        public static Country Lithuania => NorthernEurope.Lithuania;
        public static Country Norway => NorthernEurope.Norway;
        public static Country Sweden => NorthernEurope.Sweden;
        public static Country UnitedKingdom => NorthernEurope.UnitedKingdom;
        #endregion Northern Europe

        #region Southern Europe
        public static Country Albania => SouthernEurope.Albania;
        public static Country Andorra => SouthernEurope.Andorra;
        public static Country BosniaAndHerzegovina => SouthernEurope.BosniaAndHerzegovina;
        public static Country Croatia => SouthernEurope.Croatia;
        public static Country Greece => SouthernEurope.Greece;
        public static Country Italy => SouthernEurope.Italy;
        public static Country Kosovo => SouthernEurope.Kosovo;
        public static Country Malta => SouthernEurope.Malta;
        public static Country Montenegro => SouthernEurope.Montenegro;
        public static Country NorthMacedonia => SouthernEurope.NorthMacedonia;
        public static Country Portugal => SouthernEurope.Portugal;
        public static Country SanMarino => SouthernEurope.SanMarino;
        public static Country Serbia => SouthernEurope.Serbia;
        public static Country Spain => SouthernEurope.Spain;
        public static Country VaticanCity => SouthernEurope.VaticanCity;
        #endregion Southern Europe

        #region Western Europe
        public static Country Belgium => WesternEurope.Belgium;
        public static Country France => WesternEurope.France;
        public static Country Luxembourg => WesternEurope.Luxembourg;
        public static Country Monaco => WesternEurope.Monaco;
        public static Country Netherlands => WesternEurope.Netherlands;
        #endregion Western Europe

        #endregion Europe

        #region North America

        #region Northern America
        public static Country Bermuda => NorthernAmerica.Bermuda;
        public static Country Canada => NorthernAmerica.Canada;
        public static Country Greenland => NorthernAmerica.Greenland;
        public static Country SaintPierreAndMiquelon => NorthernAmerica.SaintPierreAndMiquelon;
        public static Country UnitedStates => NorthernAmerica.UnitedStates;
        #endregion Northern America

        #region Central America
        public static Country Belize => CentralAmerica.Belize;
        public static Country CostaRica => CentralAmerica.CostaRica;
        public static Country ElSalvador => CentralAmerica.ElSalvador;
        public static Country Guatemala => CentralAmerica.Guatemala;
        public static Country Honduras => CentralAmerica.Honduras;
        public static Country Nicaragua => CentralAmerica.Nicaragua;
        public static Country Panama => CentralAmerica.Panama;
        #endregion Central America

        #region Caribbean
        public static Country Anguilla => Caribbean.Anguilla;
        public static Country AntiguaAndBarbuda => Caribbean.AntiguaAndBarbuda;
        public static Country Aruba => Caribbean.Aruba;
        public static Country Bahamas => Caribbean.Bahamas;
        public static Country Barbados => Caribbean.Barbados;
        public static Country BonaireSintEustatiusAndSaba => Caribbean.BonaireSintEustatiusAndSaba;
        public static Country BritishVirginIslands => Caribbean.BritishVirginIslands;
        public static Country CaymanIslands => Caribbean.CaymanIslands;
        public static Country Cuba => Caribbean.Cuba;
        public static Country Curacao => Caribbean.Curacao;
        public static Country Dominica => Caribbean.Dominica;
        public static Country DominicanRepublic => Caribbean.DominicanRepublic;
        public static Country Grenada => Caribbean.Grenada;
        public static Country Guadeloupe => Caribbean.Guadeloupe;
        public static Country Haiti => Caribbean.Haiti;
        public static Country Jamaica => Caribbean.Jamaica;
        public static Country Martinique => Caribbean.Martinique;
        public static Country Montserrat => Caribbean.Montserrat;
        public static Country PuertoRico => Caribbean.PuertoRico;
        public static Country SaintBarthelemy => Caribbean.SaintBarthelemy;
        public static Country SaintKittsAndNevis => Caribbean.SaintKittsAndNevis;
        public static Country SaintLucia => Caribbean.SaintLucia;
        public static Country SaintMartin => Caribbean.SaintMartin;
        public static Country SaintVincentAndTheGrenadines => Caribbean.SaintVincentAndTheGrenadines;
        public static Country SintMaarten => Caribbean.SintMaarten;
        public static Country TrinidadAndTobago => Caribbean.TrinidadAndTobago;
        public static Country TurksAndCaicosIslands => Caribbean.TurksAndCaicosIslands;
        public static Country UnitedStatesVirginIslands => Caribbean.UnitedStatesVirginIslands;
        #endregion Caribbean

        #endregion North America

        #region South America

        #region South America
        public static Country Argentina => SouthAmerica.Argentina;
        public static Country Bolivia => SouthAmerica.Bolivia;
        public static Country Brazil => SouthAmerica.Brazil;
        public static Country Chile => SouthAmerica.Chile;
        public static Country Colombia => SouthAmerica.Colombia;
        public static Country Ecuador => SouthAmerica.Ecuador;
        public static Country FalklandIslands => SouthAmerica.FalklandIslands;
        public static Country FrenchGuiana => SouthAmerica.FrenchGuiana;
        public static Country Guyana => SouthAmerica.Guyana;
        public static Country Paraguay => SouthAmerica.Paraguay;
        public static Country Peru => SouthAmerica.Peru;
        public static Country Suriname => SouthAmerica.Suriname;
        public static Country Uruguay => SouthAmerica.Uruguay;
        public static Country Venezuela => SouthAmerica.Venezuela;
        #endregion South America

        #endregion South America

        #region Oceania

        #region Australia and New Zealand
        public static Country Australia => AustraliaAndNewZealand.Australia;
        public static Country ChristmasIsland => AustraliaAndNewZealand.ChristmasIsland;
        public static Country CocosIslands => AustraliaAndNewZealand.CocosIslands;
        public static Country HeardIslandAndMcDonaldIslands => AustraliaAndNewZealand.HeardIslandAndMcDonaldIslands;
        public static Country NewZealand => AustraliaAndNewZealand.NewZealand;
        public static Country NorfolkIsland => AustraliaAndNewZealand.NorfolkIsland;
        #endregion Australia and New Zealand

        #region Melanesia
        public static Country Fiji => Melanesia.Fiji;
        public static Country NewCaledonia => Melanesia.NewCaledonia;
        public static Country PapuaNewGuinea => Melanesia.PapuaNewGuinea;
        public static Country SolomonIslands => Melanesia.SolomonIslands;
        public static Country Vanuatu => Melanesia.Vanuatu;
        #endregion Melanesia

        #region Micronesia
        public static Country FederatedStatesOfMicronesia => Micronesia.FederatedStatesOfMicronesia;
        public static Country Guam => Micronesia.Guam;
        public static Country Kiribati => Micronesia.Kiribati;
        public static Country MarshallIslands => Micronesia.MarshallIslands;
        public static Country Nauru => Micronesia.Nauru;
        public static Country NorthernMarianaIslands => Micronesia.NorthernMarianaIslands;
        public static Country Palau => Micronesia.Palau;
        #endregion Micronesia

        #region Polynesia
        public static Country AmericanSamoa => Polynesia.AmericanSamoa;
        public static Country CookIslands => Polynesia.CookIslands;
        public static Country FrenchPolynesia => Polynesia.FrenchPolynesia;
        public static Country Niue => Polynesia.Niue;
        public static Country PitcairnIslands => Polynesia.PitcairnIslands;
        public static Country Samoa => Polynesia.Samoa;
        public static Country Tokelau => Polynesia.Tokelau;
        public static Country Tonga => Polynesia.Tonga;
        public static Country Tuvalu => Polynesia.Tuvalu;
        public static Country WallisAndFutuna => Polynesia.WallisAndFutuna;
        #endregion Polynesia

        #endregion Oceania

        #endregion Individual Countries

    }
}
