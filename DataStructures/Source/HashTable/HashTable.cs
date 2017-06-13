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
        private ILinkedList<Entry<TKey, TValue>>[] _buckets;

        public HashTable()
        {
            _buckets = new ILinkedList<Entry<TKey, TValue>>[15];
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
                ValidateForNull(key);

                var bucket = GetBucket(key, _buckets);
                var entry = bucket.FirstOrDefault(x => x.Key.Equals(key));
                if (entry == null)
                {
                    AddEntry(key, value, bucket);
                    return;
                }

                if (value == null)
                {
                    bucket.Remove(entry);
                    Count--;
                    return;
                }

                entry.Value = value;
            }
        }

        public void Add(TKey key, TValue value)
        {
            ValidateForNull(key);

            var bucket = GetBucket(key, _buckets);
            var entry = bucket.FirstOrDefault(x => x.Key.Equals(key));
            if (entry != null)
            {
                throw new InvalidOperationException($"Duplicated key: [{key}].");
            }

            AddEntry(key, value, bucket);
        }

        public bool TryGet(TKey key, out TValue value)
        {
            var entry = key != null ? GetBucket(key, _buckets).FirstOrDefault(x => x.Key.Equals(key)) : null;
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
            return key != null && GetBucket(key, _buckets).Any(entry => entry.Key.Equals(key));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Entry<TKey, TValue>> GetEnumerator()
        {
            return _buckets.Where(bucket => bucket != null).SelectMany(bucket => bucket).GetEnumerator();
        }

        private void AddEntry(TKey key, TValue value, ILinkedList<Entry<TKey, TValue>> bucket)
        {
            bucket.Add(new Entry<TKey, TValue>(key, value));
            Count++;
            TryResize();
        }

        private void TryResize()
        {
            if ((double)Count / _buckets.Length < LoadFactorThreshold)
            {
                return;
            }

            var resizedEntries = new ILinkedList<Entry<TKey, TValue>>[_buckets.Length * 2];
            
            foreach (var entry in _buckets.Where(bucket => bucket != null).SelectMany(entry => entry))
            {
                var bucket = GetBucket(entry.Key, resizedEntries);
                bucket.Add(entry);
            }

            _buckets = resizedEntries;
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

        public static void ValidateForNull(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
        }
    }
}