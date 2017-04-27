using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList
{
    public class LinkedList<T> : IEnumerable<Node<T>>
    {
        private Node<T> _head;
        private Node<T> _tale;

        public int Length { get; private set; }

        public void Add(T item)
        {
            Length++;

            if (_head == null)
            {
                _tale = _head = new Node<T>(item);
                return;
            }

            _tale =_tale.Next = new Node<T>(item);
        }

        public void AddAt(int index, T item)
        {
            if (index < 0 || index > Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Index [{index}] must be between [0] and [{Length}].");
            }

            if (index == Length)
            {
                _tale = _tale.Next = new Node<T>(item);
                Length++;
                return;
            }
            
            var previous = _head;
            foreach (var node in this)
            {
                if (index == 0)
                {
                    var newNode = new Node<T>(item, node);
                    if (previous != _head)
                    {
                        previous.Next = newNode;
                    }
                    else
                    {
                        _head = newNode;
                    }

                    Length++;
                    break;
                }
                previous = node;
                index--;
            }
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

            foreach (var node in this)
            {
                if (index == 0)
                {
                    return node;
                }
                index--;
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