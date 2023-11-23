using algorithms.AbstractDataTypes;
using algorithmTests.Utilities;
using Xunit.Abstractions;

namespace algorithmTests.AbstractDataTypes
{
    public class BinaryHeapTests
    {
        BinaryHeapHelper _heap;
        public BinaryHeapTests(ITestOutputHelper helper)
        {
            Helper = helper;
            IAlgoLogger logger = new UnitTestLogger(Helper);
            _heap = new BinaryHeapHelper(logger);
        }

        public ITestOutputHelper Helper { get; }

        [Fact]
        public void BinaryHeap_Insert_OneElement()
        {
            Span<int> expectedHeapValues = new Span<int>(new[] { 9 });

            LogHeap("Before");
            _heap.Insert(9);
            LogHeap("After");            

            bool result = _heap.IsHeapValid();
            Assert.True(result);

            ReadOnlySpan<int> heapValues = _heap.GetHeapValues();
            Assert.True(expectedHeapValues.SequenceEqual(heapValues));
        }

        [Fact]
        public void BinaryHeap_Insert_TwoElement()
        {
            Span<int> expectedHeapValues = new Span<int>(new[] { 9, 8 });

            LogHeap("Before");
            _heap.Insert(9);
            _heap.Insert(8);
            LogHeap("After");            

            bool result = _heap.IsHeapValid();
            Assert.True(result);

            ReadOnlySpan<int> heapValues = _heap.GetHeapValues();
            Assert.True(expectedHeapValues.SequenceEqual(heapValues));
        }

        [Fact]
        public void BinaryHeap_Insert_TwoElement_SecondElementIsGreater()
        {
            Span<int> expectedHeapValues = new Span<int>(new[] { 10, 9 });

            LogHeap("Before");
            _heap.Insert(9);
            _heap.Insert(10);
            LogHeap("After");

            bool result = _heap.IsHeapValid();
            Assert.True(result);

            ReadOnlySpan<int> heapValues = _heap.GetHeapValues();
            Assert.True(expectedHeapValues.SequenceEqual(heapValues));
        }

        [Fact]
        public void BinaryHeap_FourElements_Extract_OneElement()
        {
            _heap.Insert(6);
            _heap.Insert(7);
            _heap.Insert(8);
            _heap.Insert(9);

            LogHeap("Before Extract");
            int root = _heap.Extract();
            LogHeap("After");

            Assert.Equal(9, root);
            Assert.True(_heap.IsHeapValid());
        }

        [Fact]
        public void BinaryHeap_Extract_HeapIsEmpty()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _heap.Extract());
        }

        [Fact]
        public void BinaryHeap_SortDescending()
        {
            _heap.Insert(0);
            _heap.Insert(1);
            _heap.Insert(2);
            _heap.Insert(3);
            _heap.Insert(4);
            _heap.Insert(5);

            LogHeap("Before");
            List<int> numbersSorted = new List<int>();
            while(!_heap.IsHeapEmpty)
            {
                int number = _heap.Extract();
                numbersSorted.Add(number);
            }
            LogHeap("After");

            Helper.WriteLine($"[Sorted] [{string.Join("|", numbersSorted)}]");
            Assert.Collection(numbersSorted
                    , num => { Assert.Equal(5, num); }
                    , num => { Assert.Equal(4, num); }
                    , num => { Assert.Equal(3, num); }
                    , num => { Assert.Equal(2, num); }
                    , num => { Assert.Equal(1, num); }
                    , num => { Assert.Equal(0, num); }
                );
        }

        private void LogHeap(string description)
        {
            Helper.WriteLine("[INFO] {0}: {1}", description, _heap.OutputHeapAsString());
        }
    }
}
