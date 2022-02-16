using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode1881
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test 1: "+ (MaxValue("99", 9).ToString() == "999").ToString());
            Console.WriteLine("Test 2: " + (MaxValue("-13", 2).ToString() == "-123").ToString());
            Console.WriteLine("Test 3: " + (MaxValue("-132", 3).ToString() == "-1323").ToString());
        }


        public static string MaxValue(string n, int x)
        {
            for (int i = 0; i <= n.Length; i++)
            {
                if(n[0] == '-')
                {
                    if (i == 0) continue;

                    if (i == n.Length || Int32.Parse(n[i].ToString()) > x)
                    {
                        n = n.Insert(i, x.ToString());
                        break;
                    }
                }
                else
                {
                    if (i == n.Length || Int32.Parse(n[i].ToString()) < x)
                    {
                        n = n.Insert(i, x.ToString());
                        break;
                    }
                }
            }

            return n;
        }
    }
}
