using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode39
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var result = CombinationSum(new int[] { 2, 7, 6, 3, 5, 1 }, 9);
        }

        static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var temp = new List<int>(candidates);
            temp.Sort();
            IList<IList<int>> result = new List<IList<int>>();
            
            for (int i = 0; i < temp.Count; i++)
            {
                GetSum(new List<int>() { temp[i] }, temp.ToArray(), target, result);
            }

            return result;
        }

        static void GetSum(List<int> state, int[] candidates, int target, IList<IList<int>> result)
        {
            if (state.Sum() == target)
            {
                TryAdd(state, result);
                return;
            }
            else if (state.Sum() > target)
            {
                return;
            }
            else
            {
                for (int i = 0; i < candidates.Length; i++)
                {
                    var tempState = new List<int>(state);
                    tempState.Add(candidates[i]);
                    GetSum(tempState, candidates, target, result);
                    if (tempState.Sum() > target)
                    {
                        break;
                    }
                }
            }
        }

        static void TryAdd(List<int> state, IList<IList<int>> result)
        {
            state.Sort();

            foreach(var item in result)
            {
                if (state.SequenceEqual(item))
                {
                    return;
                }
            }

            result.Add(state);
        }
    }
}
