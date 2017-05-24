using System;
using System.Collections;
using System.Linq;
using DataStructures.LinkedList;
using FluentAssert;
using NUnit.Framework;
using DataStructures.Contracts;

namespace DataStructures.Tests
{
    [TestFixture]
    public class LinkedListTests
    {
        #region ElementAt

        [Test]
        public void ElementAt_ShouldThrow_WhenIndexIsOutOfRange()
        {
            // arrange
            ILinkedList<string> list = new LinkedList<string>();

            // act
            var actual = Assert.Throws<ArgumentOutOfRangeException>(() => list.ElementAt(-1));

            // assert
            actual.Message.ShouldBeEqualTo("Index [-1] must be between [0] and [0].\r\nParameter name: index\r\nActual value was -1.");
        }

        [Test]
        public void ElementAt_ShouldReturnCorrectElement_WhenIndexIsValid()
        {
            // arrange
            ILinkedList<int> list = new LinkedList<int> { 100, 200, 300, 400 };

            // act
            var actual = list.ElementAt(1);

            // assert
            actual.ShouldBeEqualTo(200);
        }

        #endregion

        #region Length

        [Test]
        public void Lengh_ShouldReturnCorrectValue_WhenEmptyList()
        {
            // arrange
            ILinkedList<string> list = new LinkedList<string>();

            // assert
            list.Length.ShouldBeEqualTo(0);
        }

        [Test]
        public void Lengh_ShouldReturnCorrectValue_WhenOneItemAdded()
        {
            // arrange & act
            ILinkedList<string> list = new LinkedList<string> { "Mike" };

            // assert
            list.Length.ShouldBeEqualTo(1);
        }

        #endregion

        #region Add

        [Test]
        public void Add_ShouldAddElementToList()
        {
            // arrange
            ILinkedList<string> list = new LinkedList<string>();

            // act
            list.Add("Mike");

            // assert
            list.Length.ShouldBeEqualTo(1);
        }

        #endregion

        #region AddAt

        [Test]
        public void AddAt_ShouldThrow_WhenIndexIsOutOfRange()
        {
            // arrange
            ILinkedList<int> list = new LinkedList<int> { 100, 200, 300 };

            // act
            var actual = Assert.Throws<ArgumentOutOfRangeException>(() => list.AddAt(100, 400));

            // assert
            actual.Message.ShouldBeEqualTo("Index [100] must be between [0] and [3].\r\nParameter name: index\r\nActual value was 100.");
        }

        [TestCase(0, new[] { "a", "e", "p", "m" }, TestName = "WhenElementAtBegginingOfList")]
        [TestCase(2, new[] { "e", "p", "a", "m" }, TestName = "WhenElementInMiddleOfList")]
        [TestCase(3, new[]{ "e", "p", "m", "a" }, TestName = "WhenElementAtEndOfList")]
        public void AddAt_ShouldAddElementAtPosition(int position, string[] expected)
        {
            // arrange
            ILinkedList<string> list = new LinkedList<string> { "e", "p", "m" };

            // act
            list.AddAt(position, "a");

            // assert
            list.AsEnumerable().ShouldBeEqualTo(expected);
        }
        
        #endregion

        #region Remove

        [Test]
        public void Remove_ShouldNotThrow_WhenElementWasNotFound()
        {
            // arrange
            ILinkedList<int> list = new LinkedList<int> { 1, 2 };

            // act & assert
            Assert.DoesNotThrow(() => list.Remove(10));
        }

        [Test]
        public void Remove_ShouldNotChangeList_WhenElementWasNotFound()
        {
            // arrange
            ILinkedList<int> list = new LinkedList<int> { 1, 2 };

            // act & assert
            list.Length.ShouldBeEqualTo(2);
        }

        [TestCase("e", new[] { "p", "a", "m" }, TestName = "WhenElementAtBeginningOfList")]
        [TestCase("a", new[] { "e", "p", "m" }, TestName = "WhenElementInMiddleOfList")]
        [TestCase("m", new[] { "e", "p", "a" }, TestName = "WhenElementAtEndOfList")]
        public void Remove_ShouldRemoveElement(string toRemove, string[] expected)
        {
            // arrange
            ILinkedList<string> list = new LinkedList<string> { "e", "p", "a", "m" };

            // act
            list.Remove(toRemove);

            // assert
            list.AsEnumerable().ShouldBeEqualTo(expected);
        }
        
        #endregion

        #region RemoveAt

        [Test]
        public void RemoveAt_ShouldThrow_WhenIndexIsOutOfRange()
        {
            // arrange
            ILinkedList<string> list = new LinkedList<string> { "a", "b" };

            // act
            var actual = Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(100));

            // assert
            actual.Message.ShouldBeEqualTo("Index [100] must be between [0] and [1].\r\nParameter name: index\r\nActual value was 100.");
        }
        
        [TestCase(0, new[] { "B", "C", "D" }, TestName = "WhenElementAtBeginningOfList")]
        [TestCase(3, new[] { "A", "B", "C" }, TestName = "WhenElementAtEndOfList")]
        [TestCase(1, new[] { "A", "C", "D" }, TestName = "WhenElementInMiddleOfList")]
        public void RemoveAt_ShouldRemoveElementAtPosition(int index, string[] expected)
        {
            // arrange
            ILinkedList<string> list = new LinkedList<string> { "A", "B", "C", "D" };

            // act
            list.RemoveAt(index);

            // assert
            list.AsEnumerable().ShouldBeEqualTo(expected);
        }
        
        #endregion


    }
}