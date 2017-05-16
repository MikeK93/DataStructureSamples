using DataStructures.Source.HashTable;
using System.Collections.Generic;

namespace DataStructures.Contracts
{
    public interface IHashTable<TKey, TValue> : IEnumerable<Entry<TKey, TValue>>
    {
        bool Contains(TKey key);
        void Add(TKey key, TValue value);
        TValue this[TKey key] { get; set; }
        bool TryGet(TKey key, out TValue value);
        int Count { get; }
    }
}