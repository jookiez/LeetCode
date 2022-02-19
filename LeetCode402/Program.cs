using System;

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
        }

        static string RemoveKdigits(string num, int k)
        {

            // loop through, if both sides lower (or an end) remove
            int i = 0;
            while (k != 0)
            {
                if (k == num.Length) return "0";
                
                if (i + 1 == num.Length)
                {
                    num = num.Remove(0, k);
                    k = 0;
                }
                else if ((int)num[i] < (int)num[i + 1])
                {
                    num = num.Remove(i + 1, 1);
                    k--;
                }
                else if ((int) num[i] == (int)num[i + 1])
                {
                    i++;
                }
                else
                {
                    num = num.Remove(i, 1);
                    k--;
                }
            }

            num = RemoveLeadingZeros(num);

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
