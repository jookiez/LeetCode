using System;
using System.Collections.Generic;

namespace LeetCode1046
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(1 == LastStoneWeight(new int[] { 2, 7, 4, 1, 8, 1 }));
        }

        static int LastStoneWeight(int[] stones)
        {
            var stonesList = new List<int>(stones);
            while (stonesList.Count > 1)
            {
                var topTwo = new List<int>();
                for (int i = 0; i < stonesList.Count; i++)
                {
                    if (i == 0 || i == 1)
                    {
                        topTwo.Add(stonesList[i]);
                    }
                    else
                    {
                        topTwo.Sort();

                        if (stonesList[i] > topTwo[0])
                        {
                            topTwo[0] = stonesList[i];
                        }
                    }

                }

                var newWeight = Math.Abs(topTwo[0] - topTwo[1]);

                stonesList.RemoveAt(stonesList.IndexOf(topTwo[1]));
                stonesList.RemoveAt(stonesList.IndexOf(topTwo[0]));

                if (newWeight != 0)
                {
                    stonesList.Add(newWeight);
                }
            }
            if (stonesList.Count == 0) return 0;
            return stonesList[0];
        }
    }
}
