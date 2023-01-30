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
        Assert.That(Search.LinearSearch(listToSearch, 111111111), Is.EqualTo(-1)); //check for 'not found'
        Assert.That(Search.LinearSearch(listToSearch,4), Is.EqualTo(listToSearch.IndexOf(4)));
        //final assert works due to integrated search function.
    }

    [Test]
    public void LinearLargeTest()
    {
        int[] HugeList = new int[1000]; //fixed list size
        for (int i = 0; i < HugeList.Length; i++) { HugeList[i] =i;} //populate list, fixed numerals 0-999
        TurboLinkedList<int> listToSearch = new TurboLinkedList<int>();
        listToSearch.AddRange(HugeList);
        
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int searchResult = Search.LinearSearch(listToSearch,999); //cached to int for stopwatch accuracy
        stopwatch.Stop();
        int integratedResult = listToSearch.IndexOf(999); //comparator result
        Assert.That(searchResult == integratedResult);
        Assert.That(searchResult == 999);
        Assert.That(Search.LinearSearch(listToSearch, 111111111), Is.EqualTo(-1));  //check for 'not found'
        Console.WriteLine(stopwatch.Elapsed);
        //average time for 1k test, targeting final value in list to iterate full list: 0.006ms
    }
    [Test]
    public void BinaryTest()
    {
        TurboLinkedList<int> listToSearch = new TurboLinkedList<int> { 1, 2, 4, 5, 6, 9 };
        Stopwatch stopwatch = new Stopwatch(); 
        stopwatch.Start(); 
        Assert.That(Search.BinarySearch(listToSearch, 4), Is.EqualTo(2));
        stopwatch.Stop(); 
        Console.WriteLine(stopwatch.Elapsed);
        Assert.That(Search.BinarySearch(listToSearch, 111111111), Is.EqualTo(-1));  //check for 'not found'
        Assert.That(Search.BinarySearch(listToSearch,4), Is.EqualTo(listToSearch.IndexOf(4)));
        //final assert works due to integrated search function.
    }

    [Test]
    public void BinaryLargeTest()
    {
        int[] HugeList = new int[1000]; //fixed list size
        for (int i = 0; i < HugeList.Length; i++) { HugeList[i] =i;} //populate list, fixed numerals 0-999, pre-sorted
        TurboLinkedList<int> listToSearch = new TurboLinkedList<int>();
        listToSearch.AddRange(HugeList);
        Random random = new Random();
        int target = random.Next(0, 999);
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int searchResult = Search.BinarySearch(listToSearch,target); //cached to int for stopwatch accuracy
        stopwatch.Stop();
        int integratedResult = listToSearch.IndexOf(target); //comparator result
        Assert.That(searchResult == integratedResult);
        Assert.That(searchResult == target);
        Assert.That(Search.BinarySearch(listToSearch, 111111111), Is.EqualTo(-1)); //check for 'not found'
        Console.WriteLine(stopwatch.Elapsed);
        //average time for 1k test, targeting random number: 0.001ms
    }

    [Test]
    public void Insertion()
    {
        TurboLinkedList<int> listToSearch = new TurboLinkedList<int> { 1, 2, 4, 5, 6, 9 };
        SortedInsertion.SortInsert(listToSearch, 5);
        SortedInsertion.SortInsert(listToSearch, 8);
        Assert.That(listToSearch.Get(3), Is.EqualTo(5));
        Assert.That(listToSearch.Get(4), Is.EqualTo(5));
        Assert.That(listToSearch.Get(6), Is.EqualTo(8));
        CollectionAssert.IsOrdered(listToSearch);

    }
}