using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {

        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                this.AddLast(item);
            }
        }

        public SinglyLinkedList()
        {

        }

        public SinglyLinkedListNode<T> Head { get; set; }
        private bool isHeadNull => Head == null; //? true : false;
        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            newNode.Next = Head;
            Head = newNode;
        }
        public void AddLast(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            if (isHeadNull)
            {
                Head = newNode;
                return;
            }
            var current = Head;
            while (current.Next!=null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        // Araya Ekleme:
        public void AddAfter(SinglyLinkedListNode<T> node,T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            if (isHeadNull)
            {
                AddFirst(value);
                return;
            }


            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;
            while (current!= null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException("The reference node is not in this list");
        }
        public void AddAfter(SinglyLinkedList<T> refNode,SinglyLinkedListNode<T> newNode)
        {
            throw new NotImplementedException();
        }
        public void AddBefore(SinglyLinkedList<T> node,T value)
        {
            throw new NotImplementedException(); 
        }
        public void AddBefore(SinglyLinkedList<T> refNode, 
            SinglyLinkedListNode<T> newNode)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Liste başındaki ilk elemanı kaldırma
        public T RemoveFirst()
        {
            if (isHeadNull)
            {
                throw new Exception("Underflow! Nothing the remove item");
            }
            var firstValue = Head.Value;
            Head = Head.Next;
            return firstValue;
        }
        // Son elemanı kaldırma
        public T RemoveLast()
        {
           var current = Head;
            SinglyLinkedListNode<T> prev = null;
            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }
            var lastValue = prev.Next.Value;
            prev.Next = null;
            return lastValue;
        }

        // Ara elemanı silme
        public void Remove(T value)
        {
            if (isHeadNull)
            {
                throw new Exception("Underflow! Nothing the remove item");
            }
            if(value == null)
            {
                throw new ArgumentNullException();
            }
            var current = Head;
            SinglyLinkedListNode<T> prev = null;

            do
            {
                if (current.Value.Equals(value))
                {
                    // Son eleman mı?
                    if (current.Next==null)
                    {
                        // Head silinmek isteniyorsa
                        if (prev==null)
                        {
                            Head = null;
                            return;
                        }
                        // Son eleman
                        else
                        {
                            prev.Next = null;
                            return;
                        }
                    }
                    else
                    {
                        // Head
                        if (prev == null)
                        {
                            Head = Head.Next; 
                            return;
                        }
                        // Ara düğüm
                        else
                        {
                            prev.Next = current.Next;
                            return;
                        }
                    }
                }
                prev = current;
                current = current.Next;

            } while (current != null);

            throw new ArgumentException("The value could not be found in the list");
            
        }
    }
}
