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
        /// <returns>Status if <param name="key"/> was not found.</returns>
        bool Contains(TKey key);

        /// <summary>
        /// Adds new entry to a table.
        /// </summary>
        /// <param name="key">Key of entry.</param>
        /// <param name="value">Value of entry.</param>
        /// <exception cref="System.InvalidOperationException">Throws when key already exists.</exception>
        void Add(TKey key, TValue value);

        /// <summary>
        /// Gets existing value by a key. Sets new entiry.if not key not found and update if found.
        /// </summary>
        /// <param name="key">Key of entry.</param>
        /// <returns>Value associated with a <param name="key"/>.</returns>
        /// <exception cref="System.InvalidOperationException">Throws when key was not found.</exception>
        TValue this[TKey key] { get; set; }

        /// <summary>
        /// Returns false if key was not found and true if found.
        /// </summary>
        /// <param name="key">Key of entry.</param>
        /// <param name="value">Value of entry.</param>
        /// <returns></returns>
        bool TryGet(TKey key, out TValue value);

        /// <summary>
        /// Gets count of entries in a table.
        /// </summary>
        int Count { get; }
    }
}