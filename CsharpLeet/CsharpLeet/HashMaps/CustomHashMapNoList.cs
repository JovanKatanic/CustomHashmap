using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CsharpLeet
{
    [DebuggerTypeProxy(typeof(ICustomHashmapDebugView<,>))]
    [DebuggerDisplay("Count = {Count}")]
    public class CustomHashMapNoList<TKey,TValue> : ICustomHashmap<TKey, TValue>
    {
        private int _count;
        public int Count { get { return _count; } }

        private int[] _buckets;

        private Entry[] _entries;

        public CustomHashMapNoList() : this(3)
        {

        }

        public CustomHashMapNoList(int count)
        {
            _count = 0;//get primes
            _buckets = new int[count];
            _entries = new Entry[count];
        }

        private struct Entry
        {
            public TKey key;
            public TValue value;
            public uint hash;
            public int next;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref int GetFirstEntry(uint hash,uint size)
        {
            return ref _buckets[hash % size];
        }

        public bool Put(TKey key,TValue value)
        {
            if (key == null) ThrowManager.ThrowArgumentNullException(nameof(key));

            uint hash = (uint)key.GetHashCode();
            uint len = (uint)_entries.Length;

            //uint test = hash % len; //for testing

            ref int bucket =ref GetFirstEntry(hash,len);
            int i = bucket-1;

            while ((uint)i <= len)
            {
                if (_entries[i].hash == hash && key.Equals(_entries[i].key))
                {
                    _entries[i].value = value;
                    return true;
                }
                i = _entries[i].next;
            }
            
            if (_count == len)
            {
                Resize();
                len = (uint)_entries.Length;
                bucket =ref GetFirstEntry(hash,len);
            }

            i=_count++;
            _entries[i].hash = hash;
            _entries[i].value = value;
            _entries[i].key = key;
            _entries[i].next = bucket-1;
            bucket = _count;

            return true;
        }

        public void Clear()
        {
            if (_count > 0)
            {
                _count = 0;
                Array.Clear(_buckets);
                Array.Clear(_entries, 0, _count);
            }
        }

        private void Resize() 
        {
            int size = _count * 2 + 1; //calculate new size. should use size
            Entry[] entries = new Entry[size];
            _buckets = new int[size];
            Array.Copy(_entries, entries, _count);

            for(int i = 0; i < _count; i++)
            {
                ref int first = ref GetFirstEntry(entries[i].hash,(uint)size);
                entries[i].next = first - 1;
                first =i+1;
                
            }
            _entries=entries;
        }

        public TValue Get(TKey key)
        {
            if (key == null) ThrowManager.ThrowArgumentNullException(nameof(key));
            uint hash = (uint)key.GetHashCode();
            uint len = (uint)_entries.Length;
            ref int bucket = ref GetFirstEntry(hash, len);
            int i = bucket - 1;

            while ((uint)i <= len)
            {
                if (_entries[i].hash == hash && key.Equals(_entries[i].key))
                {
                    return _entries[i].value;
                }
                i = _entries[i].next;
            }

            ThrowManager.ThrowKeyNotFoundException();
            return default(TValue);
        }

        public TValue this[TKey key]
        {
            get
            {
                return Get(key);

            }
            set
            {
                Put(key, value);
            }
        }

        public void CopyTo(ref Tuple<TKey, TValue,int>[] array,int index)
        {
            for(int i = index; i < _count; i++)
            {
                var tuple = new Tuple<TKey, TValue,int>(_entries[i].key, _entries[i].value, _entries[i].next);
                array[i] = tuple;
            }
        }


    }
}
