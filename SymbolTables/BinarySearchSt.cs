
using System;
using System.Collections.Generic;
using algorithms.Util;

namespace algorithms.SymbolTables
{
    public class BinarySearchSt<TKey, TValue>
    {
        private TKey[] _keys;
        private TValue[] _values;
        public int Count {get; private set;}
        private readonly IComparer<TKey> _comparer;
        public int Capacity => _keys.Length;

        public bool IsEmpty => Count == 0;

        private const int DefaultCapacity = 4;

        public BinarySearchSt(int capacity, IComparer<TKey> comparer)
        {
            _keys = new TKey[capacity];
            _values = new TValue[capacity];
            comparer = comparer ?? throw new ArgumentNullException();
        }

        public BinarySearchSt(int capacity):this(capacity, Comparer<TKey>.Default)
        {
        }

        public BinarySearchSt():this(DefaultCapacity)
        {
        }

        public int Rank(TKey key) // binary search
        {
            int low = 0;
            int high = Count -1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int cmp = _comparer.Compare(key, _keys[mid]);

                if (cmp < 0)
                    high = mid - 1;
                else if (cmp > 0)
                    cmp = mid + 1;
                else
                    return mid;
            }
            return low;
        }

        public TValue GetValueOrDefault(TKey key)
        {
            if (IsEmpty)
            {
                return default(TValue);
            }
            int rank = Rank(key);
            if(rank < Count && _comparer.Compare(_keys[rank], key) == 0)
            {
                return _values[rank];
            }
            return default(TValue);
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException();
            
            int rank = Rank(key);
            if (rank < Count && _comparer.Compare(_keys[rank],  key) == 0)
            {
                _values[rank] = value;
                return;
            }
            
            if (Count == Capacity)
                Resize(Capacity * 2);

            for (int j = Count; j > rank; j--)
            {
                _keys[j] = _keys[j-1];
                _values[j] = _values[j-1];
            }

            _keys[rank] = key;
            _values[rank] = value;
            
            Count++;
        }

        public IEnumerable<TKey> Keys()
        {
            foreach (var key in _keys)
            {
                yield return key;
            }
        }

        public void Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException();
            
            if (IsEmpty)
                return;
            
            int r = Rank(key);
            if (r == Count || _comparer.Compare(_keys[r], key) != 0) // not found
                return;

            for (int j = r; j < Count-1; j++) // move all to the left
            {
                _keys[j] = _keys[j+1];
                _values[j] = _values[j+1];
            }
            
            Count--;

            _keys[Count] = default(TKey);
            _values[Count] = default(TValue);
        }

        private void Resize(int capacity)
        {
            TKey[] keysTemp = new TKey[capacity];
            TValue[] valuesTemp = new TValue[capacity];
            
            // for (int i = 0; i < Count; i++)
            // {
            //     keysTemp[i] = _keys[i];
            //     valuesTemp[i] = _values[i];
            // }

            Array.Copy(_keys, keysTemp,_keys.Length);
            Array.Copy(_values, valuesTemp, _values.Length);

            _values = valuesTemp;
            _keys = keysTemp;
        }
    }
}