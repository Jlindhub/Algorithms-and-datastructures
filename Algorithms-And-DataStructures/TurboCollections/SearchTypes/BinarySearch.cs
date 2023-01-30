namespace TurboCollections.SearchTypes;

public static partial class Search
{
    public static int BinarySearch(TurboLinkedList<int> list, int value)
    {
        //IMPORTANT!!
        //THIS ASSUMES THE LIST IS PRE-SORTED, USE A SORT ON LIST FIRST OR A LIST YOU KNOW IS SORTED!!!
        int lowerBound = 0;
        int upperBound = list.Count - 1;
        int returnvalue = -1;
        bool found = false;
        while (!found)
        {
            if (upperBound < lowerBound) { return -1; } //does not exist
            int midPoint = (lowerBound + upperBound) / 2;
            if (list.Get(midPoint) < value) { lowerBound = midPoint + 1; }
            else if (list.Get(midPoint) > value) { upperBound = midPoint - 1;}
            else if (list.Get(midPoint) == value) { found = true; returnvalue = midPoint; return midPoint;} //target found
        }

        return 0; //rider insists on a return here, even though i shouldn't need one due to the while loop running until -1 or return midpoint. 
    }
}