using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SortingAlgorithms
{
    public class InsertionSort
    {
        public static T[] Sort<T>(T[] array,Shared.SortDirection sortDirection = Shared.SortDirection.Ascending)
            where T : IComparable
        {
            var comparer = new Shared.CustomComparer<T>(sortDirection,Comparer<T>.Default);
            for (int i = 0; i < array.Length-1; i++)
            {
                for (int j = i+1; j > 0; j--)
                {
                    if (comparer.Compare(array[j], array[j-1])<0)
                    {
                        Sorting.Swap<T>(array, j - 1, j);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return array;
        }
    }
}
