namespace PrimeNumber;

public class PrimeNumber
{
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
    }
    
    public bool IsComposite(int number)
    {
        return !IsPrime(number);
    }
    
    public bool IsEven(int number)
    {
        return number % 2 == 0;
    }
    
}
