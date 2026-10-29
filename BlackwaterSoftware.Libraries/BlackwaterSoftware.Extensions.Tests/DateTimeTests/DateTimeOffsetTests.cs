namespace BlackwaterSoftware.Extensions.Tests.DateTimeTests
{
    public class DateTimeOffsetTests
    {
        [Fact]
        public void ToDateTimeOffsetOutOfRangeProtected_ConvertsUtcDate()
        {
            var date = new DateTime(2025, 1, 15, 12, 30, 0, DateTimeKind.Utc);

            var result = date.ToDateTimeOffsetOutOfRangeProtected();

            Assert.Equal(new DateTimeOffset(date), result);
            Assert.Equal(TimeSpan.Zero, result.Offset);
        }

        [Fact]
        public void ToDateTimeOffsetOutOfRangeProtected_ClampsMinimumUtcDate()
        {
            var date = DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc);

            Assert.Equal(
                DateTimeOffset.MinValue,
                date.ToDateTimeOffsetOutOfRangeProtected());
        }

        [Fact]
        public void ToDateTimeOffsetOutOfRangeProtected_ClampsMaximumUtcDate()
        {
            var date = DateTime.SpecifyKind(DateTime.MaxValue, DateTimeKind.Utc);

            Assert.Equal(
                DateTimeOffset.MaxValue,
                date.ToDateTimeOffsetOutOfRangeProtected());
        }

        [Fact]
        public void ToDateTimeOffsetOutOfRangeProtected_HandlesUnspecifiedKind()
        {
            var date = new DateTime(2025, 1, 15, 12, 30, 0);

            var result = date.ToDateTimeOffsetOutOfRangeProtected();

            // Unspecified DateTime values are interpreted as local time.
            Assert.Equal(new DateTimeOffset(date), result);
        }

        [Fact]
        public void ToUnixTimestampSeconds_ReturnsExpectedTimestamp()
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 1, DateTimeKind.Utc);

            Assert.Equal(1L, date.ToUnixTimestampSeconds());
        }

        [Fact]
        public void ToUnixTimestampMilliseconds_ReturnsExpectedTimestamp()
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 1, DateTimeKind.Utc)
                .AddMilliseconds(234);

            Assert.Equal(1234L, date.ToUnixTimestampMilliseconds());
        }

        [Fact]
        public void ToUnixTimestampSeconds_HandlesDatesBeforeEpoch()
        {
            var date = new DateTime(1969, 12, 31, 23, 59, 59, DateTimeKind.Utc);

            Assert.Equal(-1L, date.ToUnixTimestampSeconds());
        }

        [Fact]
        public void ToUnixTimestampMilliseconds_PreservesMillisecondPrecision()
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddMilliseconds(999);

            Assert.Equal(999L, date.ToUnixTimestampMilliseconds());
        }
    }
}
