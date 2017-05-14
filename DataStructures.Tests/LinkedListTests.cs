using System;
using System.Collections;
using System.Linq;
using DataStructures.LinkedList;
using FluentAssert;
using NUnit.Framework;

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
            var list = new LinkedList<string>();

            // act
            var actual = Assert.Throws<ArgumentOutOfRangeException>(() => list.ElementAt(-1));

            // assert
            actual.Message.ShouldBeEqualTo("Index [-1] must be between [0] and [0].\r\nParameter name: index\r\nActual value was -1.");
        }

        [Test]
        public void ElementAt_ShouldReturnCorrectElement_WhenIndexIsValid()
        {
            // arrange
            var list = new LinkedList<int> { 100, 200, 300, 400 };

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
            var list = new LinkedList<string>();

            // assert
            list.Length.ShouldBeEqualTo(0);
        }

        [Test]
        public void Lengh_ShouldReturnCorrectValue_WhenOneItemAdded()
        {
            // arrange & act
            var list = new LinkedList<string> { "Mike" };

            // assert
            list.Length.ShouldBeEqualTo(1);
        }

        #endregion

        #region Add

        [Test]
        public void Add_ShouldAddElementAndReturn()
        {
            // arrange
            var list = new LinkedList<string>();

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
            var actual = Assert.Throws<ArgumentOutOfRangeException>(() => list.AddAt(100, 400));

            // assert
            actual.Message.ShouldBeEqualTo("Index [100] must be between [0] and [3].\r\nParameter name: index\r\nActual value was 100.");
        }

        [TestCaseSource(nameof(AddAtTestCaseSource))]
        public void AddAt_ShouldAddElementAtPosition(int position, string expected)
        {
            // arrange
            var list = new LinkedList<string> { "e", "p", "m" };

            // act
            list.AddAt(position, "a");

            var actual = list.Aggregate(string.Empty, String.Concat);

            // assert
            actual.ShouldBeEqualTo(expected);
        }
        private static IEnumerable AddAtTestCaseSource()
        {
            yield return new TestCaseData(0, "aepm") { TestName = "WhenElementAtBegginingOfList" };
            yield return new TestCaseData(2, "epam") { TestName = "WhenElementInMiddleOfList" };
            yield return new TestCaseData(3, "epma") { TestName = "WhenElementAtEndOfList" };
        }

        #endregion

        #region Remove

        [Test]
        public void Remove_ShouldDoNothing_WhenElementWasNotFound()
        {
            // arrange
            var list = new LinkedList<int> { 1, 2 };

            // act & assert
            Assert.DoesNotThrow(() => list.Remove(10));
        }

        [Test, TestCaseSource(nameof(RemoveTestCaseSource))]
        public void Remove_ShouldRemoveElement(string toRemove, string expected)
        {
            // arrange
            var list = new LinkedList<string> { "e", "p", "a", "m" };

            // act
            list.Remove(toRemove);
            var actual = list.Aggregate(string.Empty, String.Concat);

            // assert
            actual.ShouldBeEqualTo(expected);
        }

        private static IEnumerable RemoveTestCaseSource()
        {
            yield return new TestCaseData("e", "pam") { TestName = "WhenElementAtBeginningOfList" };
            yield return new TestCaseData("a", "epm") { TestName = "WhenElementInMiddleOfList" };
            yield return new TestCaseData("m", "epa") { TestName = "WhenElementAtEndOfList" };
        }

        #endregion

        #region RemoveAt

        [Test]
        public void RemoveAt_ShouldThrow_WhenIndexIsOutOfRange()
        {
            // arrange
            var list = new LinkedList<string> { "a", "b" };

            // act
            var actual = Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(100));

            // assert
            actual.Message.ShouldBeEqualTo("Index [100] must be between [0] and [1].\r\nParameter name: index\r\nActual value was 100.");
        }

        [Test, TestCaseSource(nameof(RemoveAtTestCaseSource))]
        public void RemoveAt_ShouldRemoveElementAtPosition(int index, string expected)
        {
            // arrange
            var list = new LinkedList<string> { "A", "B", "C", "D" };

            // act
            list.RemoveAt(index);
            var actual = list.Aggregate(string.Empty, String.Concat);
            
            // assert
            list.Length.ShouldBeEqualTo(3);
            actual.ShouldBeEqualTo(expected);
        }

        public static IEnumerable RemoveAtTestCaseSource()
        {
            yield return new TestCaseData(0, "BCD") { TestName = "WhenElementAtBeginningOfList" };
            yield return new TestCaseData(3, "ABC") { TestName = "WhenElementAtEndOfList" };
            yield return new TestCaseData(1, "ACD") { TestName = "WhenElementInMiddleOfList" };
        }

        #endregion
    }
}
