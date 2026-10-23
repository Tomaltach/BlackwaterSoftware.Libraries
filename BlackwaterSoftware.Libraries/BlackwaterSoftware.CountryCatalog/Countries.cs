using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;
using System.Collections.Frozen;

namespace BlackwaterSoftware.CountryCatalog
{
    public static class Countries
    {
        #region Africa
        public static readonly Country Algeria = new("Algeria", "+213", "DZ", "DZA",  Continent.Africa, Region.NorthernAfrica, "Dinar", "DZD");
        public static readonly Country Angola = new("Angola", "+244", "AO", "AGO",  Continent.Africa, Region.MiddleAfrica, "Kwanza", "AOA");
        public static readonly Country Benin = new("Benin", "+229", "BJ", "BEN",  Continent.Africa, Region.WesternAfrica, "Franc", "XOF");
        public static readonly Country Botswana = new("Botswana", "+267", "BW", "BWA",  Continent.Africa, Region.SouthernAfrica, "Pula", "BWP");
        public static readonly Country BurkinaFaso = new("Burkina Faso", "+226", "BF", "BFA",  Continent.Africa, Region.WesternAfrica, "Franc", "XOF");
        public static readonly Country Burundi = new("Burundi", "+257", "BI", "BDI",  Continent.Africa, Region.EasternAfrica, "Franc", "BIF");
        public static readonly Country Cameroon = new("Cameroon", "+237", "CM", "CMR",  Continent.Africa, Region.MiddleAfrica, "Franc", "XAF");
        public static readonly Country CapeVerde = new("Cape Verde", "+238", "CV", "CPV",  Continent.Africa, Region.WesternAfrica, "Escudo", "CVE");
        public static readonly Country CentralAfricanRepublic = new("Central African Republic", "+236", "CF", "CAF",  Continent.Africa, Region.MiddleAfrica, "Franc", "XAF");
        public static readonly Country Chad = new("Chad", "+235", "TD", "TCD",  Continent.Africa, Region.MiddleAfrica, "Franc", "XAF");
        public static readonly Country Comoros = new("Comoros", "+269", "KM", "COM",  Continent.Africa, Region.EasternAfrica, "Franc", "KMF");
        public static readonly Country RepublicOfTheCongo = new("Republic of the Congo", "+242", "CG", "COG",  Continent.Africa, Region.MiddleAfrica, "Franc", "XAF");
        public static readonly Country DemocraticRepublicOfTheCongo = new("Democratic Republic of the Congo", "+243", "CD", "COD",  Continent.Africa, Region.MiddleAfrica, "Franc", "CDF");
        public static readonly Country CoteDIvoire = new("Côte d'Ivoire", "+225", "CI", "CIV",  Continent.Africa, Region.WesternAfrica, "Franc", "XOF");
        public static readonly Country Djibouti = new("Djibouti", "+253", "DJ", "DJI",  Continent.Africa, Region.EasternAfrica, "Franc", "DJF");
        public static readonly Country Egypt = new("Egypt", "+20", "EG", "EGY",  Continent.Africa, Region.NorthernAfrica, "Pound", "EGP");
        public static readonly Country EquatorialGuinea = new("Equatorial Guinea", "+240", "GQ", "GNQ",  Continent.Africa, Region.MiddleAfrica, "Franc", "XAF");
        public static readonly Country Eritrea = new("Eritrea", "+291", "ER", "ERI",  Continent.Africa, Region.EasternAfrica, "Nakfa", "ERN");
        public static readonly Country Ethiopia = new("Ethiopia", "+251", "ET", "ETH",  Continent.Africa, Region.EasternAfrica, "Birr", "ETB");
        public static readonly Country Gabon = new("Gabon", "+241", "GA", "GAB",  Continent.Africa, Region.MiddleAfrica, "Franc", "XAF");
        public static readonly Country TheGambia = new("The Gambia", "+220", "GM", "GMB",  Continent.Africa, Region.WesternAfrica, "Dalasi", "GMD");
        public static readonly Country Ghana = new("Ghana", "+233", "GH", "GHA",  Continent.Africa, Region.WesternAfrica, "Cedi", "GHS");
        public static readonly Country Guinea = new("Guinea", "+224", "GN", "GIN",  Continent.Africa, Region.WesternAfrica, "Franc", "GNF");
        public static readonly Country GuineaBissau = new("Guinea-Bissau", "+245", "GW", "GNB",  Continent.Africa, Region.WesternAfrica, "Franc", "XOF");
        public static readonly Country Kenya = new("Kenya", "+254", "KE", "KEN",  Continent.Africa, Region.EasternAfrica, "Shilling", "KES");
        public static readonly Country Lesotho = new("Lesotho", "+266", "LS", "LSO",  Continent.Africa, Region.SouthernAfrica, "Loti", "LSL");
        public static readonly Country Liberia = new("Liberia", "+231", "LR", "LBR",  Continent.Africa, Region.WesternAfrica, "Dollar", "LRD");
        public static readonly Country Libya = new("Libya", "+218", "LY", "LBY",  Continent.Africa, Region.NorthernAfrica, "Dinar", "LYD");
        public static readonly Country Madagascar = new("Madagascar", "+261", "MG", "MDG",  Continent.Africa, Region.EasternAfrica, "Ariary", "MGA");
        public static readonly Country Malawi = new("Malawi", "+265", "MW", "MWI",  Continent.Africa, Region.EasternAfrica, "Kwacha", "MWK");
        public static readonly Country Mali = new("Mali", "+223", "ML", "MLI",  Continent.Africa, Region.WesternAfrica, "Franc", "XOF");
        public static readonly Country Mauritania = new("Mauritania", "+222", "MR", "MRT",  Continent.Africa, Region.WesternAfrica, "Ouguiya", "MRU");
        public static readonly Country Mauritius = new("Mauritius", "+230", "MU", "MUS",  Continent.Africa, Region.EasternAfrica, "Rupee", "MUR");
        public static readonly Country Morocco = new("Morocco", "+212", "MA", "MAR",  Continent.Africa, Region.NorthernAfrica, "Dirham", "MAD");
        public static readonly Country Mozambique = new("Mozambique", "+258", "MZ", "MOZ",  Continent.Africa, Region.EasternAfrica, "Metical", "MZN");
        public static readonly Country Namibia = new("Namibia", "+264", "NA", "NAM",  Continent.Africa, Region.SouthernAfrica, "Dollar", "NAD");
        public static readonly Country Niger = new("Niger", "+227", "NE", "NER",  Continent.Africa, Region.WesternAfrica, "Franc", "XOF");
        public static readonly Country Nigeria = new("Nigeria", "+234", "NG", "NGA",  Continent.Africa, Region.WesternAfrica, "Naira", "NGN");
        public static readonly Country Rwanda = new("Rwanda", "+250", "RW", "RWA",  Continent.Africa, Region.EasternAfrica, "Franc", "RWF");
        public static readonly Country SaoTomeAndPrincipe = new("São Tomé and Príncipe", "+239", "ST", "STP",  Continent.Africa, Region.MiddleAfrica, "Dobra", "STN");
        public static readonly Country Senegal = new("Senegal", "+221", "SN", "SEN",  Continent.Africa, Region.WesternAfrica, "Franc", "XOF");
        public static readonly Country Seychelles = new("Seychelles", "+248", "SC", "SYC",  Continent.Africa, Region.EasternAfrica, "Rupee", "SCR");
        public static readonly Country SierraLeone = new("Sierra Leone", "+232", "SL", "SLE",  Continent.Africa, Region.WesternAfrica, "Leone", "SLE");
        public static readonly Country Somalia = new("Somalia", "+252", "SO", "SOM",  Continent.Africa, Region.EasternAfrica, "Shilling", "SOS");
        public static readonly Country SouthAfrica = new("South Africa", "+27", "ZA", "ZAF",  Continent.Africa, Region.SouthernAfrica, "Rand", "ZAR");
        public static readonly Country SouthSudan = new("South Sudan", "+211", "SS", "SSD",  Continent.Africa, Region.EasternAfrica, "Pound", "SSP");
        public static readonly Country Sudan = new("Sudan", "+249", "SD", "SDN",  Continent.Africa, Region.NorthernAfrica, "Pound", "SDG");
        public static readonly Country Swaziland = new("Swaziland", "+268", "SZ", "SWZ",  Continent.Africa, Region.SouthernAfrica, "Lilangeni", "SZL");
        public static readonly Country Tanzania = new("Tanzania", "+255", "TZ", "TZA",  Continent.Africa, Region.EasternAfrica, "Shilling", "TZS");
        public static readonly Country Togo = new("Togo", "+228", "TG", "TGO",  Continent.Africa, Region.WesternAfrica, "Franc", "XOF");
        public static readonly Country Tunisia = new("Tunisia", "+216", "TN", "TUN",  Continent.Africa, Region.NorthernAfrica, "Dinar", "TND");
        public static readonly Country Uganda = new("Uganda", "+256", "UG", "UGA",  Continent.Africa, Region.EasternAfrica, "Shilling", "UGX");
        public static readonly Country WesternSahara = new("Western Sahara", "+212", "EH", "ESH",  Continent.Africa, Region.NorthernAfrica, "Dirham", "MAD");
        public static readonly Country Zambia = new("Zambia", "+260", "ZM", "ZMB",  Continent.Africa, Region.EasternAfrica, "Kwacha", "ZMW");
        public static readonly Country Zimbabwe = new("Zimbabwe", "+263", "ZW", "ZWE",  Continent.Africa, Region.EasternAfrica, "Dollar", "ZWL");
        #endregion Africa
        #region Asia
        public static readonly Country Afghanistan = new("Afghanistan", "+93", "AF", "AFG",  Continent.Asia, Region.SouthernAsia, "Afghani", "AFN");
        public static readonly Country Armenia = new("Armenia", "+374", "AM", "ARM",  Continent.Asia, Region.WesternAsia, "Dram", "AMD");
        public static readonly Country Azerbaijan = new("Azerbaijan", "+994", "AZ", "AZE",  Continent.Asia, Region.WesternAsia, "Manat", "AZN");
        public static readonly Country Bahrain = new("Bahrain", "+973", "BH", "BHR",  Continent.Asia, Region.WesternAsia, "Dinar", "BHD");
        public static readonly Country Bangladesh = new("Bangladesh", "+880", "BD", "BGD",  Continent.Asia, Region.SouthernAsia, "Taka", "BDT");
        public static readonly Country Bhutan = new("Bhutan", "+975", "BT", "BTN",  Continent.Asia, Region.SouthernAsia, "Ngultrum", "BTN");
        public static readonly Country Brunei = new("Brunei", "+673", "BN", "BRN",  Continent.Asia, Region.SouthEasternAsia, "Dollar", "BND");
        public static readonly Country Cambodia = new("Cambodia", "+855", "KH", "KHM",  Continent.Asia, Region.SouthEasternAsia, "Riels", "KHR");
        public static readonly Country China = new("China", "+86", "CN", "CHN",  Continent.Asia, Region.EasternAsia, "Yuan Renminbi", "CNY");
        public static readonly Country Cyprus = new("Cyprus", "+357", "CY", "CYP", Continent.Asia, Region.WesternAsia, "Euro", "EUR");
        public static readonly Country EastTimor = new("East Timor", "+670", "TL", "TLS",  Continent.Asia, Region.SouthEasternAsia, "Dollar", "USD");
        public static readonly Country Georgia = new("Georgia", "+995", "GE", "GEO",  Continent.Asia, Region.WesternAsia, "Lari", "GEL");
        public static readonly Country India = new("India", "+91", "IN", "IND",  Continent.Asia, Region.SouthernAsia, "Rupee", "INR");
        public static readonly Country Indonesia = new("Indonesia", "+62", "ID", "IDN",  Continent.Asia, Region.SouthEasternAsia, "Rupiah", "IDR");
        public static readonly Country Iran = new("Iran", "+98", "IR", "IRN",  Continent.Asia, Region.SouthernAsia, "Rial", "IRR");
        public static readonly Country Iraq = new("Iraq", "+964", "IQ", "IRQ",  Continent.Asia, Region.WesternAsia, "Dinar", "IQD");
        public static readonly Country Israel = new("Israel", "+972", "IL", "ISR",  Continent.Asia, Region.WesternAsia, "Shekel", "ILS");
        public static readonly Country Japan = new("Japan", "+81", "JP", "JPN",  Continent.Asia, Region.EasternAsia, "Yen", "JPY");
        public static readonly Country Jordan = new("Jordan", "+962", "JO", "JOR",  Continent.Asia, Region.WesternAsia, "Dinar", "JOD");
        public static readonly Country Kazakhstan = new("Kazakhstan", "+7", "KZ", "KAZ",  Continent.Asia, Region.CentralAsia, "Tenge", "KZT");
        public static readonly Country Kuwait = new("Kuwait", "+965", "KW", "KWT",  Continent.Asia, Region.WesternAsia, "Dinar", "KWD");
        public static readonly Country Kyrgyzstan = new("Kyrgyzstan", "+996", "KG", "KGZ",  Continent.Asia, Region.CentralAsia, "Som", "KGS");
        public static readonly Country Laos = new("Laos", "+856", "LA", "LAO",  Continent.Asia, Region.SouthEasternAsia, "Kip", "LAK");
        public static readonly Country Lebanon = new("Lebanon", "+961", "LB", "LBN",  Continent.Asia, Region.WesternAsia, "Pound", "LBP");
        public static readonly Country Malaysia = new("Malaysia", "+60", "MY", "MYS",  Continent.Asia, Region.SouthEasternAsia, "Ringgit", "MYR");
        public static readonly Country Maldives = new("Maldives", "+960", "MV", "MDV",  Continent.Asia, Region.SouthernAsia, "Rufiyaa", "MVR");
        public static readonly Country Mongolia = new("Mongolia", "+976", "MN", "MNG",  Continent.Asia, Region.EasternAsia, "Tugrik", "MNT");
        public static readonly Country Myanmar = new("Myanmar", "+95", "MM", "MMR",  Continent.Asia, Region.SouthEasternAsia, "Kyat", "MMK");
        public static readonly Country Nepal = new("Nepal", "+977", "NP", "NPL",  Continent.Asia, Region.SouthernAsia, "Rupee", "NPR");
        public static readonly Country NorthKorea = new("North Korea", "+850", "KP", "PRK",  Continent.Asia, Region.EasternAsia, "Won", "KPW");
        public static readonly Country Oman = new("Oman", "+968", "OM", "OMN",  Continent.Asia, Region.WesternAsia, "Rial", "OMR");
        public static readonly Country Pakistan = new("Pakistan", "+92", "PK", "PAK",  Continent.Asia, Region.SouthernAsia, "Rupee", "PKR");
        public static readonly Country Philippines = new("Philippines", "+63", "PH", "PHL",  Continent.Asia, Region.SouthEasternAsia, "Peso", "PHP");
        public static readonly Country Palestine = new("Palestine", "+970", "PS", "PSE",  Continent.Asia, Region.WesternAsia, "Shekel", "ILS");
        public static readonly Country Qatar = new("Qatar", "+974", "QA", "QAT",  Continent.Asia, Region.WesternAsia, "Rial", "QAR");
        public static readonly Country SaudiArabia = new("Saudi Arabia", "+966", "SA", "SAU",  Continent.Asia, Region.WesternAsia, "Rial", "SAR");
        public static readonly Country Singapore = new("Singapore", "+65", "SG", "SGP",  Continent.Asia, Region.SouthEasternAsia, "Dollar", "SGD");
        public static readonly Country SouthKorea = new("South Korea", "+82", "KR", "KOR",  Continent.Asia, Region.EasternAsia, "Won", "KRW");
        public static readonly Country SriLanka = new("Sri Lanka", "+94", "LK", "LKA",  Continent.Asia, Region.SouthernAsia, "Rupee", "LKR");
        public static readonly Country Syria = new("Syria", "+963", "SY", "SYR",  Continent.Asia, Region.WesternAsia, "Pound", "SYP");
        public static readonly Country Taiwan = new("Taiwan", "+886", "TW", "TWN", Continent.Asia, Region.EasternAsia, "Dollar", "TWD");
        public static readonly Country Tajikistan = new("Tajikistan", "+992", "TJ", "TJK",  Continent.Asia, Region.CentralAsia, "Somoni", "TJS");
        public static readonly Country Thailand = new("Thailand", "+66", "TH", "THA",  Continent.Asia, Region.SouthEasternAsia, "Baht", "THB");
        public static readonly Country Turkey = new("Turkey", "+90", "TR", "TUR",  Continent.Asia, Region.WesternAsia, "Lira", "TRY");
        public static readonly Country Turkmenistan = new("Turkmenistan", "+993", "TM", "TKM",  Continent.Asia, Region.CentralAsia, "Manat", "TMT");
        public static readonly Country UnitedArabEmirates = new("United Arab Emirates", "+971", "AE", "ARE",  Continent.Asia, Region.WesternAsia, "Dirham", "AED");
        public static readonly Country Uzbekistan = new("Uzbekistan", "+998", "UZ", "UZB",  Continent.Asia, Region.CentralAsia, "Som", "UZS");
        public static readonly Country Vietnam = new("Vietnam", "+84", "VN", "VNM",  Continent.Asia, Region.SouthEasternAsia, "Dong", "VND");
        public static readonly Country Yemen = new("Yemen", "+967", "YE", "YEM",  Continent.Asia, Region.WesternAsia, "Rial", "YER");
        #endregion Asia
        #region Europe
        public static readonly Country Albania = new("Albania", "+355", "AL", "ALB",  Continent.Europe, Region.SouthernEurope, "Lek", "ALL");
        public static readonly Country Andorra = new("Andorra", "+376", "AD", "AND",  Continent.Europe, Region.SouthernEurope, "Euro", "EUR");
        public static readonly Country Austria = new("Austria", "+43", "AT", "AUT",  Continent.Europe, Region.WesternEurope, "Euro", "EUR");
        public static readonly Country Belarus = new("Belarus", "+375", "BY", "BLR",  Continent.Europe, Region.EasternEurope, "Ruble", "BYN");
        public static readonly Country Belgium = new("Belgium", "+32", "BE", "BEL",  Continent.Europe, Region.WesternEurope, "Euro", "EUR");
        public static readonly Country BosniaAndHerzegovina = new("Bosnia and Herzegovina", "+387", "BA", "BIH",  Continent.Europe, Region.SouthernEurope, "Marka", "BAM");
        public static readonly Country Bulgaria = new("Bulgaria", "+359", "BG", "BGR",  Continent.Europe, Region.EasternEurope, "Lev", "BGN");
        public static readonly Country Croatia = new("Croatia", "+385", "HR", "HRV",  Continent.Europe, Region.SouthernEurope, "Euro", "EUR");
        public static readonly Country CzechRepublic = new("Czech Republic", "+420", "CZ", "CZE",  Continent.Europe, Region.EasternEurope, "Koruna", "CZK");
        public static readonly Country Denmark = new("Denmark", "+45", "DK", "DNK",  Continent.Europe, Region.NorthernEurope, "Krone", "DKK");
        public static readonly Country Estonia = new("Estonia", "+372", "EE", "EST",  Continent.Europe, Region.NorthernEurope, "Euro", "EUR");
        public static readonly Country Finland = new("Finland", "+358", "FI", "FIN",  Continent.Europe, Region.NorthernEurope, "Euro", "EUR");
        public static readonly Country France = new("France", "+33", "FR", "FRA",  Continent.Europe, Region.WesternEurope, "Euro", "EUR");
        public static readonly Country Germany = new("Germany", "+49", "DE", "DEU",  Continent.Europe, Region.WesternEurope, "Euro", "EUR");
        public static readonly Country Greece = new("Greece", "+30", "GR", "GRC",  Continent.Europe, Region.SouthernEurope, "Euro", "EUR");
        public static readonly Country Hungary = new("Hungary", "+36", "HU", "HUN",  Continent.Europe, Region.EasternEurope, "Forint", "HUF");
        public static readonly Country Iceland = new("Iceland", "+354", "IS", "ISL",  Continent.Europe, Region.NorthernEurope, "Krona", "ISK");
        public static readonly Country Ireland = new("Ireland", "+353", "IE", "IRL",  Continent.Europe, Region.NorthernEurope, "Euro", "EUR", CountryWeight.Top);
        public static readonly Country Italy = new("Italy", "+39", "IT", "ITA",  Continent.Europe, Region.SouthernEurope, "Euro", "EUR");
        public static readonly Country Kosovo = new("Kosovo", "+383", "XK", "XKX",  Continent.Europe, Region.SouthernEurope, "Euro", "EUR");
        public static readonly Country Latvia = new("Latvia", "+371", "LV", "LVA",  Continent.Europe, Region.NorthernEurope, "Euro", "EUR");
        public static readonly Country Liechtenstein = new("Liechtenstein", "+423", "LI", "LIE",  Continent.Europe, Region.WesternEurope, "Franc", "CHF");
        public static readonly Country Lithuania = new("Lithuania", "+370", "LT", "LTU",  Continent.Europe, Region.NorthernEurope, "Euro", "EUR");
        public static readonly Country Luxembourg = new("Luxembourg", "+352", "LU", "LUX",  Continent.Europe, Region.WesternEurope, "Euro", "EUR");
        public static readonly Country Macedonia = new("Macedonia", "+389", "MK", "MKD",  Continent.Europe, Region.SouthernEurope, "Denar", "MKD");
        public static readonly Country Malta = new("Malta", "+356", "MT", "MLT",  Continent.Europe, Region.SouthernEurope, "Euro", "EUR");
        public static readonly Country Moldova = new("Moldova", "+373", "MD", "MDA",  Continent.Europe, Region.EasternEurope, "Leu", "MDL");
        public static readonly Country Monaco = new("Monaco", "+377", "MC", "MCO",  Continent.Europe, Region.WesternEurope, "Euro", "EUR");
        public static readonly Country Montenegro = new("Montenegro", "+382", "ME", "MNE",  Continent.Europe, Region.SouthernEurope, "Euro", "EUR");
        public static readonly Country Netherlands = new("Netherlands", "+31", "NL", "NLD",  Continent.Europe, Region.WesternEurope, "Euro", "EUR");
        public static readonly Country Norway = new("Norway", "+47", "NO", "NOR",  Continent.Europe, Region.NorthernEurope, "Krone", "NOK");
        public static readonly Country Poland = new("Poland", "+48", "PL", "POL",  Continent.Europe, Region.EasternEurope, "Zloty", "PLN");
        public static readonly Country Portugal = new("Portugal", "+351", "PT", "PRT",  Continent.Europe, Region.SouthernEurope, "Euro", "EUR");
        public static readonly Country Romania = new("Romania", "+40", "RO", "ROU",  Continent.Europe, Region.EasternEurope, "Leu", "RON");
        public static readonly Country Russia = new("Russia", "+7", "RU", "RUS", Continent.Europe, Region.EasternEurope, "Ruble", "RUB");
        public static readonly Country SanMarino = new("San Marino", "+378", "SM", "SMR",  Continent.Europe, Region.SouthernEurope, "Euro", "EUR");
        public static readonly Country Serbia = new("Serbia", "+381", "RS", "SRB",  Continent.Europe, Region.SouthernEurope, "Dinar", "RSD");
        public static readonly Country Slovakia = new("Slovakia", "+421", "SK", "SVK",  Continent.Europe, Region.EasternEurope, "Euro", "EUR");
        public static readonly Country Slovenia = new("Slovenia", "+386", "SI", "SVN",  Continent.Europe, Region.SouthernEurope, "Euro", "EUR");
        public static readonly Country Spain = new("Spain", "+34", "ES", "ESP",  Continent.Europe, Region.SouthernEurope, "Euro", "EUR");
        public static readonly Country Sweden = new("Sweden", "+46", "SE", "SWE",  Continent.Europe, Region.NorthernEurope, "Krona", "SEK");
        public static readonly Country Switzerland = new("Switzerland", "+41", "CH", "CHE",  Continent.Europe, Region.WesternEurope, "Franc", "CHF");
        public static readonly Country Ukraine = new("Ukraine", "+380", "UA", "UKR",  Continent.Europe, Region.EasternEurope, "Hryvnia", "UAH");
        public static readonly Country UnitedKingdom = new("United Kingdom", "+44", "GB", "GBR",  Continent.Europe, Region.NorthernEurope, "Pound", "GBP", CountryWeight.Top);
        public static readonly Country VaticanCity = new("Vatican City", "+379", "VA", "VAT",  Continent.Europe, Region.SouthernEurope, "Euro", "EUR");
        #endregion Europe
        #region North America
        public static readonly Country Canada = new("Canada", "+1", "CA", "CAN",  Continent.NorthAmerica, Region.NorthernAmerica, "Dollar", "CAD", CountryWeight.Middle);
        public static readonly Country Greenland = new("Greenland", "+299", "GL", "GRL",  Continent.NorthAmerica, Region.NorthernAmerica, "Krone", "DKK");
        public static readonly Country UnitedStates = new("United States", "+1", "US", "USA",  Continent.NorthAmerica, Region.NorthernAmerica, "Dollar", "USD", CountryWeight.Top);
        public static readonly Country AntiguaAndBarbuda = new("Antigua and Barbuda", "+1268", "AG", "ATG",  Continent.NorthAmerica, Region.Caribbean, "Dollar", "XCD");
        public static readonly Country TheBahamas = new("The Bahamas", "+1242", "BS", "BHS",  Continent.NorthAmerica, Region.Caribbean, "Dollar", "BSD");
        public static readonly Country Barbados = new("Barbados", "+1246", "BB", "BRB",  Continent.NorthAmerica, Region.Caribbean, "Dollar", "BBD");
        public static readonly Country Belize = new("Belize", "+501", "BZ", "BLZ",  Continent.NorthAmerica, Region.CentralAmerica, "Dollar", "BZD");
        public static readonly Country CostaRica = new("Costa Rica", "+506", "CR", "CRI",  Continent.NorthAmerica, Region.CentralAmerica, "Colon", "CRC");
        public static readonly Country Cuba = new("Cuba", "+53", "CU", "CUB",  Continent.NorthAmerica, Region.Caribbean, "Peso", "CUP");
        public static readonly Country Curacao = new("Curacao", "+599", "CW", "CUW",  Continent.NorthAmerica, Region.Caribbean, "Guilder", "XCG");
        public static readonly Country Dominica = new("Dominica", "+1767", "DM", "DMA",  Continent.NorthAmerica, Region.Caribbean, "Dollar", "XCD");
        public static readonly Country DominicanRepublic = new("Dominican Republic", "+1809,001829,001849", "DO", "DOM",  Continent.NorthAmerica, Region.Caribbean, "Peso", "DOP");
        public static readonly Country ElSalvador = new("El Salvador", "+503", "SV", "SLV",  Continent.NorthAmerica, Region.CentralAmerica, "Dollar", "USD");
        public static readonly Country Grenada = new("Grenada", "+1473", "GD", "GRD",  Continent.NorthAmerica, Region.Caribbean, "Dollar", "XCD");
        public static readonly Country Guatemala = new("Guatemala", "+502", "GT", "GTM",  Continent.NorthAmerica, Region.CentralAmerica, "Quetzal", "GTQ");
        public static readonly Country Haiti = new("Haiti", "+509", "HT", "HTI",  Continent.NorthAmerica, Region.Caribbean, "Gourde", "HTG");
        public static readonly Country Honduras = new("Honduras", "+504", "HN", "HND",  Continent.NorthAmerica, Region.CentralAmerica, "Lempira", "HNL");
        public static readonly Country Jamaica = new("Jamaica", "+1876", "JM", "JAM",  Continent.NorthAmerica, Region.Caribbean, "Dollar", "JMD");
        public static readonly Country Mexico = new("Mexico", "+52", "MX", "MEX", Continent.NorthAmerica, Region.CentralAmerica, "Peso", "MXN");
        public static readonly Country Nicaragua = new("Nicaragua", "+505", "NI", "NIC",  Continent.NorthAmerica, Region.CentralAmerica, "Cordoba", "NIO");
        public static readonly Country Panama = new("Panama", "+507", "PA", "PAN",  Continent.NorthAmerica, Region.CentralAmerica, "Balboa", "PAB");
        public static readonly Country PuertoRico = new("Puerto Rico", "+1", "PR", "PRI",  Continent.NorthAmerica, Region.Caribbean, "Dollar", "USD");
        public static readonly Country SaintKittsAndNevis = new("Saint Kitts and Nevis", "+1869", "KN", "KNA",  Continent.NorthAmerica, Region.Caribbean, "Dollar", "XCD");
        public static readonly Country SaintLucia = new("Saint Lucia", "+1758", "LC", "LCA",  Continent.NorthAmerica, Region.Caribbean, "Dollar", "XCD");
        public static readonly Country SaintVincentAndTheGrenadines = new("Saint Vincent and the Grenadines", "+1784", "VC", "VCT",  Continent.NorthAmerica, Region.Caribbean, "Dollar", "XCD");
        public static readonly Country TrinidadAndTobago = new("Trinidad and Tobago", "+1868", "TT", "TTO",  Continent.NorthAmerica, Region.Caribbean, "Dollar", "TTD");
        public static readonly Country TurksAndCaicos = new("Turks and Caicos", "+1649", "TC", "TCA",  Continent.NorthAmerica, Region.Caribbean, "Dollar", "USD");
        #endregion North America
        #region South America
        public static readonly Country Argentina = new("Argentina", "+54", "AR", "ARG",  Continent.SouthAmerica, Region.SouthAmerica, "Peso", "ARS");
        public static readonly Country Bolivia = new("Bolivia", "+591", "BO", "BOL",  Continent.SouthAmerica, Region.SouthAmerica, "Boliviano", "BOB");
        public static readonly Country Brazil = new("Brazil", "+55", "BR", "BRA",  Continent.SouthAmerica, Region.SouthAmerica, "Real", "BRL");
        public static readonly Country Chile = new("Chile", "+56", "CL", "CHL",  Continent.SouthAmerica, Region.SouthAmerica, "Peso", "CLP");
        public static readonly Country Colombia = new("Colombia", "+57", "CO", "COL",  Continent.SouthAmerica, Region.SouthAmerica, "Peso", "COP");
        public static readonly Country Ecuador = new("Ecuador", "+593", "EC", "ECU",  Continent.SouthAmerica, Region.SouthAmerica, "Dollar", "USD");
        //public static readonly Country FrenchGuiana = new("French Guiana", "+", "", "",  Continent.SouthAmerica, Region.SouthAmerica, "");
        public static readonly Country Guyana = new("Guyana", "+592", "GY", "GUY",  Continent.SouthAmerica, Region.SouthAmerica, "Dollar", "GYD");
        public static readonly Country Paraguay = new("Paraguay", "+595", "PY", "PRY",  Continent.SouthAmerica, Region.SouthAmerica, "Guarani", "PYG");
        public static readonly Country Peru = new("Peru", "+51", "PE", "PER",  Continent.SouthAmerica, Region.SouthAmerica, "Sol", "PEN");
        public static readonly Country Suriname = new("Suriname", "+597", "SR", "SUR",  Continent.SouthAmerica, Region.SouthAmerica, "Dollar", "SRD");
        public static readonly Country Uruguay = new("Uruguay", "+598", "UY", "URY",  Continent.SouthAmerica, Region.SouthAmerica, "Peso", "UYU");
        public static readonly Country Venezuela = new("Venezuela", "+58", "VE", "VEN",  Continent.SouthAmerica, Region.SouthAmerica, "Bolivar", "VES");
        #endregion South America
        #region Oceania
        public static readonly Country Australia = new("Australia", "+61", "AU", "AUS", Continent.Oceania, Region.AustraliaAndNewZealand, "Dollar", "AUD");
        public static readonly Country FederatedStatesOfMicronesia = new("Federated States of Micronesia", "+691", "FM", "FSM",  Continent.Oceania, Region.Micronesia, "Dollar", "USD");
        public static readonly Country Fiji = new("Fiji", "+679", "FJ", "FJI",  Continent.Oceania, Region.Melanesia, "Dollar", "FJD");
        public static readonly Country Kiribati = new("Kiribati", "+686", "KI", "KIR",  Continent.Oceania, Region.Micronesia, "Dollar", "AUD");
        public static readonly Country MarshallIslands = new("Marshall Islands", "+692", "MH", "MHL",  Continent.Oceania, Region.Micronesia, "Dollar", "USD");
        public static readonly Country Nauru = new("Nauru", "+674", "NR", "NRU",  Continent.Oceania, Region.Micronesia, "Dollar", "AUD");
        public static readonly Country NewZealand = new("New Zealand", "+64", "NZ", "NZL",  Continent.Oceania, Region.AustraliaAndNewZealand, "Dollar", "NZD");
        public static readonly Country Palau = new("Palau", "+680", "PW", "PLW",  Continent.Oceania, Region.Micronesia, "Dollar", "USD");
        public static readonly Country PapuaNewGuinea = new("Papua New Guinea", "+675", "PG", "PNG",  Continent.Oceania, Region.Melanesia, "Kina", "PGK");
        public static readonly Country Samoa = new("Samoa", "+685", "WS", "WSM",  Continent.Oceania, Region.Polynesia, "Tala", "WST");
        public static readonly Country SolomonIslands = new("Solomon Islands", "+677", "SB", "SLB",  Continent.Oceania, Region.Melanesia, "Dollar", "SBD");
        public static readonly Country Tonga = new("Tonga", "+676", "TO", "TON",  Continent.Oceania, Region.Polynesia, "Paanga", "TOP");
        public static readonly Country Tuvalu = new("Tuvalu", "+688", "TV", "TUV",  Continent.Oceania, Region.Polynesia, "Dollar", "AUD");
        public static readonly Country Vanuatu = new("Vanuatu", "+678", "VU", "VUT",  Continent.Oceania, Region.Melanesia, "Vatu", "VUV");
        #endregion Oceania

