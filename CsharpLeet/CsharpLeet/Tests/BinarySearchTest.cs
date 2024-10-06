using CsharpLeet.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CsharpLeet.Tests
{
    public class BinarySearchTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(22)]
        [InlineData(65)]
        public void TestBinarySearch(int a)
        {
            int b = a + 1;
            for (int i = PrimeNumGen.Primes[a]; i < PrimeNumGen.Primes[b]; i++)
            {
                Assert.Equal(PrimeNumGen.BinarySearch(i), b);
            }

        }


    }
}
