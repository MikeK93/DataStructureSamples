using System.Collections.Generic;

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

        public override string ToString()
        {
            return $"[{Key},{Value}]";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entry<TKey, TValue>);
        }

        public bool Equals(Entry<TKey, TValue> obj)
        {
            return obj != null && Key.Equals(obj.Key) && Value.Equals(obj.Value);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<TKey>.Default.GetHashCode(Key) * 397) ^ EqualityComparer<TValue>.Default.GetHashCode(Value);
            }
        }
    }
}