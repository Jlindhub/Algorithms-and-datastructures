
namespace TurboCollections;

public static partial class TurboSort
{
    
    private static Random _random = new Random();
    
    public static void Quicksort(TurboLinkedList<int> list, int low, int high)
    {
        if (low <= high)
        {
            int PartitionIndex = Partition(list, low, high);
            Quicksort(list, low, PartitionIndex-1);
            Quicksort(list, PartitionIndex+1, high);
        }
    }

    public static int Partition(TurboLinkedList<int> list, int low, int high)
    {
        int pivotValue = list.Get(high);
        int index = low;
        
        for (int j = index; j <= high - 1; j++)
        {
            if (list.Get(j) < pivotValue)
            {
                
                //swap index=J and index=part.index
                int holder = list.Get(j); //holder = j.value
                list.Set(j,list.Get(index)); // set part.index value in j position 
                list.Set(index,holder); // set j value in part.index
                index++;
            }
        }
        //swap high with partition index
        int holder1 = list.Get(index); 
        list.Set(index,list.Get(high)); // set high value in part.index position
        list.Set(high,holder1); // set part.index value in high position
        return index;
    }
}