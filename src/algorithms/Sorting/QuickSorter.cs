
namespace algorithms;

public class QuickSorter<T> : BaseSorter<T> where T : IComparable<T>, IEquatable<T>
{
    private QuickSortPartitionEnum _partition;

    public QuickSorter(IAlgoLogger logger)
        : this(QuickSortPartitionEnum.Hoare, SortOrder.Ascending, logger) {}

    public QuickSorter(SortOrder sortOrder, IAlgoLogger logger)
    : this(QuickSortPartitionEnum.Hoare, sortOrder, logger) { }
    public QuickSorter(QuickSortPartitionEnum partition, IAlgoLogger logger)
        : this(partition, SortOrder.Ascending, logger) { }

    public QuickSorter(QuickSortPartitionEnum partition, SortOrder sortOrder, IAlgoLogger logger) 
        : base(sortOrder, logger) 
    {
        _partition = partition;
    }

    protected override void helper(T[] input, int start, int end)
    {
        LogCurrentState("Beginning", input, start, end);

        // left worker
        // the sub problem size can be 0 or 1
        // sub problem size is 0 when start is greater than end
        // sub problem size is 1 when start equals end
        if (start >= end)
            return;

        // internal node worker

        // Select a pivot randomly
        Random random = new Random();
        int pivotIndex = random.Next(start, end);

        swap(input, start, pivotIndex);

        PivotSection pivot;

        LogCurrentState("Before Partitioning", input, start, end);

        if (_partition == QuickSortPartitionEnum.Hoare)
            pivot = HoarePartitioning(input, start, end);
        else
            pivot = LomutoPartitioning(input, start, end);

        LogCurrentState("After Partitioning", input, start, end);

        // Subtree calls
        if ((pivot.start - start + 1) > 1)
            helper(input, start, pivot.start);

        if ((end - pivot.end + 1) > 1)
            helper(input, pivot.end, end);

        LogCurrentState("Ending", input, start, end);
    }


    private PivotSection HoarePartitioning(T[] input, int start, int end)
    {
        // Partitioning
        T pivotValue = input[start];
        int before = start + 1;
        int after = end;

        while (before <= after)
        {
            if (beforePivot(input[before], pivotValue))
                before++;
            else if (afterPivot(input[after], pivotValue))
                after--;
            else
            {
                swap(input, before, after);
                before++;
                after--;
            }
        }

        while (after >= start && input[after].Equals(pivotValue))
            after--;

        if ( after > start )
            swap(input, start, after);


        while (before <= end && input[before].Equals(pivotValue))
            before++;

        return new PivotSection { start = after - 1, end = before };
    }

    private PivotSection LomutoPartitioning(T[] input, int start, int end)
    {
        T pivotValue = input[start];
        int before = start;
        int pivot = start;
        int after = start;
        int idx = start + 1;

        while ( idx <= end )
        {
            if (pivot < before)
            {
                pivot++;
                continue;
            }

            if (after < pivot )
            {
                after++;
                continue;
            }

            if (beforePivot(input[idx], pivotValue))
            {
                before++;
                if ( idx != before)
                    swap(input, before, idx);
            }
            else if (afterPivot(input[idx], pivotValue))
            {
                after++;
                if ( idx != after)
                    swap(input, after, idx);
            }
            else
            {
                pivot++;
                if ( idx != pivot)
                    swap(input, pivot, idx);
            }

            idx++;
        }

        // swap the pivot value to the beginning of pivot
        swap(input, start, before);

        return new PivotSection { start = before - 1, end = pivot + 1 };
    }

    private bool beforePivot(T val, T pivot)
    {
        if (SortOrder == SortOrder.Ascending)
        {
            return pivot.CompareTo(val) > 0;
        }

        return pivot.CompareTo(val) < 0;
    }

    private bool afterPivot(T val, T pivot)
    {
        if (SortOrder == SortOrder.Ascending)
        {
            return pivot.CompareTo(val) < 0;
        }

        return pivot.CompareTo(val) > 0;
    }

    private struct PivotSection
    {
        public int start;
        public int end;
    }
}
