using System;
using System.Collections.Generic;

namespace LeetCode402
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1219" == RemoveKdigits("1432219", 3));
            Console.WriteLine("200" == RemoveKdigits("10200", 1));
            Console.WriteLine("0" == RemoveKdigits("10", 2));
            Console.WriteLine("0" == RemoveKdigits("10", 1));
            Console.WriteLine("11" == RemoveKdigits("112", 1));
            Console.WriteLine("0" == RemoveKdigits("10001", 4));
            Console.WriteLine("123" == RemoveKdigits("12345", 2));
            Console.WriteLine("1111" == RemoveKdigits("1111111", 3));
            Console.WriteLine("0" == RemoveKdigits("1234567890", 9));
        }

        static string RemoveKdigits(string num, int k)
        {

            var stack = new List<char>();
            int i = 0;
            while (k != 0)
            {
                if (k == num.Length)
                {
                    return "0";
                }
                else if (i == num.Length)
                {
                    while (k != 0)
                    {
                        stack.RemoveAt(stack.Count - 1);
                        k--;
                    }
                }
                else if (stack.Count == 0)
                {
                    stack.Add(num[i]);
                }
                else if (stack[stack.Count - 1] > num[i])
                {
                    while (stack.Count != 0 && stack[stack.Count - 1] > num[i] && k != 0)
                    {
                        stack.RemoveAt(stack.Count - 1);
                        k--;
                    }

                    stack.Add(num[i]);
                }
                else
                {
                    stack.Add(num[i]);
                }
                i++;
            }

            while(i < num.Length)
            {
                stack.Add(num[i]);
                i++;
            }

            num = RemoveLeadingZeros(new string(stack.ToArray()));

            return num;
        }

        static string RemoveLeadingZeros(string num)
        {
            if (num == "0") return num;
            while(num[0] == '0')
            {
                num = num.Remove(0, 1);
            }

            return num;
        }
    }
}
