
using System;
using System.Collections.Generic;
using System.Linq;

namespace algorithms.Util
{
    public static class Extension
    {
        public static string Extract(this int[] values)
        {
            return String.Join(",", values.Select(x => x.ToString()).ToArray());
        }

        public static string Extract(this char[] values)
        {
            return String.Join(",", values.Select(x => x.ToString()).ToArray());
        }

        public static string Extract(this List<int> values)
        {
            return String.Join(",", values.Select(x => x.ToString()).ToArray());
        }

        public static void Write(this string value)
        {
            Console.WriteLine(value);
        }
    }

}