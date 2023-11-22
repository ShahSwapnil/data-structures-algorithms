namespace algorithms;

public class QuickSorter : BaseSorter
{
    private int counter = 0;
    public QuickSorter(IAlgoLogger logger)
        : this(SortOrder.Ascending, logger) {}
    public QuickSorter(SortOrder sortOrder, IAlgoLogger logger) 
        : base(sortOrder, logger) {}

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
        counter++;
        Logger.Info("Start: {0} End: {1} Input Array: [{2}]",start, end, string.Join(", ", Enumerable.Range(start, end - start + 1).Select(i => i)));
        
        // left worker
        // the sub problem size can be 0 or 1
        // sub problem size is 0 when start is greater than end
        // sub problem size is 1 when start equals end
        if ( start >= end )
            return;

        // internal node worker
        // Partitioning
        int pivotValue = input[start];
        int smaller = start + 1;
        int bigger = end;

        while ( smaller <= bigger )
        {
            if ( input[smaller] < pivotValue )
                smaller++;
            else if ( input[bigger] > pivotValue )
                bigger--;
            else
            {             
                swap(input, smaller, bigger);   
                smaller++;                
                bigger--;
            }
        }

        swap(input, start, bigger);
        // Subtree calls
        helper(input, start, bigger - 1);
        helper(input, bigger + 1, end);
    }

    private void swap(int[] input, int indexA, int indexB)
    {
        int temp = input[indexA];
        input[indexA] = input[indexB];
        input[indexB] = temp;
    }
}
