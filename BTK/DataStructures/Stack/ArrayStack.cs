namespace DataStructures.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        private readonly List<T> list = new List<T>();
        public int Count { get; private set; }
        public T Clear()
        {
            throw new NotImplementedException();
        }
        public T Peek()
        {
            if (Count == 0)
            {
                //return default(T); 1. öneri
                throw new Exception("Empty Stack!"); // 2. öneri
            }
            return list[list.Count - 1];
        }
        public T Pop()
        {
            if (Count==0)
            {
                //return default(T); 1. öneri
                throw new Exception("Empty Stack!"); // 2. öneri
            }
            var temp = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            Count--;
            return temp;
        }
        public void Push(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            list.Add(value);
            Count++;
        }
    }
}