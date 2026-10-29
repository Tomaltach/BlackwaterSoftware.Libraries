using System.Globalization;

namespace BlackwaterSoftware.Extensions
{
    public static class DateTimeExtensions
    {
        #region Age

        /// <summary>
        /// Determines whether this date falls within an inclusive date and time range.
        /// </summary>
        /// <param name="self">The date and time to check.</param>
        /// <param name="start">The inclusive start of the range.</param>
        /// <param name="end">The inclusive end of the range.</param>
        /// <returns>
        /// <see langword="true"/> if the start is on or before the end and
        /// this date falls within the range; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool Between(this DateTime self, DateTime start, DateTime end)
            => start <= end && self >= start && self <= end;

        /// <summary>
        /// Calculates the age represented by this birth date using the current local date.
        /// </summary>
        /// <remarks>
        /// Birthdays occurring on February 29 are treated as February 28
        /// in non-leap years.
        /// </remarks>
        /// <param name="self">The birth date.</param>
        /// <returns>The age in completed years as of today.</returns>
        public static int CalculateAge(this DateTime self)
            => self.CalculateAgeAt(DateTime.Today);

        /// <summary>
        /// Calculates the age represented by a birth date at a specified reference date.
        /// </summary>
        /// <remarks>
        /// The time components of both dates are ignored.
        /// Birthdays occurring on February 29 are treated as February 28
        /// in non-leap years.
        /// </remarks>
        /// <param name="birthDate">The person's date of birth.</param>
        /// <param name="referenceDate">The date at which to calculate the age.</param>
        /// <returns>The age in completed years at the reference date.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="birthDate"/> is later than
        /// <paramref name="referenceDate"/>.
        /// </exception>
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
        /// Adds or subtracts a specified number of business days from a date.
        /// </summary>
        /// <remarks>
        /// The starting date is excluded from the count. Saturdays and Sundays
        /// are skipped. Public holidays are not excluded.
        /// The time of day is preserved.
        /// </remarks>
        /// <param name="current">The starting date and time.</param>
        /// <param name="days">
        /// The number of business days to add. Negative values subtract business days.
        /// </param>
        /// <returns>The resulting date and time after adding or subtracting business days.</returns>
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
        /// Subtracts a specified number of business days from a date.
        /// </summary>
        /// <remarks>
        /// The starting date is excluded from the count. Saturdays and Sundays
        /// are skipped. Public holidays are not excluded.
        /// The time of day is preserved.
        /// </remarks>
        /// <param name="current">The starting date and time.</param>
        /// <param name="days">The number of business days to subtract.</param>
        /// <returns>The resulting date and time after subtracting business days.</returns>
        public static DateTime SubtractBusinessDays(this DateTime current, int days)
            => current.AddBusinessDays((int)Math.Min(-(long)days, int.MaxValue));

        /// <summary>
        /// Counts business days between two dates, excluding the start date
        /// and including the end date.
        /// </summary>
        /// <remarks>
        /// Saturdays and Sundays are excluded. Public holidays are not excluded.
        /// If the dates are reversed, the result is negative.
        /// The time components are ignored.
        /// </remarks>
        /// <param name="start">The starting date.</param>
        /// <param name="end">The ending date.</param>
        /// <returns>
        /// The number of business days between the dates, with a negative result
        /// when the dates are in reverse order.
        /// </returns>
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
        /// Counts business days between two dates, including both endpoints.
        /// </summary>
        /// <remarks>
        /// Saturdays and Sundays are excluded. Public holidays are not excluded.
        /// The time components are ignored.
        /// </remarks>
        /// <param name="start">The inclusive starting date.</param>
        /// <param name="end">The inclusive ending date.</param>
        /// <returns>The number of business days within the inclusive range.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="start"/> is later than <paramref name="end"/>.
        /// </exception>
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

