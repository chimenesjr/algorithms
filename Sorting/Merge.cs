// uses more memory
// not an in-place memory

using System;
using algorithms.Util;

namespace algorithms.Sorting
{
    public class Merge : Sorting
    {
        public Merge(){
            RunTests(Sort);
        }

        public static void Sort(int[] array)
        {
            int[] aux = new int[array.Length];

            Sort(0, array.Length - 1);

            void Sort(int low, int high)
            {
                if (high <= low)
                    return;

                int mid = (high + low) / 2;

                Sort(low, mid);
                Sort(mid+1, high);

                MergeThis(low, mid, high);
            }

            void MergeThis(int low, int mid, int high)
            {
                if (array[mid] <= array[mid+1])
                    return; // already ordered

                int i = low;
                int j = mid + 1;

                Array.Copy(array, low, aux, low, high-low+1);

                for (int k = low; k <= high; k++)
                {
                    // i++ incrementation happens after the assigning of the value

                    if (i > mid) // left health is exausted, take from the right side (avoid end of array)
                        array[k] = aux[j++]; 
                    else if (j > high) // right health is exausted, take from the left side (avoid end of array)
                        array[k] = aux[i++];
                    else if (aux[j] < aux[i]) // current key on the right is less then current key on the left
                        array[k] = aux[j++]; // take from the right
                    else
                        array[k] = aux[i++]; // take from the left
                }
            }
        }
        
    }
}