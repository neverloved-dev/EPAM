using System;

namespace LeapYearCheckerNamespace
{
    public class LeapYearChecker
    {
        public bool IsLeapYear(int year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
