// uses a small amount of extra memory
// in-place memory

using System;
using algorithms.Util;

namespace algorithms.Sorting
{
    public class Shell : Sorting
    {
        public Shell(){
            RunTests(Sort);
        }

        public static void Sort(int[] array)
        {
            int gap = 1;

            while (gap < array.Length /3) // outra opcao eh comecar com 2 e ir dividindo por 2 (impacto na performance)
                gap = 3 * gap + 1;

            while (gap >= 1)
            {
                for (int i = gap; i < array.Length; i++) // quantas vezes percorre o gap
                {
                    for (int j=i; j >= gap && array[j] < array[j - gap]; j -= gap) // percorre e verifica o menor
                    {
                        Swap(array, j, j-gap);
                    }
                }

                gap /= 3; // diminue o gap
            }
        }
        
    }
}