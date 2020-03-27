using System;
using System.Collections.Generic;
using System.IO;

namespace algorithms.Data
{
    public class Data
    {
        public static IEnumerable<int> ReadInts(string filePath)
        {
            using (TextReader reader = File.OpenText($"Data/{filePath}"))
            {
                string lastLine;
                while ((lastLine = reader.ReadLine()) != null)
                {
                    yield return int.Parse(lastLine);
                }
            }
        }
    }
}