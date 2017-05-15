using System;
using System.Linq;
using DataStructures.Contracts;
using DataStructures.LinkedList;

namespace DataStructures.Source.HashTable
{
    public class HashTable : IHashTable
    {
        private const int Size = 10000;
        private const double LoadFactorThreshold = 0.9;

        private ILinkedList<Entry>[] _entries;

        public HashTable()
        {
            _entries = new LinkedList<Entry>[Size];
        }

        public object this[object key]
        {
            get { throw new NotImplementedException(); }
            set { Add(key, value); }
        }

        public void Add(object key, object value)
        {
            var bucket = GetBucket(key);

            bucket.Add(new Entry(key, value));
        }

        public bool TryGet(object key, out object value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object key)
        {
            return GetBucket(key).Any(entry => entry.Key.Equals(key));
        }

        private ILinkedList<Entry> GetBucket(object key)
        {
            var index = Compress(key);
            var bucket = _entries[index];
            if (bucket == null)
            {
                bucket = new LinkedList<Entry>();
                _entries[index] = bucket;
            }

            return bucket;
        }

        private int Compress(object key)
        {
            var hashCode = key.GetHashCode();

            int a = 127;
            int b = 1;
            int p = 16908799;

            var index = ((a * hashCode + b) % p) % _entries.Length;

            return index;
        }
    }
}