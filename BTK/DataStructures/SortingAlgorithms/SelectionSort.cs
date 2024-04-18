using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SortingAlgorithms
{
    public class SelectionSort
    {
        public static void Sort<T>(T[] array)
            where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;
                T minValue = array[i];
                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(minValue)<0)
                    {
                        minIndex = j;
                        minValue = array[minIndex];
                    }
                }
                // Swap - Takas
                DataStructures.SortingAlgorithms.Sorting.Swap<T>(array, i, minIndex);
            }
        }
        public static void Sort<T>(T[] array,Shared.SortDirection sortDirection = Shared.SortDirection.Ascending)
            where T : IComparable
        {
            var comparer = new Shared.CustomComparer<T>(sortDirection, Comparer<T>.Default);
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (comparer.Compare(array[j], array[i]) >= 0)
                    {
                        continue;
                    }
                    Sorting.Swap<T>(array, i, j);
                }
               
            }
        }
    }
}
