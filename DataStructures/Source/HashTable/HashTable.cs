using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Contracts;

namespace DataStructures.Source.HashTable
{
    public class HashTable<TKey, TValue> : IHashTable<TKey, TValue>
    {
        private const double LoadFactorThreshold = 0.9;
        private ILinkedList<Entry<TKey, TValue>>[] _entries;

        public HashTable()
        {
            _entries = new LinkedList.LinkedList<Entry<TKey, TValue>>[15];
        }

        public int Count { get; private set; }

        public TValue this[TKey key]
        {
            get
            {
                if (TryGet(key, out TValue value))
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

        public void Add(TKey key, TValue value)
        {
            AddOrUpdate(key, value, false);
        }

        public bool TryGet(TKey key, out TValue value)
        {
            var entry = GetBucket(key, _entries).FirstOrDefault(x => x.Key.Equals(key));
            if (entry == null)
            {
                value = default(TValue);
                return false;
            }

            value = entry.Value;
            return true;
        }

        public bool Contains(TKey key)
        {
            return GetBucket(key, _entries).Any(entry => entry.Key.Equals(key));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Entry<TKey, TValue>> GetEnumerator()
        {
            if (Count == 0)
            {
                yield break;
            }

            for (int i = 0; i < _entries.Length; i++)
            {
                var bucket = _entries[i];
                if (bucket == null)
                {
                    continue;
                }

                foreach (var entry in bucket)
                {
                    yield return entry;
                }
            }
        }

        private void AddOrUpdate(TKey key, TValue value, bool updatable)
        {
            var bucket = GetBucket(key, _entries);
            var entry = bucket.FirstOrDefault(x => x.Key.Equals(key));
            if (entry == null)
            {
                bucket.Add(new Entry<TKey, TValue>(key, value));
                Count++;
                TryResize();
                return;
            }

            if (!updatable)
            {
                throw new InvalidOperationException($"Duplicated key: [{key}].");
            }

            if (value == null)
            {
                bucket.Remove(entry);
                Count--;
                return;
            }

            entry.Value = value;
        }

        private void TryResize()
        {
            if ((double)Count / _entries.Length < LoadFactorThreshold)
            {
                return;
            }

            var resizedEntries = new LinkedList.LinkedList<Entry<TKey, TValue>>[_entries.Length * 2];

            for (var i = 0; i < _entries.Length; i++)
            {
                var list = _entries[i];
                if (list == null)
                {
                    continue;
                }

                foreach (var entry in list)
                {
                    var bucket = GetBucket(entry.Key, resizedEntries);
                    bucket.Add(entry);
                }
            }

            _entries = resizedEntries;
        }

        private static ILinkedList<Entry<TKey, TValue>> GetBucket(TKey key, ILinkedList<Entry<TKey, TValue>>[] buckets)
        {
            var index = GetBucketIndex(key, buckets.Length);
            var bucket = buckets[index];
            if (bucket == null)
            {
                bucket = new LinkedList.LinkedList<Entry<TKey, TValue>>();
                buckets[index] = bucket;
            }

            return bucket;
        }

        private static int GetBucketIndex(TKey key, int length)
        {
            return Math.Abs(127 * key.GetHashCode() + 1) % 16908799 % (length - 1);
        }
    }
}