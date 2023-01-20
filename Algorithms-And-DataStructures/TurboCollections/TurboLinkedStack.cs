using System.Collections;
namespace TurboCollections;

public class TurboLinkedStack<T> : IEnumerable<T> //brackets for generic class, should be named ICollection
{
    private class Node
    {
        public T Value;
        public Node? Previous;

        public Node(T value, Node? previous)
        {
            Value = value;
            Previous = previous;
        }
    }

    private Node? _lastNode;
    public int Count;
    public void Push(T item) { _lastNode = new Node(item,_lastNode ); Count++;
    }

    public T Pop()
    {
        if(_lastNode == null){ throw new InvalidOperationException("Please make Sure that the Stack is not Empty!"); }
        var node = _lastNode;
        _lastNode = node.Previous;
        Count--;
        return node.Value;
    }

    public T Peek()
    {
        if(_lastNode == null){ throw new InvalidOperationException("Please make Sure that the Stack is not Empty!"); }
        var node = _lastNode; 
        return node.Value;

    }
   public void Clear() { _lastNode = null; Count = 0; }

   public IEnumerator<T> GetEnumerator()
    { return new Enumerator(_lastNode); }

    IEnumerator IEnumerable.GetEnumerator()
    { return GetEnumerator(); }

    private class Enumerator : IEnumerator<T> //advanced stuff, i don't 100% understand it yet
    {
        private Node? _firstNode;
        private Node? _currentNode;

        public Enumerator(Node? firstNode) { _firstNode = firstNode; }
        
        public bool MoveNext()
        {
            if (_currentNode == null) { _currentNode = _firstNode; }
            else { _currentNode = _currentNode.Previous; }
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