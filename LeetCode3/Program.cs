using System;
using System.Collections.Generic;

namespace LeetCode3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(3 == LengthOfLongestSubstring("abcabcbb"));
        }
        static int LengthOfLongestSubstring(string s)
        {
            int result = 0;
            List<char> current = new List<char>();

            for (int i = 0; i < s.Length; i++)
            {
                int offset = 0;

                do
                {
                    current.Add(s[i + offset]);
                    offset++;
                } while (s.Length > i + offset && !current.Contains(s[i + offset]));

                if (offset > result)
                {
                    result = offset;
                }

                current.Clear();
            }

            return result;
        }
    }
}
