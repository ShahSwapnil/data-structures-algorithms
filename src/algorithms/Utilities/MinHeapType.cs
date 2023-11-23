using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithms.Utilities
{
    public class MinHeapType : HeapType
    {
        public override bool IsLeftChildPriorityGreater(int leftValue, int rightValue)
        {
            return Compare(leftValue, rightValue) < 0;
        }

        public override bool IsPriorityGreaterThanChild(int currentValue, int childValue)
        {
            return Compare(currentValue, childValue) <= 0;
        }

        public override bool IsPriorityLessThanParent(int currentValue, int parentValue)
        {
            return Compare(currentValue, parentValue) > 0;
        }
    }
}
