using System.Collections.Generic;

namespace DataStructures.Contracts
{
    public interface IQueue<T> : IEnumerable<T>
    {
        /// <summary>
        /// Adds item to a queue.
        /// </summary>
        /// <param name="item">Item to add to a queue</param>
        void Enqueue(T item);

        /// <summary>
        /// Returns and removes last item from the queue.
        /// </summary>
        /// <returns>Last item in a queue.</returns>
        /// <exception cref="System.InvalidOperationException">Throws when call <see cref="Dequeue()"/> on an empty queue.</exception>
        T Dequeue();

        /// <summary>
        /// Gets count of items in a queue.
        /// </summary>
        int Count { get; }
    }
}