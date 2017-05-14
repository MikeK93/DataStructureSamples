using DataStructures.LinkedList;
using System.Collections.Generic;

namespace DataStructures.Contracts
{
    public interface ILinkedList<T> : IEnumerable<T>
    {
        int Length { get; }
        void Add(T item);
        void AddAt(int index, T item);
        void Remove(T item);
        void RemoveAt(int index);
        Node<T> ElementAt(int index);
    }
}