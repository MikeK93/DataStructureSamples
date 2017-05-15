using System.Collections;
using DataStructures.Contracts;

namespace DataStructures.Source.HashTable
{
    public class HashTable : IHashTable
    {
        private const int Size = 10000;

        private Node[] _buckets;

        public HashTable()
        {
            _buckets = new Node[Size];
        }

        public object this[object key]
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public bool Contains(object key)
        {
            throw new System.NotImplementedException();
        }
        
        public void Add(object key, object value)
        {
            throw new System.NotImplementedException();
        }

        public bool TryGet(object key, out object value)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        private int Compress(object key)
        {
            var hashCode = key.GetHashCode();

            var index = 0;

            return index;
        }
    }
}