using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public abstract class BHeap<T> : IEnumerable<T>
        where T : IComparable
    {
        public T[] Array { get; private set; }
        protected int position;
        public int Count { get; private set; }
        public BHeap()
        {
            Count = 0;
            Array = new T[128];
            position = 0;
        }
        public BHeap(int _size)
        {
            Count = 0;
            Array = new T[_size];
            position = 0;
        }
        public BHeap(IEnumerable<T> collection)
        {
            Count = 0;
            Array = new T[collection.ToArray().Length];
            position = 0;
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        protected int GetLeftChildIndex(int i) => 2 * i + 1;
        protected int GetRightChildIndex(int i) => 2 * i + 2;
        protected int GetParentIndex(int i) => (i-1) / 2;
        protected bool HasLeftChild(int i) => GetLeftChildIndex(i) < position;
        protected bool HasRightChild(int i) => GetRightChildIndex(i) < position;
        protected bool IsRoot(int i) => i == 0;
        protected T GetLeftChild(int i) => Array[GetLeftChildIndex(i)];
        protected T GetRightChild(int i) => Array[GetRightChildIndex(i)];
        protected T GetParent(int i) => Array[GetParentIndex(i)];
        public bool IsEmpty() => position == 0;
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty heap!");
            }
            return Array[0];
        }
        public void Swap(int first,int second)
        {
            var temp = Array[first];
            Array[first] = Array[second];
            Array[second] = temp;
        }
        public void Add(T value)
        {
            if (position== Array.Length)
            {
                throw new IndexOutOfRangeException("OverFlow");
            }
            Array[position] = value;
            position++;
            Count++;
            HeapifUp();
        }
        public T DeleteMinMax()
        {
            if (position == 0)
            {
                throw new IndexOutOfRangeException("Underflow");
            }
            var temp = Array[0];
            Array[0] = Array[position - 1];
            position--;
            Count--;
            HeapifDown();
            return temp;
        }
        protected abstract void HeapifUp();
        protected abstract void HeapifDown();
        public IEnumerator<T> GetEnumerator()
        {
            return Array.Take(position).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
