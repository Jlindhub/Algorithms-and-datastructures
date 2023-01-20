namespace TurboCollections;

public interface ITurboQueue<T> : IEnumerable<T>
{
  
    public int count { get; }


    void Enqueue(T item);
    T Peek();
    T Dequeue();
    void Clear();

}