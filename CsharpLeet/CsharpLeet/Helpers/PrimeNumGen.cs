﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpLeet.Helpers
{
    public static class PrimeNumGen
    {
        public static ReadOnlySpan<int> Primes =>
        [
            3, 7, 11, 17, 23, 29, 37, 47, 59, 71, 89, 107, 131, 163, 197, 239, 293, 353, 431, 521, 631, 761, 919,
            1103, 1327, 1597, 1931, 2333, 2801, 3371, 4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591,
            17519, 21023, 25229, 30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363, 156437,
            187751, 225307, 270371, 324449, 389357, 467237, 560689, 672827, 807403, 968897, 1162687, 1395263,
            1674319, 2009191, 2411033, 2893249, 3471899, 4166287, 4999559, 5999471, 7199369
        ];

        

        public static int GetPrime(int min)
        {
            if(min<0)
                ThrowManager.ThrowArgumentOutOfRangeException();

            if (min < 140) return LinearSearch(min);
            return Primes[BinarySearch(min)];
        }

        public static int BinarySearch(int num)
        {
            int left = 0;
            int right = Primes.Length-1;
            int mid;

            while (left < right)
            {
                mid = (left + right) / 2;
                if(Primes[mid] == num)
                {
                    return mid;
                }
                else if (Primes[mid] < num)
                {
                    left = mid+1;
                }
                else if (Primes[mid] > num)
                {
                    right = mid;
                }
            }
            return left;
        }

        public static int LinearSearch(int min)
        {
            for (int i = 0; i < Primes.Length; i++)
            {
                int num = Primes[i];
                if (num >= min)
                {
                    return num;
                }
            }

            return min;
        }
    }
}
