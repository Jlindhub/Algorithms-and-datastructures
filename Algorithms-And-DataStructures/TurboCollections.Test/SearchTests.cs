using System.Diagnostics;
using TurboCollections.SearchTypes;

namespace TurboCollections.Test;

public class SearchTests
{
    //my list class has integrated search in 'IndexOf' (returns: index value)
    [Test]
    public void LinearTest()
    {
        TurboLinkedList<int> listToSearch = new TurboLinkedList<int> { 5, 9, 2, 4, 6, 1 };
        Stopwatch stopwatch = new Stopwatch(); 
        stopwatch.Start(); 
        Assert.That(Search.LinearSearch(listToSearch, 4), Is.EqualTo(3));
        stopwatch.Stop(); 
        Console.WriteLine(stopwatch.Elapsed);
        Assert.That(Search.LinearSearch(listToSearch,4), Is.EqualTo(listToSearch.IndexOf(4)));
        //final assert works due to integrated search function.
    }

    [Test]
    public void LinearLargeTest()
    {
        int[] HugeList = new int[1000]; //fixed list size
        for (int i = 0; i < HugeList.Length; i++) { HugeList[i] =i;} //populate list, fixed numerals
        TurboLinkedList<int> listToSearch = new TurboLinkedList<int>();
        listToSearch.AddRange(HugeList);
        
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int searchResult = Search.LinearSearch(listToSearch,999); //cached to int for stopwatch accuracy
        stopwatch.Stop();
        int integratedResult = listToSearch.IndexOf(999); //comparator result
        Assert.That(searchResult == integratedResult);
        Assert.That(searchResult == 999);
        Console.WriteLine(stopwatch.Elapsed);
        //average time for 1k test: 0.006ms
    }
}