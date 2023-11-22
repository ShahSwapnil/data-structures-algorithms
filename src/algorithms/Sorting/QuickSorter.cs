
namespace algorithms;

public class QuickSorter : BaseSorter
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

    public override void Sort(int[]? input)
    {
        if ( input is null )
            return;

        if ( input.Length == 0 )
            return;

        helper(input, 0, input.Length - 1);
    }

    private void helper(int[] input, int start, int end)
    {
        Logger.Info("{0} - Start: {1} End: {2} Input Array: [{3}]", 
            "Beginning",
            start, 
            end, 
            string.Join(", ", 
                input.Select((integer, idx) => new { integer, idx })
                    .Where(x => start <= x.idx && x.idx <= end)
                    .Select(x => x.integer)
            )
        );
        
        // left worker
        // the sub problem size can be 0 or 1
        // sub problem size is 0 when start is greater than end
        // sub problem size is 1 when start equals end
        if ( start >= end )
            return;

        // internal node worker
        // Select a pivot randomly
        Random random = new Random();
        int pivotIndex = random.Next(start, end);

        swap(input, start, pivotIndex);

        Pivot pivot;

        if (_partition == QuickSortPartitionEnum.Hoare)
            pivot = HoarePartitioning(input, start, end);
        else
            pivot = LomutoPartitioning(input, start, end);

        Logger.Info("{0} - Start: {1} End: {2} Input Array: [{3}]",
            "After Partitioning",
            start,
            end,
            string.Join(", ",
                input.Select((integer, idx) => new { integer, idx })
                    .Where(x => start <= x.idx && x.idx <= end)
                    .Select(x => x.integer)
            )
        );

        // Subtree calls
        if ( (pivot.start - start + 1) > 1 )
            helper(input, start, pivot.start);

        if ((end - pivot.end + 1) > 1)
            helper(input, pivot.end, end);

        Logger.Info("{0} - Start: {1} End: {2} Input Array: [{3}]",
            "Ending",
            start,
            end,
            string.Join(", ",
                input.Select((integer, idx) => new { integer, idx })
                    .Where(x => start <= x.idx && x.idx <= end)
                    .Select(x => x.integer)
            )
        );
    }


    private void swap(int[] input, int indexA, int indexB)
    {
        int temp = input[indexA];
        input[indexA] = input[indexB];
        input[indexB] = temp;
    }

    private bool beforePivot(int val, int pivot)
    {
        if ( SortOrder == SortOrder.Ascending )
        {
            return pivot.CompareTo(val) > 0;
        }

        return pivot.CompareTo(val) < 0;
    }

    private bool afterPivot(int val, int pivot)
    {
        if ( SortOrder == SortOrder.Ascending )
        {
            return pivot.CompareTo(val) < 0;
        }

        return pivot.CompareTo(val) > 0;
    }

    private Pivot HoarePartitioning(int[] input, int start, int end)
    {
        // Partitioning
        int pivotValue = input[start];
        int smaller = start + 1;
        int bigger = end;

        while (smaller <= bigger)
        {
            if (beforePivot(input[smaller], pivotValue))
                smaller++;
            else if (afterPivot(input[bigger], pivotValue))
                bigger--;
            else
            {
                swap(input, smaller, bigger);
                smaller++;
                bigger--;
            }
        }

        while (bigger >= start && input[bigger] == pivotValue)
            bigger--;

        if ( bigger > start )
            swap(input, start, bigger);


        while (smaller <= end && input[smaller] == pivotValue)
            smaller++;

        return new Pivot { start = bigger - 1, end = smaller };
    }

    private Pivot LomutoPartitioning(int[] input, int start, int end)
    {
        throw new NotImplementedException();
    }    

    struct Pivot
    {
        public int start;
        public int end;
    }
}
