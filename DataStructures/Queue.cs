using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    internal class Queue<T> : IEnumerable<T>
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
                return default(T);
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