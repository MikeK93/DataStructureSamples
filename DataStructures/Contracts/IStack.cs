using System.Collections.Generic;

namespace DataStructures.Contracts
{
    public interface IStack<T> : IEnumerable<T>
    {
        T Pop();
        void Push(T item);
        T Peek();
        int Count { get; }
    }
}