namespace BlackwaterSoftware.Extensions.Tests.EnumerableTests
{
    public class IterationHelperTests
    {
        [Fact]
        public void ForEach_ExecutesActionForEveryItem()
        {
            var items = new[] { 1, 2, 3 };
            var results = new List<int>();

            items.ForEach(x => results.Add(x * 2));

            Assert.Equal(new[] { 2, 4, 6 }, results);
        }

        [Fact]
        public void ForEach_ExecutesActionInSequenceOrder()
        {
            var items = new[] { 3, 1, 2 };
            var results = new List<int>();

            items.ForEach(results.Add);

            Assert.Equal(new[] { 3, 1, 2 }, results);
        }

        [Fact]
        public void ForEach_DoesNotExecuteActionForEmptySequence()
        {
            var items = Array.Empty<int>();
            var actionCalls = 0;

            items.ForEach(_ => actionCalls++);

            Assert.Equal(0, actionCalls);
        }

        [Fact]
        public void ForEach_ThrowsWhenSourceIsNull()
        {
            IEnumerable<int> items = null!;

            Assert.Throws<ArgumentNullException>(
                () => items.ForEach(_ => { }));
        }

        [Fact]
        public void ForEach_ThrowsWhenActionIsNull()
        {
            var items = new[] { 1, 2, 3 };

            Assert.Throws<ArgumentNullException>(
                () => items.ForEach(null!));
        }

        [Fact]
        public void ForEach_ExecutesActionExactlyOncePerItem()
        {
            var items = new[] { 1, 2, 3, 4, 5 };
            var actionCalls = 0;

            items.ForEach(_ => actionCalls++);

            Assert.Equal(items.Length, actionCalls);
        }

        [Fact]
        public void ForEach_PropagatesExceptionThrownByAction()
        {
            var items = new[] { 1, 2, 3 };

            Assert.Throws<InvalidOperationException>(() =>
                items.ForEach(x =>
                {
                    if (x == 2)
                        throw new InvalidOperationException("Test exception.");
                }));
        }

        [Fact]
        public void ForEach_StopsIterationWhenActionThrows()
        {
            var items = new[] { 1, 2, 3, 4 };
            var processed = new List<int>();

            Assert.Throws<InvalidOperationException>(() =>
                items.ForEach(x =>
                {
                    processed.Add(x);

                    if (x == 2)
                        throw new InvalidOperationException();
                }));

            Assert.Equal(new[] { 1, 2 }, processed);
        }
    }
}
