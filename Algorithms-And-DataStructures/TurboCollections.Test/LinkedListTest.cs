namespace TurboCollections.Test;

public class LinkedListTest
{
    [Test]
    public void LinkListFullTestSuite()
    {
        var LinkList = new TurboLinkedList<int>();
        LinkList.Add(50);
        LinkList.Add(100);
        LinkList.Add(150);
        int[] arrayAdd = { 200, 250, 300 };
        LinkList.AddRange(arrayAdd);
        //keep in mind - first index point is 0, not 1!
        Assert.That(LinkList.Get(0), Is.EqualTo(50)); 
        Assert.That(LinkList.Get(4), Is.EqualTo(250));
        LinkList.Set(4,500);
        Assert.That(LinkList.Get(4), Is.EqualTo(500));
        LinkList.RemoveAt(4);
        Assert.That(LinkList.Get(4), Is.EqualTo(300)); //300 was in index 5 - after remove, it should be index 4.
        Assert.That(LinkList.Contains(300));
        Assert.That(LinkList.IndexOf(300), Is.EqualTo(4));
        Assert.That(LinkList.IndexOf(999), Is.EqualTo(-1)); //to check for no-result search
        LinkList.Remove(300);
        Assert.That(LinkList.IndexOf(300), Is.EqualTo(-1));
        Assert.That(LinkList.Contains(300), Is.False); //checking = false because the list no longer contains 300.
        LinkList.Clear();
        Assert.That(LinkList, Is.Empty);

    }

    [Test]
    public void LinkListAddAndGet()
    {
        var LinkList = new TurboLinkedList<int>();
        LinkList.Add(50);
        LinkList.Add(100);
        LinkList.Add(150);
        Assert.That(LinkList.Get(0), Is.EqualTo(50));
        Assert.That(LinkList.Get(1), Is.EqualTo(100));
        Assert.That(LinkList.Get(2), Is.EqualTo(150));
        Assert.Throws<InvalidOperationException>(()=>LinkList.Get(3));
    }

    [Test]
    public void LinkListSetChecksOut()
    {
        var LinkList = new TurboLinkedList<int>();
        LinkList.Add(50);
        LinkList.Add(100);
        LinkList.Add(150);
        Assert.That(LinkList.Get(1), Is.EqualTo(100));
        LinkList.Set(1,200);
        Assert.That(LinkList.Get(1), Is.EqualTo(200));
    }

    [Test]
    public void LinkListRemoveAt()
    {
        var LinkList = new TurboLinkedList<int>();
        LinkList.Add(50);
        LinkList.Add(100);
        LinkList.Add(150);
        Assert.That(LinkList.Get(1), Is.EqualTo(100));
        LinkList.RemoveAt(1);
        Assert.That(LinkList.Get(1), Is.EqualTo(150));
    }

    [Test]
    public void LinkListClearsProperly()
    {
        var LinkList = new TurboLinkedList<int>();
        LinkList.Add(50);
        LinkList.Add(100);
        LinkList.Add(150);
        LinkList.Clear();
        Assert.That(LinkList, Is.Empty);
    }

    [Test]
    public void LinkListKnowsWhatItContains()
    {
        var LinkList = new TurboLinkedList<int>();
        LinkList.Add(50);
        LinkList.Add(100);
        LinkList.Add(150);
        Assert.That(LinkList.Contains(100));
        Assert.That(LinkList.Contains(300), Is.False);
    }

    [Test]
    public void LinkedListGivesCorrectItemIndex()
    {
        var LinkList = new TurboLinkedList<int>();
        LinkList.Add(50);
        LinkList.Add(100);
        LinkList.Add(150);
        Assert.That(LinkList.IndexOf(100), Is.EqualTo(1));
        Assert.That(LinkList.IndexOf(300), Is.EqualTo(-1));
    }

    [Test]
    public void LinkedListRemoveByValue()
    {
        var LinkList = new TurboLinkedList<int>();
        LinkList.Add(50);
        LinkList.Add(100);
        LinkList.Add(150);
        Assert.That(LinkList.Get(1), Is.EqualTo(100));
        LinkList.Remove(100);
        Assert.That(LinkList.Get(1), Is.EqualTo(150));
        Assert.That(LinkList.Contains(100), Is.False);
    }

    [Test]
    public void LinkedListAddRangeTurnsArrayIntoNodes()
    {
        var LinkList = new TurboLinkedList<int>();
        int[] arrayAdd = {100, 200, 300, 400, 500 };
        LinkList.AddRange(arrayAdd);
        Assert.That(LinkList.Get(0), Is.EqualTo(100));
        Assert.That(LinkList.Get(4), Is.EqualTo(500));
    }
}