namespace DataStructures.Source.HashTable
{
    public class Entry<TKey, TValue>
    {
        public Entry(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key { get; }
        public TValue Value { get; set; }
    }
}