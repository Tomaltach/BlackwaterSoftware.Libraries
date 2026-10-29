namespace BlackwaterSoftware.Extensions
{
    public static class EnumerableExtensions
    {
        #region Index Helpers

        /// <summary>
        /// Returns each item in the sequence paired with its zero-based index.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="self">The sequence to enumerate.</param>
        /// <returns>
        /// An enumerable sequence of tuples containing each item and its zero-based index.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="self"/> is <see langword="null"/>.
        /// </exception>
        public static IEnumerable<(T Item, int Index)> WithIndex<T>(this IEnumerable<T> self)
        {
            ArgumentNullException.ThrowIfNull(self);
            return self.Select((item, index) => (item, index));
        }

        /// <summary>
        /// Returns each item in the sequence paired with its zero-based index.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="self">The sequence to enumerate.</param>
        /// <returns>
        /// An enumerable sequence of tuples containing each item and its zero-based index.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="self"/> is <see langword="null"/>.
        /// </exception>
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
        /// Returns the source sequence, or an empty sequence if the source is null.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="self">The sequence to evaluate, which may be null.</param>
        /// <returns>
        /// The original sequence if it is not null; otherwise, an empty sequence.
        /// </returns>
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T>? self)
            => self ?? Enumerable.Empty<T>();

        /// <summary>
        /// Determines whether the sequence is null or contains no elements.
        /// </summary>
        /// <remarks>
        /// This method may enumerate the source sequence to determine whether
        /// at least one element exists.
        /// </remarks>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="self">The sequence to evaluate, which may be null.</param>
        /// <returns>
        /// <see langword="true"/> if the sequence is null or contains no elements;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T>? self)
            => self is null || !self.Any();

        /// <summary>
        /// Determines whether the sequence contains at least one element.
        /// </summary>
        /// <remarks>
        /// This method may enumerate the source sequence to determine whether
        /// at least one element exists.
        /// </remarks>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="self">The sequence to evaluate, which may be null.</param>
        /// <returns>
        /// <see langword="true"/> if the sequence is not null and contains at least
        /// one element; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool HasItems<T>(this IEnumerable<T>? self)
            => self is not null && self.Any();

        /// <summary>
        /// Returns a sequence containing only the non-null elements of the source.
        /// </summary>
        /// <remarks>
        /// Null elements are excluded. If the source sequence is null, an empty
        /// sequence is returned. The source is enumerated when the returned
        /// sequence is consumed.
        /// </remarks>
        /// <typeparam name="T">The reference type of elements in the sequence.</typeparam>
        /// <param name="self">The sequence to filter, which may be null.</param>
        /// <returns>
        /// A sequence containing only non-null elements of type <typeparamref name="T"/>.
        /// </returns>
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?>? self) where T : class
            => (self ?? Enumerable.Empty<T?>()).OfType<T>();

        #endregion Null Helpers

        #region Conditional Helpers

        /// <summary>
        /// Appends an item to the sequence if the specified condition is true.
        /// </summary>
        /// <remarks>
        /// If the condition is false, the original sequence is returned.
        /// The source sequence is not modified. Enumeration is deferred.
        /// </remarks>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="self">The source sequence.</param>
        /// <param name="condition">The condition determining whether to append the item.</param>
        /// <param name="item">The item to append when the condition is true.</param>
        /// <returns>
        /// A sequence containing the original elements and, when the condition
        /// is true, the appended item.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="self"/> is <see langword="null"/>.
        /// </exception>
        public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> self, bool condition, T item)
        {
            ArgumentNullException.ThrowIfNull(self);
            return condition ? self.Append(item) : self;
        }

        /// <summary>
        /// Prepends an item to the sequence if the specified condition is true.
        /// </summary>
        /// <remarks>
        /// If the condition is false, the original sequence is returned.
        /// The source sequence is not modified. Enumeration is deferred.
        /// </remarks>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="self">The source sequence.</param>
        /// <param name="condition">The condition determining whether to prepend the item.</param>
        /// <param name="item">The item to prepend when the condition is true.</param>
        /// <returns>
        /// A sequence containing the prepended item followed by the original elements
        /// when the condition is true; otherwise, the original sequence.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="self"/> is <see langword="null"/>.
        /// </exception>
        public static IEnumerable<T> PrependIf<T>(this IEnumerable<T> self, bool condition, T item)
        {
            ArgumentNullException.ThrowIfNull(self);
            return condition ? self.Prepend(item) : self;
        }

        #endregion Conditional Helpers

        #region Collection Helpers

        /// <summary>
        /// Splits a sequence into matching and non-matching elements using a predicate.
        /// </summary>
        /// <remarks>
        /// The source sequence is enumerated exactly once, and the predicate is
        /// evaluated once for each element. The matching and non-matching elements
        /// retain their original relative order. Both result collections are
        /// materialized as lists before the method returns.
        /// </remarks>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="self">The source sequence to partition.</param>
        /// <param name="predicate">The function used to determine whether an element matches.</param>
        /// <returns>
        /// A tuple containing a list of matching elements and a list of non-matching
        /// elements, in that order.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="self"/> or <paramref name="predicate"/> is
        /// <see langword="null"/>.
        /// </exception>
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
        /// Executes the specified action for each element in the sequence.
        /// </summary>
        /// <remarks>
        /// Elements are processed in sequence order. If the action throws an
        /// exception, the exception propagates to the caller and iteration stops.
        /// </remarks>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="self">The sequence whose elements will be processed.</param>
        /// <param name="action">The action to execute for each element.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="self"/> or <paramref name="action"/> is
        /// <see langword="null"/>.
        /// </exception>
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
