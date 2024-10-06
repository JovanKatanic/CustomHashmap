using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpLeet
{
    public static class ThrowManager
    {
        public static void ThrowArgumentNullException(string key)
        {
            throw new ArgumentNullException(key, "Key cannot be null.");
        }

        public static void ThrowKeyNotFoundException()
        {
            throw new KeyNotFoundException();
        }

        public static void ThrowArgumentOutOfRangeException()
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}
