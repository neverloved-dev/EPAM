using InputFormatter;

namespace Task1
{
    class Program
    {
        public static void Main(string[] args)
        {
            String firstInput = $"Hello {args[0]}";
            Console.WriteLine(firstInput);
            Console.WriteLine("After the library call");
            String newInput = firstInput.FormatString();
            Console.WriteLine(newInput);
        }
    }
}