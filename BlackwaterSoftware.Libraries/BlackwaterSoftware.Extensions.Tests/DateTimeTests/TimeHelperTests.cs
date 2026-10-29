namespace BlackwaterSoftware.Extensions.Tests.DateTimeTests
{
    public class TimeHelperTests
    {
        [Fact]
        public void TruncateToMinute_RemovesSecondsAndTicks()
        {
            var date = new DateTime(2025, 6, 15, 14, 30, 45)
                .AddTicks(1234);

            Assert.Equal(
                new DateTime(2025, 6, 15, 14, 30, 0),
                date.TruncateToMinute());
        }

        [Fact]
        public void TruncateToMinute_PreservesDateTimeKind()
        {
            var date = new DateTime(2025, 6, 15, 14, 30, 45, DateTimeKind.Utc);

            Assert.Equal(DateTimeKind.Utc, date.TruncateToMinute().Kind);
        }

        [Theory]
        [InlineData(29, 0)]
        [InlineData(30, 1)]
        [InlineData(31, 1)]
        [InlineData(59, 1)]
        public void RoundToMinute_RoundsAtThirtySeconds(int seconds, int expectedMinuteOffset)
        {
            var date = new DateTime(2025, 6, 15, 14, 30, 0)
                .AddSeconds(seconds);

            Assert.Equal(
                new DateTime(2025, 6, 15, 14, 30, 0)
                    .AddMinutes(expectedMinuteOffset),
                date.RoundToMinute());
        }

        [Fact]
        public void RoundToMinute_CarriesIntoNextHour()
        {
            var date = new DateTime(2025, 6, 15, 14, 59, 30);

            Assert.Equal(
                new DateTime(2025, 6, 15, 15, 0, 0),
                date.RoundToMinute());
        }

        [Fact]
        public void RoundToMinute_CarriesIntoNextDay()
        {
            var date = new DateTime(2025, 6, 15, 23, 59, 30);

            Assert.Equal(
                new DateTime(2025, 6, 16, 0, 0, 0),
                date.RoundToMinute());
        }

        [Fact]
        public void RoundToMinute_PreservesDateTimeKind()
        {
            var date = new DateTime(2025, 6, 15, 14, 30, 45, DateTimeKind.Utc);

            Assert.Equal(DateTimeKind.Utc, date.RoundToMinute().Kind);
        }

        [Fact]
        public void TruncateToSecond_RemovesFractionalSeconds()
        {
            var date = new DateTime(2025, 6, 15, 14, 30, 45)
                .AddTicks(1234);

            Assert.Equal(
                new DateTime(2025, 6, 15, 14, 30, 45),
                date.TruncateToSecond());
        }

        [Fact]
        public void TruncateToSecond_PreservesDateTimeKind()
        {
            var date = new DateTime(2025, 6, 15, 14, 30, 45, DateTimeKind.Local);

            Assert.Equal(DateTimeKind.Local, date.TruncateToSecond().Kind);
        }
    }
}
