using System;
using DataStructures.Contracts;
using DataStructures.Source.HashTable;
using FluentAssert;
using NUnit.Framework;

namespace DataStructures.Tests
{
    [TestFixture]
    public class HashTableTests
    {
        private const string Key = "key";
        private const string Value = "value";

        private IHashTable _hashTable;

        [SetUp]
        public void SetUp()
        {
            _hashTable = new HashTable();
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
        public void Add_ShouldAddElementToTable()
        {
            // act
            _hashTable.Add(Key, Value);

            // assert
            _hashTable.Contains(Key).ShouldBeTrue();
        }

        [Test]
        public void Add_ShouldThrow_WhenElementWithSameKeyAddedTwice()
        {
            // arrange
            _hashTable.Add(Key, Value);

            // act
            var actual = Assert.Throws<InvalidOperationException>(() => _hashTable.Add(Key, Value));

            // assert
            actual.Message.ShouldBeEqualTo("Key [key] already exists in a table.");
        }

        #endregion
    }
}