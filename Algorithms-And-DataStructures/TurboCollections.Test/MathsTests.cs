namespace TurboCollections.Test;

public class MathsTests
{
   
    [Test]
    public void SayHelloExists()
    {
        TurboMaths.SayHello();
    }

    [Test]
    public void OddNumbersWithYieldWorks()
    {
        List<int> expectedValues = new List<int> { 1, 3, 5, 7, 9, 11 };
        List<int> returnedValues = new List<int>();
        foreach (var value in TurboMaths.GetOddNumbersUntil(12))
        {
            returnedValues.Add(value);
        }
        CollectionAssert.AreEqual(expectedValues, returnedValues);
    }

    [Test]
    public void OddNumbersWithListWorks()
    {
        List<int> expectedValues = new List<int>{ 1, 3, 5, 7, 9, 11 };
        CollectionAssert.AreEqual(expectedValues, TurboMaths.GetOddNumbersUntilList(12)); 
    }
}