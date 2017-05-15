using DataStructures.Contracts;
using DataStructures.Source;
using DataStructures.Source.HashTable;
using NUnit.Framework;

namespace DataStructures.Tests
{
    [TestFixture]
    public class HashTableTests
    {
        private IHashTable _hashTable;

        [SetUp]
        public void SetUp()
        {
            _hashTable = new HashTable();
        }

        [Test]
        public void A()
        {
            object a = "Name";
            object b = "Name";

            var intAHashCode = a.GetHashCode();
        }
    }
}