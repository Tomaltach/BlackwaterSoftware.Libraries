namespace BlackwaterSoftware.Extensions.Tests.DateTimeTests
{
    public class WeekHelperTests
    {
        [Theory]
        [InlineData(2025, 1, 6)]  // Monday
        [InlineData(2025, 1, 7)]  // Tuesday
        [InlineData(2025, 1, 12)] // Sunday
        public void StartOfWeek_DefaultsToMonday(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);

            Assert.Equal(
                new DateTime(2025, 1, 6),
                date.StartOfWeek());
        }

        [Fact]
        public void StartOfWeek_WithSundayStart_ReturnsSunday()
        {
            var date = new DateTime(2025, 1, 8); // Wednesday

            Assert.Equal(
                new DateTime(2025, 1, 5),
                date.StartOfWeek(DayOfWeek.Sunday));
        }

        [Fact]
        public void StartOfWeek_OnFirstDay_ReturnsSameDate()
        {
            var monday = new DateTime(2025, 1, 6);

            Assert.Equal(monday, monday.StartOfWeek());
        }

        [Fact]
        public void StartOfWeek_PreservesTimeKind()
        {
            var date = new DateTime(2025, 1, 8, 14, 30, 0, DateTimeKind.Utc);

            Assert.Equal(DateTimeKind.Utc, date.StartOfWeek().Kind);
        }

        [Fact]
        public void StartOfWeek_ReturnsMidnight()
        {
            var date = new DateTime(2025, 1, 8, 14, 30, 45);

            Assert.Equal(
                new DateTime(2025, 1, 6),
                date.StartOfWeek());
        }

        [Fact]
        public void EndOfWeek_ReturnsLastTickOfSunday()
        {
            var date = new DateTime(2025, 1, 8);

            Assert.Equal(
                new DateTime(2025, 1, 13).AddTicks(-1),
                date.EndOfWeek());
        }

        [Fact]
        public void EndOfWeek_WithSundayStart_ReturnsLastTickOfSaturday()
        {
            var date = new DateTime(2025, 1, 8);

            Assert.Equal(
                new DateTime(2025, 1, 12).AddTicks(-1),
                date.EndOfWeek(DayOfWeek.Sunday));
        }

        [Fact]
        public void EndOfWeek_IncludesTheEntireFinalDay()
        {
            var date = new DateTime(2025, 1, 6);

            var result = date.EndOfWeek();

            Assert.Equal(new DateTime(2025, 1, 13).AddTicks(-1), result);
            Assert.Equal(999, result.Millisecond);
            Assert.Equal(9999, result.Ticks % TimeSpan.TicksPerMillisecond);
        }

        [Fact]
        public void EndOfWeek_PreservesTimeKind()
        {
            var date = new DateTime(2025, 1, 8, 14, 30, 0, DateTimeKind.Utc);

            Assert.Equal(DateTimeKind.Utc, date.EndOfWeek().Kind);
        }
    }
}
