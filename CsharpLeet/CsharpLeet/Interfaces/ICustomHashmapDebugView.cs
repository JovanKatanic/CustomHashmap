using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CsharpLeet
{
    public class ICustomHashmapDebugView<TKey,TValue>
    {
        private readonly ICustomHashmap<TKey, TValue> _map;

        public ICustomHashmapDebugView(ICustomHashmap<TKey, TValue> map)
        {
            _map = map ?? throw new ArgumentNullException(nameof(map));
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public Tuple<TKey, TValue, int>[] Items
        {
            get
            {
                Tuple<TKey, TValue, int>[] items = new Tuple<TKey, TValue, int>[_map.Count];
                _map.CopyTo(ref items, 0);
                return items;
            }
        }
    }
}
