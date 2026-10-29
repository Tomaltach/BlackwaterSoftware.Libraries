namespace BlackwaterSoftware.Extensions.Tests.DateTimeTests
{
    public class AgeTests
    {
        [Theory]
        [InlineData(2000, 1, 1, 2020, 1, 1, 20)]
        [InlineData(2000, 12, 31, 2020, 12, 30, 19)]
        [InlineData(2000, 6, 15, 2020, 6, 14, 19)]
        [InlineData(2000, 6, 15, 2020, 6, 15, 20)]
        [InlineData(2000, 6, 15, 2020, 6, 16, 20)]
        [InlineData(2000, 2, 29, 2021, 2, 27, 20)]
        [InlineData(2000, 2, 29, 2021, 2, 28, 21)]
        [InlineData(2000, 2, 29, 2024, 2, 28, 23)]
        [InlineData(2000, 2, 29, 2024, 2, 29, 24)]
        public void CalculateAgeAt_ReturnsExpectedAge(
            int birthYear, int birthMonth, int birthDay,
            int referenceYear, int referenceMonth, int referenceDay,
            int expectedAge)
        {
            var birthDate = new DateTime(birthYear, birthMonth, birthDay);
            var referenceDate = new DateTime(referenceYear, referenceMonth, referenceDay);

            Assert.Equal(expectedAge, birthDate.CalculateAgeAt(referenceDate));
        }

        [Fact]
        public void CalculateAgeAt_IgnoresTimeOfDay()
        {
            var birthDate = new DateTime(2000, 6, 15, 23, 59, 0);
            var referenceDate = new DateTime(2020, 6, 15, 0, 1, 0);

            Assert.Equal(20, birthDate.CalculateAgeAt(referenceDate));
        }

        [Fact]
        public void CalculateAgeAt_ThrowsWhenBirthDateIsInFuture()
        {
            var birthDate = new DateTime(2030, 1, 1);
            var referenceDate = new DateTime(2029, 12, 31);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => birthDate.CalculateAgeAt(referenceDate));
        }

        [Fact]
        public void CalculateAge_ReturnsAgeAtToday()
        {
            var birthDate = DateTime.Today.AddYears(-25);

            Assert.Equal(25, birthDate.CalculateAge());
        }

        [Fact]
        public void Between_IncludesBothEndpoints()
        {
            var start = new DateTime(2025, 1, 1);
            var end = new DateTime(2025, 1, 31);

            Assert.True(start.Between(start, end));
            Assert.True(end.Between(start, end));
        }

        [Fact]
        public void Between_ReturnsTrueForDateInsideRange()
        {
            var date = new DateTime(2025, 1, 15);

            Assert.True(date.Between(
                new DateTime(2025, 1, 1),
                new DateTime(2025, 1, 31)));
        }

        [Fact]
        public void Between_ReturnsFalseOutsideRange()
        {
            var start = new DateTime(2025, 1, 1);
            var end = new DateTime(2025, 1, 31);

            Assert.False(new DateTime(2024, 12, 31).Between(start, end));
            Assert.False(new DateTime(2025, 2, 1).Between(start, end));
        }

        [Fact]
        public void Between_ReturnsFalseWhenRangeIsReversed()
        {
            var date = new DateTime(2025, 1, 15);

            Assert.False(date.Between(
                new DateTime(2025, 1, 31),
                new DateTime(2025, 1, 1)));
        }

        [Fact]
        public void Between_ReturnsTrueWhenRangeContainsSingleDate()
        {
            var date = new DateTime(2025, 1, 15);

            Assert.True(date.Between(date, date));
        }
    }
}
