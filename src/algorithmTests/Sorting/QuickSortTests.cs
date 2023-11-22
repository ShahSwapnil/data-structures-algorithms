using Xunit.Abstractions;

namespace algorithmTests;

public class QuickSortTests
{
    public class SortIntegersDescendingWithHoare : QuickSorterTestsBase
    {
        public SortIntegersDescendingWithHoare(ITestOutputHelper testOutputHelper) 
            : base(SortOrder.Descending, testOutputHelper) {}

        [Fact]
        public void Sort()
        {
            int[] numbers = [14,10,1,30,11,9,4,35];

            Dut.Sort(numbers);

            Assert.Collection(numbers 
                , e => { Assert.Equal(35, e); }
                , e => { Assert.Equal(30, e); }
                , e => { Assert.Equal(14, e); }
                , e => { Assert.Equal(11, e); }
                , e => { Assert.Equal(10, e); }
                , e => { Assert.Equal(9, e); }
                , e => { Assert.Equal(4, e); }
                , e => { Assert.Equal(1, e); }
            );
        }

        [Fact]
        public void Sort_with_duplicates()
        {
            int[] numbers = [14, 10, 1, 30, 11, 10, 9,14, 4, 35];

            Dut.Sort(numbers);

            Assert.Collection(numbers
                , e => { Assert.Equal(35, e); }
                , e => { Assert.Equal(30, e); }
                , e => { Assert.Equal(14, e); }
                , e => { Assert.Equal(14, e); }
                , e => { Assert.Equal(11, e); }
                , e => { Assert.Equal(10, e); }
                , e => { Assert.Equal(10, e); }
                , e => { Assert.Equal(9, e); }
                , e => { Assert.Equal(4, e); }
                , e => { Assert.Equal(1, e); }
            );
        }
    }

    public class SortIntegersAscendingWithHoare : QuickSorterTestsBase
    {
        public SortIntegersAscendingWithHoare(ITestOutputHelper testOutputHelper) 
            : base(testOutputHelper) {}

        [Fact]
        public void Sort()
        {
            int[] numbers = [14,10,1,30,11,9,4,35];

            Dut.Sort(numbers);

            Assert.Collection(numbers 
                , e => { Assert.Equal(1, e); }
                , e => { Assert.Equal(4, e); }
                , e => { Assert.Equal(9, e); }
                , e => { Assert.Equal(10, e); }
                , e => { Assert.Equal(11, e); }
                , e => { Assert.Equal(14, e); }
                , e => { Assert.Equal(30, e); }
                , e => { Assert.Equal(35, e); }
            );
        }

        [Fact]
        public void Sort_with_duplicates()
        {
            int[] numbers = [14, 10, 1, 30, 10, 10, 9, 14, 4, 35];

            Dut.Sort(numbers);

            Assert.Collection(numbers
                , e => { Assert.Equal(1, e); }
                , e => { Assert.Equal(4, e); }
                , e => { Assert.Equal(9, e); }
                , e => { Assert.Equal(10, e); }
                , e => { Assert.Equal(10, e); }
                , e => { Assert.Equal(10, e); }
                , e => { Assert.Equal(14, e); }
                , e => { Assert.Equal(14, e); }
                , e => { Assert.Equal(30, e); }
                , e => { Assert.Equal(35, e); }
            );
        }

        [Fact]
        public void NullArray()
        {
            int[]? numbers = null;

            Dut.Sort(numbers);

            Assert.True(true);
        }

        [Fact]
        public void EmptyArray()
        {
            int[] numbers = new int[0];

            Dut.Sort(numbers);

            Assert.True(true);
        }

        [Fact]
        public void SingleElementArray()
        {
            int[] numbers = [1];

            Dut.Sort(numbers);

            Assert.Collection(numbers, e => { Assert.Equal(1, e); });
        }
    }
}

public class QuickSorterTestsBase
{
    protected QuickSorter Dut { get; set; }

    protected IAlgoLogger Logger { get; set; }

    public QuickSorterTestsBase(ITestOutputHelper testOutputHelper)
        : this(SortOrder.Ascending, testOutputHelper) { }

    public QuickSorterTestsBase(SortOrder sortOrder, ITestOutputHelper testOutputHelper)
    {
        Logger = new UnitTestLogger(testOutputHelper);
        Dut = new QuickSorter(sortOrder, Logger);
    }
}
