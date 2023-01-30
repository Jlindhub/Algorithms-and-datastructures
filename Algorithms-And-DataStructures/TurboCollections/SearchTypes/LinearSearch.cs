namespace TurboCollections.SearchTypes;

public static partial class Search
{
    public static int LinearSearch(TurboLinkedList<int> list, int value)
    {
        for(int i=0; i<list.Count; i++)
        {
            if (list.Get(i) == value)
            {
                return i;
            }
        }
        return -1;
    }
}