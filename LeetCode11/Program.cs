using System;
using System.Collections.Generic;

namespace LeetCode11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(49 == BetterMaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
            Console.WriteLine(17 == BetterMaxArea(new int[] { 2, 3, 4, 5, 18, 17, 6 }));
        }

        // my solution
        static int MaxArea(int[] height)
        {
            int result = 0;
            for (int i = 0; i < height.Length; i++)
            {
                for (int x = i + 1; x < height.Length; x++)
                {
                    result = Math.Max(result, Math.Min(height[i], height[x]) * (x - i));
                }
            }

            return result;
        }

        // the o(n) solution
        static int BetterMaxArea(int[] height)
        {
            int result = 0;
            int beginning = 0;
            int end = height.Length - 1;
            do
            {
                result = Math.Max(result, Math.Min(height[beginning], height[end]) * (end - beginning));
                if(height[beginning] > height[end])
                {
                    end--;
                }
                else
                {
                    beginning++;
                }
            } while (end - beginning != 0);

            return result;
        }
    }
}
