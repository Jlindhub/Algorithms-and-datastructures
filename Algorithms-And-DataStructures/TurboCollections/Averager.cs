using System.Collections;
namespace TurboCollections;

public class Averager
{
   public static int AveragingMachine(int[] valuestoaverage)
    {
        return valuestoaverage.Sum() / valuestoaverage.Length;
    }
}