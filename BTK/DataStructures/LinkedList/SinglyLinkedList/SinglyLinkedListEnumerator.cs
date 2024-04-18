
using System.Collections;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    internal class SinglyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private SinglyLinkedListNode<T> Head;
        private SinglyLinkedListNode<T> _current;
        public SinglyLinkedListEnumerator(SinglyLinkedListNode<T> head)
        {
            Head = head;
            _current = null;
        }
        public T Current => _current.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Head = null;
        }

        public bool MoveNext()
        {
            if(_current == null)
            {
                _current = Head;
                return true;
            }
            else
            {
                _current = _current.Next;
                return _current!=null ? true : false;
            }
        }

        public void Reset()
        {
            _current = null;
        }
    }
}