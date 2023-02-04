using TurboCollections.Trees;
namespace TurboCollections.Test;

public class TreeTest
{
   /*[Test]
   public void searchtreeSearches()
   {
      var tree = new BiTree<int>();
      tree.Insert(100);
      tree.Insert(150);
      tree.Insert(50);
      tree.Insert(25);
      tree.Insert(200);
      Assert.That(tree.Search(50), Is.EqualTo(1));
      Assert.That(tree.Search(200), Is.EqualTo(6)); // =6 because of 2 'empty' connections
   }*/

   [Test]
   public void SimpleTreeInsertAndSearch()
   {
      var tree = new SimpleBiTree<int>();
      tree.Insert(100);
      tree.Insert(150);
      tree.Insert(50);
      tree.Insert(25);
      tree.Insert(200);
      tree.Insert(125);
      SimpleBiTree<int>.Node searchednode = tree.Search(50);
      Assert.That(searchednode.Value == 50);
      Assert.That(searchednode.Parent == tree.Root);
   }

   [Test]
   public void SimpleTreeDeleteNode()
   {
      var tree = new SimpleBiTree<int>();
      tree.Insert(100);
      tree.Insert(150);
      tree.Insert(50);
      tree.Insert(25);
      tree.Insert(200);
      tree.Insert(125);
      SimpleBiTree<int>.Node searchednode = tree.Search(125); //search returns node, copy node in searchednode
      Assert.That(searchednode.Value == 125); //double check that correct node is returned by checking value
      Assert.That(searchednode.Value == tree.Root.RightChild.LeftChild.Value); //check if value matches expected position
      tree.Delete(150); //calls delete on searchnode 150, parent of 125, right child of 100
      Assert.That(searchednode.Value == tree.Root.RightChild.Value); //check that 125 has replaced it's parent
      searchednode = tree.Search(150); 
      Assert.That(searchednode == null); //check to make sure 150 is no longer found
   }

   [Test]
   public void SimpleTreeNormalOrder()
   {
      var tree = new SimpleBiTree<int>();
      tree.Insert(100);
      tree.Insert(150);
      tree.Insert(50);
      tree.Insert(25);
      tree.Insert(200);
      tree.Insert(125);
      List<int> smalltolarge = tree.SmallToLarge();
      foreach (var v in smalltolarge) { Console.WriteLine(v); }
      CollectionAssert.IsOrdered(smalltolarge);
   }
   
   [Test]
   public void SimpleTreeReverseOrder()
   {
      var tree = new SimpleBiTree<int>();
      tree.Insert(100);
      tree.Insert(150);
      tree.Insert(50);
      tree.Insert(25);
      tree.Insert(200);
      tree.Insert(125);
      List<int> largetosmall = tree.LargeToSmall();
      foreach (var v in largetosmall) { Console.WriteLine(v); }
      //CollectionAssert.IsOrdered(largetosmall);
      //i dunno how to check for reverse order using normal asserts, short of a manually constructed list. 
      List<int> shouldbe = new List<int>() { 200, 150, 125, 100, 50, 25 };
      Assert.That(largetosmall, Is.EqualTo(shouldbe));
   }

   [Test]
   public void CloningTrees()
   {
      var tree = new SimpleBiTree<int>();
      tree.Insert(100);
      tree.Insert(150);
      tree.Insert(50);
      tree.Insert(25);
      tree.Insert(200);
      tree.Insert(125);
      var clonetree = tree.CloneTree();
      List<int> original = tree.SmallToLarge();
      List<int> cloned = clonetree.SmallToLarge();
      foreach(var v in original){Console.WriteLine(v);}
      foreach(var v in cloned){Console.WriteLine(v);}
      Assert.That(cloned,Is.EqualTo(original));

   }
   
}