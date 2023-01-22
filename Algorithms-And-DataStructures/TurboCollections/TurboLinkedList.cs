using System.Collections;

namespace TurboCollections;

public class TurboLinkedList<T> : ITurboList<T>
{
    private class Node
    {
        public T Value;
        public Node? Next;

        public Node(T value, Node? next)
        {
            Value = value;
            Next = next;
        }
    }
    private Node? _firstNode;
    private Node? _lastNode;

    public int Count { get; private set; }
    
    public void Add(T item)
    {
        if (_firstNode == null) {
            var node = new Node(item,null);
            _firstNode = node;
            _lastNode = node;
        }
        else {
            var node = _lastNode;
            node!.Next = new Node(item,null); //null suppressed - if/else covers it.
            _lastNode = node.Next;
        }
        Count++;
    }

    public T Get(int index)
    {
        if (index >= Count) { throw new InvalidOperationException("Requested index is greater than list length!"); }
        var node = _firstNode;
        for(int i=0; i<index; i++) { node = node?.Next; }
        return node!.Value;
    }

    public void Set(int index, T value)
    {
        if (index >= Count)
        { throw new InvalidOperationException("Requested index is greater than list length!"); }
        var node = _firstNode;
        for(int i=0; i<index; i++) { node = node?.Next; }
        node!.Value = value;
    }

    public void Clear()
    {
         _firstNode = null; Count = 0;
    }

    public void RemoveAt(int index)
    {
        if (index >= Count)
        { throw new InvalidOperationException("Requested index is greater than list length!"); }
        var node = _firstNode;
        for(int i=0; i<index-1; i++) { node = node?.Next; }

        node!.Next = node.Next!.Next; //assigns node.next to node.next's next - so 1-2-3 -> 1-3. effectively 'poofs' middle node.
        Count--;
    }

    public bool Contains(T item)
    {
        if (_firstNode != null)
        {
            Node node = _firstNode;
            for (int i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(item, node.Value)) { return true; }
                //if above false - check if there is a following node:
                if (node.Next != null) node = node.Next;
                //if no following node - search must be complete, return false:
                else { return false; }
            }
        }
        throw new InvalidOperationException("List is empty, nothing to search!");
    }

    public int IndexOf(T item)
    {
        if (_firstNode != null)
        {
            Node node = _firstNode;
            for (int i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(item, node.Value)) { return i; }
                //if above false - check if there is a following node:
                if (node.Next != null) node = node.Next;
                //if no following node - search must be complete, return 'not found' value:
                else { return -1; }
            }
        }
        throw new InvalidOperationException("List is empty, nothing to search!");    
    }

    public void Remove(T item)
    {
        int index = IndexOf(item);
        if (index != -1) {RemoveAt(index);}
        else
        { throw new InvalidOperationException("value could not be found and not removed!"); }
    }

    public void AddRange(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }
    
    
    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(_firstNode);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    private class Enumerator : IEnumerator<T> //advanced stuff, i don't 100% understand it yet
    {
        private Node? _firstNode;
        private Node? _currentNode;

        public Enumerator(Node? firstNode) { _firstNode = firstNode; }
        
        public bool MoveNext()
        {
            if (_currentNode == null) { _currentNode = _firstNode; }
            else { _currentNode = _currentNode.Next; }
            return _currentNode != null;
        }

        public void Reset()
        {
            _currentNode = null;
        }

        public T Current
        {
            get {
                if (_currentNode != null) return _currentNode.Value;
                throw new InvalidOperationException("Please make Sure that the Stack is not Empty!");
            }
        }
        object? IEnumerator.Current => Current;
        public void Dispose() { }
    }

}