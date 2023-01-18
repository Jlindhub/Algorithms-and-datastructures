namespace TurboCollections.Test;

public class TurboLinkedStackTests
{
    [Test]
    public void ItFollowsLIFO()
    {
        var stack = new TurboLinkedStack<int>();
        stack.Push(10);
        stack.Push(100);
        stack.Push(12);
        Assert.That(stack.Peek(), Is.EqualTo(12));
        Assert.That(stack.Peek(), Is.EqualTo(12));
        Assert.That(stack.Pop(), Is.EqualTo(12));
        Assert.That(stack.Peek(), Is.EqualTo(100));
        Assert.That(stack.Peek(), Is.EqualTo(100));
        Assert.That(stack.Pop(), Is.EqualTo(100));
        Assert.That(stack.Peek(), Is.EqualTo(10));
        Assert.That(stack.Peek(), Is.EqualTo(10));
        Assert.That(stack.Pop(), Is.EqualTo(10));

    }
    
    [Test]
    public void AddedItemsAreEnumerable()
    {
        var stack = new TurboLinkedStack<int>();
        stack.Push(10);
        stack.Push(100);
        stack.Push(12);
        CollectionAssert.AreEqual(stack, new []{12,100,10});

    }
    
}