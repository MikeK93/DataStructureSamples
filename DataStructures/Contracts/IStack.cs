using System.Collections.Generic;

namespace DataStructures.Contracts
{
    public interface IStack<T> : IEnumerable<T>
    {
        /// <summary>
        /// Returns and removes item from the top of a stack.
        /// </summary>
        /// <returns>Top item in a stack.</returns>
        /// <exception cref="System.InvalidOperationException">Throws when call <see cref="Pop()"/> on an empty stack.</exception>
        T Pop();

        /// <summary>
        /// Adds item to the top of a stack.
        /// </summary>
        /// <param name="item">Item to be added to a stack.</param>
        void Push(T item);

        /// <summary>
        /// Returns item from the top of a stack without popping it.
        /// </summary>
        /// <returns>Top item in a stack.</returns>
        /// <exception cref="System.InvalidOperationException">Throws when call <see cref="Peek()"/> on an empty stack.</exception>
        T Peek();

        /// <summary>
        /// Gets count of items in a stack.
        /// </summary>
        int Count { get; }
    }
}