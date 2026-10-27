namespace BlackwaterSoftware.Extensions
{
    public static class EnumerableExtensions
    {
        #region Index Helpers
        /// <summary>
        /// Returns each item alongside its zero-based index.
        /// </summary>
        public static IEnumerable<(T Item, int Index)> WithIndex<T>(this IEnumerable<T> self)
        {
            ArgumentNullException.ThrowIfNull(self);
            return self.Select((item, index) => (item, index));
        }

        /// <summary>
        /// Returns the zero-based index of the first item matching
        /// the specified predicate, or -1 if no item matches.
        /// </summary>
        public static int IndexOf<T>(this IEnumerable<T> self, Func<T, bool> predicate)
        {
            ArgumentNullException.ThrowIfNull(self);
            ArgumentNullException.ThrowIfNull(predicate);

            var index = 0;

            foreach (var item in self)
            {
                if (predicate(item))
                    return index;

                index = checked(index + 1);
            }

            return -1;
        }
        #endregion Index Helpers

        #region Null Helpers
        /// <summary>
        /// Returns an empty sequence if the source is null.
        /// </summary>
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T>? self)
            => self ?? Enumerable.Empty<T>();

        /// <summary>
        /// Determines whether the sequence is null or contains no items.
        /// May enumerate the source.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T>? self)
            => self is null || !self.Any();

        /// <summary>
        /// Determines whether the sequence contains at least one item.
        /// May enumerate the source.
        /// </summary>
        public static bool HasItems<T>(this IEnumerable<T>? self)
            => self is not null && self.Any();

        /// <summary>
        /// Filters out null elements from a sequence of reference types.
        /// A null source produces an empty sequence.
        /// </summary>
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?>? self) where T : class
            => (self ?? Enumerable.Empty<T?>()).OfType<T>();
        #endregion Null Helpers

        #region Conditional Helpers
        /// <summary>
        /// Appends an item only when the condition is true.
        /// </summary>
        public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> self, bool condition, T item)
        {
            ArgumentNullException.ThrowIfNull(self);
            return condition ? self.Append(item) : self;
        }

        /// <summary>
        /// Prepends an item only when the condition is true.
        /// </summary>
        public static IEnumerable<T> PrependIf<T>(this IEnumerable<T> self, bool condition, T item)
        {
            ArgumentNullException.ThrowIfNull(self);
            return condition ? self.Prepend(item) : self;
        }
        #endregion Conditional Helpers

        #region Collection Helpers
        /// <summary>
        /// Splits a sequence into matching and non-matching items.
        /// Enumerates the source once and evaluates the predicate once
        /// per item. The results are materialized into lists.
        /// </summary>
        public static (List<T> Matching, List<T> NonMatching) Partition<T>(this IEnumerable<T> self, Func<T, bool> predicate)
        {
            ArgumentNullException.ThrowIfNull(self);
            ArgumentNullException.ThrowIfNull(predicate);

            var matching = new List<T>();
            var nonMatching = new List<T>();

            foreach (var item in self)
            {
                if (predicate(item)) matching.Add(item);
                else nonMatching.Add(item);
            }

            return (matching, nonMatching);
        }
        #endregion Collection Helpers

        #region Iteration Helpers
        /// <summary>
        /// Executes an action for each item in the sequence.
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> self, Action<T> action)
        {
            ArgumentNullException.ThrowIfNull(self);
            ArgumentNullException.ThrowIfNull(action);

            foreach (var item in self)
                action(item);
        }
        #endregion Iteration Helpers
    }
}
