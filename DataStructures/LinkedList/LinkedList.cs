using DataStructures.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tale;

        public int Length { get; private set; }

        public void Add(T item)
        {
            Length++;

            var node = new Node<T>(item);

            if (_head == null)
            {
                _head = node;
                _tale = node;
                return;
            }

            _tale.Next = node;
            _tale = node;
        }

        public void AddAt(int index, T item)
        {
            ValidateIndex(index, Length);

            Length++;

            if (index == 0)
            {
                _head = new Node<T>(item, _head);
                return;
            }

            if (index == Length)
            {
                Add(item);
                return;
            }

            var previous = _head.ElementAt(index - 1);
            previous.Next = new Node<T>(item, previous.Next);
        }

        public void Remove(T item)
        {
            var previous = _head;
            for (int i = 0; i < Length; i++)
            {
                var node = _head.ElementAt(i);
                if (node.Item.Equals(item))
                {
                    RemoveNode(i, previous);
                    return;
                }

                previous = node;
            }
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index, Length - 1);

            RemoveNode(index);
        }

        public Node<T> ElementAt(int index)
        {
            ValidateIndex(index, Length);

            return _head.ElementAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_head == null)
            {
                yield break;
            }

            var enumerator = _head;
            while (enumerator != null)
            {
                yield return enumerator.Item;
                enumerator = enumerator.Next;
            }
        }

        private void RemoveNode(int index, Node<T> previous = null)
        {
            if (index == 0)
            {
                _head = _head.Next;
            }
            else
            {
                previous = previous ?? _head.ElementAt(index - 1);

                if (index == Length - 1)
                {
                    _tale = previous;
                    _tale.Next = null;
                }
                else
                {
                    previous.Next = previous.Next.Next;
                }
            }

            Length--;
        }

        private void ValidateIndex(int index, int maxIndex)
        {
            if (index < 0 || index > Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Index [{index}] must be between [0] and [{maxIndex}].");
            }
        }
    }
}