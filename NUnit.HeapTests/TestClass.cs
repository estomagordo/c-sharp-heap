using Heap;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.HeapTests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void DefaultConstructor_CreatesEmptyHeap()
        {
            var heap = new Heap<int>();

            Assert.AreEqual(true, heap.Empty);
            Assert.AreEqual(0, heap.Size);
            Assert.Throws<InvalidOperationException>(() => heap.Peek());
            Assert.Throws<InvalidOperationException>(() => heap.Pop());
        }

        [Test]
        public void Push_WorksOnEmptyHeap()
        {
            var heap = new Heap<int>();
            var item = 32;

            Assert.DoesNotThrow(() => heap.Push(item));
            Assert.AreEqual(false, heap.Empty);
            Assert.AreEqual(1, heap.Size);
            Assert.AreEqual(item, heap.Peek());
        }

        [Test]
        public void Peek_DoesNotPop()
        {
            var heap = new Heap<int>();
            var item = 4564;

            heap.Push(item);
            var preSize = heap.Size;
            heap.Peek();
            var postSize = heap.Size;

            Assert.AreEqual(1, preSize);
            Assert.AreEqual(1, postSize);
        }

        [Test]
        public void Pop_RemovesOneElement()
        {
            var heap = new Heap<int>();
            var item = 321;

            heap.Push(item);
            var preSize = heap.Size;
            var result = heap.Pop();
            var postSize = heap.Size;

            Assert.AreEqual(1, preSize);
            Assert.AreEqual(0, postSize);
            Assert.AreEqual(item, result);
        }

        [Test]
        public void ListConstructor_WorksAsIntended()
        {
            var list = new List<int> { 25, -22, 1, 521, 55 };
            var heap = new Heap<int>(list);

            Assert.AreEqual(false, heap.Empty);
            Assert.AreEqual(list.Count, heap.Size);
        }

        [Test]
        public void ListConstructor_HeapSorts()
        {
            var list = new List<int> { 25, -22, 1, 521, 55 };
            var heap = new Heap<int>(list);

            Assert.AreEqual(521, heap.Pop());
            Assert.AreEqual(55, heap.Pop());
            Assert.AreEqual(25, heap.Pop());
            Assert.AreEqual(1, heap.Pop());
            Assert.AreEqual(-22, heap.Pop());
        }

        [Test]
        public void DefaultConstructorWithSequentialInsert_HeapSorts()
        {
            var list = new List<int> { 25, -22, 1, 521, 55 };
            var heap = new Heap<int>();

            list.ForEach(item => heap.Push(item));

            Assert.AreEqual(521, heap.Pop());
            Assert.AreEqual(55, heap.Pop());
            Assert.AreEqual(25, heap.Pop());
            Assert.AreEqual(1, heap.Pop());
            Assert.AreEqual(-22, heap.Pop());
        }
    }
}
