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
            var node = new Node<T>(item);

            if (_head == null)
            {
                _head = node;
                _tale = node;
            }
            else
            {
                _tale.Next = node;
                _tale = node;
            }

            Length++;
        }

        public void AddAt(int index, T item)
        {
            ValidateIndex(index, Length);

            if (index == 0)
            {
                _head = new Node<T>(item, _head);
                Length++;
                return;
            }

            if (index == Length)
            {
                Add(item);
                return;
            }

            var previous = FindNodeAt(index - 1);
            previous.Next = new Node<T>(item, previous.Next);
            Length++;
        }

        public void Remove(T item)
        {
            Node<T> previous = null;
            var node = _head;
            for (int i = 0; i < Length; i++)
            {
                if (node.Item.Equals(item))
                {
                    RemoveNode(previous);
                    return;
                }

                previous = node;
                node = node.Next;
            }
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index, Length - 1);

            var previous = FindNodeAt(index - 1);

            RemoveNode(previous);
        }

        public T ElementAt(int index)
        {
            ValidateIndex(index, Length);

            return FindNodeAt(index).Item;
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

        private void RemoveNode(Node<T> previous)
        {
            if (previous == null)
            {
                _head = _head.Next;
            }
            else if (previous.Next.Equals(_tale))
            {
                _tale = previous;
                _tale.Next = null;
            }
            else
            {
                previous.Next = previous.Next.Next;
            }

            Length--;
        }

        private Node<T> FindNodeAt(int index)
        {
            Node<T> result = null;
            for (var i = 0; i <= index; i++)
            {
                if (result == null)
                {
                    result = _head;
                }
                else
                {
                    result = result.Next;
                }
            }
            return result;
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