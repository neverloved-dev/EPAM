using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            for(int i  = 0; i < args.Length; i++)
            {
                if (args[i][0] == ' ') throw new ArgumentNullException("The string is empty");
                Console.WriteLine(args[i][0]);
                
            }
        }
    }
}