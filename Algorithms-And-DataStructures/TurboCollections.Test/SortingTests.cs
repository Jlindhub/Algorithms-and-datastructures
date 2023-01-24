using System.Diagnostics;
using Microsoft.VisualBasic;

namespace TurboCollections.Test;

public class SortingTests
{
    private Random _random = new();
    [Test]
    public void SelectionSort()
    {
        
        TurboLinkedList<int> listToSort = new TurboLinkedList<int> { 5, 9, 2, 4, 6, 1 };
        TurboLinkedList<int> listTarget = new TurboLinkedList<int> { 1, 2, 4, 5, 6, 9 };
        Stopwatch stopwatch = new Stopwatch(); 
        stopwatch.Start(); 
        TurboSort.SelectionSort(listToSort);
        stopwatch.Stop(); 
        CollectionAssert.AreEqual(listTarget,listToSort);
        Console.WriteLine(stopwatch.Elapsed);
    }

    [Test]
    public void SelectionSortRandomizedList()
    {

        //int[] randomlist = new int[random.Next(1, 1000)]; // randomized list size
        int[] randomlist = new int[1000]; //fixed list size
        for (int i = 0; i < randomlist.Length; i++) { randomlist[i] = _random.Next(1, 10000);} //populate list
        TurboLinkedList<int> listToSort = new TurboLinkedList<int>();
        listToSort.AddRange(randomlist);
        Stopwatch stopwatch = new Stopwatch(); 
        stopwatch.Start(); 
        TurboSort.SelectionSort(listToSort);
        stopwatch.Stop(); 
        Console.WriteLine(listToSort);
        Console.WriteLine(stopwatch.Elapsed);
        CollectionAssert.IsOrdered(listToSort);
        for(int i=0; i<listToSort.Count; i++){ Console.Write(listToSort.Get(i) + " "); }
        
    }
}