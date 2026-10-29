# BlackwaterSoftware.Extensions

A collection of useful C# extension methods for working with dates, times, and enumerable sequences.

`BlackwaterSoftware.Extensions` provides reusable utilities designed to simplify common operations, reduce boilerplate code, and improve readability in .NET applications.

## Features

- **DateTime Extensions** — Age calculations, business days, date boundaries, calendar operations, week helpers, time rounding, Unix timestamps, and `DateOnly`/`TimeOnly` conversions.
- **Enumerable Extensions** — Indexed enumeration, null-safe sequence handling, conditional additions, partitioning, and iteration helpers.

## Installation

Install the package from NuGet:

```bash
dotnet add package BlackwaterSoftware.Extensions
```

Or use the NuGet Package Manager in Visual Studio to search for `BlackwaterSoftware.Extensions`.

## Usage

Import the namespace:

```csharp
using BlackwaterSoftware.Extensions;
```

The examples below demonstrate the available extension methods.

---

# DateTime Extensions

## Age Calculations

Calculate age using today's local date or a specified reference date.

```csharp
var birthDate = new DateTime(2000, 5, 15);

int age = birthDate.CalculateAge();

int ageAtDate = birthDate.CalculateAgeAt(
    new DateTime(2025, 5, 15));
```

`CalculateAgeAt` throws an `ArgumentOutOfRangeException` if the birth date is after the reference date.

February 29 birthdays are treated as February 28 in non-leap years.

## Date Range Checks

Check whether a date falls within an inclusive or exclusive range.

```csharp
var date = new DateTime(2025, 6, 15);
var start = new DateTime(2025, 6, 1);
var end = new DateTime(2025, 6, 30);

bool isBetween = date.Between(start, end);

bool isBetweenExclusive =
    date.IsBetweenExclusive(start, end);
```

- `Between` includes both endpoints.
- `IsBetweenExclusive` excludes both endpoints.

## Business Days

Add or subtract weekdays, excluding the starting date.

```csharp
var date = new DateTime(2025, 6, 13); // Friday

var nextBusinessDay = date.AddBusinessDays(1);
// Monday, June 16

var previousBusinessDay = date.SubtractBusinessDays(1);
// Thursday, June 12

bool isWorkday = date.IsWorkDay();
bool isWeekend = date.IsWeekend();

var nextWorkday = date.NextWorkday();
var previousWorkday = date.PreviousWorkday();
```

Count business days between dates:

```csharp
var start = new DateTime(2025, 6, 2);
var end = new DateTime(2025, 6, 6);

int businessDays =
    DateTimeExtensions.GetBusinessDays(start, end);

int inclusiveDays =
    DateTimeExtensions.CountBusinessDaysInclusive(
        start, end);
```

- `GetBusinessDays` excludes the start date and includes the end date. Reversed ranges return a negative count.
- `CountBusinessDaysInclusive` counts both endpoints and requires the start date to be on or before the end date.

Business-day calculations exclude Saturdays and Sundays. Public holidays are not excluded.

## Date Helpers

Get the beginning or end of a day and perform common date comparisons.

```csharp
var date = new DateTime(2025, 6, 15, 14, 30, 45);

DateTime startOfDay = date.StartOfDay();
DateTime endOfDay = date.EndOfDay();

bool isToday = date.IsToday();
bool isYesterday = date.IsYesterday();
bool isTomorrow = date.IsTomorrow();

bool isPast = date.IsInThePast();
bool isFuture = date.IsInTheFuture();

bool sameDate = date.IsSameDate(
    new DateTime(2025, 6, 15, 8, 0, 0));

bool sameMonth = date.IsSameMonth(
    new DateTime(2025, 6, 1));

bool sameYear = date.IsSameYear(
    new DateTime(2024, 6, 15));

bool sameDayOfWeek = date.IsSameDayOfWeek(
    new DateTime(2025, 6, 18));

bool firstDayOfMonth = date.IsFirstDayOfMonth();
bool lastDayOfMonth = date.IsLastDayOfMonth();

bool firstDayOfYear = date.IsFirstDayOfYear();
bool lastDayOfYear = date.IsLastDayOfYear();
```

Clamp a date to an inclusive range:

```csharp
var min = new DateTime(2025, 1, 1);
var max = new DateTime(2025, 12, 31);
var date = new DateTime(2026, 3, 1);

DateTime clamped = date.Clamp(min, max);
// December 31, 2025
```

`Clamp` throws an `ArgumentException` if the minimum exceeds the maximum.

## Calendar Helpers

Get month and year boundaries, calculate the number of days in a month, and work with leap years and ISO week numbers.

```csharp
var date = new DateTime(2025, 6, 15);

DateTime startOfMonth = date.StartOfMonth();
DateTime endOfMonth = date.EndOfMonth();

DateTime startOfYear = date.StartOfYear();
DateTime endOfYear = date.EndOfYear();

int daysInMonth = date.DaysInMonth();

bool isLeapYear = date.IsLeapYear();

int isoWeek = date.GetIsoWeekOfYear();
```

Month and year end helpers return the final tick of the relevant period.

## Relative Dates

Move forwards or backwards by a day, week, month, or year.

```csharp
var date = new DateTime(2025, 6, 15);

DateTime previousDay = date.PreviousDay();
DateTime nextDay = date.NextDay();

DateTime previousWeek = date.PreviousWeek();
DateTime nextWeek = date.NextWeek();

DateTime previousMonth = date.PreviousMonth();
DateTime nextMonth = date.NextMonth();

DateTime previousYear = date.PreviousYear();
DateTime nextYear = date.NextYear();
```

