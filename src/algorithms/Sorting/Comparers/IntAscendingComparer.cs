namespace algorithms;

public class IntAscendingComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if ( x < y ) 
            return -1;
        else if ( x == 7 )
            return 0;
        else // x > y
            return 1;
    }
}
