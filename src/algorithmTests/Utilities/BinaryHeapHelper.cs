using algorithms.AbstractDataTypes;
using algorithms.Utilities;
using System.Text;

namespace algorithmTests.Utilities
{
    public class BinaryHeapHelper<T> : BinaryHeap<T> where T : IComparable<T>
    {
        public BinaryHeapHelper(HeapType<T> heapType, IAlgoLogger logger)
            : base(heapType, logger) { }

        public string OutputHeapAsString()
        {
            ReadOnlySpan<T> heapValues = _data.AsSpan<T>(1, _currentIdx - 1);
            StringBuilder sb = new StringBuilder();

            foreach ( T number  in heapValues )
            {
                if ( sb.Length > 0 )
                    sb.Append('|');

                sb.Append(number);
            }

            return $"[{sb}]";
        }

        /// <summary>
        /// Crawl the entire heap and make sure the Heap is valid. 
        /// Valid Heap means
        ///     Structure property is satisfied - in order to have a right child, there MUST be a left child. 
        ///     Heap property is satisfied - Node's priority must be greater than it's children but less than it's parent. 
        /// </summary>
        /// <returns></returns>
        public bool IsHeapValid()
        {
            return HeapValidationHealper(1);
        }

        private bool HeapValidationHealper(int idx)
        {
            if (idx >= _currentIdx)
                return true;

            int parentIdx = idx / 2;
            int leftChildIdx = idx * 2;
            int rightChildIdx = leftChildIdx + 1;

            bool hasLeftChild = IsValidNode(leftChildIdx);
            bool hasRightChild = IsValidNode(rightChildIdx);

            bool structuralPropertyIsValid = true;

            // validate Structural Property
            if (hasRightChild && !hasLeftChild)
                structuralPropertyIsValid = false;

            /*
             * Validate Heap Property
             *  Less than Parent
             *  Greater than Child(ren)
             */


            bool heapPropertyIsValid = PriorityLessThanParent(idx, parentIdx) 
                                    && PriorityGreaterThanChild(idx, leftChildIdx)
                                    && PriorityGreaterThanChild(idx, rightChildIdx);

            bool isValid = structuralPropertyIsValid && heapPropertyIsValid;

            if (!isValid)
                return false;

            if ( !HeapValidationHealper(leftChildIdx) )
                return false;

            if ( !HeapValidationHealper(rightChildIdx) )
                return false;

            return true;
        }

        private bool IsValidNode(int idx)
        {
            return idx >= _currentIdx ? false : true;
        }

        public void SetHeap(T[] data, int currentIdx)
        {
            _data = data;
            _currentIdx = currentIdx;
        }

        public ReadOnlySpan<T> GetHeapValues()
        {
            return _data.AsSpan<T>(1, _currentIdx - 1);
        }
    }
}
