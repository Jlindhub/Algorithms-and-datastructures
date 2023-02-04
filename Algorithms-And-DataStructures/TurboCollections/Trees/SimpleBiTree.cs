namespace TurboCollections.Trees;

public class SimpleBiTree<T>
{
   
    public class Node
    {
        public Node? LeftChild;
        public Node? RightChild;
        public Node? Parent;
        public int Value;
        public int Index;
        public int RootIndex = 0;

        public Node(int value)
        {
            Value = value;
        }
    }
    public Node? Root;
    public int Count { get; private set; }

    public void Insert(int item)
    {
        if (Root == null)
        {
            var node = new Node(item);
            node.Index = Count;
            Root = node;
            Count++;
        }
        else
        {
            var node = Root;
            while (true)
            {
                if (node!.LeftChild == null || node.RightChild == null) //suppressed - root already checked for null
                {
                    if (item >= node.Value)
                    {
                        node.RightChild = new Node(item) { Index = Count, Parent = node};
                        Count++;
                        return;
                    }

                    if (item < node.Value)
                    {
                        node.LeftChild = new Node(item) { Index = Count, Parent = node};
                        Count++;
                        return;
                    }
                    throw new InvalidOperationException("placing the value in a new node went wrong!");
                }
                if (item > node.Value) 
                { node = node.RightChild; }
                else
                { node = node.LeftChild; }
            }
        }
    }

    public Node Search(int item)
    {
        if (Root == null) { throw new InvalidOperationException("there is nothing to search!");}
        if (Root.Value == item) { return Root; }

        var node = Root;
        while (true)
        {
            if (node.LeftChild != null || node.RightChild != null)
            {
                if (item > node.Value) { node = node.RightChild; }
                else if (item < node.Value) { node = node.LeftChild; }
                if (item == node.Value) { return node; }
            }
            else { return null; }
        }
    }

    public void Delete(int item)
    {
        Node removeme = Search(item);
        if (removeme == null)
        { throw new InvalidOperationException("this number does not exist!"); }
        if (removeme.LeftChild == null && removeme.RightChild == null)
            //suppress note: every suppress are where there has to be a parent/child node by logic.
        {
            if (removeme == Root) { Root = null;}
            if (removeme == removeme.Parent!.RightChild) { removeme.Parent.RightChild = null; }
            else removeme.Parent.LeftChild = null;
        }
        else if (removeme.LeftChild == null && removeme.RightChild != null) //only right child
        { if (removeme == removeme.Parent!.RightChild) { removeme.Parent.RightChild = removeme.RightChild; } }
        else if (removeme.RightChild == null && removeme.LeftChild != null) //only left child
        { if (removeme == removeme.Parent!.LeftChild) { removeme.Parent.LeftChild = removeme.LeftChild; } }
        else //find maximum of left
        {
            Node maximizeLeft = removeme.LeftChild!;
            while (maximizeLeft.RightChild != null) //find max of left child (left -> right until done)
            { maximizeLeft = maximizeLeft.RightChild; }

            if (maximizeLeft.LeftChild != null) //if maxleft has left child
            { removeme.LeftChild!.RightChild = maximizeLeft.LeftChild; } //make maxleft child removeme's left's right child

            if (removeme == removeme.Parent!.LeftChild) //check if removeme is left or right child of parent, replace
            { removeme.Parent.LeftChild = maximizeLeft; }
            else removeme.Parent.RightChild = maximizeLeft;
        }
    }

    public List<int> SmallToLarge()
    {
        Node node = Root;
        List<int> retvalues = new List<int>();
        Traverse(node, retvalues);

         void Traverse(Node node, List<int> values)
         {
             if (node == null)
             { return;}
             Traverse(node.LeftChild, values);
             values.Add(node.Value);
             Traverse(node.RightChild, values);
             
         }
         return retvalues;
    }

    public List<int> LargeToSmall()
    {
        Node node = Root;
        List<int> retvalues = new List<int>();
        Traverse(node, retvalues);

        void Traverse(Node node, List<int> values)
        {
            if (node == null)
            { return;}
            Traverse(node.RightChild, values);
            values.Add(node.Value);
            Traverse(node.LeftChild, values);
             
        }
        return retvalues;
    }

    public SimpleBiTree<T> CloneTree()
    {
        SimpleBiTree<T> clonedtree = new SimpleBiTree<T>();
        clonedtree.Root = Clone(Root);

        Node Clone(Node node)
        {
            if (node == null)
                return null;
            Node cloneNode = new Node(node.Value);
            cloneNode.LeftChild = Clone(node.LeftChild);
            cloneNode.RightChild = Clone(node.RightChild);
            return cloneNode;
        }

        return clonedtree;
    }





    //older, non-recursive implementations that are very horrible. 
    public int[] ReturnStoL()
    {
        Node node = Root;
        Node prevnode=null;
        if (node == null) { throw new InvalidOperationException("no root found, no tree exists here!");}
        int[] valuesToReturn = new int[6];
        int count = 0;
        while (node.LeftChild != null || node.RightChild != null)
        {
            while (node.LeftChild != null && node.LeftChild != prevnode)
            { node = node.LeftChild; }

            if (node.LeftChild == null)
            {
                if (valuesToReturn.Length <= count) { Array.Resize(ref valuesToReturn, valuesToReturn.Length+1); }
                valuesToReturn[count] = node.Value; count++;
            }

            if (node != Root)
            {
                prevnode = node;
                node = node.Parent!;
            } //!= root is equivalent to parental null check
            if (valuesToReturn.Length <= count) { Array.Resize(ref valuesToReturn, valuesToReturn.Length+1); }
            valuesToReturn[count] = node.Value;
            count++;
            if (node.RightChild != null)
            {
                node = node.RightChild;
                if (node.LeftChild == null && node.RightChild == null)
                {
                    if (valuesToReturn.Length <= count) { Array.Resize(ref valuesToReturn, valuesToReturn.Length+1); }
                    valuesToReturn[count] = node.Value;
                    count++;
                }
            }
        }

        return valuesToReturn;
    }
    public int[] ReturnLtoS()
    {
        Node node = Root;
        Node prevnode=null;
        if (node == null) { throw new InvalidOperationException("no root found, no tree exists here!");}
        int[] valuesToReturn = new int[6];
        int count = 0;
        while (node.LeftChild != null || node.RightChild != null)
        {
            while (node.RightChild != null && node.RightChild != prevnode)
            { node = node.RightChild; }

            if (node.RightChild == null)
            {
                if (valuesToReturn.Length <= count) { Array.Resize(ref valuesToReturn, valuesToReturn.Length+1); }
                valuesToReturn[count] = node.Value; count++;
            }

            if (node != Root)
            {
                prevnode = node;
                node = node.Parent!;
            } //!= root is equivalent to parental null check
            if (valuesToReturn.Length <= count) { Array.Resize(ref valuesToReturn, valuesToReturn.Length+1); }
            valuesToReturn[count] = node.Value;
            count++;
            if (node.LeftChild != null)
            {
                node = node.LeftChild;
                if (node.RightChild == null && node.LeftChild == null)
                {
                    if (valuesToReturn.Length <= count) { Array.Resize(ref valuesToReturn, valuesToReturn.Length+1); }
                    valuesToReturn[count] = node.Value;
                    count++;
                }
            }
        }

        return valuesToReturn;
    }
    
    
    
}