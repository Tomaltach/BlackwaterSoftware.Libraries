namespace BlackwaterSoftware.Extensions.Tests.DateTimeTests
{
    public class DateHelperTests
    {
        private static readonly DateTime Sample = new(2025, 6, 15, 12, 30, 45);

        [Fact]
        public void StartOfDay_ReturnsMidnight()
        {
            Assert.Equal(new DateTime(2025, 6, 15), Sample.StartOfDay());
        }

        [Fact]
        public void EndOfDay_ReturnsLastTickOfDay()
        {
            Assert.Equal(
                new DateTime(2025, 6, 15, 23, 59, 59, 999)
                    .AddTicks(9999),
                Sample.EndOfDay());
        }

        [Fact]
        public void IsToday_ReturnsTrueForToday()
        {
            Assert.True(DateTime.Today.IsToday());
        }

        [Fact]
        public void IsYesterday_ReturnsTrueForYesterday()
        {
            Assert.True(DateTime.Today.AddDays(-1).IsYesterday());
        }

        [Fact]
        public void IsTomorrow_ReturnsTrueForTomorrow()
        {
            Assert.True(DateTime.Today.AddDays(1).IsTomorrow());
        }

        [Fact]
        public void IsInThePast_ReturnsTrueForEarlierDate()
        {
            Assert.True(DateTime.Now.AddDays(-1).IsInThePast());
        }

        [Fact]
        public void IsInTheFuture_ReturnsTrueForLaterDate()
        {
            Assert.True(DateTime.Now.AddDays(1).IsInTheFuture());
        }

        [Fact]
        public void IsSameDate_IgnoresTimeOfDay()
        {
            var first = new DateTime(2025, 6, 15, 8, 0, 0);
            var second = new DateTime(2025, 6, 15, 22, 0, 0);

            Assert.True(first.IsSameDate(second));
        }

        [Fact]
        public void IsSameMonth_RequiresSameYearAndMonth()
        {
            Assert.True(
                new DateTime(2025, 6, 1).IsSameMonth(
                    new DateTime(2025, 6, 30)));

            Assert.False(
                new DateTime(2025, 6, 1).IsSameMonth(
                    new DateTime(2024, 6, 1)));
        }

        [Fact]
        public void IsSameYear_ComparesYear()
        {
            Assert.True(
                new DateTime(2025, 1, 1).IsSameYear(
                    new DateTime(2025, 12, 31)));

            Assert.False(
                new DateTime(2025, 1, 1).IsSameYear(
                    new DateTime(2024, 12, 31)));
        }

        [Fact]
        public void IsSameDayOfWeek_ComparesDayOfWeek()
        {
            Assert.True(
                new DateTime(2025, 1, 6).IsSameDayOfWeek(
                    new DateTime(2025, 1, 13)));

            Assert.False(
                new DateTime(2025, 1, 6).IsSameDayOfWeek(
                    new DateTime(2025, 1, 7)));
        }

        [Fact]
        public void IsFirstDayOfMonth_ReturnsExpectedResult()
        {
            Assert.True(new DateTime(2025, 6, 1).IsFirstDayOfMonth());
            Assert.False(new DateTime(2025, 6, 2).IsFirstDayOfMonth());
        }

        [Theory]
        [InlineData(2025, 2, 28, true)]
        [InlineData(2024, 2, 29, true)]
        [InlineData(2025, 2, 27, false)]
        public void IsLastDayOfMonth_ReturnsExpectedResult(int year, int month, int day, bool expected)
        {
            Assert.Equal(
                expected,
                new DateTime(year, month, day).IsLastDayOfMonth());
        }

        [Fact]
        public void IsFirstDayOfYear_ReturnsExpectedResult()
        {
            Assert.True(new DateTime(2025, 1, 1).IsFirstDayOfYear());
            Assert.False(new DateTime(2025, 1, 2).IsFirstDayOfYear());
        }

        [Fact]
        public void IsLastDayOfYear_ReturnsExpectedResult()
        {
            Assert.True(new DateTime(2025, 12, 31).IsLastDayOfYear());
            Assert.False(new DateTime(2025, 12, 30).IsLastDayOfYear());
        }

        [Fact]
        public void IsBetweenExclusive_ExcludesEndpoints()
        {
            var start = new DateTime(2025, 1, 1);
            var end = new DateTime(2025, 1, 31);

            Assert.False(start.IsBetweenExclusive(start, end));
            Assert.False(end.IsBetweenExclusive(start, end));
            Assert.True(new DateTime(2025, 1, 15)
                .IsBetweenExclusive(start, end));
        }

        [Fact]
        public void IsBetweenExclusive_ReturnsFalseForReversedRange()
        {
            Assert.False(
                new DateTime(2025, 1, 15).IsBetweenExclusive(
                    new DateTime(2025, 1, 31),
                    new DateTime(2025, 1, 1)));
        }

        [Fact]
        public void Clamp_ReturnsMinimumWhenBelowRange()
        {
            var min = new DateTime(2025, 1, 10);
            var max = new DateTime(2025, 1, 20);

            Assert.Equal(
                min,
                new DateTime(2025, 1, 1).Clamp(min, max));
        }

        [Fact]
        public void Clamp_ReturnsMaximumWhenAboveRange()
        {
            var min = new DateTime(2025, 1, 10);
            var max = new DateTime(2025, 1, 20);

            Assert.Equal(
                max,
                new DateTime(2025, 1, 31).Clamp(min, max));
        }

        [Fact]
        public void Clamp_ReturnsOriginalValueWithinRange()
        {
            var min = new DateTime(2025, 1, 10);
            var max = new DateTime(2025, 1, 20);
            var value = new DateTime(2025, 1, 15);

            Assert.Equal(value, value.Clamp(min, max));
        }

        [Fact]
        public void Clamp_IncludesEndpoints()
        {
            var min = new DateTime(2025, 1, 10);
            var max = new DateTime(2025, 1, 20);

            Assert.Equal(min, min.Clamp(min, max));
            Assert.Equal(max, max.Clamp(min, max));
        }

        [Fact]
        public void Clamp_ThrowsWhenMinimumExceedsMaximum()
        {
            Assert.Throws<ArgumentException>(() =>
                Sample.Clamp(
                    new DateTime(2025, 1, 20),
                    new DateTime(2025, 1, 10)));
        }
    }
}
