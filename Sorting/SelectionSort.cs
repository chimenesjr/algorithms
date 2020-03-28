using System;
using algorithms.Util;

namespace algorithms.Sorting
{
    public class SelectionSort : Sorting
    {
        public SelectionSort(){
            RunTests(Sort);
        }

        public static void Sort(int[] array)
        {
            // 3,2,5,5,1,0,7,8
            for (int i = array.Length - 1; i > 0 ; i--) // just defining the wall to limit the next loop
            {
                var biggest = 0;

                for (int j = 0; j <= i; j++)
                {
                    if (array[j] > array[biggest])
                    {
                        biggest = j;
                    }
                }

                Swap(array, biggest, i);
            }
        }
        
    }
}