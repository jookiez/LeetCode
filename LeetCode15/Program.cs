using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BetterThreeSum(new int[] { -1, 0, 1, 2, -1, -4 }));
            Console.WriteLine(BetterThreeSum(new int[] { 1, 2, -2, -1 }));
            Console.WriteLine(BetterThreeSum(new int[] { 0, 0, 0 }));
            Console.WriteLine(BetterThreeSum(new int[] { 0, 0, 0, 0 }));
        }


        // my approach
        static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            for(int i = 0; i < nums.Length; i++)
            {
                for(int x = i + 1; x < nums.Length; x++)
                {
                    for (int c = x + 1; c < nums.Length; c++)
                    {
                        if(nums[i] + nums[x] + nums[c] == 0)
                        {
                            var temp = new List<int>() { nums[i], nums[x], nums[c]};
                            temp.Sort();
                            if (!result.Any(y => y.SequenceEqual(temp))) result.Add(temp);
                        }
                    }
                }
            }

            return result;
        }


        // optimized
        static IList<IList<int>> BetterThreeSum(int[] nums)
        {

            Array.Sort(nums);

            IList<IList<int>> result = new List<IList<int>>();
            for (int num1Idx = 0; num1Idx + 2 < nums.Length; num1Idx++)
            {
                // Skip all duplicates from left
                // num1Idx>0 ensures this check is made only from 2nd element onwards
                if (num1Idx > 0 && nums[num1Idx] == nums[num1Idx - 1])
                {
                    continue;
                }

                int num2Idx = num1Idx + 1;
                int num3Idx = nums.Length - 1;
                while (num2Idx < num3Idx)
                {
                    int sum = nums[num2Idx] + nums[num3Idx] + nums[num1Idx];
                    if (sum == 0)
                    {
                        // Add triplet to result
                        result.Add(new List<int>() { nums[num1Idx], nums[num2Idx], nums[num3Idx] });

                        num3Idx--;

                        // Skip all duplicates from right
                        while (num2Idx < num3Idx && nums[num3Idx] == nums[num3Idx + 1]) num3Idx--;
                    }
                    else if (sum > 0)
                    {
                        // Decrement num3Idx to reduce sum value
                        num3Idx--;
                    }
                    else
                    {
                        // Increment num2Idx to increase sum value
                        num2Idx++;
                    }
                }
            }
            return result;
        }
    }
}
