// divide and conquer
// recursive
// cada  divide em duas partes e roda em cada parte

using System;
using algorithms.Util;

namespace algorithms.Sorting
{
    public class Quick : Sorting
    {
        public Quick(){
            RunTests(Sort);
        }

        public static void Sort(int[] array)
        {
            Sort(0, array.Length-1);

            void Sort(int low, int high)
            {
                if(high <= low)
                    return; //finish ordering

                int j = Partition(low, high);
                
                // recursive
                Sort(low, j - 1); // left side
                Sort(j + 1, high); // right side
            }

            int Partition(int low, int high)
            {
                int i = low;
                int j = high + 1;

                int pivot = array[low]; //first of the partition

                while (true)
                {
                    while (array[++i] < pivot) // avoid out of index
                        if (i == high)
                            break;

                    while (pivot < array[--j])  // avoid out of index
                        if (j == low)
                            break;

                    if (i >= j)
                        break; // job done
                    
                    Swap(array, i, j);
                }

                Swap(array, low, j); // fix the pivot for the next partition
                
                return j; // new boundary 
            }
        }

    }
}