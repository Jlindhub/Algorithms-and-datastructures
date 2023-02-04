namespace TurboCollections.Test;
public class HashingTests
{
    [Test]
    public void HashInsertTest()
    {
        HashSet<int> set = new HashSet<int>();
        set.Add(5);
        Assert.That(set.Add(5), Is.False);
        Assert.That(set.Add(6), Is.True);
    }

    [Test]
    public void HashDuplicateInsert()
    {
        HashSet<int> set = new HashSet<int>();
        set.Add(5);
        set.Add(5);
        Assert.That(set.Count == 1);
    }

    [Test]
    public void HashContainRemoveAndEnumerate()
    {
        HashSet<int> set = new HashSet<int> { 1,2,3,4,5 };
        Assert.That(set.Contains(3));
        Assert.That(set.Remove(3), Is.True);
        Assert.That(set.Contains(3), Is.False);
        foreach (var v in set) { Console.WriteLine(v); }
    }

    [Test]
    public void DictAdd()
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        dict.Add('a',1);
        dict.Add('b',2);
        Assert.Throws<ArgumentException>(()=>dict.Add('a',3));
    }

    [Test]
    public void DictContains()
    {
        Dictionary<char, int> dict = new Dictionary<char, int> { {'a',1},{'b',2},{'c',3},{'d',4},{'e',5},{'f',6} };
        Assert.That(dict.ContainsKey('f'), Is.True);
        Assert.That(dict.ContainsKey('q'), Is.False);
    }

    [Test]
    public void DictGetSetRemove()
    {
        Dictionary<char, int> dict = new Dictionary<char, int> { {'a',1},{'b',2},{'c',3},{'d',4},{'e',5},{'f',6} };
        Assert.That(dict['a'], Is.EqualTo(1)); //get
        dict['a'] = 10; //set
        Assert.That(dict['a'], Is.EqualTo(10));
        dict.Remove('a'); //remove
        var test = 0;
        Assert.Throws<KeyNotFoundException>(() => test = dict['a']); //exception test
    }
}