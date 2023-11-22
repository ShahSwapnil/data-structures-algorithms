﻿namespace algorithms;

public class MergeSorter<T> where T: IComparable<T>
{

    public SortOrder SortOrder { get; set; }

    public MergeSorter()
    {
        SortOrder = SortOrder.Ascending;
    }

    public MergeSorter(SortOrder sortOrder)
    {
        this.SortOrder = sortOrder;
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
