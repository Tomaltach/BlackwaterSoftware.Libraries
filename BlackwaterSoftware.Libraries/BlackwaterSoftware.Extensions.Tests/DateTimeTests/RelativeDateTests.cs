namespace BlackwaterSoftware.Extensions.Tests.DateTimeTests
{
    public class RelativeDateTests
    {
        [Fact]
        public void PreviousDay_ReturnsPreviousCalendarDay()
        {
            Assert.Equal(
                new DateTime(2025, 1, 14),
                new DateTime(2025, 1, 15).PreviousDay());
        }

        [Fact]
        public void NextDay_ReturnsNextCalendarDay()
        {
            Assert.Equal(
                new DateTime(2025, 1, 16),
                new DateTime(2025, 1, 15).NextDay());
        }

        [Fact]
        public void PreviousWeek_ReturnsSevenDaysEarlier()
        {
            Assert.Equal(
                new DateTime(2025, 1, 8),
                new DateTime(2025, 1, 15).PreviousWeek());
        }

        [Fact]
        public void NextWeek_ReturnsSevenDaysLater()
        {
            Assert.Equal(
                new DateTime(2025, 1, 22),
                new DateTime(2025, 1, 15).NextWeek());
        }

        [Fact]
        public void PreviousMonth_ReturnsPreviousMonth()
        {
            Assert.Equal(
                new DateTime(2025, 4, 15),
                new DateTime(2025, 5, 15).PreviousMonth());
        }

        [Fact]
        public void NextMonth_ReturnsNextMonth()
        {
            Assert.Equal(
                new DateTime(2025, 6, 15),
                new DateTime(2025, 5, 15).NextMonth());
        }

        [Fact]
        public void PreviousMonth_ClampsEndOfMonth()
        {
            Assert.Equal(
                new DateTime(2025, 2, 28),
                new DateTime(2025, 3, 31).PreviousMonth());
        }

        [Fact]
        public void NextMonth_ClampsEndOfMonth()
        {
            Assert.Equal(
                new DateTime(2025, 2, 28),
                new DateTime(2025, 1, 31).NextMonth());
        }

        [Fact]
        public void PreviousYear_ReturnsPreviousYear()
        {
            Assert.Equal(
                new DateTime(2024, 6, 15),
                new DateTime(2025, 6, 15).PreviousYear());
        }

        [Fact]
        public void NextYear_ReturnsNextYear()
        {
            Assert.Equal(
                new DateTime(2026, 6, 15),
                new DateTime(2025, 6, 15).NextYear());
        }

        [Fact]
        public void PreviousYear_ClampsLeapDay()
        {
            Assert.Equal(
                new DateTime(2023, 2, 28),
                new DateTime(2024, 2, 29).PreviousYear());
        }

        [Fact]
        public void NextYear_ClampsLeapDay()
        {
            Assert.Equal(
                new DateTime(2025, 2, 28),
                new DateTime(2024, 2, 29).NextYear());
        }

        [Fact]
        public void RelativeDateMethods_PreserveTimeOfDay()
        {
            var date = new DateTime(2025, 6, 15, 14, 30, 45);

            Assert.Equal(
                new DateTime(2025, 6, 16, 14, 30, 45),
                date.NextDay());

            Assert.Equal(
                new DateTime(2025, 6, 22, 14, 30, 45),
                date.NextWeek());
        }
    }
}
