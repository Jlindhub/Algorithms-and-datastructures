using System.Diagnostics;

namespace TurboCollections;

public static partial class TurboSort
{
    public static void SelectionSort(TurboLinkedList<int> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            int min = i; //keeps track of index point for current min value
            
            for (int j = i + 1; j < list.Count; j++) //comparer
            {
                if (list.Get(j) < list.Get(min)) { min = j; }
            }

            if (min != i) //swapper
            {
                int holder = list.Get(i); //holder = i.value
                list.Set(i,list.Get(min)); // i.value = min.value
                list.Set(min,holder); //min.value = (old) i.value
            }
        }
    }
    
    
    
    
    
}