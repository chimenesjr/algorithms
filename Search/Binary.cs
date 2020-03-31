using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using algorithms.Util;

namespace algorithms.Search
{
    public class Binary
    {
        public Binary()
        {
            int[] input = {0,3,4,7,8,12,15,22};

            Assert.IsTrue(BinarySearch(input, 4) == 2, "BinarySearch(input, 4) == 2");
            Assert.IsTrue(BinarySearch(input, 8) == 4, "BinarySearch(input, 8) == 4");
            Assert.IsTrue(BinarySearch(input, 15) == 6, "BinarySearch(input, 15) == 6");
            Assert.IsTrue(BinarySearch(input, 22) == 7, "BinarySearch(input, 22) == 7");

            Assert.IsTrue(RecursiveBinarySearch(input, 4) == 2, "RecursiveBinarySearch(input, 4) == 2");
            Assert.IsTrue(RecursiveBinarySearch(input, 8) == 4, "RecursiveBinarySearch(input, 8) == 4");
            Assert.IsTrue(RecursiveBinarySearch(input, 15) == 6, "RecursiveBinarySearch(input, 15) == 6");
            Assert.IsTrue(RecursiveBinarySearch(input, 22) == 7, "RecursiveBinarySearch(input, 22) == 7");
        }

        public static int RecursiveBinarySearch(int[] array, int value)
        {
            return InternalRecursiveBinarySearch(0, array.Length);

            int InternalRecursiveBinarySearch(int low, int high)
            {
                if (low >= high)
                    return -1;
                
                int mid = (low + high) / 2;
                
                if (array[mid] == value)
                    return mid;
                
                if (array[mid] < value)
                    return InternalRecursiveBinarySearch(mid+1, high);

                return InternalRecursiveBinarySearch(low, mid);
            }
        }


        // divide em 2, se o elemento nao for o desejado decide se vai para cima ou para baixo
        public static int BinarySearch(int[] array, int value)
        {
            int low = 0;
            int high = array.Length;

            while (low < high)
            {
                int mid = (low + high) / 2;

                if(array[mid] == value)
                    return mid;
                
                if (array[mid] < value)
                    low = mid + 1;
                else
                    high = mid;
            }

            return -1;
        }
    }
}