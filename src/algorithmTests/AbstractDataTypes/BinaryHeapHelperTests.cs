using algorithms.Utilities;
using algorithmTests.Utilities;
using Xunit.Abstractions;

namespace algorithmTests.AbstractDataTypes
{
    public class BinaryHeapHelperTests
    {
        private readonly BinaryHeapHelper<int> _helper;

        public BinaryHeapHelperTests(ITestOutputHelper helper)
        {
            Helper = helper;
            _helper = new BinaryHeapHelper<int>(new MaxHeapType<int>(), new UnitTestLogger(helper));
        }

        public ITestOutputHelper Helper { get; }

        [Fact]
        public void HeapValidation_Successful()
        {
            int[] data = new int[100];
            data[1] = 9;

            _helper.SetHeap(data, 2);

            bool result = _helper.IsHeapValid();

            Assert.True(result);
        }

        [Fact]
        public void HeapValidation_Successful_ThreeElements()
        {
            int[] data = new int[100];
            data[1] = 9;
            data[2] = 8;
            data[3] = 7;

            _helper.SetHeap(data, 4);

            bool result = _helper.IsHeapValid();

            Assert.True(result);
        }

        [Fact]
        public void HeapValidation_NotSuccessful()
        {
            int[] data = new int[100];
            data[1] = 9;
            data[2] = 10;
            data[3] = 7;

            _helper.SetHeap(data, 4);

            bool result = _helper.IsHeapValid();

            Assert.False(result);
        }
    }
}
