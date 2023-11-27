using System;

namespace algorithms.Utilities
{
    public class MinHeapType<T> : HeapType<T> where T : IComparable<T>
    {
        public override bool IsLeftChildPriorityGreater(T leftValue, T rightValue)
        {
            return Compare(leftValue, rightValue) < 0;
        }

        public override bool IsPriorityGreaterThanChild(T currentValue, T childValue)
        {
            return Compare(currentValue, childValue) <= 0;
        }

        public override bool IsPriorityLessThanParent(T currentValue, T parentValue)
        {
            return Compare(currentValue, parentValue) > 0;
        }
    }
}
