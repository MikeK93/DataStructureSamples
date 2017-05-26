using DataStructures.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            for (Node<T> previous = null, current = _head; current != null; previous = current, current = current.Next)
            {
                if (current.Item.Equals(item))
                {
                    RemoveNode(previous);
                    return;
                }
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
            return GetSequence().Select(node => node.Item).GetEnumerator();
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
            return GetSequence().Where((node, i) => i == index).FirstOrDefault();
        }

        private IEnumerable<Node<T>> GetSequence()
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

        private void ValidateIndex(int index, int maxIndex)
        {
            if (index < 0 || index > Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Index [{index}] must be between [0] and [{maxIndex}].");
            }
        }
    }
}