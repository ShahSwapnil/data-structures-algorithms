namespace algorithms;

public class MergeSort
{
    public IComparer<int> Comparer { get; set; }

    public MergeSort(IComparer<int> comparer)
    {
        Comparer = comparer;
    }
    public void Sort(int[] numbers) => helper(numbers, 0, numbers.Length - 1);

    private void helper(int[] nums, int start, int end)
    {
        // leaf worker
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
        int[] aux = new int[auxArraySize];
        int auxCounter = 0;

        while ( i <= mid && j <= end )
        {
            if ( Comparer.Compare(nums[i], nums[j]) < 1 )
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
}
