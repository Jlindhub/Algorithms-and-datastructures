namespace TurboCollections.Test;

public class AverageTest
{
    [Test]
    public void SimpleAveraging()
    {
        int[] values = { 1, 3, 5, 7, 9 };
        Assert.That(Averager.AveragingMachine(values), Is.EqualTo(5));
        values = new[] { 6, 7, 8 };
        Assert.That(Averager.AveragingMachine(values), Is.EqualTo(7));
    }
}