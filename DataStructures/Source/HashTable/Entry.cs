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
            return AreEqual(this, obj as Entry<TKey, TValue>);
        }

        public bool Equals(Entry<TKey, TValue> obj)
        {
            return AreEqual(this, obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<TKey>.Default.GetHashCode(Key) * 397) ^ EqualityComparer<TValue>.Default.GetHashCode(Value);
            }
        }

        public bool AreEqual(Entry<TKey, TValue> obj1, Entry<TKey, TValue> obj2)
        {
            return obj1 != null && obj1.Key.Equals(obj2.Key) && obj1.Value.Equals(obj2.Value);
        }
    }
}