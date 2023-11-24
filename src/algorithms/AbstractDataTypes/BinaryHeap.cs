using algorithms.Utilities;
using System;

namespace algorithms.AbstractDataTypes
{
    public class BinaryHeap<T> where T : IComparable<T>
    {
        /// <summary>
        /// underlying data structure for the Heap
        /// </summary>
        protected T[] _data;

        /// <summary>
        /// Index at which a new element gets insert
        /// </summary>
        protected int _currentIdx;

        protected IAlgoLogger Logger { get; }

        protected HeapType<T> HeapType { get; }

        public bool IsHeapEmpty
        {
            get
            {
                return _currentIdx == 1;
            }
        }

        public int Depth => _currentIdx;

        public BinaryHeap(IAlgoLogger logger)
            : this(new MaxHeapType<T>(), logger) { }

        public BinaryHeap(HeapType<T> heapType, IAlgoLogger logger)
        {
            _data = new T[100];
            _currentIdx = 1;
            Logger = logger;
            HeapType = heapType;
        }

        public void Insert(T number)
        {
            _data[_currentIdx] = number;
            HeapifyUp(_currentIdx);
            _currentIdx++;
        }

        public T Extract()
        {
            if (_currentIdx == 1)
                throw new IndexOutOfRangeException("No Data in the heap");

            T rootValue = _data[1];
            _currentIdx--;

            swap(_data, 1, _currentIdx);
            HeapifyDown(1);

            return rootValue;
        }

        private void swap(T[] data, int indexA, int indexB)
        {
            T temp = data[indexA];
            data[indexA] = data[indexB];
            data[indexB] = temp;
        }

        public void HeapifyUp(int idx)
        {
            // at root
            if (idx == 1)
                return;

            int parentIdx = idx / 2;

            bool isLessThanParent = PriorityLessThanParent(idx, parentIdx);

            if ( !isLessThanParent )
            {
                // swap with Parent
                swap(_data, idx, parentIdx);
                HeapifyUp(parentIdx);
            }
        }

        public void HeapifyDown(int idx)
        {
            int leftChildIdx = idx * 2;
            int rightChildIdx = leftChildIdx + 1;

            bool isGreaterThanLeftChild = PriorityGreaterThanChild(idx, leftChildIdx);
            bool isGreaterThanRightCild = PriorityGreaterThanChild(idx, rightChildIdx);

            // if the Heap Property is satisfied
            if (isGreaterThanLeftChild && isGreaterThanRightCild)
                return;

            if ( !isGreaterThanLeftChild && !isGreaterThanRightCild )
            {
                // determine which child is greater
                if ( HeapType.IsLeftChildPriorityGreater(_data[leftChildIdx], _data[rightChildIdx]) )
                {
                    HeapifyDownChild(idx, leftChildIdx);
                }
                else
                {
                    HeapifyDownChild(idx, rightChildIdx);
                }
            }
            else if ( !isGreaterThanLeftChild )
            {
                HeapifyDownChild(idx, leftChildIdx);
            }
            else
            {
                HeapifyDownChild(idx, rightChildIdx);
            }
        }

        private void HeapifyDownChild(int idx, int childIdx)
        {
            swap(_data, idx, childIdx);
            HeapifyDown(childIdx);
        }

        protected bool PriorityLessThanParent(int idx, int parentIdx)
        {
            if (idx == 1)
                return true;

            return HeapType.IsPriorityLessThanParent(_data[idx], _data[parentIdx]);
        }

        protected bool PriorityGreaterThanChild(int idx, int childIdx)
        {
            if ( childIdx >= _currentIdx )
                return true;

            return HeapType.IsPriorityGreaterThanChild(_data[idx], _data[childIdx]);
        }
    }
}
