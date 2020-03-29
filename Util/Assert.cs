
using System;

namespace algorithms.Util
{
    public class Assert
    {
        public static void IsNull(object o)
        {
            if (o is null)
                Sucess($"Object is null");
            else
                Fail($"Object is not null");
        }
        
        public static void IsTrue(bool val, string msg)
        {
            if (val)
                Sucess($"{msg} - Succes");
            else
                Fail($"{msg} - Fail");
        }

        private static void Sucess(string msg)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine(msg);
            Console.ResetColor();
        }

        private static void Fail(string msg)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}