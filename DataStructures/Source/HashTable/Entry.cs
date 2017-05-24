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
            var another = obj as Entry<TKey, TValue>;
            return another != null && Key.Equals(another.Key) && Value.Equals(another.Value);
        }

        protected bool Equals(Entry<TKey, TValue> other)
        {
            return EqualityComparer<TKey>.Default.Equals(Key, other.Key) && EqualityComparer<TValue>.Default.Equals(Value, other.Value);
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