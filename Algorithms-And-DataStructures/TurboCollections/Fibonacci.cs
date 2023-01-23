namespace TurboCollections;

public class Fibonacci
{
    public static int Iterative(int fibNumber)
    {
        int previous = 1;
        int result = 0;
        for(int i=0; i<fibNumber; i++)
        {
            int temp = result;
            result = previous;
            previous = temp + previous;
        }
        return result;
    }

    public static int Recursive(int fibNumber)
    {
        if (fibNumber == 0) return 0;
        if (fibNumber == 1) return 1;
        return Recursive(fibNumber - 1) + Recursive(fibNumber - 2);
    }
}