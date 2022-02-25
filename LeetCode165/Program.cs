using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode165
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(0 == CompareVersion("1.01", "1.001"));
            Console.WriteLine(0 == CompareVersion("1.0", "1.0.0"));
            Console.WriteLine(-1 == CompareVersion("0.1", "1.1"));
            Console.WriteLine(1 == CompareVersion("1.0.1", "1"));
            Console.WriteLine(-1 == CompareVersion("1", "1.1"));
        }

        static int CompareVersion(string version1, string version2)
        {
            int result = 0;
            var version1Converted = ConvertVersion(version1);
            var version2Converted = ConvertVersion(version2);

            while (version1Converted.Any() || version2Converted.Any())
            {
                if(version1Converted.Any() && version2Converted.Any())
                {
                    result = CompareNumbers(version1Converted.First(), version2Converted.First());
                    if (result != 0) break;
                    version1Converted.RemoveAt(0);
                    version2Converted.RemoveAt(0);
                }
                else if (version1Converted.Any())
                {
                    if (version1Converted.First() != 0)
                    {
                        result = 1;
                        break;
                    } else
                    {
                        version1Converted.RemoveAt(0);
                    }
                }
                else
                {
                    if (version2Converted.First() != 0)
                    {
                        result = -1;
                        break;
                    }
                    else
                    {
                        version2Converted.RemoveAt(0);
                    }
                }
            }

            return result;
        }

        
        static int CompareNumbers(int val1, int val2)
        {
            int result = 0;
            if (val1 > val2)
            {
                result = 1;
            } 
            else if (val1 < val2)
            {
                result = -1;
            }

            return result;
        }

        static List<int> ConvertVersion(string version)
        {
            List<int> result = new List<int>();
            string[] versions = version.Split('.');

            foreach (var item in versions)
            {
                result.Add(Int32.Parse(item));
            }

            return result;
        }
    }
}
