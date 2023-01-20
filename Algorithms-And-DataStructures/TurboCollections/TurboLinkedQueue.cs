using System.Collections;
namespace TurboCollections;

public class TurboLinkedQueue<T> : ITurboQueue<T>
{
    class Node
    {
        public T Value;
        public Node Next;
    }
    private Node FirstinLine;
    private Node LastinLine;
    
    public int count => Count();

    public int Count()
    {
        int countInternal = 0;
        Node currentNode = FirstinLine;
        while (currentNode != null) {
            countInternal++;
            currentNode = currentNode.Next;
        }

        return countInternal;
    }
    
    public void Enqueue(T item) {

        if (FirstinLine == null) {
            var node = new Node { Value = item };
            FirstinLine = node;
            LastinLine = node;
        }
        else {
            var node = LastinLine;
            node.Next = new Node { Value = item };
            LastinLine = node.Next;
        }
        
    }

    public T Peek() {
        var node = FirstinLine; 
        return node.Value; 
    }

    public T Dequeue() {
        var node = FirstinLine;
        FirstinLine = FirstinLine.Next;
        return node.Value;
    }

    public void Clear()
    { FirstinLine = null; }
    
    
    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(FirstinLine);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    private class Enumerator : IEnumerator<T> //advanced stuff, i don't 100% understand it yet
    {
        private Node _firstNode;
        private Node _currentNode;

        public Enumerator(Node firstNode) { _firstNode = firstNode; }
        
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

        public T Current => _currentNode.Value;
        object IEnumerator.Current => Current;
        public void Dispose() { }
    }

}
public interface ITurboQueue<T> : IEnumerable<T>
{
  
    public int count { get; }


    void Enqueue(T item);
    T Peek();
    T Dequeue();
    void Clear();

}