namespace BlackwaterSoftware.Extensions.Tests.EnumerableTests
{
    public class NullHelperTests
    {
        [Fact]
        public void EmptyIfNull_ReturnsEmptySequenceWhenSourceIsNull()
        {
            IEnumerable<int>? items = null;

            Assert.Empty(items.EmptyIfNull());
        }

        [Fact]
        public void EmptyIfNull_ReturnsOriginalItemsWhenSourceIsNotNull()
        {
            var items = new[] { 1, 2, 3 };

            Assert.Equal(items, items.EmptyIfNull());
        }

        [Fact]
        public void IsNullOrEmpty_ReturnsTrueWhenSourceIsNull()
        {
            IEnumerable<int>? items = null;

            Assert.True(items.IsNullOrEmpty());
        }

        [Fact]
        public void IsNullOrEmpty_ReturnsTrueWhenSourceIsEmpty()
        {
            var items = Enumerable.Empty<int>();

            Assert.True(items.IsNullOrEmpty());
        }

        [Fact]
        public void IsNullOrEmpty_ReturnsFalseWhenSourceContainsItems()
        {
            var items = new[] { 1 };

            Assert.False(items.IsNullOrEmpty());
        }

        [Fact]
        public void HasItems_ReturnsFalseWhenSourceIsNull()
        {
            IEnumerable<int>? items = null;

            Assert.False(items.HasItems());
        }

        [Fact]
        public void HasItems_ReturnsFalseWhenSourceIsEmpty()
        {
            var items = Enumerable.Empty<int>();

            Assert.False(items.HasItems());
        }

        [Fact]
        public void HasItems_ReturnsTrueWhenSourceContainsItems()
        {
            var items = new[] { 1, 2, 3 };

            Assert.True(items.HasItems());
        }

        [Fact]
        public void WhereNotNull_RemovesNullElements()
        {
            string?[] items = { "Apple", null, "Banana", null, "Cherry" };

            var result = items.WhereNotNull().ToList();

            Assert.Equal(
                new[] { "Apple", "Banana", "Cherry" },
                result);
        }

        [Fact]
        public void WhereNotNull_ReturnsEmptySequenceWhenSourceIsNull()
        {
            IEnumerable<string?>? items = null;

            Assert.Empty(items.WhereNotNull());
        }

        [Fact]
        public void WhereNotNull_ReturnsEmptySequenceWhenAllItemsAreNull()
        {
            string?[] items = { null, null, null };

            Assert.Empty(items.WhereNotNull());
        }

        [Fact]
        public void WhereNotNull_PreservesOrderAndDuplicates()
        {
            string?[] items = { "Apple", null, "Apple", "Banana" };

            var result = items.WhereNotNull().ToList();

            Assert.Equal(new[] { "Apple", "Apple", "Banana" }, result);
        }
    }
}
