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
            int len1 = str1.Length;
            int len2 = str2.Length;
            int marker1 = 0;
            int marker2 = 0;

            while (marker1 < len1 && marker2 < len2)
            {
                char ch1 = str1[marker1];
                char ch2 = str2[marker2];

                int space1 = 0, space2 = 0;
                while (marker1 < len1 && (space1 = char.IsDigit(str1[marker1]) ? 1 : 0) == 0)
                {
                    marker1++;
                }
                while (marker2 < len2 && (space2 = char.IsDigit(str2[marker2]) ? 1 : 0) == 0)
                {
                    marker2++;
                }

                if (space1 == 0 && space2 == 0)
                {
                    int compareResult = ch1.CompareTo(ch2);
                    if (compareResult != 0)
                    {
                        return compareResult;
                    }
                }
                else
                {
                    string num1 = str1.Substring(marker1, space1);
                    string num2 = str2.Substring(marker2, space2);

                    int numberCompareResult = int.Parse(num1).CompareTo(int.Parse(num2));
                    if (numberCompareResult != 0)
                    {
                        return numberCompareResult;
                    }
                }

                marker1++;
                marker2++;
            }

            return len1 - len2;
        }
    }
}
