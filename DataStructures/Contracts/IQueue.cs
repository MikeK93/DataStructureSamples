using System.Collections.Generic;

namespace DataStructures.Contracts
{
    public interface IQueue<T> : IEnumerable<T>
    {
        void Enqueue(T item);
        T Dequeue();
        int Count { get; }
    }
}