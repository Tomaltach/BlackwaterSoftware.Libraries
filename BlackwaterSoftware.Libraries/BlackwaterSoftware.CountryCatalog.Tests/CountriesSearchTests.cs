namespace BlackwaterSoftware.CountryCatalog.Tests
{
    public class CountriesSearchTests
    {
        [Fact]
        public void Search_ShouldReturnAll_WhenQueryIsNull()
        {
            var result = Countries.Search(null);

            Assert.Same(Countries.All, result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        public void Search_ShouldReturnAll_WhenQueryIsBlank(string query)
        {
            var result = Countries.Search(query);

            Assert.Same(Countries.All, result);
        }

        [Theory]
        [InlineData("United States")]
        [InlineData("united states")]
        [InlineData("UNITED STATES")]
        public void Search_ShouldMatchCountryNameCaseInsensitively(string query)
        {
            var result = Countries.Search(query);

            Assert.Contains(result, c => c.Iso2 == "US");
        }

        [Fact]
        public void Search_ShouldTrimQuery()
        {
            var result = Countries.Search("  United States  ");

            Assert.Contains(result, c => c.Iso2 == "US");
        }

        [Theory]
        [InlineData("US")]
        [InlineData("USA")]
        public void Search_ShouldMatchIsoCodes(string query)
        {
            var result = Countries.Search(query);

            Assert.Contains(result, c => c.Iso2 == "US");
        }

        [Fact]
        public void Search_ShouldMatchCallingCode()
        {
            var country = Countries.All.First(
                c => !string.IsNullOrWhiteSpace(c.CallingCode));

            var result = Countries.Search(country.CallingCode);

            Assert.Contains(result, c => c.Iso2 == country.Iso2);
        }

        [Fact]
        public void Search_ShouldMatchCurrencyCode()
        {
            var country = Countries.All.First(
                c => !string.IsNullOrWhiteSpace(c.CurrencyCode));

            var result = Countries.Search(country.CurrencyCode);

            Assert.Contains(result, c => c.Iso2 == country.Iso2);
        }

        [Fact]
        public void Search_ShouldMatchCurrencyName()
        {
            var country = Countries.All.First(
                c => !string.IsNullOrWhiteSpace(c.CurrencyName));

            var result = Countries.Search(country.CurrencyName);

            Assert.Contains(result, c => c.Iso2 == country.Iso2);
        }

        [Fact]
        public void Search_ShouldReturnResultsSortedByName()
        {
            var result = Countries.Search("a");

            var expected = result
                .OrderBy(c => c.Name)
                .Select(c => c.Name)
                .ToArray();

            Assert.Equal(expected, result.Select(c => c.Name));
        }

        [Fact]
        public void Search_ShouldReturnEmpty_WhenNoMatchExists()
        {
            var result = Countries.Search(
                "no-such-country-or-currency-xyz-987");

            Assert.Empty(result);
        }

        [Fact]
        public void Search_ShouldFindEveryCountryByItsName()
        {
            foreach (var country in Countries.All)
            {
                var result = Countries.Search(country.Name);

                Assert.Contains(result, c => c.Iso2 == country.Iso2);
            }
        }
    }
}
