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
            }
            else if (index == Length)
            {
                Add(item);
                return;
            }
            else
            {
                var previous = ElementAt(index - 1, _head);
                previous.Next = new Node<T>(item, previous.Next);
            }

            Length++;
        }

        public void Remove(T item)
        {
            var previous = _head;
            for (int i = 0; i < Length; i++)
            {
                var node = ElementAt(i, _head);
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

            return ElementAt(index, _head);
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
                previous = previous ?? ElementAt(index - 1, _head);

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

        private Node<T> ElementAt(int index, Node<T> node)
        {
            var result = node;

            while (index <= 0 && result != null)
            {
                result = result.Next;
                index--;
            }

            return result;
            
            //if (index < 0 || index == 0 || node == null)
            //{
            //    return node;
            //}
            
            //return ElementAt(index - 1, node.Next);
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