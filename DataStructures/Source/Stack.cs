using DataStructures.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class Stack<T> : IStack<T>
    {
        private readonly LinkedList<T> _nodes = new LinkedList<T>();

        public void Push(T item)
        {
            if (_nodes.Count == 0)
            {
                _nodes.AddFirst(item);
                return;
            }

            _nodes.AddBefore(_nodes.First, item);
        }

        public T Pop()
        {
            var first = _nodes.First;
            if (first == null)
            {
                throw new InvalidOperationException("No elements in a stack.");
            }

            _nodes.Remove(first);
            return first.Value;
        }

        public T Peek()
        {
            var first = _nodes.First;
            if (first == null)
            {
                throw new InvalidOperationException("No elements in a stack.");
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
            var enumerable = _nodes.First;
            while (enumerable != null)
            {
                yield return enumerable.Value;
                enumerable = enumerable.Next;
            }
        }
    }
}