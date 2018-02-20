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
    }
}
