using System.Collections.Generic;

namespace DataStructures.Contracts
{
    public interface ILinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets a number of entries in a list.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Adds item to the end of a list.
        /// </summary>
        /// <param name="item">Item to be added.</param>
        void Add(T item);

        /// <summary>
        /// Adds item at specified position to a list.
        /// </summary>
        /// <param name="index">Position for the item being added. Must be between 0 and <see cref="Length"/>.</param>
        /// <param name="item">Item to be added.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Throws when index is out of range.</exception>
        void AddAt(int index, T item);
        
        /// <summary>
        /// Removes first occurence from a list.
        /// </summary>
        /// <param name="item">Item to be removed.</param>
        void Remove(T item);

        /// <summary>
        /// Removes item at specified position from a list.
        /// </summary>
        /// <param name="index">Position for the element to remove. Must be between 0 and <see cref="Length"/>-1.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Throws when index is out of range.</exception>
        void RemoveAt(int index);

        /// <summary>
        /// Returns item at specified position from a list.
        /// </summary>
        /// <param name="index">Position of item in a list. Must be between 0 and <see cref="Length"/>.</param>
        /// <returns>Item at <paramref name="index"/> position.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">When index is out of range.</exception>
        T ElementAt(int index);
    }
}