        /// <summary>
        /// Determines whether this date is a business day within an inclusive date range.
        /// </summary>
        /// <remarks>
        /// Saturdays and Sundays are not considered business days.
        /// Public holidays are not excluded. Time components are ignored.
        /// </remarks>
        /// <param name="self">The date to evaluate.</param>
        /// <param name="start">The inclusive start of the range.</param>
        /// <param name="end">The inclusive end of the range.</param>
        /// <returns>
        /// <see langword="true"/> if the range is valid, this date falls within
        /// the range, and it is a weekday; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsBusinessDayBetween(this DateTime self, DateTime start, DateTime end)
            => start.Date <= end.Date
                && self.Date >= start.Date
                && self.Date <= end.Date
                && self.IsWorkDay();

        /// <summary>
        /// Determines whether this date falls on a weekday.
        /// </summary>
        /// <remarks>
        /// Monday through Friday are considered working days.
        /// Public holidays are not excluded.
        /// </remarks>
        /// <param name="self">The date to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if the date falls on a weekday; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public static bool IsWorkDay(this DateTime self)
            => self.DayOfWeek is not DayOfWeek.Saturday and not DayOfWeek.Sunday;

        /// <summary>
        /// Determines whether this date falls on a Saturday or Sunday.
        /// </summary>
        /// <param name="self">The date to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if the date falls on a Saturday or Sunday;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsWeekend(this DateTime self)
            => self.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;

        /// <summary>
        /// Returns the first weekday strictly after this date.
        /// </summary>
        /// <remarks>
        /// Saturdays and Sundays are skipped. Public holidays are not excluded.
        /// The time of day is preserved.
        /// </remarks>
        /// <param name="self">The starting date and time.</param>
        /// <returns>The next weekday after the specified date, preserving its time of day.</returns>
        public static DateTime NextWorkday(this DateTime self)
        {
            var next = self.Date.AddDays(1);

            while (!next.IsWorkDay())
                next = next.AddDays(1);

            return next.Add(self.TimeOfDay);
        }

        /// <summary>
        /// Returns the first weekday strictly before this date.
        /// </summary>
        /// <remarks>
        /// Saturdays and Sundays are skipped. Public holidays are not excluded.
        /// The time of day is preserved.
        /// </remarks>
        /// <param name="self">The starting date and time.</param>
        /// <returns>
        /// The previous weekday before the specified date, preserving its time of day.
        /// </returns>
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
        /// Converts this <see cref="DateTime"/> to a <see cref="DateTimeOffset"/>,
        /// protecting against values outside the supported UTC range.
        /// </summary>
        /// <remarks>
        /// The value is converted to UTC to check whether it falls outside the
        /// representable range. Out-of-range values are clamped to
        /// <see cref="DateTimeOffset.MinValue"/> or
        /// <see cref="DateTimeOffset.MaxValue"/>.
        /// <see cref="DateTimeKind.Unspecified"/> values are interpreted as local time.
        /// </remarks>
        /// <param name="self">The date and time to convert.</param>
        /// <returns>
        /// A <see cref="DateTimeOffset"/> representing the date and time,
        /// clamped to the supported range when necessary.
        /// </returns>
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

        /// <summary>
        /// Converts this <see cref="DateTime"/> to a Unix timestamp expressed in seconds.
        /// </summary>
        /// <remarks>
        /// The Unix timestamp represents the number of seconds elapsed since
        /// 00:00:00 UTC on January 1, 1970. The conversion follows the
        /// <see cref="DateTimeOffset"/> interpretation of the supplied date and time.
        /// </remarks>
        /// <param name="self">The date and time to convert.</param>
        /// <returns>The Unix timestamp in seconds.</returns>
        public static long ToUnixTimestampSeconds(this DateTime self)
            => new DateTimeOffset(self).ToUnixTimeSeconds();

        /// <summary>
        /// Converts this <see cref="DateTime"/> to a Unix timestamp expressed in milliseconds.
        /// </summary>
        /// <remarks>
        /// The Unix timestamp represents the number of milliseconds elapsed since
        /// 00:00:00 UTC on January 1, 1970. The conversion follows the
        /// <see cref="DateTimeOffset"/> interpretation of the supplied date and time.
        /// </remarks>
        /// <param name="self">The date and time to convert.</param>
        /// <returns>The Unix timestamp in milliseconds.</returns>
        public static long ToUnixTimestampMilliseconds(this DateTime self)
            => new DateTimeOffset(self).ToUnixTimeMilliseconds();

