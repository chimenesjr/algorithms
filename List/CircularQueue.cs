
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using algorithms.Util;

namespace algorithms.List
{
    public class CircularQueue
    {
        public CircularQueue()
        {
            var q = new CircularQueue<int>();
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

    public class CircularQueue<T> : ArrayQueue<T>
    {

        public override void Enqueue(T item)
        {
            if (Count == _queue.Length - 1)
            {
                int countPriorResize = Count;
                T[] newArray = new T[2*_queue.Length];

                Array.Copy(_queue, _head, newArray, 0, _queue.Length - _head);
                Array.Copy(_queue, 0, newArray, _queue.Length - _head, _tail);
                _queue = newArray;

                _head = 0;
                _tail = countPriorResize;
            }

            _queue[_tail] = item;
            if(_tail < _queue.Length -1)
                _tail++;
            else
                _tail = 0;
        }

        public override void Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            
            _queue[_head++] = default(T);

            if(IsEmpty)
            {
                _head = _tail = 0;
            }
            else if (_head == _queue.Length)
            {
                _head = 0;
            }
        }

        public override int Count => _head <= _tail 
                ? _tail - _head
                : _tail - _head + _queue.Length;

        public virtual IEnumerator<T> GetEnumerator()
        {
            if (_head <= _tail)
            {
                for (int i = _head; i < _tail; i++)
                {
                    yield return _queue[i];
                }
            }
            else
            {
                for (int i = _head; i < _queue.Length; i++)
                {
                    yield return _queue[i];
                }
                for (int i = 0; i < _tail; i++)
                {
                    yield return _queue[i];
                }
            }
        }
    }
}