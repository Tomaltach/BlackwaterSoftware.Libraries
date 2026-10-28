using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.Tests
{
    public class CountriesCurrencyTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        public void FindByCurrencyCode_ShouldReturnEmpty_WhenCodeIsBlank(string? currencyCode)
        {
            var result = Countries.FindByCurrencyCode(currencyCode);

            Assert.Empty(result);
        }

        [Fact]
        public void FindByCurrencyCode_ShouldIgnoreCase()
        {
            var country = Countries.All.First(
                c => !string.IsNullOrWhiteSpace(c.CurrencyCode));

            var upper = Countries.FindByCurrencyCode(
                country.CurrencyCode.ToUpperInvariant());

            var lower = Countries.FindByCurrencyCode(
                country.CurrencyCode.ToLowerInvariant());

            Assert.Equal(
                upper.Select(c => c.Iso2).OrderBy(x => x),
                lower.Select(c => c.Iso2).OrderBy(x => x));
        }

        [Fact]
        public void FindByCurrencyCode_ShouldTrimInput()
        {
            var country = Countries.All.First(
                c => !string.IsNullOrWhiteSpace(c.CurrencyCode));

            var result = Countries.FindByCurrencyCode(
                $"  {country.CurrencyCode}  ");

            Assert.Contains(result, c => c.Iso2 == country.Iso2);
        }

        [Fact]
        public void FindByCurrencyCode_ShouldReturnOnlyMatchingCountries()
        {
            var country = Countries.All.First(
                c => !string.IsNullOrWhiteSpace(c.CurrencyCode));

            var result = Countries.FindByCurrencyCode(country.CurrencyCode);

            Assert.NotEmpty(result);

            Assert.All(result, item =>
                Assert.True(string.Equals(
                    item.CurrencyCode,
                    country.CurrencyCode,
                    StringComparison.OrdinalIgnoreCase)));
        }

        [Fact]
        public void FindByCurrencyCode_ShouldReturnResultsSortedByName()
        {
            var country = Countries.All.First(
                c => !string.IsNullOrWhiteSpace(c.CurrencyCode));

            var result = Countries.FindByCurrencyCode(country.CurrencyCode);

            var expected = result
                .OrderBy(c => c.Name)
                .Select(c => c.Name)
                .ToArray();

            Assert.Equal(expected, result.Select(c => c.Name));
        }

        [Fact]
        public void FindByCurrencyCode_ShouldReturnEmpty_WhenCodeDoesNotExist()
        {
            var result = Countries.FindByCurrencyCode("ZZZ");

            Assert.Empty(result);
        }

        [Fact]
        public void FindByCurrencyCode_ShouldReturnReadOnlyCollection()
        {
            var country = Countries.All.First(
                c => !string.IsNullOrWhiteSpace(c.CurrencyCode));

            var result = Countries.FindByCurrencyCode(country.CurrencyCode);

            var list = Assert.IsAssignableFrom<IList<Country>>(result);

            Assert.Throws<NotSupportedException>(
                () => list.Add(Countries.All[0]));
        }
    }
}
