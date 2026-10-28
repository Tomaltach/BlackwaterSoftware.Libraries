using BlackwaterSoftware.CountryCatalog.Enums;
using BlackwaterSoftware.CountryCatalog.Models;

namespace BlackwaterSoftware.CountryCatalog.Tests
{
    public class CountriesGroupingTests
    {
        [Fact]
        public void FindByContinent_ShouldReturnAllCountriesForContinent()
        {
            var continents = Countries.All
                .Select(c => c.Continent)
                .Distinct();

            foreach (var continent in continents)
            {
                var expected = Countries.All
                    .Where(c => c.Continent == continent)
                    .OrderBy(c => c.Name)
                    .ToArray();

                var actual = Countries.FindByContinent(continent);

                Assert.Equal(expected, actual);
                Assert.Equal(
                    expected.Select(c => c.Name),
                    actual.Select(c => c.Name));
            }
        }

        [Fact]
        public void FindByRegion_ShouldReturnAllCountriesForRegion()
        {
            var regions = Countries.All
                .Select(c => c.Region)
                .Distinct();

            foreach (var region in regions)
            {
                var expected = Countries.All
                    .Where(c => c.Region == region)
                    .OrderBy(c => c.Name)
                    .ToArray();

                var actual = Countries.FindByRegion(region);

                Assert.Equal(expected, actual);
                Assert.Equal(
                    expected.Select(c => c.Name),
                    actual.Select(c => c.Name));
            }
        }

        [Fact]
        public void ByContinent_ShouldContainEveryContinent()
        {
            var expected = Countries.All
                .Select(c => c.Continent)
                .Distinct()
                .OrderBy(c => c)
                .ToArray();

            var actual = Countries.ByContinent.Keys
                .OrderBy(c => c)
                .ToArray();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ByRegion_ShouldContainEveryRegion()
        {
            var expected = Countries.All
                .Select(c => c.Region)
                .Distinct()
                .OrderBy(r => r)
                .ToArray();

            var actual = Countries.ByRegion.Keys
                .OrderBy(r => r)
                .ToArray();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ByContinentAndRegion_ShouldMatchMasterCollection()
        {
            foreach (var continentGroup in Countries.All.GroupBy(c => c.Continent))
            {
                Assert.True(
                    Countries.ByContinentAndRegion.TryGetValue(
                        continentGroup.Key, out var regions));

                Assert.NotNull(regions);

                foreach (var regionGroup in continentGroup.GroupBy(c => c.Region))
                {
                    Assert.True(
                        regions!.TryGetValue(regionGroup.Key, out var actual));

                    var expectedIso2 = regionGroup
                        .OrderBy(c => c.Name)
                        .Select(c => c.Iso2)
                        .ToArray();

                    Assert.NotNull(actual);
                    Assert.Equal(
                        expectedIso2,
                        actual!.Select(c => c.Iso2));
                }
            }
        }

        [Fact]
        public void ByContinentAndRegion_ShouldContainOnlyMatchingCountries()
        {
            foreach (var continent in Countries.ByContinentAndRegion)
            {
                foreach (var region in continent.Value)
                {
                    Assert.All(
                        region.Value,
                        country =>
                        {
                            Assert.Equal(continent.Key, country.Continent);
                            Assert.Equal(region.Key, country.Region);
                        });
                }
            }
        }

        [Fact]
        public void FindByContinent_ShouldReturnEmptyForUnknownValue()
        {
            var result = Countries.FindByContinent((Continent)(-1));

            Assert.Empty(result);
        }

        [Fact]
        public void FindByRegion_ShouldReturnEmptyForUnknownValue()
        {
            var result = Countries.FindByRegion((Region)(-1));

            Assert.Empty(result);
        }

        [Fact]
        public void FindByContinent_ShouldReturnReadOnlyCollection()
        {
            var result = Countries.FindByContinent(
                Countries.All[0].Continent);

            var list = Assert.IsAssignableFrom<IList<Country>>(result);

            Assert.Throws<NotSupportedException>(
                () => list.Add(Countries.All[0]));
        }

        [Fact]
        public void FindByRegion_ShouldReturnReadOnlyCollection()
        {
            var result = Countries.FindByRegion(Countries.All[0].Region);

            var list = Assert.IsAssignableFrom<IList<Country>>(result);

            Assert.Throws<NotSupportedException>(
                () => list.Add(Countries.All[0]));
        }
    }
}
