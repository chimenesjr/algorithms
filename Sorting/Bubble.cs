using System;
using algorithms.Util;

namespace algorithms.Sorting
{
    public class Bubble : Sorting
    {
        public Bubble(){
            RunTests(BubbleSort);
        }

        public static void BubbleSort(int[] array){

            for (int i = array.Length - 1; i > 0 ; i--) // just defining the wall to limit the next loop
            {
                for (int j = 0; j < i; j++)
                {
                    if(array[j] > array[j+1]) // swap if the left is greater 
                        Swap(array, j, j+1);
                }
            }
        }
    }
}