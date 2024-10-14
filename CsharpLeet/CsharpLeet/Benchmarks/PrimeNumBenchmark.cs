using BenchmarkDotNet.Attributes;
using CsharpLeet.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpLeet.Benchmarks
{

    public class PrimeNumBenchmark
    {
        [Params(3,6,14,34,74,178,400,860,1800,3800,8000)]
        public int N;
        [Benchmark]
        public void MyWay()
        {
            PrimeNumGen.GetPrime(N);
        }

        //[Benchmark]
        //public void FastWay()
        //{
        //    PrimeNumGen.GetPrimeFast(N);
        //}
    }
}
