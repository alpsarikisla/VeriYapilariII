﻿namespace DataStructures.Heap
{
    public class MinHeap<T> : BHeap<T>, IEnumerable<T>
        where T : IComparable
    {
        public MinHeap() : base()
        {
            
        }
        public MinHeap(int _size) : base(_size)
        {

        }
        public MinHeap(IEnumerable<T> collection) : base(collection)
        {
            
        }
        protected override void HeapifDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index).CompareTo(GetLeftChild(index))<0)
                {
                    smallerIndex = GetRightChildIndex(index);
                }
                if (Array[smallerIndex].CompareTo(Array[index])>=0)
                {
                    break;
                }
                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }
        protected override void HeapifUp()
        {
            var index = position - 1;
            while (!IsRoot(index) && Array[index].CompareTo(GetParent(index))<0)
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }
    }
    public class MaxHeap<T> : BHeap<T>, IEnumerable<T>
        where T : IComparable
    {
        public MaxHeap() : base()
        {
            
        }
        public MaxHeap(int size) : base(size)
        {
            
        }
        public MaxHeap(IEnumerable<T> collection) : base(collection)
        {

        }
        protected override void HeapifDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index).CompareTo(GetLeftChild(index)) > 0)
                {
                    smallerIndex = GetRightChildIndex(index);
                }
                if (Array[smallerIndex].CompareTo(Array[index]) < 0)
                {
                    break;
                }
                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }
        protected override void HeapifUp()
        {
            var index = position - 1;
            while (!IsRoot(index) && Array[index].CompareTo(GetParent(index)) > 0)
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }
    }
}
