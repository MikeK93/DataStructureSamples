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
            var node = new Node<T>(item, _head);

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
                _tale.Next = _head;
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
            RemoveNode(GetSequence().FirstOrDefault(node => node.Next.Item.Equals(item)));
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index, Length - 1);

            RemoveNode(FindNodeAt(index - 1));
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
                return;
            }

            if (previous == _tale)
            {
                _head = _head.Next;
                _tale.Next = _head;
            }
            else if (previous.Next.Equals(_tale))
            {
                _tale = previous;
                _tale.Next = _head;
            }
            else
            {
                previous.Next = previous.Next.Next;
            }

            Length--;
        }

        private Node<T> FindNodeAt(int index)
        {
            var nodeIndex = index >= 0 ? index : Length + index;
            return GetSequence().Skip(nodeIndex).FirstOrDefault();
        }

        private IEnumerable<Node<T>> GetSequence()
        {
            if (_head == null)
            {
                yield break;
            }

            var enumerator = _head;
            do
            {
                yield return enumerator;
                enumerator = enumerator.Next;
            } while (enumerator != _head);
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