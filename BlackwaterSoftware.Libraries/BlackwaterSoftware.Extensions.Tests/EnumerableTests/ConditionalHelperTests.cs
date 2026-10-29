namespace BlackwaterSoftware.Extensions.Tests.EnumerableTests
{
    public class ConditionalHelperTests
    {
        [Fact]
        public void AppendIf_AppendsItemWhenConditionIsTrue()
        {
            var items = new[] { 1, 2, 3 };

            var result = items.AppendIf(true, 4).ToList();

            Assert.Equal(new[] { 1, 2, 3, 4 }, result);
        }

        [Fact]
        public void AppendIf_DoesNotAppendItemWhenConditionIsFalse()
        {
            var items = new[] { 1, 2, 3 };

            var result = items.AppendIf(false, 4).ToList();

            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public void AppendIf_WorksWithEmptySource()
        {
            var items = Array.Empty<int>();

            Assert.Equal(new[] { 4 }, items.AppendIf(true, 4));
            Assert.Empty(items.AppendIf(false, 4));
        }

        [Fact]
        public void AppendIf_ThrowsWhenSourceIsNull()
        {
            IEnumerable<int> items = null!;

            Assert.Throws<ArgumentNullException>(
                () => items.AppendIf(true, 4));
        }

        [Fact]
        public void PrependIf_PrependsItemWhenConditionIsTrue()
        {
            var items = new[] { 1, 2, 3 };

            var result = items.PrependIf(true, 0).ToList();

            Assert.Equal(new[] { 0, 1, 2, 3 }, result);
        }

        [Fact]
        public void PrependIf_DoesNotPrependItemWhenConditionIsFalse()
        {
            var items = new[] { 1, 2, 3 };

            var result = items.PrependIf(false, 0).ToList();

            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public void PrependIf_WorksWithEmptySource()
        {
            var items = Array.Empty<int>();

            Assert.Equal(new[] { 0 }, items.PrependIf(true, 0));
            Assert.Empty(items.PrependIf(false, 0));
        }

        [Fact]
        public void PrependIf_ThrowsWhenSourceIsNull()
        {
            IEnumerable<int> items = null!;

            Assert.Throws<ArgumentNullException>(
                () => items.PrependIf(true, 0));
        }

        [Fact]
        public void AppendIf_DoesNotModifyOriginalCollection()
        {
            var items = new List<int> { 1, 2, 3 };

            _ = items.AppendIf(true, 4).ToList();

            Assert.Equal(new[] { 1, 2, 3 }, items);
        }

        [Fact]
        public void PrependIf_DoesNotModifyOriginalCollection()
        {
            var items = new List<int> { 1, 2, 3 };

            _ = items.PrependIf(true, 0).ToList();

            Assert.Equal(new[] { 1, 2, 3 }, items);
        }
    }
}
