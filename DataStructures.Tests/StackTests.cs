using DataStructures.Contracts;
using FluentAssert;
using NUnit.Framework;
using System;

namespace DataStructures.Tests
{
    [TestFixture]
    public class StackTests
    {
        private IStack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [Test]
        public void Push_AddsElementToStackAndReturnAddedElement()
        {
            // arrange
            var expected = "Yes";

            // act
            var actual = _stack.Push(expected);

            // assert
            _stack.Count.ShouldBeEqualTo(1);
            actual.ShouldBeEqualTo(expected);
        }

        #region Pop

        [Test]
        public void Pop_ShouldPopElementsInRightOrder()
        {
            // arrange
            _stack.Push("first");
            _stack.Push("last");

            // act
            var first = _stack.Pop();
            var last = _stack.Pop();

            // assert
            _stack.Count.ShouldBeEqualTo(0);
            first.ShouldBeEqualTo("last");
            last.ShouldBeEqualTo("first");
        }

        [Test]
        public void Pop_ShouldThrow_WhenStackIsEmpty()
        {
            // act
            var actual = Assert.Throws<InvalidOperationException>(() => _stack.Pop());

            // assert
            actual.Message.ShouldBeEqualTo("No elements in a stack.");
        }

        #endregion

        #region Peek

        [Test]
        public void Peek_ShouldShowNextElementWithoutPopping()
        {
            // arrange
            _stack.Push("a");

            // act
            var actual = _stack.Peek();

            // assert
            _stack.Count.ShouldBeEqualTo(1);
            actual.ShouldBeEqualTo("a");
        }

        [Test]
        public void Peek_ShouldThrow_WhenStackIsEmpty()
        {
            // act
            var actual = Assert.Throws<InvalidOperationException>(() => _stack.Peek());

            // assert
            actual.Message.ShouldBeEqualTo("No elements in a stack.");
        }

        #endregion
    }
}