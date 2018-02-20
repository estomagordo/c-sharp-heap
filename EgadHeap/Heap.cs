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

        public bool Empty
        {
            get
            {
                return Size == 0;
            }
        }

        public Heap()
        {
            _container = new List<T>();
        }

        public Heap(List<T> data)
        {
            _container = new List<T>(data);
            Build();
        }

        public T Peek()
        {
            if (Empty)
            {
                throw new InvalidOperationException();
            }

            return _container[0];
        }

        public void Push(T item)
        {
            _container.Add(item);
            var pos = Size - 1;
            var parent = (pos - 1) / 2;

            while (parent >= 0 && _container[pos].CompareTo(_container[parent]) > 0)
            {
                Swap(pos, parent);
                pos = parent;
                parent = (pos - 1) / 2;
            }
        }

        public T Pop()
        {
            var root = Peek();

            _container[0] = _container[Size - 1];
            _container.RemoveAt(Size - 1);
            var pos = 0;

            while ((pos * 2 + 1 < Size && _container[pos * 2 + 1].CompareTo(_container[pos]) > 0) || (pos * 2 + 2 < Size && _container[pos * 2 + 2].CompareTo(_container[pos]) > 0))
            {
                var largest = pos * 2 + 1;
                if (pos * 2 + 2 < Size && _container[pos * 2 + 2].CompareTo(_container[pos * 2 + 1])  > 0)
                {
                    largest = pos * 2 + 2;
                }
                Swap(pos, largest);
                pos = largest;
            }

            return root;
        }

        private void Heapify(int i)
        {
            var l = i * 2 + 1;
            var r = i * 2 + 2;

            var largest = l < Size && _container[l].CompareTo(_container[i]) > 0 ? l : i;

            if (r < Size && _container[r].CompareTo(_container[largest]) > 0)
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
