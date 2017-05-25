using System;
using DataStructures.Contracts;
using DataStructures.Source.HashTable;
using FluentAssert;
using NUnit.Framework;
using System.Linq;

namespace DataStructures.Tests
{
    [TestFixture]
    public class HashTableTests
    {
        private const string Key = "key";
        private const string Value = "value";
        private const string Key2 = "Key2";
        private const string Value2 = "Value2";

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
            // arrange
            _hashTable.Add(Key2, Value2);

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
            _hashTable.Add(Key2, Value);

            // assert
            _hashTable.Contains(Key).ShouldBeTrue();
            _hashTable.Contains(Key2).ShouldBeTrue();
        }

        [Test]
        public void Add_ShouldUpdateCount()
        {
            // act
            _hashTable.Add(Key, Value);
            _hashTable.Add(Key2, Value);

            // assert
            _hashTable.Count.ShouldBeEqualTo(2);
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
        public void Setter_ShouldRemoveElement_WhenSetNullValueForExistingKey()
        {
            // arrange
            _hashTable.Add(Key, Value);
            _hashTable.Add(Key2, Value);

            // act
            _hashTable[Key] = null;

            // assert
            _hashTable.Contains(Key).ShouldBeFalse();
        }

        [Test]
        public void Setter_ShouldRemoveElementAndUpdateCount_WhenSetNullValueForExistingKey()
        {
            // arrange
            _hashTable.Add(Key, Value);
            _hashTable.Add(Key2, Value);

            // act
            _hashTable[Key] = null;

            // assert
            _hashTable.Count.ShouldBeEqualTo(1);
        }

        [Test]
        public void Setter_ShouldRemoveElementAndDontRemoveAnotherKey_WhenSetNullValueForExistingKey()
        {
            // arrange
            _hashTable.Add(Key, Value);
            _hashTable.Add(Key2, Value);

            // act
            _hashTable[Key] = null;

            // assert
            _hashTable.Contains(Key2).ShouldBeTrue();
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
            _hashTable.Add(Key2, Value2);

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
            _hashTable.Add(Key2, Value2);

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
            _hashTable.Add(Key2, Value2);

            // act
            var actual = Assert.Throws<InvalidOperationException>(() => { var value = _hashTable["invalid key"]; });

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
            _hashTable.Add(Key2, Value2);

            // act
            var actual = _hashTable.TryGet("invalid key", out string value);

            // assert
            actual.ShouldBeFalse();
        }

        [Test]
        public void TryGet_ShouldSetValueToNull_WhenKeyWasNotFound()
        {
            // arrange
            _hashTable.Add(Key, Value);
            _hashTable.Add(Key2, Value2);

            // act
            _hashTable.TryGet("invalid key", out string value);

            // assert
            value.ShouldBeNull();
        }

        [Test]
        public void TryGet_ShouldReturnTrue_WhenKeyExists()
        {
            // arrange
            _hashTable.Add(Key, Value);
            _hashTable.Add(Key2, Value2);

            // act
            var actual = _hashTable.TryGet(Key, out string value);

            // assert
            actual.ShouldBeTrue();
        }

        [Test]
        public void TryGet_ShoudSetOutParameterWithCorrectValue_WhenKeyExists()
        {
            // arrange
            _hashTable.Add(Key, Value);
            _hashTable.Add(Key2, Value2);

            // act
            _hashTable.TryGet(Key, out string value);

            // assert
            value.ShouldBeEqualTo(Value);
        }

        #endregion

        [Test]
        public void IEnumerableImplementation_ShouldBeAbleToIterateOverTable()
        {
            // arrange
            var expected = new[]
            {
                new Entry<string, string>("key1", "value1"),
                new Entry<string, string>("key2", "value2"),
                new Entry<string, string>("key3", "value3"),
                new Entry<string, string>("key4", "value4")
            };

            // act
            _hashTable = new HashTable<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" },
                { "key3", "value3" },
                { "key4", "value4" }
            };

            // assert
            _hashTable.AsEnumerable().ShouldBeEqualTo(expected);
        }
    }
}