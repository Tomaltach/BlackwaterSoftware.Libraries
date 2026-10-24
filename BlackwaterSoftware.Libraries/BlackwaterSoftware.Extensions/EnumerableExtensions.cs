namespace BlackwaterSoftware.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
            => self.Select((item, index) => (item, index));

        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> self)
            => self ?? Enumerable.Empty<T>();
    }
}
