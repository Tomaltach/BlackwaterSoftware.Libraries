namespace BlackwaterSoftware.Extensions.Tests.EnumerableTests
{
    public class IndexHelperTests
    {
        [Fact]
        public void WithIndex_ReturnsEachItemWithZeroBasedIndex()
        {
            var items = new[] { "Apple", "Banana", "Cherry" };

            var result = items.WithIndex().ToList();

            Assert.Collection(
                result,
                item => Assert.Equal(("Apple", 0), item),
                item => Assert.Equal(("Banana", 1), item),
                item => Assert.Equal(("Cherry", 2), item));
        }

        [Fact]
        public void WithIndex_ReturnsEmptySequenceForEmptySource()
        {
            var items = Array.Empty<int>();

            Assert.Empty(items.WithIndex());
        }

        [Fact]
        public void WithIndex_ThrowsWhenSourceIsNull()
        {
            IEnumerable<int> items = null!;

            Assert.Throws<ArgumentNullException>(() => items.WithIndex());
        }

        [Fact]
        public void WithIndex_PreservesDuplicateItemsWithDistinctIndices()
        {
            var items = new[] { 5, 5, 5 };

            var result = items.WithIndex().ToList();

            Assert.Equal(
                new[] { (5, 0), (5, 1), (5, 2) },
                result);
        }

        [Fact]
        public void IndexOf_ReturnsIndexOfMatchingItem()
        {
            var items = new[] { 10, 20, 30, 40 };

            var result = items.IndexOf(x => x == 30);

            Assert.Equal(2, result);
        }

        [Fact]
        public void IndexOf_ReturnsFirstMatchingIndex()
        {
            var items = new[] { 10, 20, 10, 30 };

            var result = items.IndexOf(x => x == 10);

            Assert.Equal(0, result);
        }

        [Fact]
        public void IndexOf_ReturnsNegativeOneWhenNoItemMatches()
        {
            var items = new[] { 10, 20, 30 };

            var result = items.IndexOf(x => x == 99);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void IndexOf_ReturnsNegativeOneForEmptySequence()
        {
            var items = Array.Empty<int>();

            Assert.Equal(-1, items.IndexOf(x => x > 0));
        }

        [Fact]
        public void IndexOf_ThrowsWhenSourceIsNull()
        {
            IEnumerable<int> items = null!;

            Assert.Throws<ArgumentNullException>(
                () => items.IndexOf(x => x > 0));
        }

        [Fact]
        public void IndexOf_ThrowsWhenPredicateIsNull()
        {
            var items = new[] { 1, 2, 3 };

            Assert.Throws<ArgumentNullException>(
                () => items.IndexOf(null!));
        }

        [Fact]
        public void IndexOf_StopsEvaluatingAfterFirstMatch()
        {
            var items = new[] { 10, 20, 30, 40 };
            var evaluated = new List<int>();

            var result = items.IndexOf(x =>
            {
                evaluated.Add(x);
                return x == 20;
            });

            Assert.Equal(1, result);
            Assert.Equal(new[] { 10, 20 }, evaluated);
        }
    }
}
