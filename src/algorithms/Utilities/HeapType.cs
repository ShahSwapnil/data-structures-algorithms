using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithms.Utilities
{
    public abstract class HeapType<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T? x, T? y)
        {
            return x!.CompareTo(y!);
        }

        public abstract bool IsPriorityLessThanParent(T currentValue, T parentValue);
        public abstract bool IsPriorityGreaterThanChild(T currentValue, T childValue);
        public abstract bool IsLeftChildPriorityGreater(T leftValue, T rightValue);
    }
}
