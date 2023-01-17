namespace TurboCollections;

public class TurboMaths
{
    public static void SayHello()
    {
        Console.WriteLine($"Hello, I'm {typeof(TurboMaths)}");
    }


    public static IEnumerable<int> GetOddNumbersUntil(int number)
    {
        for (int i = 0; i < number; i++)
        {
            if(i %2 !=0)
            { yield return i; }
        }
    }

    public static List<int> GetOddNumbersUntilList(int number)
    {
        List<int> list = new List<int>();
        for (int i = 0; i < number; i++)
        {
            if(i%2 !=0){ list.Add(i); }
        }

        return list;
    }
}