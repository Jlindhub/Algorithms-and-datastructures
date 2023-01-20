using System.Collections;
namespace TurboCollections;

public class TurboLinkedQueue<T> : ITurboQueue<T>
{
    class Node
    {
        public T Value;
        public Node? Next;
        public Node(T value, Node? next)
        {
            Value = value;
            Next = next;
        }
    }
    private Node? _firstInLine;
    private Node? _lastInLine;
    private int _newCount;
    public int count => _newCount;

    public void Enqueue(T item) {

        if (_firstInLine == null) {
            var node = new Node(item,null);
            _firstInLine = node;
            _lastInLine = node;
        }
        else {
            var node = _lastInLine;
            node!.Next = new Node(item,null); //null suppressed - if/else covers it.
            _lastInLine = node.Next;
        }
        _newCount++;
    }

    public T Peek() {
        if(_firstInLine == null){ throw new InvalidOperationException("Please make Sure that the Stack is not Empty!"); }
        var node = _firstInLine; 
        return node.Value; 
    }

    public T Dequeue() {
        if(_firstInLine == null){ throw new InvalidOperationException("Please make Sure that the Stack is not Empty!"); }
        var node = _firstInLine;
        _firstInLine = _firstInLine.Next;
        _newCount--;
        return node.Value;
    }

    public void Clear()
    { _firstInLine = null; _newCount = 0; }
    
    
    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(_firstInLine);
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