namespace TurboCollections.Test;

public class SortingTests
{
    [Test]
    public void SelectionSort()
    {
        TurboLinkedList<int> listToSort = new TurboLinkedList<int> { 5, 9, 2, 4, 6, 1 };
        TurboLinkedList<int> listTarget = new TurboLinkedList<int> { 1, 2, 4, 5, 6, 9 };
        TurboSort.SelectionSort(listToSort);
        CollectionAssert.AreEqual(listTarget,listToSort);
    }
}