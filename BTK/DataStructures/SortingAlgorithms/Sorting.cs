using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SortingAlgorithms
{
    public class Sorting
    {
        public static void Swap<T>(T[] array,int first,int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
