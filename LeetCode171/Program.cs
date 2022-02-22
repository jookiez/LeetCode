using System;
using System.Collections.Generic;

namespace LeetCode171
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(1 == TitleToNumber("A"));
            Console.WriteLine(28 == TitleToNumber("AB"));
            Console.WriteLine(701 == TitleToNumber("ZY"));
            Console.WriteLine(703 == TitleToNumber("AAA"));
            Console.WriteLine(1353 == TitleToNumber("AZA"));
            Console.WriteLine(1379 == TitleToNumber("BAA"));
            Console.WriteLine(2147483647 == TitleToNumber("FXSHRXW"));
        }

        static int TitleToNumber(string columnTitle)
        {
            int colNum = 0;
            for (int i = 0; i < columnTitle.Length; i++)
            {
                var power = (int)Math.Pow(26, (long)(columnTitle.Length - 1) - i);
                var letterNumber = (int)columnTitle[i] - 64;
                colNum += power * letterNumber;
            }

            return colNum;
        }
    }
}