        #endregion DateTimeOffset Helpers

        #region Date Helpers

        /// <summary>
        /// Converts this <see cref="DateTime"/> to a Unix timestamp expressed in milliseconds.
        /// </summary>
        /// <remarks>
        /// The Unix timestamp represents the number of milliseconds elapsed since
        /// 00:00:00 UTC on January 1, 1970. The conversion follows the
        /// <see cref="DateTimeOffset"/> interpretation of the supplied date and time.
        /// </remarks>
        /// <param name="self">The date and time to convert.</param>
        /// <returns>The Unix timestamp in milliseconds.</returns>
        public static DateTime StartOfDay(this DateTime self)
            => self.Date;

        /// <summary>
        /// Returns the final tick of the day for this date.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>
        /// The final representable tick of the day, at 23:59:59.9999999,
        /// preserving the original <see cref="DateTime.Kind"/>.
        /// </returns>
        public static DateTime EndOfDay(this DateTime self)
            => self.Date.AddDays(1).AddTicks(-1);

        /// <summary>
        /// Determines whether this date falls on the current local calendar day.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if the date matches today's local calendar date;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsToday(this DateTime self)
            => self.Date == DateTime.Today;

        /// <summary>
        /// Determines whether this date falls on the previous local calendar day.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if the date matches yesterday's local calendar date;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsYesterday(this DateTime self)
            => self.Date == DateTime.Today.AddDays(-1);

        /// <summary>
        /// Determines whether this date falls on the next local calendar day.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if the date matches tomorrow's local calendar date;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsTomorrow(this DateTime self)
            => self.Date == DateTime.Today.AddDays(1);

        /// <summary>
        /// Determines whether this date and time is earlier than the current local date and time.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if this value is earlier than <see cref="DateTime.Now"/>;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsInThePast(this DateTime self)
            => self < DateTime.Now;

        /// <summary>
        /// Determines whether this date and time is later than the current local date and time.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if this value is later than <see cref="DateTime.Now"/>;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsInTheFuture(this DateTime self)
            => self > DateTime.Now;

        /// <summary>
        /// Determines whether this date has the same calendar date as another date,
        /// ignoring the time components.
        /// </summary>
        /// <param name="self">The first date and time.</param>
        /// <param name="other">The date and time to compare against.</param>
        /// <returns>
        /// <see langword="true"/> if both values have the same year, month, and day;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsSameDate(this DateTime self, DateTime other)
            => self.Date == other.Date;

        /// <summary>
        /// Determines whether this date and another date fall within the same calendar month and year.
        /// </summary>
        /// <param name="self">The first date and time.</param>
        /// <param name="other">The date and time to compare against.</param>
        /// <returns>
        /// <see langword="true"/> if both values have the same year and month;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsSameMonth(this DateTime self, DateTime other)
            => self.Year == other.Year && self.Month == other.Month;

        /// <summary>
        /// Determines whether this date and another date fall within the same calendar year.
        /// </summary>
        /// <param name="self">The first date and time.</param>
        /// <param name="other">The date and time to compare against.</param>
        /// <returns>
        /// <see langword="true"/> if both values have the same year;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsSameYear(this DateTime self, DateTime other)
            => self.Year == other.Year;

        /// <summary>
        /// Determines whether this date and another date fall on the same day of the week.
        /// </summary>
        /// <param name="self">The first date and time.</param>
        /// <param name="other">The date and time to compare against.</param>
        /// <returns>
        /// <see langword="true"/> if both values have the same <see cref="DayOfWeek"/>;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsSameDayOfWeek(this DateTime self, DateTime other)
            => self.DayOfWeek == other.DayOfWeek;

        /// <summary>
        /// Determines whether this date is the first day of its calendar month.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if the day of the month is 1;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsFirstDayOfMonth(this DateTime self)
            => self.Day == 1;

        /// <summary>
        /// Determines whether this date is the last day of its calendar month.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if the date is the final day of its month;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsLastDayOfMonth(this DateTime self)
            => self.Day == DateTime.DaysInMonth(self.Year, self.Month);

