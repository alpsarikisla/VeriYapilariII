namespace DataStructures.Shared
{
    public class CustomComparer<T> : IComparer<T>
        where T : IComparable
    {
        private readonly bool isMax;
        private readonly IComparer<T> comparer;
        public CustomComparer(SortDirection  sortDirection,IComparer<T> comparer)
        {
            this.isMax = sortDirection == SortDirection.Descending;
            this.comparer = comparer;
        }
        public int Compare(T x, T y)
        {
            return !isMax ? comparer.Compare(x, y) : compare(y, x);
        }
        private int compare(T x, T y) => comparer.Compare(x, y);
    }
}
