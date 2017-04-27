using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    internal class Stack<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> _nodes = new LinkedList<T>();

        public T Push(T item)
        {
            if (_nodes.Count == 0)
            {
                return _nodes.AddFirst(item).Value;
            }

            return _nodes.AddBefore(_nodes.First, item).Value;
        }

        public T Pop()
        {
            var first = _nodes.First;
            if (first == null)
            {
                return default(T);
            }

            _nodes.Remove(first);
            return first.Value;
        }

        public T Peek()
        {
            var first = _nodes.First;
            if (first == null)
            {
                return default(T);
            }

            return first.Value;
        }

        public int Count => _nodes.Count;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (_nodes.Count != 0)
            {
                yield return Pop();
            }
        }
    }
}