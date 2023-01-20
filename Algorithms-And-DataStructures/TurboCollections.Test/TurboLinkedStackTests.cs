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

    [Test]
    public void ClearCustomers()
    {
        var stack = new TurboLinkedStack<int>();
        stack.Push(10);
        stack.Push(100);
        stack.Push(12);
        Assert.That(stack.Peek(), Is.EqualTo(12));
        stack.Clear();
        Assert.That(stack, Is.Empty);

    }

    [Test]
    public void CountNodes()
    {
        var stack = new TurboLinkedStack<int>();
        stack.Push(10);
        stack.Push(100);
        stack.Push(12);
        stack.Push(10);
        stack.Push(100);
        stack.Push(12);
        Assert.That(stack.Count(), Is.EqualTo(6));
    }
    [Test]
    public void SomeTest(){
        TurboLinkedStack<int> stack = new TurboLinkedStack<int>();
        Assert.Throws<InvalidOperationException>(()=>stack.Peek());
    }

    class Hero{}
    [Test]
    public void SeeNull()
    {
        TurboLinkedStack<Hero?> heroes = new TurboLinkedStack<Hero?>();
        heroes.Push(new Hero());
        heroes.Push(null);
        Assert.That(heroes.Pop(), Is.Null);
    }

}