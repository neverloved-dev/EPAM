using System.Runtime.CompilerServices;

namespace InputFormatter
{
    public static class Class1
    {
        public static string FormatString(this String input)
        {
            string time = $"{DateTime.Now.Hour.ToString()}:{DateTime.Now.Minute.ToString()} ";
            String modified = input.Insert(0, time);
            return modified;
        }
    }
}
