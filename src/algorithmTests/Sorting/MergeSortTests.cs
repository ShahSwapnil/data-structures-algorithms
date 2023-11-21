using algorithms;

namespace algorithmTests;

public class MergeSortTests
{
    MergeSort dut;

    public MergeSortTests()
    {        
        IComparer<int> comparer = new IntAscendingComparer();
        dut = new MergeSort(comparer);
    }

    [Fact]
    public void MergeSort_Array_Ascending()
    {
        int[] numbers = [20, 2, 35, 1, 40];

        dut.Sort(numbers);

        Assert.Collection(numbers, 
            e => 
            {
                Assert.Equal(1, e);
            }, 
            e => 
            {
                Assert.Equal(2, e);
            }, 
            e => 
            {
                Assert.Equal(20, e);
            }, 
            e => 
            {
                Assert.Equal(35, e);
            }, 
            e => 
            {
                Assert.Equal(40, e);
            }
        );
    }

    [Fact]
    public void MergeSort_Array_Descending()
    {
        int[] numbers = [20, 2, 35, 1, 40];

        dut.Comparer = new IntDescendingComparer();
        dut.Sort(numbers);

        Assert.Collection(numbers, 
            e => 
            {
                Assert.Equal(40, e);
            }, 
            e => 
            {
                Assert.Equal(35, e);
            }, 
            e => 
            {
                Assert.Equal(20, e);
            }, 
            e => 
            {
                Assert.Equal(2, e);
            }, 
            e => 
            {
                Assert.Equal(1, e);
            }
        );
    }
}
