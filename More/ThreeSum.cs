using System;
using System.Diagnostics;
using System.Linq;

namespace algorithms.More
{
    public class ThreeSum
    {
        public ThreeSum()
        {
            Process("1Kints.txt", "1K");
            Process("2Kints.txt", "2K");
            Process("4Kints.txt", "4K"); // 2 minutes

            void Process(string file, string name)
            {
                var ints = Data.Data.ReadInts(file).ToArray();

                var watch = new Stopwatch();
                watch.Start();
                
                var triplets = ThreeSum.Count(ints);

                System.Console.WriteLine($"Sum {name}: {triplets}");
                System.Console.WriteLine($"Time: {watch.Elapsed:g}");
            }
        }

        public static int Count(int[] a)
        {
            int n = a.Length;
            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (a[i] + a[j] + a[k] == 0)
                            counter++;
                    }
                }
            }

            return counter;
        }
    }
}