namespace TurboCollections;

public static partial class TurboSort
{
    public static void BubbleSort(TurboLinkedList<int> list)
    {
        int loop = list.Count;
        for (int i = 0; i < loop; i++)
        {
            bool swapped = false;
            for (int j = 0; j < loop; j++)
            {
                if (j+1 < loop)
                {
                    if (list.Get(j) > list.Get(j + 1) && j+1 < loop)
                    {
                        swapped = true;
                        int holder = list.Get(j); //holder = j.value
                        list.Set(j, list.Get(j + 1)); // i.value = min.value
                        list.Set(j + 1, holder);
                        
                    }
                }
            }
            if (!swapped) { break; }
        }
    }
}