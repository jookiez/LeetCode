using System;
using System.Linq;

namespace LeetCode1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new int[] { 0, 1 }.SequenceEqual(TwoSum(new int[] { 2, 7, 11, 15 }, 9)));
            Console.WriteLine(new int[] { 1, 2 }.SequenceEqual(TwoSum(new int[] { 3, 2, 4 }, 6)));
        }

        // for O(n) use hashmap lookup            

        static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int x = i + 1; x < nums.Length; x++)
                {
                    if (nums[i] + nums[x] == target)
                    {
                        return new int[] { i, x };
                    }
                }
            }

            return new int[] { 0, 0 };
        }
    }
}
