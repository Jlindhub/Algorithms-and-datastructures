namespace TurboCollections.SearchTypes;

public static class SortedInsertion
{
    public static void SortInsert(TurboLinkedList<int> list, int value)
    {
        //IMPORTANT!!
        //THIS ASSUMES THE LIST IS PRE-SORTED, USE A SORT ON LIST FIRST OR A LIST YOU KNOW IS SORTED!!!
        int lowerBound = 0;
        int upperBound = list.Count - 1;
        bool found = false;
        while (!found)
        {
            int midPoint = (lowerBound + upperBound) / 2;
            if (upperBound < lowerBound) {found = true; list.InsertAfter(midPoint,value); } //does not exist, place at last midpoint
            if (list.Get(midPoint) < value) { lowerBound = midPoint + 1; }
            else if (list.Get(midPoint) > value) { upperBound = midPoint - 1;}
            else if (list.Get(midPoint) == value) { found = true; list.InsertAfter(midPoint, value);} //target found
        }
    }
}