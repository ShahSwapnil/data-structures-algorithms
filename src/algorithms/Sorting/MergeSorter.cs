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
public class MergeSorter<T> where T: IComparable<T>
{

    private SortOrder _sortOrder { get; set; }

    public MergeSorter()
    {
        _sortOrder = SortOrder.Ascending;
    }

    public MergeSorter(SortOrder sortOrder)
    {
        this._sortOrder = sortOrder;
    }    

    public void Sort(T[]? numbers) 
    {
        if ( numbers is null )
            return;

        if ( numbers.Length == 0 )
            return;

        helper(numbers, 0, numbers.Length - 1);
    } 

    private void helper(T[] nums, int start, int end)
    {
        // leaf worker
        // The array will always have one element when at the leaf node. 
        if ( start == end )
            return;

        // Internal Node worker
        int mid = start + ((end-start) / 2);

        // left subtree
        helper(nums, start, mid);

        // right subtree
        helper(nums, mid + 1, end);

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
            if ( Comparison(nums[i], nums[j]) )             
            {
                aux[auxCounter] = nums[i];
                i++;
            }
            else
            {
                aux[auxCounter] = nums[j];
                j++;
            }
            auxCounter++;            
        }

        while ( i <= mid )
        {
            aux[auxCounter] = nums[i];
            i++;
            auxCounter++;
        }

        while ( j <= end )
        {
            aux[auxCounter] = nums[end];
            j++;
            auxCounter++;
        }

        // copy aux back into nums
        int numbersIdx = start;
        for ( int idx = 0; idx < aux.Length; idx++ )
        {
            nums[numbersIdx] = aux[idx];
            numbersIdx++;
        }

        return;
    }

    private bool Comparison(T a, T b)
    {
        if ( _sortOrder == SortOrder.Ascending )
        {
            return a.CompareTo(b) < 1;
        }
        else
        {
            return a.CompareTo(b) > -1;
        }
    }
}
