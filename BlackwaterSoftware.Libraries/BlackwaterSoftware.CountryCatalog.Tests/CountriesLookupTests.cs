namespace BlackwaterSoftware.CountryCatalog.Tests
{
    public class CountriesLookupTests
    {
        [Fact]
        public void FindByIso2_ShouldReturnCountry_WhenCodeExists()
        {
            var country = Countries.FindByIso2("US");

            Assert.NotNull(country);
            Assert.Equal("US", country.Iso2);
            Assert.Equal(Countries.UnitedStates.Name, country.Name);
        }

        [Fact]
        public void FindByIso2_ShouldBeCaseInsensitive()
        {
            var upper = Countries.FindByIso2("US");
            var lower = Countries.FindByIso2("us");
            var mixed = Countries.FindByIso2("Us");

            Assert.NotNull(upper);
            Assert.Same(upper, lower);
            Assert.Same(upper, mixed);
        }

        [Theory]
        [InlineData("ZZ")]
        [InlineData("")]
        [InlineData("  ")]
        public void FindByIso2_ShouldReturnNull_WhenCodeDoesNotExist(string iso2)
        {
            Assert.Null(Countries.FindByIso2(iso2));
        }

        [Fact]
        public void FindByIso3_ShouldReturnCountry_WhenCodeExists()
        {
            var country = Countries.FindByIso3("USA");

            Assert.NotNull(country);
            Assert.Equal("USA", country.Iso3);
            Assert.Equal(Countries.UnitedStates.Name, country.Name);
        }

        [Fact]
        public void FindByIso3_ShouldBeCaseInsensitive()
        {
            var upper = Countries.FindByIso3("USA");
            var lower = Countries.FindByIso3("usa");
            var mixed = Countries.FindByIso3("UsA");

            Assert.NotNull(upper);
            Assert.Same(upper, lower);
            Assert.Same(upper, mixed);
        }

        [Theory]
        [InlineData("ZZZ")]
        [InlineData("")]
        [InlineData("  ")]
        public void FindByIso3_ShouldReturnNull_WhenCodeDoesNotExist(string iso3)
        {
            Assert.Null(Countries.FindByIso3(iso3));
        }

        [Fact]
        public void FindByIso2_ShouldMatchEveryCountry()
        {
            foreach (var country in Countries.All)
            {
                Assert.Same(country, Countries.FindByIso2(country.Iso2));
            }
        }

        [Fact]
        public void FindByIso3_ShouldMatchEveryCountry()
        {
            foreach (var country in Countries.All)
            {
                Assert.Same(country, Countries.FindByIso3(country.Iso3));
            }
        }

        [Fact]
        public void IsoDictionaries_ShouldContainEveryCountry()
        {
            Assert.Equal(Countries.All.Count, Countries.ByIso2.Count);
            Assert.Equal(Countries.All.Count, Countries.ByIso3.Count);

            foreach (var country in Countries.All)
            {
                Assert.Contains(country.Iso2, Countries.ByIso2.Keys);
                Assert.Contains(country.Iso3, Countries.ByIso3.Keys);
            }
        }
    }
}