        /// <summary>
        /// Determines whether this date is the first day of its calendar year.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if the date is January 1;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsFirstDayOfYear(this DateTime self)
            => self.Month == 1 && self.Day == 1;

        /// <summary>
        /// Determines whether this date is the last day of its calendar year.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if the date is December 31;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsLastDayOfYear(this DateTime self)
            => self.Month == 12 && self.Day == 31;

        /// <summary>
        /// Determines whether this date falls strictly between two date and time values.
        /// </summary>
        /// <remarks>
        /// Both boundaries are exclusive. The start must be earlier than the end
        /// for the range to be valid.
        /// </remarks>
        /// <param name="self">The date and time to evaluate.</param>
        /// <param name="start">The exclusive lower boundary.</param>
        /// <param name="end">The exclusive upper boundary.</param>
        /// <returns>
        /// <see langword="true"/> if the start is earlier than the end and this value
        /// falls strictly between them; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsBetweenExclusive(this DateTime self, DateTime start, DateTime end)
            => start < end && self > start && self < end;

        /// <summary>
        /// Restricts this date and time to an inclusive range.
        /// </summary>
        /// <remarks>
        /// If this value is earlier than the minimum, the minimum is returned.
        /// If it is later than the maximum, the maximum is returned.
        /// Otherwise, this value is returned unchanged.
        /// </remarks>
        /// <param name="self">The date and time to constrain.</param>
        /// <param name="min">The inclusive lower boundary.</param>
        /// <param name="max">The inclusive upper boundary.</param>
        /// <returns>The value constrained to the specified range.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="min"/> is later than <paramref name="max"/>.
        /// </exception>
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

        /// <summary>
        /// Returns the beginning of the calendar month containing this date.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>
        /// The first day of the month at midnight, preserving the original
        /// <see cref="DateTime.Kind"/>.
        /// </returns>
        public static DateTime StartOfMonth(this DateTime self)
            => new(self.Year, self.Month, 1, 0, 0, 0, self.Kind);

        /// <summary>
        /// Returns the final tick of the calendar month containing this date.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>
        /// The final representable tick of the month, at 23:59:59.9999999,
        /// preserving the original <see cref="DateTime.Kind"/>.
        /// </returns>
        public static DateTime EndOfMonth(this DateTime self)
            => self.StartOfMonth().AddMonths(1).AddTicks(-1);

        /// <summary>
        /// Returns the beginning of the calendar year containing this date.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>
        /// January 1 at midnight for the year containing this date,
        /// preserving the original <see cref="DateTime.Kind"/>.
        /// </returns>
        public static DateTime StartOfYear(this DateTime self)
            => new(self.Year, 1, 1, 0, 0, 0, self.Kind);

        /// <summary>
        /// Returns the final tick of the calendar year containing this date.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>
        /// The final representable tick of the year, at 23:59:59.9999999,
        /// preserving the original <see cref="DateTime.Kind"/>.
        /// </returns>
        public static DateTime EndOfYear(this DateTime self)
            => self.StartOfYear().AddYears(1).AddTicks(-1);

        /// <summary>
        /// Returns the number of days in the calendar month containing this date.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>
        /// The number of days in the month, accounting for leap years.
        /// </returns>
        public static int DaysInMonth(this DateTime self)
            => DateTime.DaysInMonth(self.Year, self.Month);

        /// <summary>
        /// Determines whether the calendar year containing this date is a leap year.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>
        /// <see langword="true"/> if the year is a leap year; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public static bool IsLeapYear(this DateTime self)
            => DateTime.IsLeapYear(self.Year);

        /// <summary>
        /// Returns the ISO 8601 week number for the date.
        /// </summary>
        /// <remarks>
        /// ISO week numbering uses Monday as the first day of the week.
        /// Week 1 is the first week containing at least four days in the new year.
        /// As a result, dates near the beginning or end of a calendar year may
        /// belong to an ISO week-year different from their calendar year.
        /// </remarks>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>The ISO 8601 week number, from 1 to 53.</returns>
        public static int GetIsoWeekOfYear(this DateTime self)
            => ISOWeek.GetWeekOfYear(self);

        #endregion Calendar Helpers

