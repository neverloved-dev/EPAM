using System;
using System.Collections;
using System.Collections.Generic;

namespace NaturalOrderStringSortingClass
{
    public class NaturalStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return NaturalCompare(x, y);
        }

        private int NaturalCompare(string str1, string str2)
        {
            return AlphanumComparator.Compare(str1, str2);
        }
    }

    internal class AlphanumComparator
    {
        public static int Compare(string str1, string str2)
        {
            string[] split1 = Split(str1);
            string[] split2 = Split(str2);

            for (int i = 0; i < Math.Min(split1.Length, split2.Length); i++)
            {
                int result;
                if (split1[i] != split2[i] && (result = PartCompare(split1[i], split2[i])) != 0)
                {
                    return result;
                }
            }

            return split1.Length.CompareTo(split2.Length);
        }

        private static string[] Split(string s)
        {
            return System.Text.RegularExpressions.Regex.Split(s.Replace(" ", ""), "([0-9]+)");
        }

        private static int PartCompare(string left, string right)
        {
            bool leftIsNum = int.TryParse(left, out int leftNum);
            bool rightIsNum = int.TryParse(right, out int rightNum);

            if (leftIsNum && rightIsNum)
            {
                return leftNum.CompareTo(rightNum);
            }

            return left.CompareTo(right);
        }
    }
}

