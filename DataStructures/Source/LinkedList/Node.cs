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

        public Node<T> ElementAt(int index)
        {
            if (index < 0 || (index != 0 && Next == null))
            {
                return null;
            }

            if (index == 0)
            {
                return this;
            }

            return Next.ElementAt(index - 1);
        }
    }
}