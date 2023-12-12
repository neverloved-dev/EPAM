namespace OddEvenClasses;

public class Class1
{
    public bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    public bool IsOdd(int number)
    {
        return !IsEven(number) && !IsPrime(number);
    }

    public bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }}
