using System.Globalization;

namespace BlackwaterSoftware.Extensions
{
    public static class DateTimeExtensions
    {
        #region Age
        /// <summary>
        /// Determines whether this date falls within an inclusive range.
        /// </summary>
        public static bool Between(this DateTime self, DateTime start, DateTime end)
            => start <= end && self >= start && self <= end;

        /// <summary>
        /// Calculates age using the current local date.
        /// February 29 birthdays are treated as February 28 in non-leap years.
        /// </summary>
        public static int CalculateAge(this DateTime self)
            => self.CalculateAgeAt(DateTime.Today);

        /// <summary>
        /// Calculates age at a specified reference date.
        /// </summary>
        public static int CalculateAgeAt(this DateTime birthDate, DateTime referenceDate)
        {
            birthDate = birthDate.Date;
            referenceDate = referenceDate.Date;

            if (birthDate > referenceDate)
                throw new ArgumentOutOfRangeException(
                    nameof(birthDate),
                    "Birth date cannot be after the reference date.");

            var age = referenceDate.Year - birthDate.Year;
            var birthdayThisYear = birthDate.AddYears(age);
            if (referenceDate < birthdayThisYear) age--;
            return age;
        }
        #endregion Age

        #region Business Days
        /// <summary>
        /// Adds or subtracts weekdays, excluding the starting date.
        /// Saturdays and Sundays are not counted.
        /// </summary>
        public static DateTime AddBusinessDays(this DateTime current, int days)
        {
            long remaining = Math.Abs((long)days);
            var direction = Math.Sign(days);

            while (remaining > 0)
            {
                current = current.AddDays(direction);
                if (current.IsWorkDay()) remaining--;
            }

            return current;
        }

        /// <summary>
        /// Subtracts business days, excluding the starting date.
        /// </summary>
        public static DateTime SubtractBusinessDays(this DateTime current, int days)
            => current.AddBusinessDays((int)Math.Min(-(long)days, int.MaxValue));

        /// <summary>
        /// Counts weekdays between two dates, excluding the start
        /// and including the end. Returns a negative count when reversed.
        /// </summary>
        public static int GetBusinessDays(DateTime start, DateTime end)
        {
            if (start.Date == end.Date) return 0;

            var sign = start.Date < end.Date ? 1 : -1;
            var first = sign > 0 ? start.Date : end.Date;
            var last = sign > 0 ? end.Date : start.Date;

            var count = CountBusinessDaysInclusive(first.AddDays(1), last);
            return sign * count;
        }

        /// <summary>
        /// Counts weekdays, including both endpoints.
        /// </summary>
        public static int CountBusinessDaysInclusive(DateTime start, DateTime end)
        {
            start = start.Date;
            end = end.Date;

            if (start > end)
                throw new ArgumentException("Start date must be on or before end date.");

            var totalDays = (end - start).Days + 1;
            var fullWeeks = totalDays / 7;
            var count = fullWeeks * 5;

            var remainingDays = totalDays % 7;

            for (var i = 0; i < remainingDays; i++)
            {
                var day = start.AddDays(fullWeeks * 7 + i).DayOfWeek;

                if (day is not DayOfWeek.Saturday and not DayOfWeek.Sunday)
                    count++;
            }

            return count;
        }

        public static bool IsBusinessDayBetween(this DateTime self, DateTime start, DateTime end)
            => start.Date <= end.Date
                && self.Date >= start.Date
                && self.Date <= end.Date
                && self.IsWorkDay();

        public static bool IsWorkDay(this DateTime self)
            => self.DayOfWeek is not DayOfWeek.Saturday and not DayOfWeek.Sunday;

        public static bool IsWeekend(this DateTime self)
            => self.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;

        /// <summary>
        /// Returns the first weekday strictly after this date,
        /// preserving the time of day.
        /// </summary>
        public static DateTime NextWorkday(this DateTime self)
        {
            var next = self.Date.AddDays(1);

            while (!next.IsWorkDay())
                next = next.AddDays(1);

            return next.Add(self.TimeOfDay);
        }

        /// <summary>
        /// Returns the first weekday strictly before this date,
        /// preserving the time of day.
        /// </summary>
        public static DateTime PreviousWorkday(this DateTime self)
        {
            var previous = self.Date.AddDays(-1);

            while (!previous.IsWorkDay())
                previous = previous.AddDays(-1);

            return previous.Add(self.TimeOfDay);
        }
        #endregion Business Days

        #region DateTimeOffset Helpers
        /// <summary>
        /// Converts to DateTimeOffset, clamping out-of-range UTC
        /// values to the minimum or maximum representable offset.
        /// Unspecified DateTime values are interpreted as local time.
        /// </summary>
        public static DateTimeOffset ToDateTimeOffsetOutOfRangeProtected(this DateTime self)
        {
            var utc = self.ToUniversalTime();

            if (utc <= DateTimeOffset.MinValue.UtcDateTime)
                return DateTimeOffset.MinValue;

            if (utc >= DateTimeOffset.MaxValue.UtcDateTime)
                return DateTimeOffset.MaxValue;

            try
            {
                return new DateTimeOffset(self);
            }
            catch (ArgumentOutOfRangeException)
            {
                return utc < DateTimeOffset.MinValue.UtcDateTime
                    ? DateTimeOffset.MinValue
                    : DateTimeOffset.MaxValue;
            }
        }

        public static long ToUnixTimestampSeconds(this DateTime self)
            => new DateTimeOffset(self).ToUnixTimeSeconds();

