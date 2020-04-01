
using System;
using System.Collections.Generic;
using algorithms.Util;

namespace algorithms.SymbolTables
{
    public class SequentialSearchST<TKey, TValue>
    {
        private class Node
        {
            public TKey Key { get; }
            public TValue Value { get; set; }
            public Node Next { get; set; }

            public Node(TKey key, TValue value, Node next)
            {
                Key = key;
                Value = value;
                Next = next;
            }
        }

        private Node _first;
        private readonly EqualityComparer<TKey> _compare;

        public int Count {get; private set;}

        public SequentialSearchST()
        {
            _compare = EqualityComparer<TKey>.Default;
        }

        public SequentialSearchST(EqualityComparer<TKey> comparer)
        {
            _compare = comparer ?? throw new ArgumentNullException();
        }

        public bool TryGet(TKey key, out TValue val)
        {
            for (Node x = _first; x != null; x = x.Next)
            {
                if (_compare.Equals(key, x.Key))
                {
                    val = x.Value;
                    return true;
                }
            }

            val = default(TValue);
            return false;
        }

        public void Add(TKey key, TValue val)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key cannot be null");
            }

            for (Node x = _first; x != null; x = x.Next)
            {
                if (_compare.Equals(key, x.Key))
                {
                    x.Value = val;
                    return;
                }
            }
            _first = new Node(key, val, _first);
            Count++;
        }

        public bool Contains(TKey key)
        {
            for (Node x = _first; x != null; x = x.Next)
            {
                if (_compare.Equals(key, x.Key))
                    return true;
            }
            return false;
        }

        public IEnumerable<TKey> Keys()
        {
            for (Node x = _first; x != null; x = x.Next)
            {
                yield return x.Key;
            }
        }

        public bool Remove(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key cannot be null");
            }

            if (Count ==1 && _compare.Equals(_first.Key, key))
            {
                _first = null;
                Count--;
                return true;
            }

            Node prev = default(Node);
            Node current = _first;

            while (current != null)
            {
                if (_compare.Equals(current.Key, key))
                {
                    if (prev == null)
                    {
                        _first = current.Next;
                    }
                    else
                        prev.Next = current.Next;
                    
                    Count--;
                    return true;
                }

                prev = current;
                current = current.Next;
            }
            
            return false;
        }

    }
}