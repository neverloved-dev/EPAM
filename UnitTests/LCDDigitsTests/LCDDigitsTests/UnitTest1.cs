using LCDDigitsNamespace;

namespace LCDDigitsTests
{
    public class LCDDigitsTests
    {
        [Fact]
        public void TestPrintLCDDigits_SingleDigit()
        {
            LCDDigits lcdDigits = new LCDDigits();
            int number = 7;

            string[] expectedOutput = {
            "._. ",
            "..| ",
            "..| "
        };

            AssertPrintLCDDigits(lcdDigits, number, expectedOutput);
        }

        [Fact]
        public void TestPrintLCDDigits_MultipleDigits()
        {
            LCDDigits lcdDigits = new LCDDigits();
            int number = 12345;

            string[] expectedOutput = {
            "._. ._. ._. ._. ._. ",
            "|_| ..| |_. |_. ..| ",
            "..| ..| |_| ._| ..| "
        };

            AssertPrintLCDDigits(lcdDigits, number, expectedOutput);
        }

        [Fact]
        public void TestPrintLCDDigits_Zero()
        {
            LCDDigits lcdDigits = new LCDDigits();
            int number = 0;

            string[] expectedOutput = {
            "._. ",
            "|.| ",
            "|_| "
        };

            AssertPrintLCDDigits(lcdDigits, number, expectedOutput);
        }

        [Fact]
        public void TestPrintLCDDigits_NegativeNumber()
        {
            LCDDigits lcdDigits = new LCDDigits();
            int number = -8;

            string[] expectedOutput = {
            "... ",
            "..| ",
            "..| "
        };

            AssertPrintLCDDigits(lcdDigits, number, expectedOutput);
        }

        [Fact]
        public void TestPrintLCDDigits_MaxInteger()
        {
            LCDDigits lcdDigits = new LCDDigits();
            int number = int.MaxValue;

            string[] expectedOutput = {
            "._. ._. ._. ._. ._. ._. ._. ._. ._. ._. ",
            "|.| ..| ..| |.| |.| |.| |.| |.| |.| |.| ",
            "|_| ..| |_| |_| |_| |_| |_| |_| |_| |_| "
        };

            AssertPrintLCDDigits(lcdDigits, number, expectedOutput);
        }

        private void AssertPrintLCDDigits(LCDDigits lcdDigits, int number, string[] expectedOutput)
        {
            using (ConsoleRedirector consoleRedirector = new ConsoleRedirector())
            {
                lcdDigits.PrintLCDDigits(number);

                string[] actualOutput = consoleRedirector.GetOutput().Trim().Split('\n');

                Assert.Equal(expectedOutput.Length, actualOutput.Length);

                for (int i = 0; i < expectedOutput.Length; i++)
                {
                    Assert.Equal(expectedOutput[i].Trim(), actualOutput[i].Trim());
                }
            }
        }

      
    }
}