        private static readonly Country[] _all =
        [
            #region Africa
            Algeria,
            Angola,
            Benin,
            BurkinaFaso,
            Burundi,
            Cameroon,
            CapeVerde,
            CentralAfricanRepublic,
            Chad,
            Comoros,
            RepublicOfTheCongo,
            DemocraticRepublicOfTheCongo,
            CoteDIvoire,
            Djibouti,
            Egypt,
            EquatorialGuinea,
            Eritrea,
            Ethiopia,
            Gabon,
            TheGambia,
            Ghana,
            Guinea,
            GuineaBissau,
            Kenya,
            Lesotho,
            Liberia,
            Libya,
            Madagascar,
            Malawi,
            Mali,
            Mauritania,
            Mauritius,
            Morocco,
            Mozambique,
            Namibia,
            Niger,
            Nigeria,
            Rwanda,
            SaoTomeAndPrincipe,
            Senegal,
            Seychelles,
            SierraLeone,
            Somalia,
            SouthAfrica,
            SouthSudan,
            Sudan,
            Swaziland,
            Tanzania,
            Togo,
            Tunisia,
            Uganda,
            WesternSahara,
            Zambia,
            Zimbabwe,
            #endregion Africa
            #region Asia
            Afghanistan,
            Armenia,
            Azerbaijan,
            Bahrain,
            Bangladesh,
            Bhutan,
            Brunei,
            Cambodia,
            China,
            Cyprus,
            EastTimor,
            Georgia,
            India,
            Indonesia,
            Iran,
            Iraq,
            Israel,
            Japan,
            Jordan,
            Kazakhstan,
            Kuwait,
            Kyrgyzstan,
            Laos,
            Lebanon,
            Malaysia,
            Maldives,
            Mongolia,
            Myanmar,
            Nepal,
            NorthKorea,
            Oman,
            Pakistan,
            Philippines,
            Palestine,
            Qatar,
            SaudiArabia,
            Singapore,
            SouthKorea,
            SriLanka,
            Syria,
            Taiwan,
            Tajikistan,
            Thailand,
            Turkey,
            Turkmenistan,
            UnitedArabEmirates,
            Uzbekistan,
            Vietnam,
            Yemen,
            #endregion Asia
            #region Europe
            Albania,
            Andorra,
            Austria,
            Belarus,
            Belgium,
            BosniaAndHerzegovina,
            Bulgaria,
            Croatia,
            CzechRepublic,
            Denmark,
            Estonia,
            Finland,
            France,
            Germany,
            Greece,
            Hungary,
            Iceland,
            Ireland,
            Italy,
            Kosovo,
            Latvia,
            Liechtenstein,
            Lithuania,
            Luxembourg,
            Macedonia,
            Malta,
            Moldova,
            Monaco,
            Montenegro,
            Netherlands,
            Norway,
            Poland,
            Portugal,
            Romania,
            Russia,
            SanMarino,
            Serbia,
            Slovakia,
            Slovenia,
            Spain,
            Sweden,
            Switzerland,
            Ukraine,
            UnitedKingdom,
            VaticanCity,
            #endregion Europe
            #region North America
            Canada,
            Greenland,
            UnitedStates,
            Mexico,
            AntiguaAndBarbuda,
            TheBahamas,
            Barbados,
            Belize,
            CostaRica,
            Cuba,
            Curacao,
            Dominica,
            DominicanRepublic,
            ElSalvador,
            Grenada,
            Guatemala,
            Haiti,
            Honduras,
            Jamaica,
            Nicaragua,
            Panama,
            PuertoRico,
            SaintKittsAndNevis,
            SaintLucia,
            SaintVincentAndTheGrenadines,
            TrinidadAndTobago,
            TurksAndCaicos,
            #endregion North America
            #region South America
            Argentina,
            Bolivia,
            Brazil,
            Chile,
            Colombia,
            Ecuador,
            //FrenchGuiana,
            Guyana,
            Paraguay,
            Peru,
            Suriname,
            Uruguay,
            Venezuela,
            #endregion South America
            #region Oceania
            Australia,
            FederatedStatesOfMicronesia,
            Fiji,
            Kiribati,
            MarshallIslands,
            Nauru,
            NewZealand,
            Palau,
            PapuaNewGuinea,
            Samoa,
            SolomonIslands,
            Tonga,
            Tuvalu,
            Vanuatu
            #endregion Oceania
        ];
        public static IReadOnlyList<Country> All { get; } = Array.AsReadOnly(_all);

        #region FrozenDictionary
        private static readonly FrozenDictionary<string, Country> ByIso2 = _all.ToFrozenDictionary(
            c => c.Iso2,
            StringComparer.OrdinalIgnoreCase);

        private static readonly FrozenDictionary<string, Country> ByIso3 = _all.ToFrozenDictionary(
            c => c.Iso3,
            StringComparer.OrdinalIgnoreCase);

        private static readonly FrozenDictionary<Continent, Country[]> ByContinent = _all
            .GroupBy(c => c.Continent)
            .ToFrozenDictionary(
                group => group.Key,
                group => group.OrderBy(c => c.Name)
            .ToArray());

        private static readonly FrozenDictionary<Region, Country[]> ByRegion = _all
            .GroupBy(c => c.Region)
            .ToFrozenDictionary(
                group => group.Key,
                group => group.OrderBy(c => c.Name)
            .ToArray());
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
    }
}
