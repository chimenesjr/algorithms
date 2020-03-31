
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using algorithms.Util;

namespace algorithms.List
{
    public class ArrayQueue
    {
        public ArrayQueue()
        {
            ArrayQueue<int> q = new ArrayQueue<int>();
            Assert.IsTrue(q.Count == 0, "q.Count == 0");
            Assert.IsTrue(q.IsEmpty, "q.IsEmpty");
            Assert.IsTrue(q.Capacity == 4, "q.Capacity == 4");
            q.Enqueue(1);
            Assert.IsTrue(q.Count == 1, "q.Count == 1");
            Assert.IsTrue(!q.IsEmpty, "!q.IsEmpty");
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);
            Assert.IsTrue(q.Capacity == 8, "q.Capacity == 8");
            Assert.IsTrue(q.Peek() == 1, "q.Peek() == 1");
            q.Dequeue();
            Assert.IsTrue(q.Peek() == 2, "q.Peek() == 2");
            var list = q.GetEnumerator();
        }
    }

    public class ArrayQueue<T> : IEnumerable<T>
    {
        private T[] _queue;
        private int _head;
        private int _tail;

        public ArrayQueue()
        {
            const int defaultCapacity = 4;
            _queue = new T[defaultCapacity];
        }

        public ArrayQueue(int capacity)
        {
            _queue = new T[capacity];
        }

        public int Count => _tail - _head;
        public bool IsEmpty => Count == 0;
        public int Capacity => _queue.Length;

        public void Enqueue(T item)
        {
            if (_queue.Length == _tail)
            {
                T[] largerArray = new T[Count*2];
                Array.Copy(_queue, largerArray, Count);
                _queue = largerArray;
            }

            _queue[_tail++] = item;
        }

        public void Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            _queue[_head++] = default(T); // make it empty

            if(IsEmpty)
                _head = _tail = 0;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            return _queue[_head];
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _head; i < _tail; i++)
            {
                yield return _queue[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}