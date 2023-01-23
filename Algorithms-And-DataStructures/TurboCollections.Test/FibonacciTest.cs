namespace TurboCollections.Test;

public class FibonacciTest
{
    [Test]
    public void FibonacciIterative()
    {
        Assert.That(Fibonacci.Iterative(40), Is.EqualTo(102334155));
        //response time: ~4ms
    }

    [Test]
    public void FibonacciRecursive()
    {
        Assert.That(Fibonacci.Recursive(40), Is.EqualTo(102334155));
        //response time: ~700ms
    }
}