Month and year operations follow standard .NET `DateTime.AddMonths` and `DateTime.AddYears` behaviour, including adjusting dates such as January 31 or February 29 when necessary.

## Week Helpers

Get the start and end of a week, with Monday as the default first day.

```csharp
var date = new DateTime(2025, 6, 18); // Wednesday

DateTime weekStart = date.StartOfWeek();
// Monday, June 16

DateTime weekEnd = date.EndOfWeek();
// Sunday, June 22, at 23:59:59.9999999
```

Specify a different first day when required:

```csharp
DateTime sundayStart =
    date.StartOfWeek(DayOfWeek.Sunday);

DateTime sundayEnd =
    date.EndOfWeek(DayOfWeek.Sunday);
```

## Time Helpers

Truncate or round a date and time to the nearest minute or truncate it to the nearest second.

```csharp
var date = new DateTime(
    2025, 6, 15, 14, 30, 45);

DateTime truncatedMinute = date.TruncateToMinute();
// 14:30:00

DateTime roundedMinute = date.RoundToMinute();
// 14:31:00

DateTime truncatedSecond = date.TruncateToSecond();
// 14:30:45
```

`RoundToMinute` rounds up when the seconds component is 30 or greater. Otherwise, it rounds down.

## DateTimeOffset and Unix Timestamps

Convert a `DateTime` to a `DateTimeOffset` with boundary protection, or obtain Unix timestamps.

```csharp
var date = new DateTime(
    2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);

DateTimeOffset offset =
    date.ToDateTimeOffsetOutOfRangeProtected();

long seconds = date.ToUnixTimestampSeconds();
long milliseconds = date.ToUnixTimestampMilliseconds();
```

Unix timestamps represent elapsed time relative to the Unix epoch, January 1, 1970 UTC.

`ToDateTimeOffsetOutOfRangeProtected` clamps UTC values outside the representable `DateTimeOffset` range. Unspecified `DateTime` values are interpreted as local time.

## DateOnly and TimeOnly (.NET 6+)

Convert between `DateTime`, `DateOnly`, and `TimeOnly`.

```csharp
var date = new DateTime(
    2025, 6, 15, 14, 30, 45);

DateOnly dateOnly = date.ToDateOnly();
TimeOnly timeOnly = date.ToTimeOnly();

DateTime combined = dateOnly.ToDateTime(timeOnly);
```

---

# Enumerable Extensions

## Index Helpers

Enumerate items alongside their zero-based indices.

```csharp
var fruits = new[] { "Apple", "Banana", "Cherry" };

foreach (var (item, index) in fruits.WithIndex())
{
    Console.WriteLine($"{index}: {item}");
}
```

Find the index of the first item matching a predicate:

```csharp
int index = fruits.IndexOf(
    fruit => fruit == "Banana");

// 1
```

`IndexOf` returns `-1` if no item matches.

Both methods throw an `ArgumentNullException` when their required arguments are null.

## Null Helpers

Handle null or empty sequences without repeatedly writing null checks.

```csharp
IEnumerable<string>? items = null;

var safeItems = items.EmptyIfNull();

bool empty = items.IsNullOrEmpty();
// true

bool hasItems = items.HasItems();
// false
```

Filter null elements from a sequence of reference types:

```csharp
string?[] values =
{
    "Apple",
    null,
    "Banana",
    null
};

var nonNullValues = values.WhereNotNull();

// Apple, Banana
```

- `EmptyIfNull` returns an empty sequence when the source is null.
- `IsNullOrEmpty` determines whether a sequence is null or empty.
- `HasItems` determines whether a sequence contains at least one item.
- `WhereNotNull` filters null elements from a sequence of reference types and returns an empty sequence for a null source.

`IsNullOrEmpty` and `HasItems` may enumerate the source.

## Conditional Helpers

Append or prepend an item only when a condition is true.

```csharp
var numbers = new[] { 2, 3, 4 };

var withStart = numbers.PrependIf(true, 1);
// 1, 2, 3, 4

var withEnd = numbers.AppendIf(true, 5);
// 2, 3, 4, 5

var unchanged = numbers.AppendIf(false, 6);
// 2, 3, 4
```

These helpers compose with LINQ and do not modify the original collection.

## Collection Helpers

Split a sequence into matching and non-matching items using `Partition`.

```csharp
var numbers = new[] { 1, 2, 3, 4, 5, 6 };

var (matching, nonMatching) =
    numbers.Partition(number => number % 2 == 0);

// matching:    2, 4, 6
// nonMatching: 1, 3, 5
```

`Partition`:

- Enumerates the source once.
- Evaluates the predicate once per item.
- Preserves the order of each group.
- Materializes both results into lists.

## Iteration Helpers

Execute an action for every item in a sequence.

```csharp
var names = new[] { "Alice", "Bob", "Charlie" };

names.ForEach(name =>
{
    Console.WriteLine(name);
});
```

`ForEach` processes items in sequence order. Exceptions thrown by the action propagate to the caller and stop further iteration.

---

## Requirements

- A .NET target framework compatible with the published package.
- The `DateOnly` and `TimeOnly` helpers require .NET 6 or later.

Check the package's NuGet metadata for the exact supported target frameworks.

## Testing

The library is covered by an xUnit test project.

Run the tests from the solution directory:

```bash
dotnet test
```

## License

See the repository's `LICENSE` file for licensing terms.

## Contributing

Bug reports, suggestions, and improvements are welcome through the repository's issue tracker and pull requests.