
using System;
using algorithms.Util;

namespace algorithms.List
{
    public class SinglyLinkedList
    {
        public SinglyLinkedList()
        {
            var list = new SinglyLinkedList<int>();
            
            Assert.IsTrue(list.Head is null, "list.Head is null");
            Assert.IsTrue(list.Tail is null, "list.Tail is null");
            Assert.IsTrue(list.IsEmpty, "list.IsEmpty");

            list.AddFirst(1);
            Assert.IsTrue(list.Count == 1, "list.Count == 1");
            Assert.IsTrue(list.Head == list.Tail, "list.Head == list.Tail");

            list.RemoveLast();
            Assert.IsTrue(list.Count == 0, "list.Count == 0");
            Assert.IsTrue(list.Head == list.Tail, "list.Head == list.Tail");

            list.AddFirst(1);
            list.AddLast(2);
            Assert.IsTrue(list.Count == 2, "list.Count == 2");
            Assert.IsTrue(list.Head != list.Tail, "list.Head != list.Tail");

            list.AddFirst(3);
            Assert.IsTrue(list.Count == 3, "list.Count == 3");
            Assert.IsTrue(list.Head.Value == 3, "list.Head.Value == 3");

            list.AddLast(4);
            Assert.IsTrue(list.Count == 4, "list.Count == 4");
            Assert.IsTrue(list.Tail.Value == 4, "list.Head.Value == 4");

            list.RemoveLast();
            Assert.IsTrue(list.Tail.Value == 2, "list.Head.Value == 2");

            list.RemoveFirt();
            Assert.IsTrue(list.Tail.Value == 2, "list.Head.Value == 1");

            list.RemoveLast();
            Assert.IsTrue(list.Tail.Value == 1, "list.Head.Value == 1");
        }
    }

    public class SinglyLinkedList<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            AddFirst(new Node<T>(value));
        }

        private void AddFirst(Node<T> node)
        {
            var temp = Head;
            Head = node;
            Head.Next = temp;

            Count++;

            if(Count == 1)
                Tail = Head;
        }

        public void AddLast(T value)
        {
            AddLast(new Node<T>(value));
        }

        private void AddLast(Node<T> node)
        {
            if (IsEmpty)
                Head = node;
            else
                Tail.Next = node;

            Tail = node;
            Count++;
        }

        public void RemoveFirt()
        {
            if(IsEmpty)
                throw new InvalidOperationException();
            
            Head = Head.Next;

            if(Count == 1)
                Tail = null;
            
            Count--;
        }

        public void RemoveLast()
        {
            if(IsEmpty)
                throw new InvalidOperationException();
            
            if(Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                var penultimate = Head; 

                while (penultimate.Next != Tail)
                    penultimate = penultimate.Next;

                Tail = penultimate;
                Tail.Next = null;
            }

            Count--;
        }
        public bool IsEmpty => Count == 0;
    }
}