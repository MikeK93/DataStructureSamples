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

            _tale = _tale.Next = new Node<T>(item);
        }

        public void AddAt(int index, T item)
        {
            ValidateIndex(index, Length);

            if (index == Length)
            {
                _tale = _tale.Next = new Node<T>(item);
            }
            else
            {
                var previous = _head;
                foreach (var current in this)
                {
                    if (index != 0)
                    {
                        previous = current;
                        index--;
                        continue;
                    }

                    var node = new Node<T>(item, current);
                    if (previous == current)
                    {
                        _head = node;
                        break;
                    }

                    previous.Next = node;
                    break;
                }
            }

            Length++;
        }

        public void Remove(T item)
        {
            var previous = _head;

            foreach (var current in this)
            {
                if (!current.Item.Equals(item))
                {
                    previous = current;
                    continue;
                }

                Length--;
                
                RemoveNode(current, previous);
                break;
            }
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index, Length - 1);
            
            var previous = _head;
            foreach (var current in this)
            {
                if (index != 0)
                {
                    index--;
                    previous = current;
                    continue;
                }

                RemoveNode(current, previous);
                break;
            }
        }

        public Node<T> ElementAt(int index)
        {
            ValidateIndex(index, Length);

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

        private void RemoveNode(Node<T> current, Node<T> previous)
        {
            if (current.Equals(previous))
            {
                _head = current.Next;
                return;
            }

            previous.Next = current.Next;
            if (previous.Next == null)
            {
                _tale = previous;
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