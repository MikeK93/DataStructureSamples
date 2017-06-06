using System;

namespace DataStructures.LinkedList
{
    public class Node<T>
    {
        public Node(T item) : this(item, null) { }

        public Node(T item, Node<T> next)
        {
            Item = item;
            Next = next;
        }

        public T Item { get; set; }

        public Node<T> Next { get; set; }

        public override string ToString()
        {
            var nextValue = Next == null ? "NULL" : Convert.ToString(Next.Item);
            return $"{Convert.ToString(Item)} -> {nextValue}";
        }
    }
}