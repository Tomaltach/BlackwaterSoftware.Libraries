namespace BlackwaterSoftware.Extensions.Tests.EnumerableTests
{
    public class CollectionHelperTests
    {
        [Fact]
        public void Partition_SplitsMatchingAndNonMatchingItems()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6 };

            var (matching, nonMatching) =
                items.Partition(x => x % 2 == 0);

            Assert.Equal(new[] { 2, 4, 6 }, matching);
            Assert.Equal(new[] { 1, 3, 5 }, nonMatching);
        }

        [Fact]
        public void Partition_ReturnsEmptyListsForEmptySource()
        {
            var items = Array.Empty<int>();

            var (matching, nonMatching) =
                items.Partition(x => x > 0);

            Assert.Empty(matching);
            Assert.Empty(nonMatching);
        }

        [Fact]
        public void Partition_PutsAllItemsInMatchingWhenPredicateAlwaysTrue()
        {
            var items = new[] { 1, 2, 3 };

            var (matching, nonMatching) =
                items.Partition(_ => true);

            Assert.Equal(items, matching);
            Assert.Empty(nonMatching);
        }

        [Fact]
        public void Partition_PutsAllItemsInNonMatchingWhenPredicateAlwaysFalse()
        {
            var items = new[] { 1, 2, 3 };

            var (matching, nonMatching) =
                items.Partition(_ => false);

            Assert.Empty(matching);
            Assert.Equal(items, nonMatching);
        }

        [Fact]
        public void Partition_PreservesOriginalOrder()
        {
            var items = new[] { 9, 2, 7, 4, 5, 6 };

            var (matching, nonMatching) =
                items.Partition(x => x % 2 == 0);

            Assert.Equal(new[] { 2, 4, 6 }, matching);
            Assert.Equal(new[] { 9, 7, 5 }, nonMatching);
        }

        [Fact]
        public void Partition_ThrowsWhenSourceIsNull()
        {
            IEnumerable<int> items = null!;

            Assert.Throws<ArgumentNullException>(
                () => items.Partition(x => x > 0));
        }

        [Fact]
        public void Partition_ThrowsWhenPredicateIsNull()
        {
            var items = new[] { 1, 2, 3 };

            Assert.Throws<ArgumentNullException>(
                () => items.Partition(null!));
        }

        [Fact]
        public void Partition_EvaluatesPredicateOncePerItem()
        {
            var items = new[] { 1, 2, 3, 4 };
            var predicateCalls = 0;

            var (matching, nonMatching) = items.Partition(x =>
            {
                predicateCalls++;
                return x % 2 == 0;
            });

            Assert.Equal(4, predicateCalls);
            Assert.Equal(new[] { 2, 4 }, matching);
            Assert.Equal(new[] { 1, 3 }, nonMatching);
        }

        [Fact]
        public void Partition_EnumeratesSourceOnlyOnce()
        {
            var source = new SingleEnumerationEnumerable<int>(new[] { 1, 2, 3, 4 });

            var (matching, nonMatching) =
                source.Partition(x => x % 2 == 0);

            Assert.Equal(new[] { 2, 4 }, matching);
            Assert.Equal(new[] { 1, 3 }, nonMatching);
            Assert.Equal(1, source.EnumerationCount);
        }

        private sealed class SingleEnumerationEnumerable<T>(IEnumerable<T> items) : IEnumerable<T>
        {
            private readonly IEnumerable<T> _items = items;

            public int EnumerationCount { get; private set; }

            public IEnumerator<T> GetEnumerator()
            {
                EnumerationCount++;

                if (EnumerationCount > 1)
                    throw new InvalidOperationException("The sequence was enumerated more than once.");

                return _items.GetEnumerator();
            }

            System.Collections.IEnumerator
                System.Collections.IEnumerable.GetEnumerator()
                => GetEnumerator();
        }
    }
}
