
using System;

namespace algorithms.CoolStuff
{
    public class Cool<T>
    {
        public Cool()
        {
            Run(PrintInt);
        }

        int x = default(int);
        T t = default(T);

        public int GetVal()
        {
            return GetInt(null);

            int GetInt(int? i)
            {
                x = i ?? 0;
                return x;
            }
        }

        private void Run(Action action)
        {
            action();
        }

        void PrintInt()
        {
            var i = GetVal();
            System.Console.WriteLine(i);
        }

        public class InternalClass
        {

        }
    }
}