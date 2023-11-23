using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithms.Utilities
{
    public abstract class HeapType : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }

        public abstract bool IsPriorityLessThanParent(int currentValue, int parentValue);
        public abstract bool IsPriorityGreaterThanChild(int currentValue, int childValue);
        public abstract bool IsLeftChildPriorityGreater(int leftValue, int rightValue);
    }
}
