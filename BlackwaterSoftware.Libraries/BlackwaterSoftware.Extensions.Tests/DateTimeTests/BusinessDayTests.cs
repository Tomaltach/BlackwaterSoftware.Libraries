namespace BlackwaterSoftware.Extensions.Tests.DateTimeTests
{
    public class BusinessDayTests
    {
        [Theory]
        [InlineData(2025, 1, 3, 1, 2025, 1, 6)]  // Friday -> Monday
        [InlineData(2025, 1, 3, 2, 2025, 1, 7)]  // Friday -> Tuesday
        [InlineData(2025, 1, 6, -1, 2025, 1, 3)] // Monday -> Friday
        [InlineData(2025, 1, 4, 1, 2025, 1, 6)]  // Saturday -> Monday
        [InlineData(2025, 1, 5, 1, 2025, 1, 6)]  // Sunday -> Monday
        public void AddBusinessDays_ReturnsExpectedDate(
            int year, int month, int day, int days,
            int expectedYear, int expectedMonth, int expectedDay)
        {
            var date = new DateTime(year, month, day);

            var result = date.AddBusinessDays(days);

            Assert.Equal(
                new DateTime(expectedYear, expectedMonth, expectedDay),
                result);
        }

        [Fact]
        public void AddBusinessDays_WithZero_ReturnsOriginalDate()
        {
            var date = new DateTime(2025, 1, 4, 12, 30, 0);

            Assert.Equal(date, date.AddBusinessDays(0));
        }

        [Fact]
        public void AddBusinessDays_PreservesTimeOfDay()
        {
            var date = new DateTime(2025, 1, 3, 14, 30, 45);

            var result = date.AddBusinessDays(1);

            Assert.Equal(new DateTime(2025, 1, 6, 14, 30, 45), result);
        }

        [Fact]
        public void SubtractBusinessDays_SubtractsWeekdays()
        {
            var date = new DateTime(2025, 1, 8); // Wednesday

            Assert.Equal(
                new DateTime(2025, 1, 6),
                date.SubtractBusinessDays(2));
        }

        [Fact]
        public void SubtractBusinessDays_WithZero_ReturnsOriginalDate()
        {
            var date = new DateTime(2025, 1, 8, 10, 0, 0);

            Assert.Equal(date, date.SubtractBusinessDays(0));
        }

        [Fact]
        public void SubtractBusinessDays_WithNegativeDays_AddsBusinessDays()
        {
            var date = new DateTime(2025, 1, 8); // Wednesday

            Assert.Equal(
                new DateTime(2025, 1, 10),
                date.SubtractBusinessDays(-2));
        }

        [Fact]
        public void GetBusinessDays_ExcludesStartAndIncludesEnd()
        {
            var start = new DateTime(2025, 1, 6); // Monday
            var end = new DateTime(2025, 1, 10);  // Friday

            Assert.Equal(4, DateTimeExtensions.GetBusinessDays(start, end));
        }

        [Fact]
        public void GetBusinessDays_ReturnsNegativeCountForReversedDates()
        {
            var start = new DateTime(2025, 1, 10); // Friday
            var end = new DateTime(2025, 1, 6);    // Monday

            Assert.Equal(-4, DateTimeExtensions.GetBusinessDays(start, end));
        }

        [Fact]
        public void GetBusinessDays_ReturnsZeroForSameDate()
        {
            var date = new DateTime(2025, 1, 6);

            Assert.Equal(0, DateTimeExtensions.GetBusinessDays(date, date));
        }

        [Fact]
        public void CountBusinessDaysInclusive_CountsBothEndpoints()
        {
            var start = new DateTime(2025, 1, 6); // Monday
            var end = new DateTime(2025, 1, 10);  // Friday

            Assert.Equal(
                5,
                DateTimeExtensions.CountBusinessDaysInclusive(start, end));
        }

        [Fact]
        public void CountBusinessDaysInclusive_ExcludesWeekendDays()
        {
            var start = new DateTime(2025, 1, 3); // Friday
            var end = new DateTime(2025, 1, 6);   // Monday

            Assert.Equal(
                2,
                DateTimeExtensions.CountBusinessDaysInclusive(start, end));
        }

        [Fact]
        public void CountBusinessDaysInclusive_ReturnsOneForSingleWeekday()
        {
            var date = new DateTime(2025, 1, 6);

            Assert.Equal(
                1,
                DateTimeExtensions.CountBusinessDaysInclusive(date, date));
        }

        [Fact]
        public void CountBusinessDaysInclusive_ThrowsForReversedDates()
        {
            var start = new DateTime(2025, 1, 10);
            var end = new DateTime(2025, 1, 6);

            Assert.Throws<ArgumentException>(
                () => DateTimeExtensions.CountBusinessDaysInclusive(start, end));
        }

        [Theory]
        [InlineData(2025, 1, 6, 2025, 1, 10, 2025, 1, 8, true)]
        [InlineData(2025, 1, 6, 2025, 1, 10, 2025, 1, 11, false)]
        [InlineData(2025, 1, 6, 2025, 1, 10, 2025, 1, 4, false)]
        public void IsBusinessDayBetween_ReturnsExpectedResult(
            int startYear, int startMonth, int startDay,
            int endYear, int endMonth, int endDay,
            int dateYear, int dateMonth, int dateDay,
            bool expected)
        {
            var start = new DateTime(startYear, startMonth, startDay);
            var end = new DateTime(endYear, endMonth, endDay);
            var date = new DateTime(dateYear, dateMonth, dateDay);

            Assert.Equal(expected, date.IsBusinessDayBetween(start, end));
        }

        [Fact]
        public void IsBusinessDayBetween_ReturnsFalseForReversedRange()
        {
            var date = new DateTime(2025, 1, 8);

            Assert.False(date.IsBusinessDayBetween(
                new DateTime(2025, 1, 10),
                new DateTime(2025, 1, 6)));
        }

        [Theory]
        [InlineData(2025, 1, 6, true)]  // Monday
        [InlineData(2025, 1, 10, true)] // Friday
        [InlineData(2025, 1, 11, false)]
        [InlineData(2025, 1, 12, false)]
        public void IsWorkDay_ReturnsExpectedResult(int year, int month, int day, bool expected)
        {
            Assert.Equal(expected, new DateTime(year, month, day).IsWorkDay());
        }

        [Theory]
        [InlineData(2025, 1, 11, true)]
        [InlineData(2025, 1, 12, true)]
        [InlineData(2025, 1, 10, false)]
        [InlineData(2025, 1, 13, false)]
        public void IsWeekend_ReturnsExpectedResult(int year, int month, int day, bool expected)
        {
            Assert.Equal(expected, new DateTime(year, month, day).IsWeekend());
        }

        [Fact]
        public void NextWorkday_SkipsWeekendAndPreservesTime()
        {
            var date = new DateTime(2025, 1, 10, 14, 30, 45); // Friday

            Assert.Equal(
                new DateTime(2025, 1, 13, 14, 30, 45),
                date.NextWorkday());
        }

        [Fact]
        public void PreviousWorkday_SkipsWeekendAndPreservesTime()
        {
            var date = new DateTime(2025, 1, 13, 14, 30, 45); // Monday

            Assert.Equal(
                new DateTime(2025, 1, 10, 14, 30, 45),
                date.PreviousWorkday());
        }

        [Fact]
        public void NextWorkday_FromSaturday_ReturnsMonday()
        {
            Assert.Equal(
                new DateTime(2025, 1, 13),
                new DateTime(2025, 1, 11).NextWorkday());
        }

        [Fact]
        public void PreviousWorkday_FromSunday_ReturnsFriday()
        {
            Assert.Equal(
                new DateTime(2025, 1, 10),
                new DateTime(2025, 1, 12).PreviousWorkday());
        }
    }
}
