using System;
using System.Collections.Generic;

namespace LCDDigitsNamespace
{
    public class LCDDigits
    {
        private readonly string[] digitPatterns = {
        "._. .|. |_|",
        "... ..| ..|",
        "._. ._. |_|",
        "._. ._. ..|",
        "... |_| ..|",
        "._. |_| ._|",
        "._. |_| |_|",
        "._. ..| ..|",
        "._. |_| |_|",
        "._. |_| ..|"
    };

        public void PrintLCDDigits(int number)
        {
            string numberStr = number.ToString();

            int height = 3;
            int width = numberStr.Length * 3;

            List<string> lines = new List<string>();
            for (int i = 0; i < height; i++)
            {
                string line = "";
                foreach (char digit in numberStr)
                {
                    int index = digit - '0';
                    string pattern = digitPatterns[index];
                    line += pattern.Substring(i * 3, 3) + " ";
                }
                lines.Add(line);
            }

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
