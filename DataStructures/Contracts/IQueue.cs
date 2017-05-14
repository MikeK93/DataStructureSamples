using System.Collections.Generic;

namespace DataStructures.Contracts
{
    public interface IQueue<T> : IEnumerable<T>
    {
        T Enqueue(T item);
        T Dequeue();
        int Count { get; }
    }
}