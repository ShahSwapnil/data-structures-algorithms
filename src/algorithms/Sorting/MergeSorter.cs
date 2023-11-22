namespace algorithms;

/// <summary>
/// Implements Merge sort Algorithm. 
/// 1. Divide the problem into smaller pieces
/// 2. using recursion solve the smaller problem
/// 3. Merge the solutions from left and right subtree. 
/// 
/// 
///     [0 |1|2 |3|4 |5 |6 |7 ]
///     [14|4|28|1|75|50|36|18]
///   Lv  
///   0         [14|4|28|1|75|50|36|18]
///   1     [14|4|28|1]       [75|50|36|18]
///   2   [14|4]   [28|1]   [75|50]   [36|18]    <-- internal node workers
///   3  [14] [4] [28] [1] [75] [50] [36] [18]   <-- leaf workers
///     
///   2   [4|14]   [1|28]   [50|75]   [18|36]    <-- internal node workers
///   1     [1|4|14|28]       [18|36|50|75]
///   0         [1|4|14|18|28|36|50|75]
///   
/// </summary>
/// <typeparam name="T"></typeparam>
public class MergeSorter<T> : BaseSorter<T> where T: IComparable<T>
{

    public MergeSorter(IAlgoLogger logger)
        : this(SortOrder.Ascending, logger) { }

    public MergeSorter(SortOrder sortOrder, IAlgoLogger logger)
        : base(sortOrder, logger) { }

    protected override void helper(T[] input, int start, int end)
    {
        LogCurrentState("Beginning", input, start, end);

        // leaf worker
        // The array will always have one element when at the leaf node. 
        if ( start == end )
            return;

        // Internal Node worker
        int mid = start + ((end-start) / 2);

        // left subtree
        helper(input, start, mid);

        // right subtree
        helper(input, mid + 1, end);

        // merge the results from the two subtrees
        int i = start;
        int j = mid + 1;

        int auxArraySize = end - start + 1;
        T[] aux = new T[auxArraySize];
        int auxCounter = 0;
        
        while ( i <= mid && j <= end )
        {
            //if ( Comparer.Compare(nums[i], nums[j]) < 1 )
            //if ( nums[i].CompareTo(nums[j]) < 1 )
            if ( Comparison(input[i], input[j]) )             
            {
                aux[auxCounter] = input[i];
                i++;
            }
            else
            {
                aux[auxCounter] = input[j];
                j++;
            }
            auxCounter++;            
        }

        while ( i <= mid )
        {
            aux[auxCounter] = input[i];
            i++;
            auxCounter++;
        }

        while ( j <= end )
        {
            aux[auxCounter] = input[end];
            j++;
            auxCounter++;
        }

        // copy aux back into nums
        int numbersIdx = start;
        for ( int idx = 0; idx < aux.Length; idx++ )
        {
            input[numbersIdx] = aux[idx];
            numbersIdx++;
        }

        LogCurrentState("Ending", input, start, end);
    }

    private bool Comparison(T a, T b)
    {
        if ( SortOrder == SortOrder.Ascending )
        {
            return a.CompareTo(b) < 1;
        }
        else
        {
            return a.CompareTo(b) > -1;
        }
    }
}
