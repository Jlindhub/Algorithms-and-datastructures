namespace TurboCollections;

public interface ITurboList<T> : IEnumerable<T>
{
    int Count { get; }
    void Add(T item);
    T Get(int index);
    void Set(int index, T value);
    void Clear();
    void RemoveAt(int index);

    bool Contains(T item);
    int IndexOf(T item);
    void Remove(T item);
    void AddRange(IEnumerable<T> items);
}