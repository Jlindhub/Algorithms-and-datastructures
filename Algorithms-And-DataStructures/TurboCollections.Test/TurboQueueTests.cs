namespace TurboCollections.Test;

public class TurboQueueTests
{
    [Test]
    public void ItFollowsFIFO() //should be first in, first out. tests: peek, enqueue, dequeue.
    {
        var queue = new TurboLinkedQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(100);
        queue.Enqueue(12);
        Assert.That(queue.Peek(), Is.EqualTo(10));
        Assert.That(queue.Peek(), Is.EqualTo(10));
        Assert.That(queue.Dequeue(), Is.EqualTo(10));
        Assert.That(queue.Peek(), Is.EqualTo(100));
        Assert.That(queue.Peek(), Is.EqualTo(100));
        Assert.That(queue.Dequeue(), Is.EqualTo(100));
        Assert.That(queue.Peek(), Is.EqualTo(12));
        Assert.That(queue.Peek(), Is.EqualTo(12));
        Assert.That(queue.Dequeue(), Is.EqualTo(12));
    }
    [Test]
    public void AddedItemsAreEnumerable() //tests that enumeration works
    {
        var queue = new TurboLinkedQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(100);
        queue.Enqueue(12);
        CollectionAssert.AreEqual(queue, new []{10,100,12});
    }
    [Test]
    public void CountNodes() //tests that node count works
    {
        var queue = new TurboLinkedQueue<int>();
        queue.Enqueue(100);
        queue.Enqueue(12);
        queue.Enqueue(10);
        queue.Enqueue(10);
        queue.Enqueue(100);
        queue.Enqueue(12);
        Assert.That(queue.Count, Is.EqualTo(6));
    }
    [Test]
    public void ClearQueue()
    {
        var Queue = new TurboLinkedQueue<int>();
        Queue.Enqueue(10);
        Queue.Enqueue(100);
        Queue.Enqueue(12);
        Assert.That(Queue.Peek(), Is.EqualTo(10));
        Queue.Clear();
        Assert.That(Queue, Is.Empty);
    }
    
    
    
    
}