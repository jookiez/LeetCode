using System;

namespace LeetCode5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("bab" == LongestPalindrome("babad"));
            Console.WriteLine("bb" == LongestPalindrome("cbbd"));
            Console.WriteLine("a" == LongestPalindrome("a"));
            Console.WriteLine("ccc" == LongestPalindrome("ccc"));
        }

        static string LongestPalindrome(string s)
        {
            if (s.Length == 0 || s.Length == 1) return s;
            string result = "";

            for (int i = 0; i < s.Length - 1; i++)
            {
                

                if (s[i + 1] == s[i])
                {
                    var tempResultEven = GetResult(s, i, 0, 1);
                    if (tempResultEven.Length > result.Length)
                    {
                        result = tempResultEven;
                    }
                }

                var tempResultOdd = GetResult(s, i, 0, 0);
                if (tempResultOdd.Length > result.Length)
                {
                    result = tempResultOdd;
                }
            }

            return result;
        }

        private static string GetResult(string s, int i, int offsetBack, int offsetFront)
        {
            string result = "";
            bool done = false;
            while (!done)
            {
                if (i - offsetBack < 0 || i + offsetFront == s.Length) break;

                if (s[i - offsetBack] == s[i + offsetFront])
                {
                    offsetBack++;
                    offsetFront++;
                }
                else
                {
                    done = true;
                }
            }

            offsetBack--;
            offsetFront--;

            var lengthInQuestion = (i + offsetFront) - (i - offsetBack) + 1;

            result = s.Substring(i - offsetBack, lengthInQuestion);

            return result;
        }
    }
}
