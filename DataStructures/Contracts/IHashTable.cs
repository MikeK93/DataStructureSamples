using DataStructures.Source.HashTable;
using System.Collections.Generic;

namespace DataStructures.Contracts
{
    public interface IHashTable<TKey, TValue> : IEnumerable<Entry<TKey, TValue>>
    {
        /// <summary>
        /// Checks if key exists in a table.
        /// </summary>
        /// <param name="key">Key to look up.</param>
        /// <returns>Exists or no.</returns>
        bool Contains(TKey key);

        /// <summary>
        /// Adds new entry to a table.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="System.InvalidOperationException">Throws when key already exists.</exception>
        void Add(TKey key, TValue value);

        /// <summary>
        /// Gets existing value by a key. Sets new entiry.if not key not found and update if found.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Value by a key.</returns>
        /// <exception cref="System.InvalidOperationException">Throws when key was not found.</exception>
        TValue this[TKey key] { get; set; }

        /// <summary>
        /// Returns false if key was not found and true if found.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool TryGet(TKey key, out TValue value);

        /// <summary>
        /// Gets count of entries in a table.
        /// </summary>
        int Count { get; }
    }
}