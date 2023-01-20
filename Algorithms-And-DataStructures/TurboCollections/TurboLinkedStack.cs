using System.Collections;
namespace TurboCollections;

public class TurboLinkedStack<T> : IEnumerable<T> //brackets for generic class, should be named ICollection
{
    private class Node
    {
        public T Value;
        public Node Previous;
    }
    Node lastNode;
    public int Count;
    public void Push(T item) { lastNode = new Node { Value = item, Previous = lastNode }; Count++;
    }
   public T Pop() { var node = lastNode; lastNode = node.Previous; Count--; return node.Value;  }

   public T Peek() { var node = lastNode; return node.Value; }
   public void Clear() { lastNode = null; Count = 0; }

   public IEnumerator<T> GetEnumerator()
    { return new Enumerator(lastNode); }

    IEnumerator IEnumerable.GetEnumerator()
    { return GetEnumerator(); }

    private class Enumerator : IEnumerator<T> //advanced stuff, i don't 100% understand it yet
    {
        private Node _firstNode;
        private Node _currentNode;

        public Enumerator(Node firstNode) { _firstNode = firstNode; }
        
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

        public T Current => _currentNode.Value;

        object IEnumerator.Current => Current;

        public void Dispose() { }
    }
}