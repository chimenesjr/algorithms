using System;
using algorithms.Util;

namespace algorithms.Sorting
{
    public class Insertion : Sorting
    {
        public Insertion(){
            RunTests(Sort);
        }

        public static void Sort(int[] array){
            // 3,2,5,5,1,0,7,8

            for (int partIndex = 0; partIndex < array.Length; partIndex++)
            {
                var curUnsorted = array[partIndex];
                int i = 0;

                for (i = partIndex; i > 0 && array[i-1] > curUnsorted; i--) // comeca na wall e desce ate achar o lugar
                {
                    array[i] = array[i-1]; // muda todos de lugar ate achar um menor
                }

                array[i] = curUnsorted; // adiona o valor no lugar 
            }
        }
    }
}