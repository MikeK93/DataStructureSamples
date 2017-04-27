using System;
using System.Collections;
using System.Linq;
using DataStructures.LinkedList;
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

        #region AddAt

        [Test]
        public void AddAt_ShouldThrow_WhenIndexIsOutOfRange()
        {
            // arrange
            var list = new LinkedList<int> { 100, 200, 300 };

            // act
            var actual = Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.AddAt(100, 400));

            // assert
            actual.Message.ShouldBeEqualTo("Index [100] must be between [0] and [3].\r\nParameter name: index\r\nActual value was 100.");
        }

        [TestCaseSource(nameof(AddAtTestCaseSource))]
        public void AddAt_ShouldAddElementAtPosition_WhenPassedCorrectIndex(int position, string expected)
        {
            // arrange
            var list = new LinkedList<string> { "e", "p", "m" };

            // act
            list.AddAt(position, "a");

            var actual = list.Aggregate(string.Empty, (current, node) => current + node.Item);

            // assert
            actual.ShouldBeEqualTo(expected);
        }
        private static IEnumerable AddAtTestCaseSource()
        {
            yield return new TestCaseData(0, "aepm");
            yield return new TestCaseData(2, "epam");
            yield return new TestCaseData(3, "epma");
        }

        #endregion

        #region Remove

        [Test]
        public void Remove_ShouldDoNothing_WhenElementWasNotFound()
        {
            // arrange
            // act
            // assert
        }

        [Test]
        public void Remove_ShouldRemoveElement_WhenElementExistsInList()
        {
            // arrange
            // act
            // assert
        }

        #endregion
    }
}
