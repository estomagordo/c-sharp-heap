using System;
using System.Collections.Generic;

namespace Heap
{
    public class Heap<T> where T : IComparable<T>
    {
        private List<T> _container;

        public int Size
        {
            get
            {
                return _container.Count;
            }
        }

        public Heap()
        {
            _container = new List<T>();
        }

        public Heap(List<T> data)
        {
            _container = data;
            Build();
        }

        private void Heapify(int i)
        {
            var l = i * 2 + 1;
            var r = i * 2 + 2;

            var largest = l <= Size && _container[l].CompareTo(_container[i]) > 0 ? l : i;

            if (r <= Size && _container[r].CompareTo(_container[largest]) > 0)
            {
                largest = r;
            }

            if (largest != i)
            {
                Swap(i, largest);
                Heapify(largest);
            }
        }

        private void Build()
        {
            for (var i = Size / 2 - 1; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        private void Swap(int i, int j)
        {
            var temp = _container[i];
            _container[i] = _container[j];
            _container[j] = temp;
        }
    }
}
