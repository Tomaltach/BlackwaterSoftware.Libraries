namespace BlackwaterSoftware.Extensions.Tests.DateTimeTests
{
    public class CalendarHelperTests
    {
        [Fact]
        public void StartOfMonth_ReturnsFirstDayAtMidnight()
        {
            var date = new DateTime(2025, 6, 15, 12, 30, 45, DateTimeKind.Utc);
            var expected = new DateTime(2025, 6, 1, 0, 0, 0, DateTimeKind.Utc);

            Assert.Equal(expected, date.StartOfMonth());
        }

        [Fact]
        public void EndOfMonth_ReturnsLastTickOfMonth()
        {
            var date = new DateTime(2025, 2, 15);

            Assert.Equal(
                new DateTime(2025, 3, 1).AddTicks(-1),
                date.EndOfMonth());
        }

        [Fact]
        public void EndOfMonth_HandlesLeapYear()
        {
            var date = new DateTime(2024, 2, 15);

            Assert.Equal(
                new DateTime(2024, 3, 1).AddTicks(-1),
                date.EndOfMonth());
        }

        [Fact]
        public void StartOfYear_ReturnsFirstDayAtMidnight()
        {
            var date = new DateTime(2025, 6, 15, 12, 30, 45, DateTimeKind.Utc);

            Assert.Equal(
                new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                date.StartOfYear());
        }

        [Fact]
        public void EndOfYear_ReturnsLastTickOfYear()
        {
            var date = new DateTime(2025, 6, 15);

            Assert.Equal(
                new DateTime(2026, 1, 1).AddTicks(-1),
                date.EndOfYear());
        }

        [Fact]
        public void StartOfMonth_PreservesDateTimeKind()
        {
            var date = new DateTime(2025, 6, 15, 12, 30, 0, DateTimeKind.Utc);

            Assert.Equal(DateTimeKind.Utc, date.StartOfMonth().Kind);
        }

        [Fact]
        public void StartOfYear_PreservesDateTimeKind()
        {
            var date = new DateTime(2025, 6, 15, 12, 30, 0, DateTimeKind.Local);

            Assert.Equal(DateTimeKind.Local, date.StartOfYear().Kind);
        }

        [Theory]
        [InlineData(2025, 1, 31)]
        [InlineData(2024, 2, 29)]
        [InlineData(2025, 2, 28)]
        [InlineData(2025, 4, 30)]
        [InlineData(2025, 12, 31)]
        public void DaysInMonth_ReturnsExpectedValue(int year, int month, int expectedDays)
        {
            var date = new DateTime(year, month, 1);

            Assert.Equal(expectedDays, date.DaysInMonth());
        }

        [Theory]
        [InlineData(2024, true)]
        [InlineData(2025, false)]
        [InlineData(2000, true)]
        [InlineData(1900, false)]
        public void IsLeapYear_ReturnsExpectedResult(int year, bool expected)
        {
            Assert.Equal(
                expected,
                new DateTime(year, 1, 1).IsLeapYear());
        }

        [Theory]
        [InlineData(2021, 1, 4, 1)]
        [InlineData(2021, 1, 10, 1)]
        [InlineData(2021, 1, 11, 2)]
        [InlineData(2024, 1, 1, 1)]
        [InlineData(2021, 1, 1, 53)]
        public void GetIsoWeekOfYear_ReturnsExpectedWeek(int year, int month, int day, int expectedWeek)
        {
            var date = new DateTime(year, month, day);

            Assert.Equal(expectedWeek, date.GetIsoWeekOfYear());
        }
    }
}
