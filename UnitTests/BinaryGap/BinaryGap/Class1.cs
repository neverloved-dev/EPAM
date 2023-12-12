using System;

namespace BinaryGapClass
{
    public class BinaryGap
    {
        public int GetLongestGap(int N)
        {
            int maxGap = 0;
            int currentGap = 0;
            bool isGap = false;

            while (N > 0)
            {
                if (N % 2 == 0)
                {
                    if (isGap)
                    {
                        currentGap++;
                    }
                }
                else
                {
                    if (!isGap)
                    {
                        isGap = true;
                    }
                    else
                    {
                        if (currentGap > maxGap)
                        {
                            maxGap = currentGap;
                        }
                        currentGap = 0;
                    }
                }
                N /= 2;
            }

            return maxGap;
        }
    }
}