        public static long ToUnixTimestampMilliseconds(this DateTime self)
            => new DateTimeOffset(self).ToUnixTimeMilliseconds();
        #endregion DateTimeOffset Helpers

        #region Date Helpers
        public static DateTime StartOfDay(this DateTime self)
            => self.Date;

        public static DateTime EndOfDay(this DateTime self)
            => self.Date.AddDays(1).AddTicks(-1);

        public static bool IsToday(this DateTime self)
            => self.Date == DateTime.Today;

        public static bool IsYesterday(this DateTime self)
            => self.Date == DateTime.Today.AddDays(-1);

        public static bool IsTomorrow(this DateTime self)
            => self.Date == DateTime.Today.AddDays(1);

        public static bool IsInThePast(this DateTime self)
            => self < DateTime.Now;

        public static bool IsInTheFuture(this DateTime self)
            => self > DateTime.Now;

        public static bool IsSameDate(this DateTime self, DateTime other)
            => self.Date == other.Date;

        public static bool IsSameMonth(this DateTime self, DateTime other)
            => self.Year == other.Year && self.Month == other.Month;

        public static bool IsSameYear(this DateTime self, DateTime other)
            => self.Year == other.Year;

        public static bool IsSameDayOfWeek(this DateTime self, DateTime other)
            => self.DayOfWeek == other.DayOfWeek;

        public static bool IsFirstDayOfMonth(this DateTime self)
            => self.Day == 1;

        public static bool IsLastDayOfMonth(this DateTime self)
            => self.Day == DateTime.DaysInMonth(self.Year, self.Month);

        public static bool IsFirstDayOfYear(this DateTime self)
            => self.Month == 1 && self.Day == 1;

        public static bool IsLastDayOfYear(this DateTime self)
            => self.Month == 12 && self.Day == 31;

        public static bool IsBetweenExclusive(this DateTime self, DateTime start, DateTime end)
            => start < end && self > start && self < end;

        /// <summary>
        /// Clamps a date and time to an inclusive range.
        /// </summary>
        public static DateTime Clamp(this DateTime self, DateTime min, DateTime max)
        {
            if (min > max)
                throw new ArgumentException("Minimum must be on or before maximum.");

            if (self < min) return min;
            if (self > max) return max;

            return self;
        }
        #endregion Date Helpers

        #region Calendar Helpers
        public static DateTime StartOfMonth(this DateTime self)
            => new(self.Year, self.Month, 1, 0, 0, 0, self.Kind);

        public static DateTime EndOfMonth(this DateTime self)
            => self.StartOfMonth().AddMonths(1).AddTicks(-1);

        public static DateTime StartOfYear(this DateTime self)
            => new(self.Year, 1, 1, 0, 0, 0, self.Kind);

        public static DateTime EndOfYear(this DateTime self)
            => self.StartOfYear().AddYears(1).AddTicks(-1);

        public static int DaysInMonth(this DateTime self)
            => DateTime.DaysInMonth(self.Year, self.Month);

        public static bool IsLeapYear(this DateTime self)
            => DateTime.IsLeapYear(self.Year);

        public static int GetIsoWeekOfYear(this DateTime self)
            => ISOWeek.GetWeekOfYear(self);
        #endregion Calendar Helpers

        #region Relative Dates
        public static DateTime PreviousDay(this DateTime self)
            => self.AddDays(-1);

        public static DateTime NextDay(this DateTime self)
            => self.AddDays(1);

        public static DateTime PreviousWeek(this DateTime self)
            => self.AddDays(-7);

        public static DateTime NextWeek(this DateTime self)
            => self.AddDays(7);

        public static DateTime PreviousMonth(this DateTime self)
            => self.AddMonths(-1);

        public static DateTime NextMonth(this DateTime self)
            => self.AddMonths(1);

        public static DateTime PreviousYear(this DateTime self)
            => self.AddYears(-1);

        public static DateTime NextYear(this DateTime self)
            => self.AddYears(1);
        #endregion Relative Dates

        #region Week Helpers
        public static DateTime StartOfWeek(this DateTime self, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            var difference = (7 + (int)self.DayOfWeek - (int)firstDayOfWeek) % 7;
            return self.Date.AddDays(-difference);
        }

        public static DateTime EndOfWeek(this DateTime self, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
            => self
                .StartOfWeek(firstDayOfWeek)
                .AddDays(7)
                .AddTicks(-1);
        #endregion Week Helpers

        #region Time Helpers
        public static DateTime TruncateToMinute(this DateTime self)
            => new(
                self.Year, self.Month, self.Day,
                self.Hour, self.Minute, 0, self.Kind);

        public static DateTime RoundToMinute(this DateTime self)
        {
            var truncated = self.TruncateToMinute();
            return self.Second >= 30
                ? truncated.AddMinutes(1)
                : truncated;
        }

        public static DateTime TruncateToSecond(this DateTime self)
            => new(
                self.Year, self.Month, self.Day,
                self.Hour, self.Minute, self.Second, self.Kind);
        #endregion Time Helpers

        #region DateOnly And TimeOnly (.NET 6+)
        public static DateOnly ToDateOnly(this DateTime self)
            => DateOnly.FromDateTime(self);

        public static TimeOnly ToTimeOnly(this DateTime self)
            => TimeOnly.FromDateTime(self);

        public static DateTime ToDateTime(this DateOnly self, TimeOnly time)
            => self.ToDateTime(time);
        #endregion DateOnly And TimeOnly
    }
}
