namespace DataStructures.Source.HashTable
{
    public class Entry
    {
        public Entry(object key, object value)
        {
            Key = key;
            Value = value;
        }

        public object Key { get; }
        public object Value { get; set; }
    }
}