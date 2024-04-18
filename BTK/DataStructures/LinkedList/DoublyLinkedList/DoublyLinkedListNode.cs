using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode <T> Prev {  get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public T Value { get; set; }
        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }
        public override string ToString() => Value.ToString();
        
    }
}
