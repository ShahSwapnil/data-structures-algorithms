using algorithms;
using algorithmTests.Utilities;
using Xunit.Abstractions;

namespace algorithmTests;

public class MergeSortTests
{
    public class MergeSortIntegersAscending : MergeSortTestsBase<int>
    {
        public MergeSortIntegersAscending(ITestOutputHelper helper)
            : base(helper) {}

        [Fact]
        public void Sort()
        {
            int[] numbers = [10,5,35,1,48];

            Dut.Sort(numbers);

            Assert.Collection(numbers, 
                e => 
                {
                    Assert.Equal(1, e);
                }, 
                e => 
                {
                    Assert.Equal(5, e);
                }, 
                e => 
                {
                    Assert.Equal(10, e);
                }, 
                e => 
                {
                    Assert.Equal(35, e);
                }, 
                e => 
                {
                    Assert.Equal(48, e);
                }
            );
        }

        [Fact]
        public void emptyArray()
        {
            int[] numbers = new int[0];

            Dut.Sort(numbers);

            Assert.True(true);
        }

        [Fact]
        public void NullArray()
        {
            int[]? numbers = null;

            Dut.Sort(numbers);

            Assert.True(true);
        }
    }

    public class MergeSortIntegersDescending : MergeSortTestsBase<int>
    {
        public MergeSortIntegersDescending(ITestOutputHelper helper)
            : base (SortOrder.Descending, helper) {}


        [Fact]
        public void Sort()
        {
            int[] numbers = [10,5,35,1,48];

            Dut.Sort(numbers);

            Assert.Collection(numbers, 
                e => 
                {
                    Assert.Equal(48, e);
                }, 
                e => 
                {
                    Assert.Equal(35, e);
                }, 
                e => 
                {
                    Assert.Equal(10, e);
                }, 
                e => 
                {
                    Assert.Equal(5, e);
                }, 
                e => 
                {
                    Assert.Equal(1, e);
                }
            );
        }       
    }

    public class MergeSortStringAscending : MergeSortTestsBase<string>
    {
        public MergeSortStringAscending(ITestOutputHelper helper) 
            : base(helper) {}

        [Fact]
        public void Sort()
        {
            string[] words = ["abc", "acb", "ade"];

            Dut.Sort(words);

            Assert.Collection(words
                , e => { Assert.Equal("abc", e); }
                , e => { Assert.Equal("acb", e); }
                , e => { Assert.Equal("ade", e); }
            );
        }
    }

    public class MergeSortStringDescending : MergeSortTestsBase<string>
    {
        public MergeSortStringDescending(ITestOutputHelper helper) 
            : base(SortOrder.Descending, helper) {}

        [Fact]
        public void Sort()
        {
            string[] words = ["abc", "acb", "ade"];

            Dut.Sort(words);

            Assert.Collection(words
                , e => { Assert.Equal("ade", e); }
                , e => { Assert.Equal("acb", e); }
                , e => { Assert.Equal("abc", e); }
            );
        }
    }

    public class MergeSortRandomObjectAscending : MergeSortTestsBase<RandomUnitTestObject>
    {
        public MergeSortRandomObjectAscending(ITestOutputHelper helper) 
            : base(helper) {}

        [Fact]
        public void Sort()
        {
            RandomUnitTestObject[] objects = [ 
                new RandomUnitTestObject { ID = 10},
                new RandomUnitTestObject { ID = 1},
                new RandomUnitTestObject { ID = 15},
                new RandomUnitTestObject { ID = 3},
                new RandomUnitTestObject { ID = 0}
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

            Assert.Collection(objects
                , obj => { Assert.Equal(0, obj.ID); }
                , obj => { Assert.Equal(1, obj.ID); }
                , obj => { Assert.Equal(3, obj.ID); }
                , obj => { 
                    Assert.Equal(10, obj.ID);
                    Assert.Equal(2, obj.SecondaryID);
                }
                , obj => {
                    Assert.Equal(10, obj.ID);
                    Assert.Equal(1, obj.SecondaryID);
                }
                , obj => { Assert.Equal(15, obj.ID); }
            );
        }
    }
}

public class MergeSortTestsBase<T> where T: IComparable<T>
{
    protected MergeSorter<T> Dut { get; set; }

    IAlgoLogger Logger { get; set; }

    public MergeSortTestsBase(ITestOutputHelper helper)
        : this(SortOrder.Ascending, helper) {}

    public MergeSortTestsBase(SortOrder mergeSortOrder, ITestOutputHelper helper)        
    {
        Logger = new UnitTestLogger(helper);
        Dut = new MergeSorter<T>(mergeSortOrder, Logger);
    }
}