        #region Relative Dates

        /// <summary>
        /// Returns the date and time one day before this value.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>A date and time one day earlier, preserving the time of day and <see cref="DateTime.Kind"/>.</returns>
        public static DateTime PreviousDay(this DateTime self)
            => self.AddDays(-1);

        /// <summary>
        /// Returns the date and time one day after this value.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>A date and time one day later, preserving the time of day and <see cref="DateTime.Kind"/>.</returns>
        public static DateTime NextDay(this DateTime self)
            => self.AddDays(1);

        /// <summary>
        /// Returns the date and time one week before this value.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>A date and time seven days earlier, preserving the time of day and <see cref="DateTime.Kind"/>.</returns>
        public static DateTime PreviousWeek(this DateTime self)
            => self.AddDays(-7);

        /// <summary>
        /// Returns the date and time one week after this value.
        /// </summary>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>A date and time seven days later, preserving the time of day and <see cref="DateTime.Kind"/>.</returns>
        public static DateTime NextWeek(this DateTime self)
            => self.AddDays(7);

        /// <summary>
        /// Returns the date and time one calendar month before this value.
        /// </summary>
        /// <remarks>
        /// If the resulting month has fewer days than the original date,
        /// the day is adjusted to the last valid day of the resulting month.
        /// </remarks>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>A date and time one calendar month earlier.</returns>
        public static DateTime PreviousMonth(this DateTime self)
            => self.AddMonths(-1);

        /// <summary>
        /// Returns the date and time one calendar month after this value.
        /// </summary>
        /// <remarks>
        /// If the resulting month has fewer days than the original date,
        /// the day is adjusted to the last valid day of the resulting month.
        /// </remarks>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>A date and time one calendar month later.</returns>
        public static DateTime NextMonth(this DateTime self)
            => self.AddMonths(1);

        /// <summary>
        /// Returns the date and time one calendar year before this value.
        /// </summary>
        /// <remarks>
        /// If the original date is February 29 and the previous year is not
        /// a leap year, the resulting date is February 28.
        /// </remarks>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>A date and time one calendar year earlier.</returns>
        public static DateTime PreviousYear(this DateTime self)
            => self.AddYears(-1);

        /// <summary>
        /// Returns the date and time one calendar year after this value.
        /// </summary>
        /// <remarks>
        /// If the original date is February 29 and the following year is not
        /// a leap year, the resulting date is February 28.
        /// </remarks>
        /// <param name="self">The date and time to evaluate.</param>
        /// <returns>A date and time one calendar year later.</returns>
        public static DateTime NextYear(this DateTime self)
            => self.AddYears(1);

        #endregion Relative Dates

        #region Week Helpers

        /// <summary>
        /// Returns the start of the week containing this date.
        /// </summary>
        /// <remarks>
        /// The returned value is at midnight on the first day of the week.
        /// The default first day is Monday. The calculation uses the
        /// specified <see cref="DayOfWeek"/> to determine the week boundary.
        /// </remarks>
        /// <param name="self">The date and time to evaluate.</param>
        /// <param name="firstDayOfWeek">
        /// The day of the week that begins the week. Defaults to
        /// <see cref="DayOfWeek.Monday"/>.
        /// </param>
        /// <returns>
        /// The first day of the containing week at midnight, preserving the
        /// original <see cref="DateTime.Kind"/>.
        /// </returns>
        public static DateTime StartOfWeek(this DateTime self, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            var difference = (7 + (int)self.DayOfWeek - (int)firstDayOfWeek) % 7;
            return self.Date.AddDays(-difference);
        }

