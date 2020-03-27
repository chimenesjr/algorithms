using System;
using algorithms.Util;

namespace algorithms.Sorting
{
    public class Bubble
    {
        public Bubble(){
            RunTests(BubbleSort);
        }

        private void RunTests(Action<int[]> sort)
        {
            foreach (var item in Samples())
            {
                sort(item);
                item.Extract().Write();
            }
        }

        public static void BubbleSort(int[] array){

            for (int i = array.Length - 1; i > 0 ; i--) // just defining the wall to limit the next loop
            {
                for (int j = 0; j < i; j++)
                {
                    if(array[j] > array[j+1])
                        Swap(array, j, j+1);
                }
            }
        }

        private static void Swap(int[] array, int x, int y){
            
            if(x == y)
                return;

            var xval = array[x];
            array[x] = array[y];
            array[y] = xval;
        }

        private int[][] Samples()
        {
            int[][] samples = new int[9][];

            samples[0] = new int[] {1};
            samples[1] = new int[] {2,1};
            samples[2] = new int[] {2,1,3};
            samples[3] = new int[] {1,1,1};
            samples[4] = new int[] {2,-1,3,3};
            samples[5] = new int[] {4,-5,3,3};
            samples[6] = new int[] {0,-5,3,3};
            samples[7] = new int[] {0,-5,3,0};
            samples[8] = new int[] {3,2,5,5,1,0,7,8};

            return samples;
        }
    }
}