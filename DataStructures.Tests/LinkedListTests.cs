using System;
using FluentAssert;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DataStructures.Tests
{
    [TestFixture]
    public class LinkedListTests
    {
        #region ElementAt

        [Test]
        public void ElementAt_ShouldThrow_WhenIndexIsNegativeNumber()
        {
            // arrange
            var list = new LinkedList.LinkedList<string>();

            // act
            var actual = Assert.ThrowsException<ArgumentException>(() => list.ElementAt(-1));

            // assert
            actual.Message.ShouldBeEqualTo("Invalid index [-1].");
        }

        [Test]
        public void ElementAt_ShouldReturnCorrectElement_WhenIndexIsValid()
        {
            // arrange
            var list = new LinkedList.LinkedList<int> { 100, 200, 300, 400 };

            // act
            var actual = list.ElementAt(1);

            // assert
            actual.Item.ShouldBeEqualTo(200);
        }

        #endregion

        #region Length

        [Test]
        public void Lengh_ShouldReturnCorrectValue_WhenEmptyList()
        {
            // arrange
            var list = new LinkedList.LinkedList<string>();

            // assert
            list.Length.ShouldBeEqualTo(0);
        }

        [Test]
        public void Lengh_ShouldReturnCorrectValue_WhenOneItemAdded()
        {
            // arrange
            var list = new LinkedList.LinkedList<string>();

            // act
            list.Add("Mike");

            // assert
            list.Length.ShouldBeEqualTo(1);
        }

        #endregion

        #region Add

        [Test]
        public void Add_ShouldAddElementAndReturn()
        {
            // arrange
            var list = new LinkedList.LinkedList<string>();

            // act
            list.Add("Mike");

            // assert
            list.Length.ShouldBeEqualTo(1);
        }

        #endregion
    }
}
