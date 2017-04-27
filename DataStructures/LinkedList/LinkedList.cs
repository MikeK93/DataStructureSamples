using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.LinkedList
{
    public class LinkedList<T> : IEnumerable<Node<T>>
    {
        private Node<T> _head;
        private Node<T> _tale;

        public int Length => this.Count();

        public void Add(T item)
        {
            if (_head == null)
            {
                _tale = _head = new Node<T>(item);
                return;
            }
            
            _tale.Next = new Node<T>(item);
            _tale = _tale.Next;
        }

        public void AddAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public Node<T> ElementAt(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException($"Invalid index [{index}].");
            }

            var position = 0;
            foreach (var node in this)
            {
                if (position == index)
                {
                    return node;
                }
                position++;
            }

            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            if (_head == null)
            {
                yield break;
            }

            var enumerator = _head;
            while (enumerator != null)
            {
                yield return enumerator;
                enumerator = enumerator.Next;
            }
        }
    }
}