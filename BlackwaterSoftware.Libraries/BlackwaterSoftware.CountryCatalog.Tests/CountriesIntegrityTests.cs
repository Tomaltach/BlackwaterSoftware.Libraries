using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.Tests
{
    public class CountriesIntegrityTests
    {
        [Fact]
        public void All_ShouldNotBeEmpty()
        {
            Assert.NotEmpty(Countries.All);
        }

        [Fact]
        public void All_ShouldNotContainDuplicateIso2Codes()
        {
            var duplicates = Countries.All
                .GroupBy(c => c.Iso2, StringComparer.OrdinalIgnoreCase)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToArray();

            Assert.Empty(duplicates);
        }

        [Fact]
        public void All_ShouldNotContainDuplicateIso3Codes()
        {
            var duplicates = Countries.All
                .GroupBy(c => c.Iso3, StringComparer.OrdinalIgnoreCase)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToArray();

            Assert.Empty(duplicates);
        }

        [Fact]
        public void All_ShouldHaveNonEmptyRequiredProperties()
        {
            Assert.All(Countries.All, country =>
            {
                Assert.False(string.IsNullOrWhiteSpace(country.Name));
                Assert.False(string.IsNullOrWhiteSpace(country.Iso2));
                Assert.False(string.IsNullOrWhiteSpace(country.Iso3));

                Assert.NotNull(country.CallingCode);
                Assert.NotNull(country.CurrencyCode);
                Assert.NotNull(country.CurrencyName);
            });
        }

        [Fact]
        public void All_ShouldContainUniqueIso2Codes()
        {
            var uniqueCodes = Countries.All
                .Select(c => c.Iso2)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Count();

            Assert.Equal(Countries.All.Count, uniqueCodes);
        }

        [Fact]
        public void All_ShouldHaveConsistentIsoCodeLengths()
        {
            Assert.All(Countries.All, country =>
            {
                Assert.True(
                    country.Iso2.Length == 2,
                    $"{country.Name} must have a two-character ISO-2 code.");

                Assert.True(
                    country.Iso3.Length == 3,
                    $"{country.Name} must have a three-character ISO-3 code.");
            });
        }

        [Fact]
        public void All_ShouldContainNoNullCountries()
        {
            Assert.All(Countries.All, Assert.NotNull);
        }

        [Fact]
        public void All_ShouldContainNoDuplicateCountryReferences()
        {
            var uniqueReferences = Countries.All
                .Distinct(ReferenceEqualityComparer.Instance)
                .Count();

            Assert.Equal(Countries.All.Count, uniqueReferences);
        }

        [Fact]
        public void All_ShouldBeExposedAsReadOnlyCollection()
        {
            var list = Assert.IsAssignableFrom<IList<Country>>(
                Countries.All);

            Assert.Throws<NotSupportedException>(
                () => list.Add(Countries.All[0]));
        }

        [Fact]
        public void FrozenDictionaries_ShouldUseCaseInsensitiveKeys()
        {
            foreach (var country in Countries.All)
            {
                Assert.True(
                    Countries.ByIso2.ContainsKey(country.Iso2.ToLowerInvariant()));

                Assert.True(
                    Countries.ByIso3.ContainsKey(country.Iso3.ToLowerInvariant()));
            }
        }
    }
}
