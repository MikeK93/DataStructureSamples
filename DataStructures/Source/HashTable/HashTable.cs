using System;
using System.Linq;
using DataStructures.Contracts;
using DataStructures.LinkedList;

namespace DataStructures.Source.HashTable
{
    public class HashTable : IHashTable
    {
        private const double LoadFactorThreshold = 0.9;
        private int _count;
        private ILinkedList<Entry>[] _entries;

        public HashTable()
        {
            _entries = new LinkedList<Entry>[15];
        }

        public object this[object key]
        {
            get
            {
                if (TryGet(key, out object value))
                {
                    return value;
                }

                throw new InvalidOperationException($"Key [{key}] does not exist in a table.");
            }
            set
            {
                AddOrUpdate(key, value, true);
            }
        }

        public void Add(object key, object value)
        {
            AddOrUpdate(key, value, false);
        }

        public bool TryGet(object key, out object value)
        {
            var entry = GetBucket(key, _entries).FirstOrDefault(x => x.Key.Equals(key));
            if (entry == null)
            {
                value = null;
                return false;
            }

            value = entry.Value;
            return true;
        }

        public bool Contains(object key)
        {
            return GetBucket(key, _entries).Any(entry => entry.Key.Equals(key));
        }

        private void AddOrUpdate(object key, object value, bool updatable)
        {
            var bucket = GetBucket(key, _entries);
            var entry = bucket.FirstOrDefault(x => x.Key.Equals(key));
            if (entry == null)
            {
                bucket.Add(new Entry(key, value));
                _count++;
                if ((double)_count / _entries.Length > LoadFactorThreshold)
                {
                    Resize();
                }
                return;
            }

            if (!updatable)
            {
                throw new InvalidOperationException($"Duplicated key: [{key}].");
            }

            if (value == null)
            {
                bucket.Remove(entry);
                _count--;
                return;
            }

            entry.Value = value;
        }

        private void Resize()
        {
            _count = 0;
            var resizedEntries = new LinkedList<Entry>[_entries.Length * 2];
            foreach (var list in _entries)
            {
                if (list == null)
                {
                    continue;
                }

                foreach (var entry in list)
                {
                    var bucket = GetBucket(entry.Key, resizedEntries);
                    bucket.Add(entry);
                    _count++;
                }
            }
        }

        private static ILinkedList<Entry> GetBucket(object key, ILinkedList<Entry>[] buckets)
        {
            var index = GetBucketIndex(key, buckets.Length);
            var bucket = buckets[index];
            if (bucket == null)
            {
                bucket = new LinkedList<Entry>();
                buckets[index] = bucket;
            }

            return bucket;
        }

        private static int GetBucketIndex(object key, int length)
        {
            return Math.Abs(127 * key.GetHashCode() + 1) % 16908799 % (length - 1);
        }
    }
}