namespace BlackwaterSoftware.Extensions.Tests.DateTimeTests
{
    public class DateOnlyTimeOnlyTests
    {
        [Fact]
        public void ToDateOnly_ReturnsDateComponent()
        {
            var date = new DateTime(2025, 6, 15, 14, 30, 45);

            Assert.Equal(new DateOnly(2025, 6, 15), date.ToDateOnly());
        }

        [Fact]
        public void ToTimeOnly_ReturnsTimeComponent()
        {
            var date = new DateTime(2025, 6, 15, 14, 30, 45)
                .AddTicks(1234);

            Assert.Equal(
                new TimeOnly(14, 30, 45).Add(TimeSpan.FromTicks(1234)),
                date.ToTimeOnly());
        }

        [Fact]
        public void ToDateTime_CombinesDateAndTime()
        {
            var date = new DateOnly(2025, 6, 15);
            var time = new TimeOnly(14, 30, 45);

            Assert.Equal(
                new DateTime(2025, 6, 15, 14, 30, 45),
                date.ToDateTime(time));
        }

        [Fact]
        public void ToDateTime_ReturnsMidnightWhenTimeIsMidnight()
        {
            var date = new DateOnly(2025, 6, 15);
            var time = TimeOnly.MinValue;

            Assert.Equal(
                new DateTime(2025, 6, 15),
                date.ToDateTime(time));
        }

        [Fact]
        public void ToDateTime_PreservesFractionalTimePrecision()
        {
            var date = new DateOnly(2025, 6, 15);
            var time = new TimeOnly(14, 30, 45)
                .Add(TimeSpan.FromTicks(1234));

            Assert.Equal(
                new DateTime(2025, 6, 15, 14, 30, 45)
                    .AddTicks(1234),
                date.ToDateTime(time));
        }
    }
}
