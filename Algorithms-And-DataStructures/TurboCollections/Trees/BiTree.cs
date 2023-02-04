namespace TurboCollections.Trees;

public class BiTree<T>
{
   private T[] _nodes = new T[1_000_000];
   public Node Root => new Node(0, this);
   
   private int RootIndex => 0;
   private int GetLChildIndex(int index) { return index * 2 + 1; }
   private int GetRChildIndex(int index) { return index * 2 + 2; }
   private T GetValue(int index) => _nodes[index];
   private void SetValue(int index, T value)
   {
      if (_nodes.Length <= index) 
         Array.Resize(ref _nodes, _nodes.Length*2);
      
      _nodes[index] = value;
   }

   public struct Node
   {
       private readonly int _nodeI;
       private readonly BiTree<T> _tree;

       public Node(int nodeI, BiTree<T> tree) //constructor
       {
          _nodeI = nodeI; 
          _tree = tree;
       }
       public Node LeftChild => new(_tree.GetLChildIndex(_nodeI), _tree);
       public Node RightChild => new(_tree.GetRChildIndex(_nodeI), _tree);
       public T Value { get => _tree.GetValue(_nodeI); set => _tree.SetValue(_nodeI, value); }
       public int GetIndex => _nodeI;
   }
   
   public int Compare(T x, T y)
   { //use format: desired value, current node
      return Comparer<T>.Default.Compare(x, y); //x<y =-0, x=y=0,x>y=+0 
   }//just mimic the <>s of desired result probably

   public int Search(T search)
   {
      Node node = Root;
      if (Compare(search, node.Value) == 0) { return RootIndex; }
      while (Compare(search, node.Value) != 0)
      {
         if (Compare(search, node.Value) > 0) //greater than - right subtree
         { node = node.RightChild; }
         else { node = node.LeftChild; }

         if (node.LeftChild.Equals(0) && node.RightChild.Equals(0)) { return -1; }
         //if value of node is equal to search value, while loop will not iterate
      }
      return node.GetIndex;
   }

   public void Insert(T value)
   {
      Node node = Root;
      if (node.Value.Equals(0)) { node.Value = value; return; }

      while (Compare(value, node.Value) != 0)
      {
         if (node.LeftChild.Value.Equals(0) || node.RightChild.Value.Equals(0))
         {
            if (Compare(value, node.Value) > 0)
            {
               var newNode = node.RightChild;
               newNode.Value = value;
               return;
            }
            else
            {
               var newNode = node.LeftChild;
               newNode.Value = value;
               return;
            }
         }
         
         if (Compare(value, node.Value) > 0) { node = node.RightChild; }
         else { node = node.LeftChild; }
      }
   }

   public void InOrderTransversal(Node node, List<T> result)
   {
      
      
   }

  

}