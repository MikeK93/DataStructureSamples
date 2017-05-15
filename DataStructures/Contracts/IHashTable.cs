using System.Collections;

namespace DataStructures.Contracts
{
    public interface IHashTable : IEnumerable
    {
        bool Contains(object key);
        void Add(object key, object value);
        object this[object key] { get; set; }
        bool TryGet(object key, out object value);
    }
}