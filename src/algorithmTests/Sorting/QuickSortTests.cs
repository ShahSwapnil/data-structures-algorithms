using algorithmTests.Utilities;
using Xunit.Abstractions;

namespace algorithmTests;

public class QuickSortTests
{

    public class QuickSortRandomObjectAscending : QuickSorterTestsBase<RandomUnitTestObject>
    {
        public QuickSortRandomObjectAscending(ITestOutputHelper helper)
            : base(helper) { }

        [Fact]
        public void Sort()
        {
            RandomUnitTestObject[] objects = [
                new RandomUnitTestObject { ID = 10 },
                new RandomUnitTestObject { ID = 1 },
                new RandomUnitTestObject { ID = 15 },
                new RandomUnitTestObject { ID = 3 },
                new RandomUnitTestObject { ID = 0 }
            ];

            Dut.Sort(objects);

            Assert.Collection(objects
                , obj => { Assert.Equal(0, obj.ID); }
                , obj => { Assert.Equal(1, obj.ID); }
                , obj => { Assert.Equal(3, obj.ID); }
                , obj => { Assert.Equal(10, obj.ID); }
                , obj => { Assert.Equal(15, obj.ID); }
            );
        }

        [Fact]
        public void Sort_Duplicates_Stability()
        {
            RandomUnitTestObject[] objects = [
                new RandomUnitTestObject { ID = 10, SecondaryID = 2 },
                new RandomUnitTestObject { ID = 10, SecondaryID = 1 },
                new RandomUnitTestObject { ID = 1 },
                new RandomUnitTestObject { ID = 15 },
                new RandomUnitTestObject { ID = 3 },
                new RandomUnitTestObject { ID = 0 }
            ];

            Dut.Sort(objects);

            // Can't guarantee the order of objects when there are duplicates. There for cannot check SecondaryID
            Assert.Collection(objects
                , obj => { Assert.Equal(0, obj.ID); }
                , obj => { Assert.Equal(1, obj.ID); }
                , obj => { Assert.Equal(3, obj.ID); }
                , obj => { Assert.Equal(10, obj.ID); }
                , obj => { Assert.Equal(10, obj.ID); }
                , obj => { Assert.Equal(15, obj.ID); }
            );
        }
    }
    public class SortIntegersAscendingWithLomuto : QuickSorterTestsBase<int>
    {
        public SortIntegersAscendingWithLomuto(ITestOutputHelper testOutputHelper)
            : base(QuickSortPartitionEnum.Lomuto, testOutputHelper) { }

        [Fact]
        public void Sort()
        {
            int[] numbers = [14, 10, 1, 30, 11, 9, 4, 35];

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
    }
    public class SortIntegersDescendingWithLomuto : QuickSorterTestsBase<int>
    {
        public SortIntegersDescendingWithLomuto(ITestOutputHelper testOutputHelper)
            : base(QuickSortPartitionEnum.Lomuto, SortOrder.Descending, testOutputHelper) { }

        [Fact]
        public void Sort()
        {
            int[] numbers = [14, 10, 1, 30, 11, 9, 4, 35];

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
            int[] numbers = [14, 10, 1, 30, 11, 10, 9, 14, 4, 35];

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

    public class SortIntegersDescendingWithHoare : QuickSorterTestsBase<int>
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

    public class SortIntegersAscendingWithHoare : QuickSorterTestsBase<int>
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

public class QuickSorterTestsBase<T> where T : IComparable<T>, IEquatable<T>
{
    protected QuickSorter<T> Dut { get; set; }

    protected IAlgoLogger Logger { get; set; }

    public QuickSorterTestsBase(ITestOutputHelper testOutputHelper)
        : this(QuickSortPartitionEnum.Hoare,SortOrder.Ascending, testOutputHelper) { }
    public QuickSorterTestsBase(SortOrder sortOrder,ITestOutputHelper testOutputHelper)
        : this(QuickSortPartitionEnum.Hoare, sortOrder, testOutputHelper) { }

    public QuickSorterTestsBase(QuickSortPartitionEnum partition, ITestOutputHelper testOutputHelper)
        : this(partition, SortOrder.Ascending, testOutputHelper) { }

    public QuickSorterTestsBase(QuickSortPartitionEnum partition,SortOrder sortOrder, ITestOutputHelper testOutputHelper)
    {
        Logger = new UnitTestLogger(testOutputHelper);
        Dut = new QuickSorter<T>(partition,sortOrder, Logger);
    }
}
