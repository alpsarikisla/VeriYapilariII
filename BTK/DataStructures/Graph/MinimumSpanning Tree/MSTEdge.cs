using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.MinimumSpanning_Tree
{
    public class MSTEdge<T, TW> : IComparable
        where TW : IComparable
    {
        public MSTEdge(T source, T destination, TW weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }

        public T Source { get;}
        public T Destination { get;}
        public TW Weight { get;}

        public int CompareTo(object? obj)
        {
            return Weight.CompareTo(((MSTEdge<T, TW>)obj).Weight);
        }
        public override string ToString()
        {
            return $"{Source} - {Destination} W:{Weight}";
        }
    }
}
