namespace CsharpLeet
{
    public class CustomHashMapWithLists<TKey,TValue>
    {
        private int _count;
        public int Count { get { return _count; } }

        private Entry[] _buckets;

        public void fun()
        {
            Console.WriteLine(this);
        }
        private class Entry
        {
            public TKey _key;
            public TValue _value;
            public Entry? _next;
            public uint _hash;
            public Entry(TKey key, TValue value,uint hash) { 
                _key = key;
                _value = value;
                _hash = hash;
                _next = null;
            }
        }

        public CustomHashMapWithLists()
        {
            _count = 0;
            _buckets = new Entry[4];
        }

        public bool Put(TKey key,TValue value)
        {
            if (key == null) ThrowManager.ThrowArgumentNullException(nameof(key));

            uint hash =(uint)key.GetHashCode();
            uint bucket_ind =(uint)(hash % (_buckets.Length));
            Entry bucket_item = _buckets[bucket_ind];
            Entry entry = new Entry(key, value, hash);

            if (bucket_item == null)
            {
                _buckets[bucket_ind] = entry;
                _count++;
                return true;
            }

            while (bucket_item._next != null) 
            {
                if (bucket_item._hash == hash && bucket_item._key.Equals(key))
                {
                    bucket_item._value = value;
                    return true;

                }
                bucket_item= bucket_item._next;
            }

            if (bucket_item._hash == hash && bucket_item._key.Equals(key))
            {
                bucket_item._value = value;
                return true;
            }
            bucket_item._next = entry;
            _count++;

            return true;
        }

        public TValue Get(TKey key)
        {
            if (key == null) ThrowManager.ThrowArgumentNullException(nameof(key));
            uint hash = (uint)key.GetHashCode();
            uint bucket_ind = (uint)(hash % (_buckets.Length));

            Entry bucket_item = _buckets[bucket_ind];

            while (bucket_item != null)
            {
                if (bucket_item._hash == hash)
                {
                    if (bucket_item._key.Equals(key)) return bucket_item._value;
                }
                bucket_item = bucket_item._next;
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

        public bool Remove(TKey key)
        {
            if (key == null) ThrowManager.ThrowArgumentNullException(nameof(key));
            uint hash = (uint)key.GetHashCode();
            uint bucket_ind = (uint)(hash % (_buckets.Length));

            Entry bucket_item = _buckets[bucket_ind];
            Entry prev;

            if (bucket_item == null)
            {
                return false;
            }
            else if (bucket_item._next == null)
            {
                if (bucket_item._hash == hash && bucket_item._key.Equals(key))
                {
                    _buckets[bucket_ind] = null;
                    _count--;
                    return true;
                }
                return false;
            }

            prev = bucket_item;
            bucket_item = bucket_item._next;
            while (bucket_item != null)
            {
                if (bucket_item._hash == hash)
                {
                    if (bucket_item._key.Equals(key))
                    {
                        prev._next = bucket_item._next;
                        _count--;
                        return true;
                    }
                }
                bucket_item = bucket_item._next;
            }

            return false;
        }

        public void Clear()
        {
            int count = _count;
            if (count > 0)
            {
                _count = 0;
                Array.Clear(_buckets, 0, _buckets.Length);
                
            }
        }



    }
}
