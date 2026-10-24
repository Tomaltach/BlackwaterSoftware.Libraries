namespace BlackwaterSoftware.Extensions
{
    public static class DateTimeExtensions
    {
        #region Age
        public static bool Between(this DateTime self, DateTime start, DateTime end)
            => self.Ticks >= start.Ticks && self.Ticks <= end.Ticks;

        public static int CalculateAge(this DateTime self)
        {
            var age = DateTime.Now.Year > self.Year
                ? DateTime.Now.Month > self.Month
                    ? DateTime.Now.Day > self.Day
                        ? DateTime.Now.Year - self.Year
                        : DateTime.Now.Year - self.Year
                    : DateTime.Now.Year - self.Year - 1
                : DateTime.Now.Year - self.Year - 1;
            return age;
        }
        #endregion Age

        #region Business Days
        public static DateTime AddBusinessDays(this DateTime current, int days)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do { current = current.AddDays(sign); }
                while (current.DayOfWeek == DayOfWeek.Saturday || current.DayOfWeek == DayOfWeek.Sunday);
            }
            return current;
        }

        public static DateTime SubtractBusinessDays(this DateTime current, int days)
            => AddBusinessDays(current, -days);

        public static int GetBusinessDays(DateTime start, DateTime end)
        {
            if (start.DayOfWeek == DayOfWeek.Saturday) start = start.AddDays(2);
            else if (start.DayOfWeek == DayOfWeek.Sunday) start = start.AddDays(1);

            if (end.DayOfWeek == DayOfWeek.Saturday) end = end.AddDays(-1);
            else if (end.DayOfWeek == DayOfWeek.Sunday) end = end.AddDays(-2);

            int diff = (int)end.Subtract(start).TotalDays;
            int result = diff / 7 * 5 + diff % 7;

            return result;
        }

        public static bool IsWorkDay(this DateTime self)
            => self.DayOfWeek != DayOfWeek.Saturday && self.DayOfWeek != DayOfWeek.Sunday;

        public static bool IsWeekend(this DateTime self)
            => self.DayOfWeek == DayOfWeek.Saturday && self.DayOfWeek == DayOfWeek.Sunday;

        public static DateTime NextWorkday(this DateTime self)
        {
            var nextDay = self;
            while (!nextDay.IsWorkDay()) nextDay = nextDay.AddDays(1);
            return nextDay;
        }
        #endregion Business Days

        public static DateTimeOffset ToDateTimeOffsetOutOfRangeProtected(this DateTime self)
        {
            var utcDateTime = self.ToUniversalTime();
            if (utcDateTime <= DateTimeOffset.MinValue.UtcDateTime) return DateTimeOffset.MinValue;
            else if (utcDateTime >= DateTimeOffset.MaxValue.UtcDateTime) return DateTimeOffset.MaxValue;
            else return new DateTimeOffset(self);
        }
    }
}
