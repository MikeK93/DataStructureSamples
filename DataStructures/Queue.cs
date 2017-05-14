using DataStructures.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class Queue<T> : IQueue<T>
    {
        private readonly LinkedList<T> _list = new LinkedList<T>();

        public T Enqueue(T item)
        {
            if (_list.Count == 0)
            {
                return _list.AddFirst(item).Value;
            }

            return _list.AddAfter(_list.Last, item).Value;
        }

        public T Dequeue()
        {
            var first = _list.First;
            if (first == null)
            {
                throw new InvalidOperationException("No elements in a queue.");
            }

            _list.Remove(first);
            return first.Value;
        }

        public int Count => _list.Count;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (_list.Count != 0)
            {
                yield return Dequeue();
            }
        }
    }
}