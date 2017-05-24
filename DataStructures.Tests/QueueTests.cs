using DataStructures;
using NUnit.Framework;
using FluentAssert;
using DataStructures.Contracts;
using System;
using System.Linq;

namespace DataStructures.Tests
{
    [TestFixture]
    public class QueueTests
    {
        private IQueue<string> _queue;

        [SetUp]
        public void SetUp()
        {
            _queue = new Queue<string>();
        }

        [Test]
        public void Enqueue_ShouldAddElementToQueue()
        {
            // act
            _queue.Enqueue("e");

            // assert
            _queue.Count.ShouldBeEqualTo(1);
        }

        #region Dequeue

        [Test]
        public void Dequeue_ShouldRemoveElementFromQueueInRightOrder()
        {
            // arrange
            _queue.Enqueue("e");
            _queue.Enqueue("p");

            // act
            var first = _queue.Dequeue();
            var last = _queue.Dequeue();

            // assert
            first.ShouldBeEqualTo("e");
            last.ShouldBeEqualTo("p");
        }

        [Test]
        public void Dequeue_ShouldUpdateCount()
        {
            // arrange
            _queue.Enqueue("a");
            _queue.Enqueue("a");

            // act
            _queue.Dequeue();

            // assert
            _queue.Count.ShouldBeEqualTo(1);
        }

        [Test]
        public void Dequeue_ShouldThrow_WhenQueueIsEmpty()
        {
            // act 
            var actual = Assert.Throws<InvalidOperationException>(() => _queue.Dequeue());

            // assert
            actual.Message.ShouldBeEqualTo("No elements in a queue.");
        }

        #endregion

        [Test]
        public void IEnumerableImplementation_ShouldBeAbleToIterateOverQueue()
        {
            // arrange
            var expeced = new[] { "A", "B", "C" };

            // act
            _queue.Enqueue("A");
            _queue.Enqueue("B");
            _queue.Enqueue("C");
            
            // assert
            _queue.AsEnumerable().ShouldBeEqualTo(expeced);
        }
    }
}