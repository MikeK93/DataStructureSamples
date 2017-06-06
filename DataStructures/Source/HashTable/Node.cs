namespace DataStructures.Source.HashTable
{
    public class Node
    {
        public Node(object key, object value) : this(key, value, null) { }

        public Node(object key, object value, Node next)
        {
            Key = key;
            Value = value;
            Next = next;
        }

        public object Value { get; set; }
        public object Key { get; private set; }
        public Node Next { get; private set; }
    }
}