        /// <summary>
        /// Returns the end of the week containing this date.
        /// </summary>
        /// <remarks>
        /// The returned value is the final representable tick of the last day
        /// of the week, at 23:59:59.9999999. The default first day is Monday,
        /// making Sunday the last day of the week.
        /// </remarks>
        /// <param name="self">The date and time to evaluate.</param>
        /// <param name="firstDayOfWeek">
        /// The day of the week that begins the week. Defaults to
        /// <see cref="DayOfWeek.Monday"/>.
        /// </param>
        /// <returns>
        /// The final tick of the containing week, preserving the original
        /// <see cref="DateTime.Kind"/>.
        /// </returns>
        public static DateTime EndOfWeek(this DateTime self, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
            => self
                .StartOfWeek(firstDayOfWeek)
                .AddDays(7)
                .AddTicks(-1);

        #endregion Week Helpers

        #region Time Helpers

        /// <summary>
        /// Removes the seconds and fractional seconds from this date and time.
        /// </summary>
        /// <remarks>
        /// The year, month, day, hour, and minute are preserved.
        /// The seconds and fractional seconds are set to zero.
        /// The original <see cref="DateTime.Kind"/> is preserved.
        /// </remarks>
        /// <param name="self">The date and time to truncate.</param>
        /// <returns>The date and time truncated to the beginning of the minute.</returns>
        public static DateTime TruncateToMinute(this DateTime self)
            => new(
                self.Year, self.Month, self.Day,
                self.Hour, self.Minute, 0, self.Kind);

        /// <summary>
        /// Rounds this date and time to the nearest minute.
        /// </summary>
        /// <remarks>
        /// If the seconds component is 30 or greater, the result is rounded up
        /// to the next minute. Otherwise, it is rounded down to the beginning
        /// of the current minute. Fractional seconds do not affect the rounding
        /// decision. The original <see cref="DateTime.Kind"/> is preserved.
        /// </remarks>
        /// <param name="self">The date and time to round.</param>
        /// <returns>The date and time rounded to the nearest minute.</returns>
        public static DateTime RoundToMinute(this DateTime self)
        {
            var truncated = self.TruncateToMinute();
            return self.Second >= 30
                ? truncated.AddMinutes(1)
                : truncated;
        }

        /// <summary>
        /// Removes the fractional seconds from this date and time.
        /// </summary>
        /// <remarks>
        /// The year, month, day, hour, minute, and whole seconds are preserved.
        /// Fractional seconds are set to zero.
        /// The original <see cref="DateTime.Kind"/> is preserved.
        /// </remarks>
        /// <param name="self">The date and time to truncate.</param>
        /// <returns>The date and time truncated to the beginning of the second.</returns>
        public static DateTime TruncateToSecond(this DateTime self)
            => new(
                self.Year, self.Month, self.Day,
                self.Hour, self.Minute, self.Second, self.Kind);

        #endregion Time Helpers

        #region DateOnly And TimeOnly (.NET 6+)

        /// <summary>
        /// Converts this date and time to a <see cref="DateOnly"/> value.
        /// </summary>
        /// <remarks>
        /// The time component and <see cref="DateTime.Kind"/> are not included
        /// in the resulting value.
        /// </remarks>
        /// <param name="self">The date and time to convert.</param>
        /// <returns>A <see cref="DateOnly"/> representing the date component.</returns>
        public static DateOnly ToDateOnly(this DateTime self)
            => DateOnly.FromDateTime(self);

        /// <summary>
        /// Converts this date and time to a <see cref="TimeOnly"/> value.
        /// </summary>
        /// <remarks>
        /// The date component and <see cref="DateTime.Kind"/> are not included
        /// in the resulting value.
        /// </remarks>
        /// <param name="self">The date and time to convert.</param>
        /// <returns>A <see cref="TimeOnly"/> representing the time component.</returns>
        public static TimeOnly ToTimeOnly(this DateTime self)
            => TimeOnly.FromDateTime(self);

        /// <summary>
        /// Combines a <see cref="DateOnly"/> value with a <see cref="TimeOnly"/> value
        /// to create a <see cref="DateTime"/>.
        /// </summary>
        /// <remarks>
        /// The resulting <see cref="DateTime.Kind"/> is
        /// <see cref="DateTimeKind.Unspecified"/>.
        /// </remarks>
        /// <param name="self">The date component of the resulting value.</param>
        /// <param name="time">The time component of the resulting value.</param>
        /// <returns>A <see cref="DateTime"/> combining the specified date and time.</returns>
        public static DateTime ToDateTime(this DateOnly self, TimeOnly time)
            => self.ToDateTime(time);

        #endregion DateOnly And TimeOnly
    }
}
