using System;
using DataStructures.Contracts;
using DataStructures.Source.HashTable;
using FluentAssert;
using NUnit.Framework;
using System.Collections.Generic;

namespace DataStructures.Tests
{
    [TestFixture]
    public class HashTableTests
    {
        private const string Key = "key";
        private const string Value = "value";

        private IHashTable<string, string> _hashTable;

        [SetUp]
        public void SetUp()
        {
            _hashTable = new HashTable<string, string>();
        }

        #region Contains

        [Test]
        public void Contains_ShouldReturnFalse_WhenElementIsNotInTable()
        {
            // act & assert
            _hashTable.Contains(Key).ShouldBeFalse();
        }

        [Test]
        public void Contains_ShouldReturnTrue_WhenElementExistsInTable()
        {
            // arrange
            _hashTable.Add(Key, Value);

            // act & assert
            _hashTable.Contains(Key).ShouldBeTrue();
        }

        #endregion

        #region Add

        [Test]
        public void Add_ShouldAddElementsToTable()
        {
            // act
            _hashTable.Add(Key, Value);
            _hashTable.Add("Key2", Value);

            // assert
            _hashTable.Contains(Key).ShouldBeTrue();
            _hashTable.Contains("Key2").ShouldBeTrue();
        }

        [Test]
        public void Add_ShouldThrow_WhenElementWithSameKeyAddedTwice()
        {
            // arrange
            _hashTable.Add(Key, Value);

            // act
            var actual = Assert.Throws<InvalidOperationException>(() => _hashTable.Add(Key, Value));

            // assert
            actual.Message.ShouldBeEqualTo("Duplicated key: [key].");
        }

        #endregion

        #region Setter

        [Test]
        public void Setter_ShouldRemoveElement_WhenSetNullValueForKey()
        {
            // arrange
            _hashTable.Add(Key, Value);
            _hashTable.Add("Key2", Value);

            // act
            _hashTable[Key] = null;

            // assert
            _hashTable.Contains(Key).ShouldBeFalse();
            _hashTable.Contains("Key2").ShouldBeTrue();
        }

        [Test]
        public void Setter_ShouldAddElement_WhenKeyNotExistsAndNonNullValueForKeyPassed()
        {
            // act
            _hashTable[Key] = Value;

            // assert
            _hashTable.Contains(Key).ShouldBeTrue();
        }

        [Test]
        public void Setter_ShouldModifyElement_WhenKeyExists()
        {
            // arrange
            _hashTable.Add(Key, Value);

            // act
            _hashTable[Key] = "modified";

            // assert
            _hashTable[Key].ShouldBeEqualTo("modified");
        }

        #endregion

        #region Getter

        [Test]
        public void Getter_ShouldReturnElement_WhenKeyExists()
        {
            // arrange
            _hashTable.Add(Key, Value);

            // act
            var actual = _hashTable[Key];

            // assert
            actual.ShouldBeEqualTo(Value);
        }

        [Test]
        public void Getter_ShouldThrow_WhenKeyDoesNotExist()
        {
            // arrange
            _hashTable.Add(Key, Value);

            // act
            object value = null;
            var actual = Assert.Throws<InvalidOperationException>(() => value = _hashTable["invalid key"]);

            // assert
            actual.Message.ShouldBeEqualTo("Key [invalid key] does not exist in a table.");
        }

        #endregion

        #region TryGet

        [Test]
        public void TryGet_ShouldReturnFalse_WhenKeyWasNotFound()
        {
            // arrange
            _hashTable.Add(Key, Value);

            // act
            var actual = _hashTable.TryGet("invalid key", out string value);

            // assert
            actual.ShouldBeFalse();
        }
        
        [Test]
        public void TryGet_ShouldReturnTrueAndSetOutParameter_WhenKeyExists()
        {
            // arrange
            _hashTable.Add(Key, Value);

            // act
            var actual = _hashTable.TryGet(Key, out string value);

            // assert
            actual.ShouldBeTrue();
            value.ShouldBeEqualTo(Value);
        }

        #endregion

        [Test]
        public void IEnumerableImplementation_ShouldBeAbleToIterateOverTable()
        {
            // arrange
            var items = new Entry<string, string>[]
            {
                new Entry<string, string>("key1", "value1"),
                new Entry<string, string>("key2", "value2"),
                new Entry<string, string>("key3", "value3"),
                new Entry<string, string>("key4", "value4")
            };

            foreach (var item in items)
            {
                _hashTable.Add(item.Key, item.Value);
            }

            // act
            var actual = new List<Entry<string, string>>();
            foreach (var item in _hashTable)
            {
                actual.Add(item);
            }

            // assert
            actual.Count.ShouldBeEqualTo(4);
            actual.TrueForAll(entry => _hashTable.Contains(entry.Key)).ShouldBeTrue();
        }
    }
}