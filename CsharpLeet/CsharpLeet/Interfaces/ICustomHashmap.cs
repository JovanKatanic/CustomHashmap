using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpLeet
{
    public interface ICustomHashmap<TKey,TValue>
    {
        int Count 
        { 
            get; 
        }
        bool Put(TKey key, TValue value);
        void Clear();
        TValue Get(TKey key);

        TValue this[TKey key]
        {
            get;
            set;
        }

        void CopyTo(ref Tuple<TKey, TValue, int>[] array, int index);
    }
}
